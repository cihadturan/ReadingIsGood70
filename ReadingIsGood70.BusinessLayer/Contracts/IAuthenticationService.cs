using System;
using System.Threading;
using System.Threading.Tasks;
using ReadingIsGood70.BusinessLayer.RequestModels.Auth;
using ReadingIsGood70.BusinessLayer.ResponseModels.Auth;
using ReadingIsGood70.EntityLayer.Database.Auth;

namespace ReadingIsGood70.BusinessLayer.Contracts
{
    public interface IAuthenticationService
    {
        Task RegisterCustomer(RegistrationRequest request, CancellationToken cancellationToken);

        Task<AuthenticationResponse> AuthenticateCustomer(AuthenticationRequest request,
            CancellationToken cancellationToken);

        Task<RefreshLoginResponse> RefreshLogin(RefreshLoginRequest request, CancellationToken cancellationToken);

        Task<User> GetById(Guid uuid);
    }
}