using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi5.Entities;

namespace webapi5.Interfaces.Repositories
{
    public interface IUsersRepository: IRepository<UserEntity>
    {
        Task<IEnumerable<UserEntity>> GetAdmins();
    }
}
