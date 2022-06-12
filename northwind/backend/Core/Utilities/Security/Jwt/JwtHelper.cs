using Core.Entities.Concrete;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //WebAPI'deki appsettingsjson değerlerini okumamıza yarıyor.
        private TokenOptions _tokenOptions;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();// Buradaki hata için Microsoft.Extensions.Configuration.Binder kur
            //appsettingsjson>TokenOptions ile arasındaki bağlantı (json to class)
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        }
    }
}
