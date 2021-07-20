using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using webapi5.Contexts;
using webapi5.Entities;
using webapi5.Interfaces.Repositories;

namespace webapi5.Services.Repositories
{
    public class RoomsRepository: Repository<RoomEntity>, IRoomsRepository
    {
        public RoomsRepository(RoomsContext context): base(context)
        {

        }

        public async Task<IEnumerable<RoomEntity>> GetAllComplete()
        {
            return await _context.Set<RoomEntity>().Where(room => !room.IsDeleted).Include(room => room.Users).ToListAsync();
        }

        public async Task<RoomEntity> GetOneComplete(Expression<Func<RoomEntity, bool>> predicat)
        {
            return await _context.Set<RoomEntity>().Where(room => !room.IsDeleted).Include(room => room.Users).Where(predicat).FirstOrDefaultAsync();
        }
    }
}
