using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace MvcPointAppTest.Models
{
    public class MembersContext : DbContext
    {
        public MembersContext()
            : base("(LocalDB)\v11.0")
        {
        }

        public DbSet<Student> Student { get; set; }
    }

    [Table("Student")]
    public class Student
    {
        public int studentid { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        public string middlename { get; set; }
        [Required]
        [Range (9,12)]
        public int grade { get; set; }
        public bool active { get; set; }
    }
}