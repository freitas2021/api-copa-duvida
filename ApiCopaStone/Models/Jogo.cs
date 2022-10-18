using System;
using System.ComponentModel.DataAnnotations.Schema;



namespace ApiCopaStone.Models
{
    public class Jogo
    {
        public int JogoId { get; set; }
        public Selecao Selecao { get; set; }
        public int SelecaoAId { get; set; }
        public int SelecaoBId { get; set; }
        public int GolsSelecaoA { get; set; }
        public int GolsSelecaoB { get; set; }
        public int FaseCopaId { get; set; } 
        public FaseCopa FaseCopa { get; set; }  
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




