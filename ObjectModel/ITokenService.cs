namespace ObjectModel
{
    public interface ITokenService
    {
        string BuildToken(Account user);
        //string GenerateJSONWebToken(string key, string issuer, UserDTO user);
        bool IsTokenValid(string token);

        int DeserializeToken(string token);
        string GetUserId(string token);
    }
}