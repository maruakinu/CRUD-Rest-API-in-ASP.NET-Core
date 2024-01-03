using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicManagementSystem.Data;
using MusicManagementSystem.Models;

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


        // POST api/<ArtistController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Song song)
        {
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            var songs = await (from song in _dbContext.Songs
            select new
            {
                Id = song.Id,
                Title = song.Title,
                Duration = song.Duration           
            }).ToListAsync();

            return Ok(songs);
        }


        //   [HttpGet("[action]")]
        //  public async Task<IActionResult> FeaturedSongs()
        //   {
        //      var songs = await (from song in _dbContext.Songs
        //                        where song.isFeatured == true
        //                        select new
        //                         {
        //                              Id = song.Id,
        //                             Title = song.Title,
        //                              Duration = song.Duration
        //                          }).ToListAsync();
        //
        //       return Ok(songs);
        //   }


        [HttpGet("[action]")]
        public async Task<IActionResult> SearchSongs(string query)
        {
            var songs = await (from song in _dbContext.Songs
                               where song.Title.StartsWith(query)
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                                   Duration = song.Duration
                               }).Take(15).ToListAsync();

            return Ok(songs);
        }

    }
}
