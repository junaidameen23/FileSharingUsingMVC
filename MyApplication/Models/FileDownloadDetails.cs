using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyApplication.Models
{
    public class FileDownloadDetails
    {
        [Key]
        public int Id { get; set; }
        public int FileId { get; set; }
        [ForeignKey("FileId")]
        public FileDetails FileDetails { get; set; }

        [Required]
        public string DownloadedById { get; set; }
        [ForeignKey("DownloadedById")]
        public ApplicationUser DownloadedBy { get; set; }

    }
}