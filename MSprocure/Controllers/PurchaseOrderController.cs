using Microsoft.AspNetCore.Mvc;
using MSprocure.Service.IService;

namespace MSprocure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPOservice _poService;
        private readonly IConfiguration _config;
        private readonly ILogger<PurchaseOrderController> _logger;
        public PurchaseOrderController(IPOservice poService, IConfiguration config, ILogger<PurchaseOrderController> logger)
        {
            _poService = poService;
            _config = config;
            _logger = logger;
        }
        #pragma warning disable CS8604

        [HttpPost]
        public async Task<IActionResult> CreatePO()
        {

            var ClientApiURL = _config["ProcedureURL"];

            string PO = string.Empty;
            using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                PO = await reader.ReadToEndAsync();
            }

            if (string.IsNullOrEmpty(ClientApiURL)) 
            { 
                _logger.LogWarning("Client URL not set in configuration file. PO will not be sent to client."); 
            }

            _logger.LogInformation($"PO received: { PO }");

            var response = await _poService.ProcessPO(PO, ClientApiURL );
            return Ok(response);
        }
        #pragma warning restore CS8604
    }
}
