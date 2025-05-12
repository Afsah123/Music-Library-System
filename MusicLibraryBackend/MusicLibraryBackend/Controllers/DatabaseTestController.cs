using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace MusicLibraryBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseTestController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DatabaseTestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetTables()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                var tables = connection.GetSchema("Tables");
                var tableNames = new List<string>();
                foreach (DataRow row in tables.Rows)
                {
                    tableNames.Add(row[2].ToString());
                }
                return Ok(new { success = true, tables = tableNames });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }
    }
} 