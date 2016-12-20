namespace  Demo.Moq.Code.Demo18
{
    public class CustomerNameFormatter
    {
        public string From(Customer customer)
        {
            var firstName = ParseBadWordsFrom(customer.FirstName);
            var lastName = ParseBadWordsFrom(customer.LastName);

            return $"{lastName}, {firstName}";
        }

        protected virtual string ParseBadWordsFrom(string value)
        {
            return value.Replace("SAP", string.Empty);
        }
    }
}