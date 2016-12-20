using System;

namespace  Demo.Moq.Code.Demo09
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(
                customerToCreate.FirstName,
                customerToCreate.LastName);

            customerRepository.LocalTimeZone =
                TimeZone.CurrentTimeZone.StandardName;

            customerRepository.Save(customer);
        }
    }
}