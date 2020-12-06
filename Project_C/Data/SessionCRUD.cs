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
    public class SessionCRUD
    {
        public ApplicationDbContext DbContext { get; set; }

        public SessionCRUD(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<SessionInfo>> GetSessionAsync()
        {
            return await DbContext.Session.ToListAsync();
        }

        public async Task<SessionInfo> GetSessionByIdAsync(int id)
        {
            return await DbContext.Session.FindAsync(id);
        }

        public async Task<SessionInfo> InsertSessionAsync(SessionInfo session)
        {
            DbContext.Session.Add(session);
            await DbContext.SaveChangesAsync();

            return session;
        }

        public async Task<SessionInfo> UpdateSessionAsync(int id, SessionInfo s)
        {
            var session = await DbContext.Session.FindAsync(id);

            if (session == null)
                return null;

            session.session_name = s.session_name;
            session.session_location = s.session_location;
            session.session_date = s.session_date;

            DbContext.Session.Update(session);
            await DbContext.SaveChangesAsync();

            return session;
        }

        public async Task<SessionInfo> DeleteSessionAsync(int id)
        {
            var student = await DbContext.Session.FindAsync(id);

            if (student == null)
                return null;

            DbContext.Session.Remove(student);
            await DbContext.SaveChangesAsync();

            return student;
        }

        private bool SessionExist(int id)
        {
            return DbContext.Session.Any(e => e.session_id == id);
        }
    }
}