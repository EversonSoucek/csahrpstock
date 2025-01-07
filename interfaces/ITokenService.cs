using csahrpstock.models;

namespace csahrpstock.interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}