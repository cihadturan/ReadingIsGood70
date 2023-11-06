using ReadingIsGood70.EntityLayer.Enum;

namespace ReadingIsGood70.BusinessLayer.ResponseModels.Base
{
    public interface IErrorResponse
    {
        ErrorCodes Code { get; set; }
        string Message { get; set; }
        object Payload { get; set; }
    }
}