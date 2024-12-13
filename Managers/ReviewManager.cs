using Managers.Context;
using Managers.Services;
using Models;

namespace Managers
{
    public class ReviewManager : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GuestReview> GetAllGuestReviews() => _context.GuestReviews.ToList();
        public GuestReview? GetGuestReviewById(int id) => _context.GuestReviews.Find(id);

        public IEnumerable<UserReview> GetAllUserReviews() => _context.UserReviews.ToList();
        public UserReview? GetUserReviewById(int id) => _context.UserReviews.Find(id);

        public void AddGuestReview(GuestReview review)
        {
            _context.GuestReviews.Add(review);
            _context.SaveChanges();
        }

        public GuestReview? UpdateGuestReview(int id, GuestReview review)
        {
            var guestReview = GetGuestReviewById(id);
            if (guestReview == null)
            {
                return null;
            }

            guestReview = review;
            _context.SaveChanges();

            return guestReview;
        }

        public bool DeleteGuestReview(int id)
        {
            var review = GetGuestReviewById(id);
            if (review == null)
            {
                return false;
            }

            _context.GuestReviews.Remove(review);
            _context.SaveChanges();

            return true;
        }

        public void AddUserReview(UserReview review)
        {
            _context.UserReviews.Add(review);
            _context.SaveChanges();
        }

        public UserReview? UpdateUserReview(int id, UserReview review)
        {
            var userReview = GetUserReviewById(id);
            if (userReview == null)
            {
                return null;
            }

            userReview = review;
            _context.SaveChanges();

            return userReview;
        }

        public bool DeleteUserReview(int id)
        {
            var review = GetUserReviewById(id);
            if (review == null)
            {
                return false;
            }

            _context.UserReviews.Remove(review);
            _context.SaveChanges();

            return true;
        }
    }
}
