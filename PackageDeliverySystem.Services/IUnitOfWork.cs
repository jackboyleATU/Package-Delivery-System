using PackageDeliverySystem.DataAccess.Repository;
using PackageDeliverySystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDeliverySystem.Services
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepo { get; }
        IEmployeeRepository EmployeeRepo { get; }
        IPackageRepository PackageRepo { get; }

        void Save();
    }
}
