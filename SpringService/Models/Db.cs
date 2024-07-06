using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpringService.Models
{
    [Table("AppDb")]
    public class Db
    {
        /*[PrimaryKey]
        [AutoIncrement]*/
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Slug { get; set; }
        public double Balance { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Designation { get; set; }
        public string Details { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; }
        public bool IsVerified { get; set; } 
        public string Social { get; set; } 
    }
}
