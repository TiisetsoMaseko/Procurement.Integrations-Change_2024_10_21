using Microsoft.AspNetCore.Mvc;
using MSprocure.Service.IService;

namespace MSprocure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IinvoiceService _invoiceService;
        private readonly IConfiguration _config;
        private readonly ILogger<InvoiceController> _logger;
        public InvoiceController(IinvoiceService invoiceService, IConfiguration config, ILogger<InvoiceController> logger)
        {
            _invoiceService = invoiceService;
            _config = config;
            _logger = logger;
        }

        #pragma warning disable CS8604

        [HttpPost]
        //public async Task<IActionResult> PostInvoice([FromBody] string Invoice)
        public async Task<IActionResult> PostInvoice()
        {
            var ClientApiURL = _config["WeirMCoupaURL"];

            string Invoice = string.Empty;
            using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                Invoice = await reader.ReadToEndAsync();
            }

            _logger.LogInformation($"Received Invoice: {Invoice}");

            if (string.IsNullOrEmpty(ClientApiURL))
            {
                _logger.LogWarning("Client URL not set in configuration file. PO will not be sent to client.");
            }

            var response = await _invoiceService.ProcessInvoice(Invoice, ClientApiURL);
            return Ok(response);
        }
        #pragma warning restore CS8604
    }
}
