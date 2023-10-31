﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upbase_project.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public string Name {  get; set; }

        public string Email {  get; set; }

        public string Password { get; set; }
    }
}
