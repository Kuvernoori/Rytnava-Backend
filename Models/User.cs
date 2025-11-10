namespace RytnavaBack.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int FriendshipPoints { get; set; } = 0;
    public string? ChosenCharacter { get; set; }
}