using DotnetNTierArchitecture.Core.DTOs.Authentication;

namespace DotnetNTierArchitecture.API.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        AuthResponseDto Authenticate(string userName, string password);

    }
}
