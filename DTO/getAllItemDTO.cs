﻿using CoolMate.Models;

namespace CoolMate.DTO
{
    public class getAllItemDTO
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? ColorImage { get; set; }
        public int? QtyInStock { get; set; }
        public string  name { get; set; }
        public string ? priceStr { get; set; }
    }
}
