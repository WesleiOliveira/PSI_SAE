using System;

namespace PUC.LDSI.MVC.Models
{
    public class QuestaoAvaliacaoViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("AvaliacaoId")]
        public int AvaliacaoId { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        [DisplayName("Tipo")]
        public int Tipo { get; set; }

        [Required(ErrorMessage = "O campo Enunciado é obrigatório.")]
        [MaxLength(255, ErrorMessage = "Informe no máximo {0} caracteres.")]
        [DisplayName("Enunciado")]
        public string Enunciado { get; set; }

    }
}