using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicManagementSystem.Data;
using MusicManagementSystem.Models;

namespace MusicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private ApiDbContext _dbContext;

        //Making a constructor and initialize the database
        public ArtistsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // POST api/<ArtistController>
        //This will add data from server to database that associates with the model
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Artist artist)
        {
            if (artist == null)
            {
                throw new ArgumentNullException(nameof(artist));
            }else
            {
                await _dbContext.Artists.AddAsync(artist);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created);
            }
           
        }


        [HttpGet]
        public async Task<IActionResult> GetArtist()
        {
            var artists = await (from artist in _dbContext.Artists
                          select new
                          {
                              Id = artist.Id,
                              Name = artist.Name
                          }).ToListAsync();

            return Ok(artists);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ArtistDetails(int artistId)
        {
            var artistDetails = await _dbContext.Artists.Where(a=>a.Id == artistId).Include(a => a.Songs).ToListAsync();
            return Ok(artistDetails);

        }

    }
}
