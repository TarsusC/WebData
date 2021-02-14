using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebData.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DbConnection") {  }
        public DbSet<Data> Dates { get; set; }
    }
}