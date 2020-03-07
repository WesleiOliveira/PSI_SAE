using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Aluno : Entity
    {
        public Aluno() { }
        public override string [] Validate()
        {
            
            var erros = new List<string>();

            if(TurmaId == 0)
                erros.Add("A turma precisa ser informada!");
                
            if (string.IsnNullOrEmpty(Nome))
                erros.Add("O nome precisa ser informado!");
            return erros.ToArray();
        }
       
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public varchar Nome { get; set; }
        public int Turma { get; set; }
        

    }
}
