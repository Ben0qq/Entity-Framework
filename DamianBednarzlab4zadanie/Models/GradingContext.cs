using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamianBednarzlab4zadanie.Models
{
    class GradingContext:DbContext
    {
        public GradingContext():base("AppContext")
        {
                
        }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
    }
}
