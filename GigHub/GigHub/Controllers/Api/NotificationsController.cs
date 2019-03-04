using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;
using GigHub.Persistence;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _unitOfWork;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(_context);
        }
        public IEnumerable<NotificationDto> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.UserNotifications.GetNotifications(userId);

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.UserNotifications.GetUserNotifications(userId);
            notifications.ForEach(n => n.Read());
            _context.SaveChanges();
            return Ok();
        }
    }
}
