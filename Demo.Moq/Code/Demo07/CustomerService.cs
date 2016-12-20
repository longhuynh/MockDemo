namespace  Demo.Moq.Code.Demo07
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomerStatusFactory customerStatusFactory;

        public CustomerService(ICustomerRepository customerRepository, 
            ICustomerStatusFactory customerStatusFactory)
        {
            this.customerRepository = customerRepository;
            this.customerStatusFactory = customerStatusFactory;
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(
                customerToCreate.FirstName, customerToCreate.LastName);

            customer.StatusLevel =
                customerStatusFactory.CreateFrom(customerToCreate);

            if (customer.StatusLevel == CustomerStatus.Platinum)
            {
                customerRepository.SaveSpecial(customer);
            }
            else
            {
                customerRepository.Save(customer);
            }
        }
    }
}