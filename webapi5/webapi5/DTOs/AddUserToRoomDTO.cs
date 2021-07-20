using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi5.DTOs
{
    public class AddUserToRoomDTO
    {
        [Required]
        public Guid Id_Room { get; set; }
        [Required]
        public Guid Id_User { get; set; }
    }
}
