namespace  Demo.Moq.Code.Demo15
{
    public class CustomerNameFormatter : BaseFormatter
    {
        public string From(Customer customer)
        {
            var firstName = ParseBadWordsFrom(customer.FirstName);
            var lastName = ParseBadWordsFrom(customer.LastName);

            return $"{lastName}, {firstName}";
        }
    }
}