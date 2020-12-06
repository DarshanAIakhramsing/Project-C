using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_C.Models;
using Project_C.Data;

namespace Project_C.Services
{
    public class UserService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public UserService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        public List<User> DisplayUser()
        {
            return _dbcontext.Users.ToList();
                                   //.OrderBy(User.accepted_invitation);
        }

        public List<User> DisplayEmail(string email)
        {
            return _dbcontext.Users.Where(x => x.Email == email).ToList();
        }
    }
}
