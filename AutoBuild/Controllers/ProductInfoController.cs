using AutoBuild.Model;
using Microsoft.AspNetCore.Mvc;

namespace AutoBuild.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductInfoController : ControllerBase
    {  
        private readonly ILogger<ProductInfoController> _logger;

        public ProductInfoController(ILogger<ProductInfoController> logger)
        {
            _logger = logger;
        }
        [HttpPost]       
        [Route("run-file")]
        public IActionResult RunFile([FromBody] ProductInfo productInfo)
        {            
            if (System.IO.File.Exists(productInfo.Path))
            {
                System.Diagnostics.Process.Start(productInfo.Path);
                return Ok("File executed successfully.");
            }

            return NotFound("File not found.");
        }
    }
}
