namespace  Demo.Moq.Code.Demo17
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