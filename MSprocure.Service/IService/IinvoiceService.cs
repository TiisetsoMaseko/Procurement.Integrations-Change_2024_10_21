using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSprocure.Service.IService
{
    public interface IinvoiceService
    {
        Task<string> ProcessInvoice(string Invoice, string ClientURL);
    }
}
