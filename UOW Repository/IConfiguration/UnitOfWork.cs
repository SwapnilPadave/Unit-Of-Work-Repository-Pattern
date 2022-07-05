using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW_Models;
using UOW_Repository.Repositories;

namespace UOW_Repository.IConfiguration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger _logger;
        public IUserRepository Users { get; private set; }

        public UnitOfWork(ApplicationDBContext context,ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Logs");

            Users = new UserRepository(_context, _logger);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }        
        public void Dispose()
        {
            _context.Dispose();
        }
        //public async Task DisposeAsync()
        //{
        //   await _context.DisposeAsync();
        //}
    }
}
