using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicManagementSystem.Data;
using MusicManagementSystem.Models;

namespace MusicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public AlbumsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // POST api/<AlbumsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Album album)
        {
            await _dbContext.Albums.AddAsync(album);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            var albums = await (from album in _dbContext.Albums
                                select new
                                {
                                    Id = album.Id,
                                    Name = album.Name,
                                    ImageUrl = album.ImageUrl
                                }).ToListAsync();

            return Ok(albums);
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> AlbumDetails(int albumId)
        {
            var albumDetails = await _dbContext.Albums.Where(a=>a.Id == albumId).Include(a => a.Songs).ToListAsync();
            return Ok(albumDetails);
        }

    }
}
