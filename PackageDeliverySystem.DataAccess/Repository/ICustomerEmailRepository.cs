using PackageDeliverySystem.Models.Models;

namespace PackageDeliverySystem.DataAccess.Repository
{
    public interface ICustomerEmailRepository : IRepository<CustomerEmail>
    {
        IEnumerable<CustomerEmail> GetEmailsByCustomer(int customerId);
        IEnumerable<CustomerEmail> GetUnreadEmailsByCustomer(int customerId);
        CustomerEmail? GetEmailWithDetails(int id);
        int GetUnreadCount(int customerId);
        void Update(CustomerEmail email);
    }
}

