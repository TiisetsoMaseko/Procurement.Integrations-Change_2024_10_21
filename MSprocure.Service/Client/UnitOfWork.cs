using Microsoft.Extensions.Configuration;
using MSprocure.Service.Client.IClients;
using MSprocure.Service.Domain;
using MSprocure.Service.Domain.Canonical;
using MSprocure.Service.Domain.DTOs;
using MSprocure.Service.Helpers;
using MSprocure.Service.Models.Content.Requests;
using MSprocure.Service.Models.Content.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MSprocure.Service.Client
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        #pragma warning disable CS8602, CS8601, CS8603, IDE0052
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        public UnitOfWork(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<string> AsnToBuyerAsync(string URL, string shipNoticeRequest)
        {
            try
            {
                var Request = new HttpRequestMessage(HttpMethod.Post, URL + SD.AsnEndpointAPIpath);
                var client = _httpClientFactory.CreateClient();

                //Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/text"));
                Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                Request.Content = new StringContent(shipNoticeRequest, System.Text.Encoding.UTF8, "text/plain");
                //Request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/text");
                Console.WriteLine(await Request.Content.ReadAsStringAsync());

                HttpResponseMessage response = await client.SendAsync(Request);
                var jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            catch (Exception ex)
            {
                throw new($"ASN. {ex.Message}");
            }


        }

        public async Task<string> InvoiceSellerToBuyerAsync(string URL, string invoiceDetail)
        {
            try
            {
                var Request = new HttpRequestMessage(HttpMethod.Post, URL + SD.InvoiceEndpointAPIpath);
                var client = _httpClientFactory.CreateClient();

                Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/text"));
                Request.Content = new StringContent(invoiceDetail, System.Text.Encoding.UTF8);
                Request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/text");

                HttpResponseMessage response = await client.SendAsync(Request);
                var jsonString = await response.Content.ReadAsStringAsync();

                return jsonString;
            }
            catch (Exception x)
            {
                throw new($"Invoice. {x.Message}");
            }
        }

        //public async Task<string> InvoiceToBuyerAsync(string URL, string invoiceDetail)
        //{
        //    try
        //    {
        //        var Request = new HttpRequestMessage(HttpMethod.Post, URL + SD.InvoiceEndpointAPIpath);
        //        var client = _httpClientFactory.CreateClient();

        //        Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/text"));
        //        Request.Content = new StringContent(invoiceDetail, System.Text.Encoding.UTF8);
        //        Request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/text");

        //        HttpResponseMessage response = await client.SendAsync(Request);
        //        var jsonString = await response.Content.ReadAsStringAsync();

        //        return jsonString;
        //    }
        //    catch (Exception x)
        //    {
        //        throw new ($"Invoice. {x.Message}");
        //    }
        //}

        public async Task<T> PoToSupplierAsync(string URL, string requestDto)
        {
            try
            {
                var QueryObject = JsonConvert.SerializeObject(requestDto);
                var Request = new HttpRequestMessage(HttpMethod.Post, URL + SD.PoEndpointAPIpath);
                var client = _httpClientFactory.CreateClient();

                Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Request.Content = new StringContent(QueryObject, System.Text.Encoding.UTF8);
                Request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.SendAsync(Request);
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                throw new($"Purchase order. {ex.Message}");
            }
        }
        #pragma warning restore CS8602, CS8601, CS8603, IDE0052
    }
}
