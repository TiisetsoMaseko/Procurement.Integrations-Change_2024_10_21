using MSprocure.Controllers;
using MSprocure.Service.Helpers;
using MSprocure.Service.CXML.Helpers;
using Newtonsoft.Json;
using System.Net;
using MSprocure.Service.Models.Content.Responses;

namespace MSprocure.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        #pragma warning disable CS8618, IDE0051, IDE0052
        private static string errorMessage;
        private static bool IsSuccess;
        const string ErrorStatus = "ERROR";
        public RequestDelegate requestDelegate;
        private readonly ILogger<PurchaseOrderController> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate, ILogger<PurchaseOrderController> logger)
        {
            this.requestDelegate = requestDelegate;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.LogInformation($"Local service processing caller request...");
                await requestDelegate(context);
                _logger.LogInformation("Local service ran successfully. Sent results to caller...");
            }

            catch (System.Xml.XmlException x)
            {
                _logger.LogError($"{x.Message}. Error occured {x.StackTrace}");
                await HandleException(context, x);
            }

            catch (UnauthorizedAccessException x)
            {
                _logger.LogError($"{x.Message}. Error occured {x.StackTrace}");
                await HandleException(context, x);
            }

            catch (Exception x)
            {
                _logger.LogError($"{x.Message}. Error occured {x.StackTrace}");
                await HandleException(context, x);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex)
        {
            var POresponse = CxmlHelper.CreatePoResponse("500", ex.Message);

            var statusCode = (int)HttpStatusCode.InternalServerError;

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            switch (ex)
            {
                case System.Xml.XmlException:
                POresponse = CxmlHelper.CreatePoResponse("406", ex.Message);
                    statusCode = (int)406;
                    break;

                case UnauthorizedAccessException:
                    POresponse = CxmlHelper.CreatePoResponse("401", ex.Message);
                    statusCode = (int)401;
                    break;
            }

            errorMessage = SerializeHelper.SerializeStringResponse<OrderResponse>(ref POresponse, out IsSuccess, "", "");

            //if (ex.Message.Contains("Invoice"))
            //{
            //    errorMessage = ex.Message;
            //}
            //else if (ex.Message.Contains("ASN"))
            //{
            //    errorMessage = ex.Message;
            //}

            context.Response.ContentType = "application/text";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(errorMessage);
        }
        #pragma warning restore CS8618, IDE0051, IDE0052
    }
}
