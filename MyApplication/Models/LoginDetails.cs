using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyApplication.Models
{
    public class LoginDetails
    {
        [Key]
        public int Id { get; set; }

        public DateTime? Login { get; set; }
        public DateTime? Logout { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}

