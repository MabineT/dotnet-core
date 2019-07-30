namespace causal.api.Models
{
    public class ContactDetails
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public int CustomerId { get; set; }
        public bool Active { get; set; }
    }
}