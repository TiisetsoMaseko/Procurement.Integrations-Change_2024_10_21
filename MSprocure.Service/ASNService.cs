using MSprocure.Service.Client.IClients;
using MSprocure.Service.Helpers;
using MSprocure.Service.IService;
using MSprocure.Service.Models.Content.Requests;
using MSprocure.Service.Models.Content.Responses;
using Newtonsoft.Json;

namespace MSprocure.Service
{
    public class ASNService : IASNService
    {
        private readonly IClient _repo;
        private string AsnToClient;

        #pragma warning disable CS8618, CS0219, IDE0059 // Ignore Naming Rule Violations

        public ASNService(IClient repo)
        {
            _repo = repo;
        }

        public async Task<string> ProcessASN(string ShipmentNotice, string ClientURL)
        {
            var IsValid = false;
            var success = false;
            ShipNoticeRequest ShipNotice = new ShipNoticeRequest();
            OrderResponse response = new OrderResponse();

            var AsnDeserializedJson = JsonConvert.DeserializeObject<ShipNoticeRequest>(ShipmentNotice);
            #region ToDelete
            // AsnJson = JsonConvert.SerializeObject(ShipNotice);

            //SerializeHelper.DeserializeString(ref ShipmentNotice, out ShipNotice);



            //map to do

            //var AsnJsonDeserialize = JsonConvert.DeserializeObject<ShipNoticeRequest>(AsnJson);
            #endregion ToDelete

            var SerializedASN = SerializeHelper.SerializeStringASN(ref AsnDeserializedJson, out success, "", "");
            var SanitizingASN_DeployMode = SerializedASN.Replace("<Request>", "<Request deploymentMode=\"production\">");
            //var SanitizingASN_UOM = SanitizingASN_DeployMode.Replace("<UnitOfMeasure />", "<UnitOfMeasure>EA</UnitOfMeasure>");
            AsnToClient = await _repo.AsnToBuyerAsync(ClientURL, SanitizingASN_DeployMode);
            //SerializeHelper.DeserializeString(ref AsnToClient, out response);
            //return response.Response.Status.text;
            return AsnToClient;
        }
        #pragma warning restore CS8618, CS0219, IDE0059 // Ignore Naming Rule Violations
    }
}
