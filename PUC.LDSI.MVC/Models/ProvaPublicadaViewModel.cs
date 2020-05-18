using Microsoft.AspNetCore.Identity;
using PUC.LDSI.Identity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PUC.LDSI.MVC.Models
{
    public class ProvaPublicadaViewModel
    {
        //private readonly UserManager<Usuario> _userManager;
        //private readonly SignInManager<Usuario> _signInManager;

        //public ProvaPublicadaViewModel(
        //    UserManager<Usuario> userManager,
        //    SignInManager<Usuario> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}

        public int AvaliacaoId { get; set; }

        [DisplayName("Publicado Em")]
        public DateTime DataCriacao { get; set; }

        [DisplayName("Início")]
        public DateTime DataInicio { get; set; }

        [DisplayName("Fim")]
        public DateTime DataFim { get; set; }

        [DisplayName("Valor da Prova")]
        public int ValorProva { get; set; }

        [DisplayName("Nota")]
        public decimal NotaObtida { get; set; }

        [DisplayName("Disciplina")]
        public decimal Disciplina { get; set; }

        [DisplayName("Matéria")]
        public decimal Materia { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Situação")]
        public string Status
        {
            get
            {
                return Status;
            }
            set
            {
                this.ConverterData();
            }
        }

        private string ConverterData()
        {
            if (DataInicio > DateTime.Now)
            {
                return "Agendada";
            }
            else if (DateTime.Now < DataFim && DateTime.Now > DataInicio)
            {
                return "Disponível ";
            }
            else
            {
                return "Perdida ";
            }
            //else if (_signInManager.IsSignedIn(System.Security.Claims.ClaimsPrincipal.Current))
            //{
            //    return "Realizada ";    
        }
    }
}
