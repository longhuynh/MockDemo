using System.Collections.Generic;

namespace  Demo.Moq.Code.Demo05
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IIdFactory idFactory;

        public CustomerService(
            ICustomerRepository customerRepository,
            IIdFactory idFactory)
        {
            this.customerRepository = customerRepository;
            this.idFactory = idFactory;
        }

        public void Create(IEnumerable<CustomerToCreateDto> customersToCreate)
        {
            foreach (var customerToCreateDto in customersToCreate)
            {
                var customer = new Customer(
                    customerToCreateDto.FirstName,
                    customerToCreateDto.LastName);

                customer.Id = idFactory.Create();

                customerRepository.Save(customer);
            }
        }
    }
}