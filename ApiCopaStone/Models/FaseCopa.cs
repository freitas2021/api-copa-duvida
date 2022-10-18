//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace ApiCopaStone.Models
//{
//    public class FaseCopa
//    {
//        [Key]
//        public int Id { get; set; }

//        [Required(ErrorMessage = "Campo obrigatório")]
//        [MaxLength(30)]
//        public string Nome { get; set; }

//        [ForeignKey("jogo")]
//        public List<Jogo> Jogos { get; set; }
//    }
//}
using System.Collections.Generic;

namespace ApiCopaStone.Models
{
    public class FaseCopa
    {
        
        public int FaseCopaId { get; set; }
        public string Nome { get; set; }
        //public ICollection<Jogo> Jogos { get; set; }

        
        //public string Jogos { get; set; } = "";

        //public void CriaJogos(List<Jogo> jogos)
        //{
        //    foreach (Jogo jogo in jogos)
        //    {
        //        Jogos += Convert.ToString(jogo.Id) + ",";
        //    }
        //}
    }
}