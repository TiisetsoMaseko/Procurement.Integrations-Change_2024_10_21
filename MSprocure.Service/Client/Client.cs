using Microsoft.Extensions.Configuration;
using MSprocure.Service.Client.IClients;
using MSprocure.Service.Domain.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MSprocure.Service.Client
{
    public class Client : UnitOfWork<string>, IClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        public Client(IHttpClientFactory httpClientFactory, IConfiguration config) : base(httpClientFactory, config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }
    }
}
