namespace  Demo.Moq.Code.Demo03
{
    public class CustomerService
    {
        private readonly ICustomerAddressBuilder customerAddressBuilder;
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerAddressBuilder customerAddressBuilder, 
            ICustomerRepository customerRepository)
        {
            this.customerAddressBuilder = customerAddressBuilder;
            this.customerRepository = customerRepository;
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(
                customerToCreate.FirstName,
                customerToCreate.LastName);

            customer.MailingAddress = customerAddressBuilder.From(customerToCreate);

            if (customer.MailingAddress == null)
            {
                throw new InvalidCustomerMailingAddressException();
            }

            customerRepository.Save(customer);
        }
    }
}