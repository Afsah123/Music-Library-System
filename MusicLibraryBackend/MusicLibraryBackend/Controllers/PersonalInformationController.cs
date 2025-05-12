using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLibraryBackend.Data;
using MusicLibraryBackend.Models;
using System.Threading.Tasks;

namespace MusicLibraryBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonalInformationController : ControllerBase
    {
        private readonly MusicLibraryContext _context;
        public PersonalInformationController(MusicLibraryContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var info = await _context.PersonalInformations.FirstOrDefaultAsync(p => p.UserModelId == userId);
            if (info == null) return NotFound();
            return Ok(info);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromBody] PersonalInformation model)
        {
            var existing = await _context.PersonalInformations.FirstOrDefaultAsync(p => p.UserModelId == model.UserModelId);
            if (existing == null)
            {
                _context.PersonalInformations.Add(model);
            }
            else
            {
                existing.FullName = model.FullName;
                existing.Gender = model.Gender;
                existing.DateOfBirth = model.DateOfBirth;
                existing.PhoneNumber = model.PhoneNumber;
                existing.Address = model.Address;
            }
            await _context.SaveChangesAsync();
            return Ok(model);
        }
    }
} 