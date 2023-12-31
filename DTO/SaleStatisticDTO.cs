﻿namespace CoolMate.DTO
{
    public class OneSaleStatisticDTO
    {
        public long total { get; set; }
        public int count { get; set; }
        public DateTime time { get; set; }
    }
    public class SaleStatisticDTO
    {
        public List<OneSaleStatisticDTO> data { get; set; }
    }
}
