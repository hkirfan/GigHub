using System.Web.Mvc;
using GigHub.Core;
using GigHub.Core.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class FollowController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var followees = _unitOfWork.Users.GetArtistsFollowedBy(userId);
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