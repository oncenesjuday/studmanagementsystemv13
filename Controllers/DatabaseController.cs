using Microsoft.AspNetCore.Mvc;
using studmanagementsystemv13.Models;

namespace studmanagementsystemv13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public DatabaseController(IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }
        [HttpGet("testconnection")]
        public IActionResult TestConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var dbContext = new DbContext(connectionString);

            try
            {
                bool isConnected = dbContext.TestConnection();

                if (isConnected)
                {
                    return Ok(new { Message = "Successfully connected to the database" });
                }
                else
                {
                    return BadRequest(new { Message = "Failed to connect to the database" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occured while checking the database connection: {ex.Message} " });
            }
        }
    }
}
