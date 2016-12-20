namespace  Demo.Moq.Code.Demo16
{
    public class CustomerService
    {
        private readonly IAddressFormatterFactory addressFormatterFactory;
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository, 
            IAddressFormatterFactory addressFormatterFactory)
        {
            this.customerRepository = customerRepository;
            this.addressFormatterFactory = addressFormatterFactory;
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(customerToCreate.Name);

            var addressFormatter = addressFormatterFactory.From(
                customerToCreate.Country);

            customerRepository.Save(customer);
        }
    }
}