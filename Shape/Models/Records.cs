using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Shape.Models
{
    public class Record
    {
        public int ID { get; set; }
        public DateTime RecordDate { get; set; }
        public decimal Weight { get; set; }
        public decimal Waist { get; set; }
    }

    public class RecordsDbContext: DbContext
    {
        public DbSet<Record> Records { get; set; } 
    }
}