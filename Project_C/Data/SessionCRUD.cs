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
    public class SessionCRUD : IDisposable, IAsyncDisposable
    {
        public ApplicationDbContext DbContext { get; }

        //Makes database connection
        public SessionCRUD(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        //Gets the sessions in a list
        public async Task<IList<SessionInfo>> GetSessionsAsync() => await DbContext.Session.ToListAsync();

        //Gets the session by id
        public async Task<SessionInfo> GetSessionAsync(int id) => await DbContext.Session.FindAsync(id);

        //Adds session to database
        public async Task InsertSessionAsync(SessionInfo session)
        {
            DbContext.Session.Add(session);
            await DbContext.SaveChangesAsync();
        }


        //Updates all the changes made to the database
        public async Task UpdateSessionAsync(SessionInfo session)
        {
            DbContext.Session.Update(session);
            await DbContext.SaveChangesAsync();
        }

        //Deletes the session out of the database
        public async Task DeleteSessionAsync(SessionInfo session)
        {
            DbContext.Session.Remove(session);
            await DbContext.SaveChangesAsync();
        }

        //Checks if a session exists
        public bool SessionExist(int id) => GetSessionAsync(id) is not null;

        #region Disposable support
        public ValueTask DisposeAsync()
        {
            return ((IAsyncDisposable)DbContext).DisposeAsync();
        }

        public void Dispose()
        {
            ((IDisposable)DbContext).Dispose();
        }
        #endregion
    }
}