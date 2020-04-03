using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Publicacao : Entity
    {
        public int AvaliacaoId { get; set; }
        public int TurmaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int ValorProva { get; set; }
        public Avaliacao Avaliacao { get; set; } 
        public Turma Turma { get; set; }

        public override string[] Validate()
        {
            var erros = new List<string>();
            if (AvaliacaoId == 0)
                erros.Add("A Avaliação deve ser informada");
            if (TurmaId == 0)
                erros.Add("A Turma deve ser informado");
            if (string.IsNullOrEmpty(DataInicio.ToString()))
                erros.Add("A Data de inicio precisa ser informado");
            if (string.IsNullOrEmpty(DataFim.ToString()))
                erros.Add("A Data Fim precisa ser informado");
            if (ValorProva  <= 0 )
                erros.Add("A Valor da prova precisa ser informado");
            return erros.ToArray();
        }

    }
}
