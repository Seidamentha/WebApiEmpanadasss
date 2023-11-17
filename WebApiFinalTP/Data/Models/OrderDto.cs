using System;
using System.Text.Json.Serialization;

namespace WebApiFinalTP.Data.Models
{
	public class OrderDto
	{

         [JsonIgnore]

        public int Id { get; set; }
        public bool Status { get; set; } = true;

        [JsonIgnore]
        public int UserId { get; set; }

	}
}

