namespace EmailSenderApp.Models
{

    public enum EmailType
    {
        Welcome,
        ComeBack,
        
    }
    public class Customer
    {
        public string Email { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
