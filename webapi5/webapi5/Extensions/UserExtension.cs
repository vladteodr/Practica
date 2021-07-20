using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi5.Controllers;
using webapi5.DTOs;
using webapi5.Entities;

namespace webapi5.Extensions
{
    public static class UserExtension
    {
        public static UserDTO toDTO(this UserEntity user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                Nume = user.Nume,
                Prenume  = user.Prenum,
                Parola = user.Parola
            };
        }

        public static UserEntity toEntity(this UserDTO user)
        {
            return new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                Nume = user.Nume,
                Prenum = user.Prenume,
                Parola = user.Parola,
                IsDeleted = false
            };
        }

        public static UserEntity toEntity(this UserRegisterDTO user)
        {
            return new UserEntity()
            {
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                Nume = user.Nume,
                Prenum = user.Prenume,
                Parola = user.Parola,
                IsDeleted = false
            };
        }
    }
}
