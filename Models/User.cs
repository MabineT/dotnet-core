namespace causal.api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public string PassportNumber { get; set; }
        public bool Active { get; set; }
    }
}