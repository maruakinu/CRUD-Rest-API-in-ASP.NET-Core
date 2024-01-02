using Microsoft.AspNetCore.Mvc;
using MusicManagementSystem.Data;
using MusicManagementSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {

        private ApiDbContext _dbContext;

        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<SongsController>
        [HttpGet]
        public IActionResult Get()
        {
            return _dbContext.Songs;
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public Song Get(int id)
        {
            var song =  _dbContext.Songs.Find(id);
            return song;
        }

        // POST api/<SongsController>
        [HttpPost]
        public void Post([FromBody] Song song)
        {
            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Song songObj)
        {
           var song = _dbContext.Songs.Find(id);
            song.Title = songObj.Title;
            song.Language = songObj.Language;
            _dbContext.SaveChanges();
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           var song = _dbContext.Songs.Find(id);
           _dbContext.Songs.Remove(song);
           _dbContext.SaveChanges();
        }
    }
}
