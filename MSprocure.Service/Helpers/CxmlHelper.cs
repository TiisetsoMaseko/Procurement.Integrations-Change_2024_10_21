using MSprocure.Service.Models;
using MSprocure.Service.Models.Content.Responses;
using System;
using System.Diagnostics;

namespace MSprocure.Service.CXML.Helpers
{
    public static class CxmlHelper
    {
        public static string GeneratePayloadID(DateTime timeStamp, string hostName)
        {
            var dateTime = timeStamp;
            var ticks = dateTime.Ticks.ToString("0000000");
            var processID = Process.GetCurrentProcess().Id.ToString("0000");
            var random = new Random(dateTime.Millisecond).Next(1, 9999).ToString("0000");
            var hostname = hostName;

            return $"{ticks}.{processID}.{random}@{hostname}";
        }

        public static OrderResponse CreatePoResponse(string Code, string Text)
        {
            OrderResponse cXml = new OrderResponse()
            {
                payloadID = GeneratePayloadID(DateTime.Now, "MEM"),
                timestamp = DateTime.Now,
                lang = "en",
                Response = new MSprocure.Service.Models.Response()
                {
                    Status = new()
                    {
                        code = Code,
                        text = Text
                    }
                }
            };

            return cXml;
        }


    }
}
