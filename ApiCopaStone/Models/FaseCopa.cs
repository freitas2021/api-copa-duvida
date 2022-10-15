using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCopaStone.Models
{
    public class FaseCopa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30)]
        public string Nome { get; set; }

        [ForeignKey("jogo")]
        public List<Jogo> Jogos { get; set; }
    }
}
