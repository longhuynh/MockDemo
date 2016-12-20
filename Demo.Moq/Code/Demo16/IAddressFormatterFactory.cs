namespace  Demo.Moq.Code.Demo16
{
    public interface IAddressFormatterFactory
    {
        IAddressFormatter From(string country);
    }
}