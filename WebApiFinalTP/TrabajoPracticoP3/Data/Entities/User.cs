using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoPracticoP3.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }

        public string? Adress { get; set; }


        [Required]
        public string? UserName { get; set; }
        public string? UserType { get; set; }
        public string? Password { get; set; }

        public bool State { get; set; } = true; 
    }
}
