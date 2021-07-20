using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi5.DTOs;
using webapi5.Extensions;
using webapi5.Interfaces.UnitsOfWork;

namespace webapi5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRoomsUnitOfWork _unit;
        public UsersController(IRoomsUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            return Ok((await _unit.Users.Get()).Select(user => user.toDTO()).ToList());
        }

        [HttpGet("admins")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAdmins()
        {
            return Ok((await _unit.Users.GetAdmins()).Select(user => user.toDTO()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(Guid id)
        {
            var _user = await _unit.Users.Get(user => user.Id == id);
            if (_user == null)
                return NotFound();
            else return Ok(_user.toDTO());
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register([FromBody] UserRegisterDTO user)
        {
            var _added = await _unit.Users.Add(user.toEntity());
            await _unit.Complete();
            return CreatedAtAction(nameof(Get), new { id = _added.Id }, _added.toDTO());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<UserDTO>> Update(Guid id, [FromBody] UserDTO user)
        {
            if (id != user.Id)
                return BadRequest();
            else
            {
                var _update = await _unit.Users.Update(user.toEntity());
                await _unit.Complete();
                return Ok(_update.toDTO());
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> Delete(Guid id)
        {
            var _deleted = await _unit.Users.Delete(id);
            await _unit.Complete();
            return Ok(_deleted.toDTO());
        }


    }
}
