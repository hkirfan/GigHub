using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Controllers
{
    public class FollowViewModel
    {
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public List<ApplicationUser> Followees { get; set; }
    }
}