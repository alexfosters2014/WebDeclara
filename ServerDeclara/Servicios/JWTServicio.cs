using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ServerDeclara.Servicios
{
    public static class JWTServicio
    {

        public static (string mail, string id) GetClaimsFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // Accede a los claims del token.
            var claims = jwtToken.Claims;

            string mail = claims.FirstOrDefault(c => c.Type == "email")?.Value;
            string idUsuarioGoogle = claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            return (mail,idUsuarioGoogle);
        }
    }
}
