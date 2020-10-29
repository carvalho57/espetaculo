namespace Espetaculos.Domain.Utils
{

    public static class Hash
    {
        public static string Encript(string password)
        {
            var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return encryptedPassword;
        }

        public static bool Compare(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }
    }
}