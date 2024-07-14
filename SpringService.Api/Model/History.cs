﻿using System.ComponentModel.DataAnnotations;

namespace SpringService.Api.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string ServiceId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; } //might change this to char
        public double Charge { get; set; }
        public double Commission { get; set; }
        public string Details { get; set; }
        public string Type { get; set; } 
    }
}
