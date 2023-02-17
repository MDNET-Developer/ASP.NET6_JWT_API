using static System.Net.WebRequestMethods;

namespace MD.JWTApp.Back.Infrastructure.Tool
{
    public class JwtSettingsDefault
    {
        public const string ValidIssuer = "http://localhost";
        public const string ValidAudience = "http://localhost";
        public const string SigningKey = "murad2001";
        public const int ExpireTime = 5;

    }
}
