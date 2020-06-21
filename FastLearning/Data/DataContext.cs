using FastLearning.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearning.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> Opts) : base(Opts) { }

        public DbSet<Student> Students { get; set; }
        
    }
}
