using MSprocure.Service.Domain;
using MSprocure.Service.Domain.DTOs;
using MSprocure.Service.Models.Content.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSprocure.Service.Client.IClients
{
    public interface IUnitOfWork<T> where T : class
    {
        Task<T> PoToSupplierAsync(string URL, string requestDto);
        //Task<T> InvoiceToBuyerAsync(string URL, string invoiceDetail);
        Task<string> AsnToBuyerAsync(string URL, string shipNoticeRequest);
        Task<string> InvoiceSellerToBuyerAsync(string URL, string invoiceDetail);
    }
}