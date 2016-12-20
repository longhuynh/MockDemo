namespace  Demo.Moq.Code.Demo01
{
    public class Customer
    {
        public Customer(string name, string city)
        {
            Name = name;
            City = city;
        }

        public string Name { get; set; }
        public string City { get; set; }
    }
}