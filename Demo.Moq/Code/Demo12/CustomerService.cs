namespace  Demo.Moq.Code.Demo12
{
    public class CustomerService
    {
        private readonly IApplicationSettings applicationSettings;
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository, 
            IApplicationSettings applicationSettings)
        {
            this.customerRepository = customerRepository;
            this.applicationSettings = applicationSettings;
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(customerToCreate.Name);

            var workstationId = applicationSettings.WorkstationId;

            if (!workstationId.HasValue)
            {
                throw new InvalidWorkstationIdException();
            }

            customer.WorkstationCreatedOn = workstationId.Value;

            customerRepository.Save(customer);
        }
    }
}