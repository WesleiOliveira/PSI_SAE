using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel;


namespace PUC.LDSI.MVC.Models
{
    public class PublicacaoViewModel
    {
        public int Id { get; set; }
        [DisplayName("Fim")]
        [Required(ErrorMessage = "O campo fim é obrigatório.")]
        public DateTime DataFim { get; set; }
        [DisplayName("Valor da prova")]
        [Required(ErrorMessage = "O campo valor da prova é obrigatório.")]
        public int ValorProva { get; set; }
        [DisplayName("Avaliação")]
        public AvaliacaoViewModel Avaliacao;
        [DisplayName("Turma")]
        public int TurmaId { get; set; }
        [DisplayName("Avaliação")]
        public TurmaViewModel Turma;
        [DisplayName("Publicado Em")]
        public DateTime DataCriacao { get; set; }
        [DisplayName("Início")]
        [Required(ErrorMessage = "O campo inicio é obrigatório.")]
        public DateTime DataInicio { get; set; }
        [DisplayName("Avaliação")]
        public int AvaliacaoId { get; set; }
    }
}