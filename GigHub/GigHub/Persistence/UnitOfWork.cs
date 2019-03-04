using GigHub.Models;
using GigHub.Repositories;

namespace GigHub.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public AttendanceRepository Attendances { get; private set; }
        public GigRepository Gigs { get; private set; }
        public FollowingRepository Followings { get; private set; }
        public GenreRepository Genres { get; private set; }
        public UserNotificationRepository UserNotifications { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Attendances = new AttendanceRepository(_context);
            Gigs = new GigRepository(_context);
            Followings = new FollowingRepository(_context);
            Genres = new GenreRepository(_context);
            UserNotifications = new UserNotificationRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}