﻿namespace SpringService.Models
{
    public class History
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string ServiceId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public double Charge { get; set; }
        public double Commission { get; set; }
        public string Details { get; set; }
        public string Type { get; set; } 
    }
}
