namespace SpringService.Api.Models
{
    public class Transaction
    {
        /*
          `trx` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
          `gateway_transaction` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
          `commission` decimal(28,8) NOT NULL, 
          `charge` decimal(10,0) NOT NULL, 
          `type` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,*/
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ServiceId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public double Charge { get; set; }
        public double Commission { get; set; }
        public string Details { get; set; }
        public string Type { get; set; }
    }
}
