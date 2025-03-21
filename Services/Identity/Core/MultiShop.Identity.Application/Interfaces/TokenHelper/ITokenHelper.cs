using MultiShop.Identity.Domain.Entities;
using MultiShop.Identity.Domain.ValueObjects;

namespace MultiShop.Identity.Application.Interfaces.TokenHelper
{
    public interface ITokenHelper
    {
        AccessToken CreateAccessToken(User user,IList<OperationClaim> operationClaims);

        RefreshToken CreateRefreshToken(User user,string ipAddress,int addedExpireDayNumber);

    }
}
