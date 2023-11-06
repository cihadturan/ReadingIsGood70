namespace ReadingIsGood70.BusinessLayer.ResponseModels.Base
{
    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}