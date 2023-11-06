using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingIsGood70.BusinessLayer.ResponseModels.Product;

namespace ReadingIsGood70.BusinessLayer.ResponseModels.Order
{
    public class OrderListItemResponse
    {
        public IList<ProductResponse> Products { get; set; }

        public string Address { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
