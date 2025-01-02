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
                if (productInfo.ProductName == Enums.ProductCategory.FFR)
                {
                    startInfo.Arguments = @"D:\Source\AutoBuild\Scripts\AutoBuild_R_FF.py";
                }
                else if (productInfo.ProductName == Enums.ProductCategory.FFR_Portable)
                {
                    startInfo.Arguments = @"D:\Source\AutoBuild\Scripts\AutoBuild_R_FF_Portable.py 0 1";
                }
                else if (productInfo.ProductName == Enums.ProductCategory.FMFR)
                {
                    startInfo.Arguments = @"D:\Source\AutoBuild\Scripts\AutoBuild_R_FMF.py";
                }
                else
                {
                    startInfo.Arguments = @"D:\Source\AutoBuild\Scripts\AutoBuild_R_FML.py";
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
