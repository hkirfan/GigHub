using System.Web.Mvc;
using GigHub.Models;
using GigHub.Persistence;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class FollowController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _unitOfWork;

        public FollowController()
        {
            _context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var followees = _unitOfWork.Followings.GetFollowingArtists(userId);
            var viewModel = new FollowViewModel
            {
                Followees = followees,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Artists I'm Following"
            };
            return View(viewModel);

        }
    }
}