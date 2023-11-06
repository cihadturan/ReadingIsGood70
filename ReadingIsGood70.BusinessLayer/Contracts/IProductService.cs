using System.Collections.Generic;
using System.Threading.Tasks;
using ReadingIsGood70.BusinessLayer.ResponseModels.Product;

namespace ReadingIsGood70.BusinessLayer.Contracts
{
    public interface IProductService
    {
        public IList<ProductResponse> GetAvailableProductList();

        Task CreateProductOrIncreaseStock();
    }
}
