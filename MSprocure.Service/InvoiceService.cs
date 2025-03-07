using Microsoft.Extensions.Configuration;
using MSprocure.Service.Authorize.IAuthorize;
using MSprocure.Service.Client;
using MSprocure.Service.Client.IClients;
using MSprocure.Service.Helpers;
using MSprocure.Service.IService;
using MSprocure.Service.Models.Content.Requests;
using MSprocure.Service.Models.Content.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MSprocure.Service
{
    public class InvoiceService : IinvoiceService
    {
        private readonly IClient _repo;
        private string InvoiceToClient;

        #pragma warning disable CS8618, CS0219, IDE0059 // Ignore Naming Rule Violations

        public InvoiceService(IClient repo)
        {
            _repo = repo;
        }

        public async Task<string> ProcessInvoice(string Invoice, string ClientURL)
        {
            var IsValid = false;
            var success = false;
            var InvoiceObj = "";
            MSprocure.Service.Models.Content.Requests.InvoiceDetailRequest invoice = new MSprocure.Service.Models.Content.Requests.InvoiceDetailRequest();
            OrderResponse response = new OrderResponse();

            var InvoiceDeserializedJson = JsonConvert.DeserializeObject<MSprocure.Service.Models.Content.Requests.InvoiceDetailRequest>(Invoice);
            #region ToDelete
            //SerializeHelper.DeserializeString<MSprocure.Service.Models.Content.Requests.InvoiceDetailRequest>(ref InvoiceDeserializedJson, out invoice);
            //var JsonPO = JsonConvert.SerializeObject(invoice);
            //map to do
            #endregion ToDelete

            var SerializedInvoice = SerializeHelper.SerializeStringInvoice(ref InvoiceDeserializedJson, out success, "", "");
            InvoiceToClient = await _repo.InvoiceSellerToBuyerAsync(ClientURL, SerializedInvoice);
            SerializeHelper.DeserializeString(ref InvoiceToClient, out response);
            return response.Response.Status.text;
        }
        #pragma warning restore CS8618, CS0219, IDE0059 // Ignore Naming Rule Violations
    }
}
