using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi5.DTOs;
using webapi5.Entities;
using webapi5.Extensions;
using webapi5.Interfaces.UnitsOfWork;

namespace webapi5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsUnitOfWork _unit;

        public RoomsController(IRoomsUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> Get()
        {
            return Ok((await _unit.Rooms.GetAllComplete()).Select(room => room.toDTO()).ToList());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetbyId(Guid id)
        {
            var _found = await _unit.Rooms.GetOneComplete(room => room.Id == id);
            if (_found == null) return NotFound();
            else return Ok(_found.toDTO());
        }

        [HttpPost]
        public async Task<ActionResult<RoomDTO>> AddRoom([FromBody] AddRoomDTO room)
        {
            var _added = await _unit.Rooms.Add(room.toEntity());
            await _unit.Complete();
            var _getAddedRoom = await _unit.Rooms.GetOneComplete(room => room.Id == _added.Id);
            return CreatedAtAction(nameof(GetbyId), new { id = _added.Id }, _getAddedRoom.toDTO());
        }

        [HttpPut]
        public async Task<ActionResult<RoomDTO>> AddUserToRoom([FromBody] AddUserToRoomDTO addUserToRoom)
        {
            var _roomTask = await _unit.Rooms.GetOneComplete(room => room.Id == addUserToRoom.Id_Room);
            var _userTask = await _unit.Users.Get(user => user.Id == addUserToRoom.Id_User);
            if (_roomTask == null && _userTask == null) return NotFound();
            if (_roomTask.Users == null)
                _roomTask.Users = new List<UserEntity>();
            _roomTask.Users.Add(_userTask);
            await _unit.Complete();
            return Ok((await _unit.Rooms.GetOneComplete(room => room.Id == _roomTask.Id)).toDTO());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomDTO>> DeleteRoom(Guid id)
        {
            var _CompleteDeleted = await _unit.Rooms.GetOneComplete(room => room.Id == id);
            await _unit.Rooms.Delete(id);
            await _unit.Complete();
            return Ok(_CompleteDeleted.toDTO());
        }


    }
}
