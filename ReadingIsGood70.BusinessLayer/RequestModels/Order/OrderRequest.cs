using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using ReadingIsGood70.BusinessLayer.Exceptions;
using ReadingIsGood70.BusinessLayer.RequestModels.Base;

namespace ReadingIsGood70.BusinessLayer.RequestModels.Order
{
    public class OrderRequest : Request
    {
        [JsonPropertyName("productQuantities")]
        public IEnumerable<ProductQuantityData> ProductQuantities { get; set; }
        
        [JsonPropertyName("address")]
        public string Address { get; set; }

        public override void ValidateAndThrow()
        {
            if (string.IsNullOrWhiteSpace(Address))
            {
                throw new RequestParameterException($"Please provide address information");
            }

            if (ProductQuantities == null || !ProductQuantities.Any())
            {
                throw new RequestParameterException($"Please provide Product information.");
            }
        }
    }
}