using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingIsGood70.BusinessLayer.RequestModels.Product;
using ReadingIsGood70.EntityLayer.Database.Content;

namespace ReadingIsGood70.BusinessLayer.Extensions
{
    public static class ProductRequestExtensions
    {
        public static Product ToProduct(this ProductRequest request)

            => new Product
            {
                Name = request.Name,
                AmountLeft = request.Quantity,
                Uuid = Guid.NewGuid(),
                UnitPrice = request.Price
            };
    }
}
