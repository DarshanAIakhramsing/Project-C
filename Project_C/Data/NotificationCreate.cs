using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Project_C.Data;
using Project_C.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Project_C.Data
{
    public class NotificationCreate
    {
        public ApplicationDbContext DbContext { get; set; }

        public NotificationCreate(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<UserMeeting> InsertMeetingAsync(UserMeeting meeting)
        {
            DbContext.UserMeetings.Add(meeting);
            await DbContext.SaveChangesAsync();

            return meeting;
        }
    }
}