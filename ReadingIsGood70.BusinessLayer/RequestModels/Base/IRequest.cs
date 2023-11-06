namespace ReadingIsGood70.BusinessLayer.RequestModels.Base
{
    public interface IRequest
    {
        bool ValidateModel();
        void ValidateAndThrow();
    }
}