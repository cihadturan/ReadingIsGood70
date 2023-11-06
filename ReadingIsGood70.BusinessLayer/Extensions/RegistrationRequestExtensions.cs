using System.Text;
using ReadingIsGood70.BusinessLayer.RequestModels.Auth;
using ReadingIsGood70.EntityLayer.Database.Auth;
using ReadingIsGood70.Utils.Crypto;

namespace ReadingIsGood70.BusinessLayer.Extensions
{
    public static class RegistrationRequestExtensions
    {
        public static User ToNewUser(this RegistrationRequest request, string salt)
        {
            return new()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHashed = PasswordHelper.GenerateHashedPassword(request.Password, Encoding.ASCII.GetBytes(salt))
            };
        }
    }
}