using Managers.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ReadReviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReviewsController : ControllerBase
    {
        private readonly IReviewService _userReviewService;

        public UserReviewsController(IReviewService userReviewService)
        {
            _userReviewService = userReviewService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReview>> GetAllUserReviews()
        {
            var userReviews = _userReviewService.GetAllUserReviews();
            return Ok(userReviews);
        }

        [HttpGet("{id}")]
        public ActionResult<UserReview> GetUserReviewById(int id)
        {
            return _userReviewService.GetUserReviewById(id) switch
            {
                null => NotFound(),
                UserReview userReview => Ok(userReview)
            };
        }

        [HttpPost]
        public ActionResult AddUserReview(UserReview userReview)
        {
            _userReviewService.AddUserReview(userReview);
            return CreatedAtAction(nameof(GetUserReviewById), new { id = userReview.Id }, userReview);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserReview(int id, UserReview userReview)
        {
            return _userReviewService.UpdateUserReview(id, userReview) switch
            {
                null => NotFound(),
                _ => NoContent()
            };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserReview(int id)
        {
            return _userReviewService.DeleteUserReview(id) ? NoContent() : NotFound();
        }
    }
}
