using System.Web.Http;
using GigHub.Dtos;
using GigHub.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _unitOfWork;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Followings.GetFollowing(dto.FolloweeId, userId) != null)
                return BadRequest("Following already exists.");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _unitOfWork.Followings.Add(following);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollowing(string id)
        {
            var userId = User.Identity.GetUserId();

            var following = _unitOfWork.Followings.GetFollowing(id, userId);

            if (following == null)
                return NotFound();

            _unitOfWork.Followings.Remove(following);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}