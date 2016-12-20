namespace  Demo.Moq.Code.Demo03
{
    public class Customer
    {
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address MailingAddress { get; set; }
    }
}