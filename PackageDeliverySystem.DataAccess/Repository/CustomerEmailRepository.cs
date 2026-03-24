using Microsoft.EntityFrameworkCore;
using PackageDeliverySystem.DataAccess.DataAccess;
using PackageDeliverySystem.Models.Models;

namespace PackageDeliverySystem.DataAccess.Repository
{
    public class CustomerEmailRepository : Repository<CustomerEmail>, ICustomerEmailRepository
    {
        private readonly AppDBContext _dbContext;

        public CustomerEmailRepository(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CustomerEmail> GetEmailsByCustomer(int customerId)
        {
            return _dbContext.CustomerEmails
                .Include(e => e.Package)
                .Include(e => e.Customer)
                .Where(e => e.CustomerId == customerId)
                .OrderByDescending(e => e.SentAt)
                .ToList();
        }

        public IEnumerable<CustomerEmail> GetUnreadEmailsByCustomer(int customerId)
        {
            return _dbContext.CustomerEmails
                .Include(e => e.Package)
                .Include(e => e.Customer)
                .Where(e => e.CustomerId == customerId && !e.IsRead)
                .OrderByDescending(e => e.SentAt)
                .ToList();
        }

        public CustomerEmail? GetEmailWithDetails(int id)
        {
            return _dbContext.CustomerEmails
                .Include(e => e.Package)
                .Include(e => e.Customer)
                .FirstOrDefault(e => e.Id == id);
        }

        public int GetUnreadCount(int customerId)
        {
            return _dbContext.CustomerEmails.Count(e => e.CustomerId == customerId && !e.IsRead);
        }

        public void Update(CustomerEmail email)
        {
            _dbContext.CustomerEmails.Update(email);
        }
    }
}

