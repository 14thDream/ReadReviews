using Managers.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ReadReviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestReviewsController : ControllerBase
    {
        private readonly IReviewService _guestReviewService;

        public GuestReviewsController(IReviewService guestReviewService)
        {
            _guestReviewService = guestReviewService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GuestReview>> GetAllGuestReviews()
        {
            var guestReviews = _guestReviewService.GetAllGuestReviews();
            return Ok(guestReviews);
        }

        [HttpGet("{id}")]
        public ActionResult<GuestReview> GetGuestReviewById(int id)
        {
            return _guestReviewService.GetGuestReviewById(id) switch
            {
                null => NotFound(),
                GuestReview guestReview => Ok(guestReview)
            };
        }

        [HttpPost]
        public ActionResult AddGuestReview(GuestReview guestReview)
        {
            _guestReviewService.AddGuestReview(guestReview);
            return CreatedAtAction(nameof(GetGuestReviewById), new { id = guestReview.Id }, guestReview);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGuestReview(int id, GuestReview guestReview)
        {
            return _guestReviewService.UpdateGuestReview(id, guestReview) switch
            {
                null => NotFound(),
                _ => NoContent()
            };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGuestReview(int id)
        {
            return _guestReviewService.DeleteGuestReview(id) ? NoContent() : NotFound();
        }
    }
}
