using System.Security.Claims;

namespace MultiShop.Identity.Infrastructure.Extensions
{
    public static class ClaimPrincipalExtension
    {
        public static List<string>? Claims(this ClaimsPrincipal principal,string claimType)
        {
            var result=principal.FindAll(claimType).Select(x=>x.Value).ToList();
            return result;
        }

        public static List<string>? ClaimRoles(this ClaimsPrincipal principal) =>
            principal.Claims(ClaimTypes.Role);


        public static int GetUserId(this ClaimsPrincipal principal) =>
            Convert.ToInt32(principal.Claims(ClaimTypes.NameIdentifier)!.FirstOrDefault());
    }
}
