using AutoBuild.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "python";            
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = false;
            if (productInfo.ProductName == Enums.ProductCategory.FFR)
            {
                startInfo.Arguments = @"D:\Source\AutoBuild\Scripts\AutoBuild_R_FF.py";              
            }
            else
            {
                startInfo.Arguments = @"D:\Source\AutoBuild\Scripts\AutoBuild_R_FF_Portable.py 0 1";
            }
            using (Process process = Process.Start(startInfo))
            {
                // ���μ����� ����� ������ ��ٸ�
                process.WaitForExit();
            }            
            return Ok("File executed successfully.");                       
        }
    }
}
