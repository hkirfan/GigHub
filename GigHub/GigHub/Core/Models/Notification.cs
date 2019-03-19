using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Core.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }

        private Notification(Gig gig, NotificationType type)
        {
            Gig = gig ?? throw new ArgumentException("Gig cannot be null.");
            DateTime = DateTime.Now;
            NotificationType = type;
        }

        protected Notification()
        {
        }

        public static Notification GigCreated(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCreated);
        }
        public static Notification GigUpdated(Gig gig)
        {
            var notification = new Notification(gig, NotificationType.GigUpdated)
            {
                OriginalDateTime = gig.DateTime,
                OriginalVenue = gig.Venue
            };
            return notification;
        }
        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCanceled);
        }
    }
}