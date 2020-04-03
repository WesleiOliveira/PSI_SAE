    using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Prova : Entity
    {
        public int AvaliacaoId { get; set; }
        public int AlunoId { get; set; }
        public DateTime DataProva { get; set; }
        public Decimal NotaObtida { get; set; }
        public Avaliacao Avaliacao { get; set; }
        public Aluno Aluno { get; set; }
        public List<QuestaoProva> QuestoesProva { get; set; }


        public override string[] Validate()
        {
            var erros = new List<string>();
            if (AvaliacaoId == 0)
                erros.Add("A Avaliação deve ser informada");
            if (AlunoId == 0)
                erros.Add("O Aluno deve ser informado");
            DateTime resultado = DateTime.MinValue;
            if (string.IsNullOrEmpty(DataProva.ToString()))
                erros.Add("A Data da Prova precisa ser informado");
            return erros.ToArray();
        }
    }
}
