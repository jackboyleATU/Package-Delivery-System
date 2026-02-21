using Microsoft.EntityFrameworkCore;
using PackageDeliverySystem.DataAccess.DataAccess;
using PackageDeliverySystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDeliverySystem.DataAccess.Repository
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        private readonly AppDBContext _dbContext;
        public PackageRepository(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Package> GetAllWithCustomer()
        {
            return _dbContext.Packages.Include(p => p.Customer).ToList();
        }
    }
}
