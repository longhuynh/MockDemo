namespace  Demo.Moq.Code.Demo10
{
    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public int WorkstationCreatedOn { get; set; }
    }
}