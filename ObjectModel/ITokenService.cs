namespace ObjectModel
{
    public interface ITokenService
    {
        string BuildToken(Account user);
        //string GenerateJSONWebToken(string key, string issuer, UserDTO user);
        bool IsTokenValid(string token);
    }
}