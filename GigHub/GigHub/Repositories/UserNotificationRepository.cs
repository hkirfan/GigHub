using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GigHub.Models;

namespace GigHub.Repositories
{
    public class UserNotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public UserNotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetNotifications(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();
        }

        public IEnumerable<UserNotification> GetUserNotifications(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();
        }
    }
}