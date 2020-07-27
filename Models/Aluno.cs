using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_EFCore2.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Sexo { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Nascimento { get; set; }

    }
}
