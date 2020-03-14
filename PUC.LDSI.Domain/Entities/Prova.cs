using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Prova : Entity
    {
        public Prova() { }
        public int AvaliacaoId { get; set; }
        public int AlunoId { get; set; }
        public DateTime DataProva { get; set; }
        public Decimal NotaObtida { get; set; }

        public override string[] Validate()
        {

            var erros = new List<string>();

            if (AvaliacaoId == 0)
                erros.Add("A avaliação precisa ser informada!");

            if (AlunoId == 0)
                erros.Add("O aluno precisa ser informado!");

            if (DataProva == DateTime.MinValue())
                erros.Add("A data precisa ser informada!");
            return erros.ToArray();
        }
    }
}
