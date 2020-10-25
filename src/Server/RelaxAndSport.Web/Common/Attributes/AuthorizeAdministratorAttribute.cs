namespace RelaxAndSport.Web.Common.Attributes
{
    using Microsoft.AspNetCore.Authorization;

    using static RelaxAndSport.Infrastructure.Common.Constants.InfrastructureConstants.IdentityConstants;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = AdministratorRoleName;
    }
}
