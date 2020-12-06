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
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ses = await _dbContext.Session.ToListAsync();
            return Ok(ses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ses = await _dbContext.Session.FirstOrDefaultAsync(a => a.session_id == id);
            return Ok(ses);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SessionInfo session)
        {
            _dbContext.Add(session);
            await _dbContext.SaveChangesAsync();
            return Ok(session.session_id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(SessionInfo session)
        {
            _dbContext.Entry(session).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ses = new SessionInfo { session_id = id };
            _dbContext.Remove(ses);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}