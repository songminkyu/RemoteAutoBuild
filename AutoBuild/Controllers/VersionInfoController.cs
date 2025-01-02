using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoBuild.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionInfoController : ControllerBase
    {
        // GET: api/VersionInfo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "10.0.0.1", "987654321" };
        }

    }
}
