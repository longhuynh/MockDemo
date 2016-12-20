namespace  Demo.Moq.Code.Demo04
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMailingAddressFactory mailingAddressFactory;

        public CustomerService(ICustomerRepository customerRepository,
            IMailingAddressFactory mailingAddressFactory)
        {
            this.customerRepository = customerRepository;
            this.mailingAddressFactory = mailingAddressFactory;
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(customerToCreate.Name);

            MailingAddress mailingAddress;
            var mailingAddressSuccessfullyCreated =
                mailingAddressFactory.TryParse(
                    customerToCreate.Address,
                    out mailingAddress);

            if (mailingAddress == null)
            {
                throw new InvalidMailingAddressException();
            }
            customer.MailingAddress = mailingAddress;
            customerRepository.Save(customer);
        }
    }
}