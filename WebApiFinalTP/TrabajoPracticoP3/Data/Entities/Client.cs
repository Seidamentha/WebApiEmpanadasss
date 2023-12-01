namespace TrabajoPracticoP3.Data.Entities
{
    public class Client : User
    {
        public string? City { get; set; }
        public string? Adress { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;

    }
}