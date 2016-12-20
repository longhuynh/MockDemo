using System.Collections.Generic;

namespace  Demo.Moq.Code.Demo02
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void Create(IEnumerable<CustomerToCreateDto> customersToCreate)
        {
            foreach (var customerToCreateDto in customersToCreate)
            {
                customerRepository.Save(
                    new Customer(
                        customerToCreateDto.FirstName,
                        customerToCreateDto.LastName)
                    );
            }
        }
    }
}