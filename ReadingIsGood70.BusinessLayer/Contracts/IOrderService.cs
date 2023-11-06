using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ReadingIsGood70.BusinessLayer.RequestModels.Order;
using ReadingIsGood70.BusinessLayer.ResponseModels.Base;
using ReadingIsGood70.BusinessLayer.ResponseModels.Order;

namespace ReadingIsGood70.BusinessLayer.Contracts
{
    public interface IOrderService
    {
        IList<OrderListItemResponse> GetOrderList(Guid userUuid, CancellationToken cancellationToken);

        Task<OrderDetailResponse> GetOrderDetail(Guid userUuid, Guid orderUuid, CancellationToken cancellationToken);

        Task<IList<ProductQuantityData>> Order(Guid userUuid, OrderRequest request, CancellationToken cancellationToken);
    }
}
