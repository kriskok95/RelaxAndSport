using System.Collections.Generic;

namespace RelaxAndSport.Infrastructure.Identity
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user, IEnumerable<string> roles = default!);
    }
}
