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
    class Grade
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(250)]
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pole Ocena jest wymagane")]
        [DisplayName("Ocena")]
        public int Note { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
    }
}
