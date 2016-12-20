namespace  Demo.Moq.Code.Demo09
{
    public interface ICustomerRepository
    {
        string LocalTimeZone { get; set; }
        void Save(Customer customer);
    }
}