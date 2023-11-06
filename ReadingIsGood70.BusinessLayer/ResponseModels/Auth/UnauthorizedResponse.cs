using System.Net;
using ReadingIsGood70.BusinessLayer.ResponseModels.Base;

namespace ReadingIsGood70.BusinessLayer.ResponseModels.Auth
{
    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse(string requestId)
        {
            Status = (int) HttpStatusCode.Unauthorized;
            RequestId = requestId;
        }
    }
}