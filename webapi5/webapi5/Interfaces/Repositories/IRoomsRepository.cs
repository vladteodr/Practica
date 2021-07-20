using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using webapi5.Entities;

namespace webapi5.Interfaces.Repositories
{
    public interface IRoomsRepository: IRepository<RoomEntity>
    {
        public Task<IEnumerable<RoomEntity>> GetAllComplete();

        public Task<RoomEntity> GetOneComplete(Expression<Func<RoomEntity, bool>> predicat);
    }
}
