using ReadingIsGood70.EntityLayer.Enum;

namespace ReadingIsGood70.BusinessLayer.ResponseModels.Base
{
    public class ErrorResponse : IErrorResponse
    {
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
        public object Payload { get; set; }
    }
}
