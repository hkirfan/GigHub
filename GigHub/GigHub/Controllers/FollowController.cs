using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class FollowController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FollowController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var followees = _context.Followings
                .Where(a => a.FollowerId == userId)
                .Select(a => a.Followee)
                .ToList();
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