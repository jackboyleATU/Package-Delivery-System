using PackageDeliverySystem.DataAccess.DataAccess;
using PackageDeliverySystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDeliverySystem.DataAccess.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly AppDBContext _dbContext;
        public CustomerRepository(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
