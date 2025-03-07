using Microsoft.AspNetCore.Mvc;
using MSprocure.Service.IService;

namespace MSprocure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentNoticeController : ControllerBase
    {
        private readonly IASNService _asnService;
        private readonly IConfiguration _config;
        private readonly ILogger<ShipmentNoticeController> _logger;
        public ShipmentNoticeController(IASNService asnService, IConfiguration config, ILogger<ShipmentNoticeController> logger)
        {
            _asnService = asnService;
            _config = config;
            _logger = logger;
        }

        #pragma warning disable CS8604

        [HttpPost]
        public async Task<IActionResult> PostASN()
        {
            string ShipNotice = string.Empty;
            using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                ShipNotice = await reader.ReadToEndAsync();
            }

            var ClientApiURL = _config["WeirMCoupaURL"];
            _logger.LogInformation($"Received ASN: { ShipNotice }");

            if (string.IsNullOrEmpty(ClientApiURL))
            {
                _logger.LogError("Client URL not set in configuration file. PO will not be sent to client.");
            }

            var response = await _asnService.ProcessASN(ShipNotice, ClientApiURL);
            return Ok(response);
        }
        #pragma warning restore CS8604
    }
}
