namespace  Demo.Moq.Code.Demo08
{
    public class CustomerService
    {
        private readonly ICustomerAddressFactory customerAddressFactory;
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository, 
            ICustomerAddressFactory customerAddressFactory)
        {
            this.customerRepository = customerRepository;
            this.customerAddressFactory = customerAddressFactory;
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            try
            {
                var customer = new Customer(customerToCreate.Name);
                customer.Address = customerAddressFactory.From(customerToCreate);
                customerRepository.Save(customer);
            }
            catch (InvalidCustomerAddressException e)
            {
                throw new CustomerCreationException(e);
            }
        }
    }
}