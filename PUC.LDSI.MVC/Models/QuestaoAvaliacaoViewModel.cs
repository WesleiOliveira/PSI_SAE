using System;

namespace PUC.LDSI.MVC.Models
{
    public class QuestaoAvaliacaoViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("AvaliacaoId")]
        public int AvaliacaoId { get; set; }

        [Required(ErrorMessage = "O campo Tipo � obrigat�rio.")]
        [DisplayName("Tipo")]
        public int Tipo { get; set; }

        [Required(ErrorMessage = "O campo Enunciado � obrigat�rio.")]
        [MaxLength(255, ErrorMessage = "Informe no m�ximo {0} caracteres.")]
        [DisplayName("Enunciado")]
        public string Enunciado { get; set; }

    }
}