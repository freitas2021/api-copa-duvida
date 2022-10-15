using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiCopaStone.Models
{ 
    public class Jogo
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Selecao")]
        public int SelecaoAId { get; set; }
        public int SelecaoBId { get; set; }
        
        public virtual Selecao Selecao{get; set;}
        
        public int GolsSelecaoA { get; set; }
        public int GolsSelecaoB { get; set; }

        public DateTime InicioJogo { get; set; }

        [NotMapped]
        public TimeSpan Tempo_atual
        {
            get
            {
                return DateTime.Now - InicioJogo;
            }
        }
    }
}
