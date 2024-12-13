namespace Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public AccountType TypeOfAccount { get; set; }
    }

    public enum AccountType
    {
        User,
        Moderator,
        Administrator
    }
}
