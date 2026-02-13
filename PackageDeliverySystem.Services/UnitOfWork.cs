using PackageDeliverySystem.DataAccess.DataAccess;
using PackageDeliverySystem.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDeliverySystem.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;

        public ICustomerRepository CustomerRepo { get; private set; }
        public IEmployeeRepository EmployeeRepo { get; private set; }
        public IPackageRepository PackageRepo { get; private set; }

        public UnitOfWork(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            CustomerRepo = new CustomerRepository(_dbContext);
            EmployeeRepo = new EmployeeRepository(_dbContext);
            PackageRepo = new PackageRepository(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
