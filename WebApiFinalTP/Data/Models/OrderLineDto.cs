﻿using System;
namespace WebApiFinalTP.Data.Models
{
	public class OrderLineDto
	{
        public int OrderId { get; set; }
        public int ProductId { get; set; } 
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
    }
}

