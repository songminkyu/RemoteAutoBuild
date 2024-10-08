using AutoBuild.Model;
using Microsoft.AspNetCore.Mvc;

namespace AutoBuild.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileExecutionController : ControllerBase
    {  
        private readonly ILogger<FileExecutionController> _logger;

        public FileExecutionController(ILogger<FileExecutionController> logger)
        {
            _logger = logger;
        }
        [HttpPost]       
        [Route("run-file")]
        public IActionResult RunFile([FromBody] FileExeInfo fileinfo)
        {            
            if (System.IO.File.Exists(fileinfo.Path))
            {
                System.Diagnostics.Process.Start(fileinfo.Path);
                return Ok("File executed successfully.");
            }

            return NotFound("File not found.");
        }
    }
}
