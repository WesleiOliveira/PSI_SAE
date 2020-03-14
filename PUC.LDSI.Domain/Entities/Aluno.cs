﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Aluno : Entity
    {
        public Aluno() { }
       
       
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Nome { get; set; }
        public int Turma { get; set; }
        
        public Turma Turma { get; set; }
        public List<Prova> Provas { get; set; }

         public override string [] Validate()
        {
            throw new NotImplementedException();
        }
        
    }
}
