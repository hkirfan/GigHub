using System.Web.Http;
using GigHub.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext _context;
        private readonly UnitOfWork _unitOfWork;

        public GigsController()
        {
            _context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var gig = _unitOfWork.Gigs.GetGigWithAttendees(id);

            if (gig == null || gig.IsCanceled)
                return NotFound();

            if (gig.ArtistId != User.Identity.GetUserId())
                return Unauthorized();

            gig.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
