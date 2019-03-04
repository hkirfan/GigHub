using System.Collections.Generic;
using System.Linq;
using GigHub.Models;

namespace GigHub.Repositories
{
    public class FollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string artistId, string userId)
        {
            return _context.Followings.FirstOrDefault(a => a.FolloweeId == artistId && a.FollowerId == userId);
        }

        public List<ApplicationUser> GetFollowingArtists(string userId)
        {
            return _context.Followings
                .Where(a => a.FollowerId == userId)
                .Select(a => a.Followee)
                .ToList();
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }
    }
}