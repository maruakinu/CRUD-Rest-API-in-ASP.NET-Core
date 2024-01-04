using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicManagementSystem.Data;
using MusicManagementSystem.Models;
using System.Linq;

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

        //This has a pagination
        [HttpGet]
        public async Task<IActionResult> GetAllSongs(int? pageNumber, int? pageSize)
        {
            int currentPageNumber = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
            var songs = await (from song in _dbContext.Songs
            select new
            {
                Id = song.Id,
                Title = song.Title,
                Duration = song.Duration           
            }).ToListAsync();

            return Ok(songs.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
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
