using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSprocure.Service.Authorize.IAuthorize
{
    public interface IAuthorization
    {
        Task<bool> AuthorizePO(MSprocure.Service.Models.Content.Requests.OrderRequest orderRequest);
    }
}
