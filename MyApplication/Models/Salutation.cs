using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApplication.Models
{
    public class Salutation
    {
        public Salutation() { }

        #region Properties
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public bool IsActive { get; set; }
        #endregion
    }
}