using NLayerCore.DTOs;
using NLayerCore.Models;


namespace NLayerCore.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);
    }
}
