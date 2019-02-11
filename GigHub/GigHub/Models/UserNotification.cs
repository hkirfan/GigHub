using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; private set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; private set; }

        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set; }

        public bool IsRead { get; private set; }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            User = user ?? throw new ArgumentException("user cannot be null.");
            Notification = notification ?? throw new ArgumentException("notification cannot be null.");
        }

        protected UserNotification()
        {

        }

        public void Read()
        {
            IsRead = true;
        }
    }
}