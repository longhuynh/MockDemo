namespace  Demo.Moq.Code.Demo04
{
    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public MailingAddress MailingAddress { get; set; }
    }
}