namespace SecureApp.Models;


public class User
{
public int Id { get; set; }
public string Email { get; set; } = string.Empty;
public string PasswordHash { get; set; } = string.Empty; // bcrypt hash
public string Role { get; set; } = "User"; // simple RBAC
public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
} 