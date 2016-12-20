namespace  Demo.Moq.Code.Demo07
{
    public interface ICustomerStatusFactory
    {
        CustomerStatus CreateFrom(CustomerToCreateDto customerToCreate);
    }
}