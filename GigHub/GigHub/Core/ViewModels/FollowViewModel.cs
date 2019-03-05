using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
    public class FollowViewModel
    {
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public List<ApplicationUser> Followees { get; set; }
    }
}