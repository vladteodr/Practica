using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi5.Interfaces.Repositories;

namespace webapi5.Interfaces.UnitsOfWork
{
    public interface IRoomsUnitOfWork: IDisposable
    {
        public IRoomsRepository Rooms { get; }
    
        public IUsersRepository Users { get; }

        Task<int> Complete();
    }
}
