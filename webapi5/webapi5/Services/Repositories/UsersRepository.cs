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
    public class UsersRepository : Repository<UserEntity>, IUsersRepository
    {

        public UsersRepository(RoomsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserEntity>> GetAdmins()
        {
            return await _context.Set<UserEntity>().Where(user => user.IsAdmin && !user.IsDeleted).ToListAsync();
        }
    }
}
