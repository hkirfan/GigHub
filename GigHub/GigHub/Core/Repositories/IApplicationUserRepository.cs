using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetArtistsFollowedBy(string userId);
    }
}