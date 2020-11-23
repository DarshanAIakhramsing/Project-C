using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_C.Models;
using Project_C.Data;

namespace Project_C.Services
{
    public class SessionService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public SessionService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        public List<SessionInfo> DisplaySession()
        {
            return _dbcontext.Session.ToList();
        }
    }
}
