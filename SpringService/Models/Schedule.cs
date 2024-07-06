namespace SpringService.Models
{
    public class Schedule
    {
        /*`id` bigint UNSIGNED NOT NULL,
      `user_id` bigint UNSIGNED NOT NULL,
      `week_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
      `start_time` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
      `end_time` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
      `status` tinyint(1) NOT NULL, */
        public int Id { get; set; }
        public int UserId { get; set; }

    }
}
