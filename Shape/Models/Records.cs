using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Shape.Models
{
    public class Record
    {
        public int ID { get; set; }

        [Display(Name ="Record Date")]
        [DataType(DataType.Date)]
        public DateTime RecordDate { get; set; }
        public decimal Weight { get; set; }
        public decimal Waist { get; set; }
    }

    public class RecordsDbContext: DbContext
    {
        public DbSet<Record> Records { get; set; } 
    }
}