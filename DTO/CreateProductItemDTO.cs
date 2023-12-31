﻿namespace CoolMate.DTO
{
    public class CreateProductItemDTO
    {
        public int ProductId { get; set; }
        public List<string> Size { get; set; }
        public ColorDTO Color { get; set; }
        public int Qty { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
