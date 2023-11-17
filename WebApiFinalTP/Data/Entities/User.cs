using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFinalTP.Data.Entities
{
	
        public class User
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
            public string? Name { get; set; }
            public string? Password { get; set; }

            [Required]
            public string? UserType { get; set; }
            public ICollection<Order> Orders { get; set; } = new List<Order>();

        }
    
}

