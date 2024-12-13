namespace Models
{
    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string? Content { get; set; }
    }

    public class GuestReview : Review
    {
        public string Name { get; set; }
    }

    public class UserReview : Review
    {
        public int UserId { get; set; }
    }
}
