using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi5.Contexts;
using webapi5.Interfaces.Repositories;
using webapi5.Interfaces.UnitsOfWork;

namespace webapi5.Services.UnitsOfWork
{
    public class RoomsUnitOfWork : IRoomsUnitOfWork
    {
        private readonly RoomsContext _context;
        public IRoomsRepository Rooms { get; }
        public IUsersRepository Users { get; }

        public RoomsUnitOfWork(RoomsContext context, IRoomsRepository roomsRepo, IUsersRepository usersRepo)
        {
            _context = context;
            Rooms = roomsRepo;
            Users = usersRepo;
        }

        

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
