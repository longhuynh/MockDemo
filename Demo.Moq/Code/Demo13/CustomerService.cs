namespace  Demo.Moq.Code.Demo13
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMailingRepository mailingRepository;

        public CustomerService(
            ICustomerRepository customerRepository,
            IMailingRepository mailingRepository)
        {
            this.customerRepository = customerRepository;
            this.mailingRepository = mailingRepository;
            this.customerRepository.NotifySalesTeam += NotifySalesTeam;
        }

        private void NotifySalesTeam(object sender, NotifySalesTeamEventArgs e)
        {
            mailingRepository.NewCustomerMessage(e.Name);
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(customerToCreate.Name);

            customerRepository.Save(customer);
        }
    }
}