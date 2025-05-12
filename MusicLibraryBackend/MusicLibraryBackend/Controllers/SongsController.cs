using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLibraryBackend.Data;
using MusicLibraryBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicLibraryBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly MusicLibraryContext _context;
        public SongsController(MusicLibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            var songs = await _context.Songs.ToListAsync();
            return Ok(songs);
        }
    }
} 