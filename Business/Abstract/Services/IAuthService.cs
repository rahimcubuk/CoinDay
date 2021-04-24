using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;

namespace Business.Abstract.Services
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult AddUserDefaultClaim(UserForRegisterDto userForRegisterDto);
    }
}
