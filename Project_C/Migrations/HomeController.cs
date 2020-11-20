using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_C.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<SessionInfo>> Get()
        {
            return await _dbContext.Session.ToListAsync();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody] SessionInfo session)
        {
            if (ModelState.IsValid)
            {
                session.session_name = Guid.NewGuid().ToString();
                _dbContext.Add(session);
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}