using MSprocure.Service.Authorize.IAuthorize;
using MSprocure.Service.Client.IClients;
using MSprocure.Service.CXML.Helpers;
using MSprocure.Service.Helpers;
using MSprocure.Service.IService;
using MSprocure.Service.Mappers;
using MSprocure.Service.Models.Content.Responses;
using Newtonsoft.Json;

namespace MSprocure.Service
{
    public class POservice : IPOservice
    {
        const string Code = "200";
        const string Text = "OK";
        private readonly IClient _repo;
        private readonly IAuthorization _auth;

        public POservice(IClient repo, IAuthorization auth)
        {
            _repo = repo;
            _auth = auth;
        }

#pragma warning disable CS8618, CS0219, IDE0059 // Ignore Naming Rule Violations

        public async Task<string> ProcessPO(string PO, string ClientURL)
        {
            var IsValid = false;
            Models.Content.Requests.OrderRequest or = new Models.Content.Requests.OrderRequest();
            SerializeHelper.DeserializeString(ref PO, out or);

            //var JsonPO = JsonConvert.SerializeObject(or);
            var JsonSerializedPO = JsonConvert.SerializeObject(or, Formatting.Indented);

            var HeaderAuthorized = await _auth.AuthorizePO(or);
            if (HeaderAuthorized == true)
            {
                //To utilize mapper
                //var InternalPOType = MapperToInternalType.MapPurchaseOrderDto(or);


                // send to Supplier client
                var SendPoToClient = await _repo.PoToSupplierAsync(ClientURL, JsonSerializedPO);
                var POresponse = CxmlHelper.CreatePoResponse(Code, Text);
                var ResponseMsg = SerializeHelper.SerializeStringResponse(ref POresponse, out IsValid, "", "");
                return ResponseMsg;
            }
            else
            {
                throw new UnauthorizedAccessException("Invalid header credentials.");
            }
        }
#pragma warning restore CS8618, CS0219, IDE0059 // Ignore Naming Rule Violations
    }
}