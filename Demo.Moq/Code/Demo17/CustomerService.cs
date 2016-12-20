namespace  Demo.Moq.Code.Demo17
{
    public class CustomerService
    {
        private readonly ICustomerAddressFormatter customerAddressFormatter;
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository,
            ICustomerAddressFormatter customerAddressFormatter)
        {
            this.customerRepository = customerRepository;
            this.customerAddressFormatter = customerAddressFormatter;
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(customerToCreate.Name)
            {
                Address = customerAddressFormatter.For(customerToCreate)
            };


            customerRepository.Save(customer);
        }
    }
}