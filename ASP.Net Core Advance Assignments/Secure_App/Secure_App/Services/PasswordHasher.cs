using BCrypt.Net;


namespace SecureApp.Services;


public static class PasswordHasher
{
public static string Hash(string password)
{
// WorkFactor defaults are safe; adjust if needed
return BCrypt.Net.BCrypt.HashPassword(password);
}


public static bool Verify(string password, string hash)
{
return BCrypt.Net.BCrypt.Verify(password, hash);
}
}