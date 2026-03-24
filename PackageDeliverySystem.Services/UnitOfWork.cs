using PackageDeliverySystem.DataAccess.DataAccess;
using PackageDeliverySystem.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PackageDeliverySystem.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;

        public ICustomerRepository CustomerRepo { get; private set; }
        public IEmployeeRepository EmployeeRepo { get; private set; }
        public IPackageRepository PackageRepo { get; private set; }
        public ICustomerEmailRepository CustomerEmailRepo { get; private set; }

        public UnitOfWork(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            CustomerRepo = new CustomerRepository(_dbContext);
            EmployeeRepo = new EmployeeRepository(_dbContext);
            PackageRepo = new PackageRepository(_dbContext);
            CustomerEmailRepo = new CustomerEmailRepository(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var entries = ex.Entries?.Select(e => $"{e.Entity.GetType().Name} ({e.State})");
                var msg = $"Save failed: {ex.InnerException?.Message ?? ex.Message}. Entries: {string.Join(", ", entries ?? Enumerable.Empty<string>())}";
                throw new Exception(msg, ex);
            }
        }
    }
}
