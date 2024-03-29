﻿using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        Attendance GetAttendance(string userId, int gigId);
        void Add(Attendance attendance);
        void Remove(Attendance attendance);
    }
}