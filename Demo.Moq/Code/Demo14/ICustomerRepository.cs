using System.Collections.Generic;

namespace  Demo.Moq.Code.Demo14
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        IEnumerable<Customer> FetchAll();
    }
}