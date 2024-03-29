﻿using System;

namespace GigHub.Core.Models
{
    public class UserNotification
    {
        public string UserId { get; private set; }

        public int NotificationId { get; private set; }

        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set; }

        public bool IsRead { get; private set; }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            User = user ?? throw new ArgumentException("user cannot be null.");
            Notification = notification ?? throw new ArgumentException("notification cannot be null.");

            User = user;
            UserId = user.Id;
            Notification = notification;
            NotificationId = notification.Id;
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