using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Avaliacao : Entity
    {
        public Avaliacao() { }
        
        public int Id { get; set; } 
        public DateTime DataCriacao { get; set; }
        public int ProfessorId { get; set; }
        public string Disciplina { get; set; }
        public string Materia { get; set; }
        public string Descricao { get; set; }

        public Professor Professor { get; set; }
        public List<Quest> Questoes { get; set; }

        public override string [] Validate()
        {
            throw new NotImplementedException();
        }
    }

}
