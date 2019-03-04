using System.Collections.Generic;
using System.Linq;
using GigHub.Models;

namespace GigHub.Repositories
{
    public class AttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .ToList();
        }

        public Attendance GetAttendance(string userId, int gigId)
        {
            return _context.Attendances.FirstOrDefault(a => a.AttendeeId == userId && a.GigId == gigId);
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void Remove(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }
    }
}