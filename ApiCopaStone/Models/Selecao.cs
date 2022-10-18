using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCopaStone.Models

{
    public class Selecao
    {
        [Key]
        public int SelecaoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(20)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(300)]
        public string UrlImagemBandeira { get; set; }
    }
}
//rever video 4- criando uma api data driven...1:55