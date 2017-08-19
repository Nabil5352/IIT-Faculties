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

        [StringLength(60)]
        public string Designation { get; set; }

        [StringLength(100)]
        public string Qualtification { get; set; }

        [StringLength(60)]
        public string DBLP { get; set; }

        [StringLength(60)]
        public string GoogleScholar { get; set; }

        [StringLength(60)]
        public string Academia { get; set; }

        [StringLength(60)]
        public string ResearchGate { get; set; }

        public int Status { get; set; }
    }

    public class IITFacultyDBContext : DbContext
    {
        public IITFacultyDBContext()
        { }
        public DbSet<Faculty> Faculties { get; set; }
    }
}