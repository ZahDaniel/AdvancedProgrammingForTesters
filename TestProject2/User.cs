namespace TestProject2
{
    public class User
    {
        public required string Username { get; set; }
        public string Email { get; set; } = string.Empty; // Initialize with a default value
        public int Age { get; set; }
    }
}