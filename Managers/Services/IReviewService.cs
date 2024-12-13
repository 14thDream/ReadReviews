using Models;

namespace Managers.Services
{
    public interface IReviewService
    {
        IEnumerable<GuestReview> GetAllGuestReviews();
        GuestReview? GetGuestReviewById(int id);
        void AddGuestReview(GuestReview guestReview);
        GuestReview? UpdateGuestReview(int id, GuestReview guestReview);
        bool DeleteGuestReview(int id);

        IEnumerable<UserReview> GetAllUserReviews();
        UserReview? GetUserReviewById(int id);
        void AddUserReview(UserReview userReview);
        UserReview? UpdateUserReview(int id, UserReview userReview);
        bool DeleteUserReview(int id);
    }
}
