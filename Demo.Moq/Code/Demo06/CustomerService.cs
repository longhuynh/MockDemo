namespace  Demo.Moq.Code.Demo06
{
    public class CustomerService
    {
        private readonly ICustomerFullNameBuilder customerFullName;
        private readonly ICustomerRepository customerRepository;

        public CustomerService(
            ICustomerRepository customerRepository,
            ICustomerFullNameBuilder customerFullName)
        {
            this.customerRepository = customerRepository;
            this.customerFullName = customerFullName;
        }

        public void Create(CustomerToCreateDto customerToCreateDto)
        {
            var fullName = customerFullName.From(
                customerToCreateDto.FirstName,
                customerToCreateDto.LastName);

            var customer = new Customer(fullName);

            customerRepository.Save(customer);
        }
    }
}