using Mapster;
using MSprocure.Service.Domain.DTOs;
using MSprocure.Service.Models.Content.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSprocure.Service.Mappers
{
    public class MapperToInternalType
    {
        public static OrderRequestDto MapPurchaseOrderDto(OrderRequest PurchaseOrderRequest)
        {
            var InternalOrderRequest = new OrderRequestDto();
            PurchaseOrderRequest.Adapt(InternalOrderRequest);

            return InternalOrderRequest;
        }
    }
}
