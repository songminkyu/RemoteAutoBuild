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
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "python";
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = false;
                if (productInfo.ProductName == Enums.ProductCategory.delivery_msa)
                {
                    startInfo.Arguments = @"Todo delivery_msa build argument";
                }
                else if (productInfo.ProductName == Enums.ProductCategory.loans_msa)
                {
                    startInfo.Arguments = @"Todo loans_msa build argument";
                }
                else
                {
                    startInfo.Arguments = @"Todo other build argument";
                }
                using (Process process = Process.Start(startInfo))
                {
                    // ���μ����� ����� ������ ��ٸ�
                    process.WaitForExit();                    
                }
                string res = string.Format("{0} ���尡 �Ϸ� �Ǿ����ϴ�", productInfo.ProductName);
                _logger.LogInformation(res);
                return Ok(res);
            }
            catch (Exception ex) 
            {
                string exMessage = string.Format("Build Error : {0}", ex.Message);
                _logger.LogError(exMessage);
                return NotFound(exMessage);
            }            
        }
    }
}
