using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamianBednarzlab4zadanie.Models
{
    class Parent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Imie")]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
