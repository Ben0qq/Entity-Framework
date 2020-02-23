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
    class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nazwa Przedmiotu")]
        public string Name { get; set; }
    }
}
