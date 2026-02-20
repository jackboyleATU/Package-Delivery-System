using PackageDeliverySystem.DataAccess.DataAccess;
using PackageDeliverySystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDeliverySystem.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly AppDBContext _dbContext;
        public EmployeeRepository(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
