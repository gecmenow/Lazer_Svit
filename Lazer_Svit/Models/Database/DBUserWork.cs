using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models.Database
{
    public class DBUserWork
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPhone { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string File { get; set; }
        [Required]
        public string FileTime { get; set; }
    }
}