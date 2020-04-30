using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading;

namespace PUC.LDSI.MVC.Models
{
    public class QuestaoAvaliacaoViewModel
    {
        [Key]
        public int Id { get; set; }
        public int AvaliacaoId { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        [DisplayName("Tipo")]
        public int Tipo { get; set; }

        [Required(ErrorMessage = "O campo Enunciado é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Informe no máximo {0} caracteres.")]
        [DisplayName("Enunciado")]
        public string Enunciado { get; set; }
       
        public AvaliacaoViewModel Avaliacao { get; set; }
        public List<OpcaoAvaliacaoViewModel> Opcoes { get; set; }

   
        public string Erro
        {
            get
            {
                {
                    if (Opcoes == null || Opcoes.Count < 4)
                        return "A questão deve ter pelo menos 4 (quatro) opções.";

                    if (Tipo == 1)
                    {
                        bool aux = false;

                        for (int i =0; i < Opcoes.Count; i++)
                        {
                            {
                               if (Opcoes[i].Verdadeira)
                                    aux = true;
                            }
                        }  
                        if(aux == false)
                            return "A questão deve ter pelo menos 1 (uma) opção verdadeira.";
                    }                     

                }   

                return " ";
            }
        }
    }
}

