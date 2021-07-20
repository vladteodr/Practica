using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi5.DTOs;
using webapi5.Entities;

namespace webapi5.Extensions
{
    public static class RoomExtensions
    {
        public static RoomEntity toEntity(this RoomDTO room)
        {
            return new RoomEntity()
            {
                Id = room.Id,
                IsDeleted = false,
                M2 = room.M2,
                Pret = room.Pret
            };
        }

        public static RoomDTO toDTO(this RoomEntity room)
        {
            return new RoomDTO()
            {
                Id = room.Id,
                M2 = room.M2,
                Pret = room.Pret,
                Users = room?.Users?.Select(user => user.toDTO()).ToList()
            };
        }

        public static RoomEntity toEntity(this AddRoomDTO room)
        {
            return new RoomEntity()
            {
                IsDeleted = false,
                M2 = room.M2,
                Pret = room.Pret
            };
        }
    }
}
