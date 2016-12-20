namespace  Demo.Moq.Code.Demo16
{
    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public Address Address { get; set; }
    }
}