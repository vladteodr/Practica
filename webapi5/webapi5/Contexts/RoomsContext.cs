using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi5.Entities;

namespace webapi5.Contexts
{
    public class RoomsContext: DbContext
    {
        public RoomsContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
    }
}
