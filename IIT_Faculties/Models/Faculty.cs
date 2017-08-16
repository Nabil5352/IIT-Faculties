using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IIT_Faculties.Models
{
    public class Faculty
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }

        [Range(24, 60)]
        public int Age { get; set; }
    }

    public class FacultyDBContext : DbContext
    {
        public FacultyDBContext()
        { }
        public DbSet<Faculty> Faculties { get; set; }
    }
}