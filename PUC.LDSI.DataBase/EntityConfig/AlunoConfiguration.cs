using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.Property(x => x.Nome).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Nome).HasColumnType("varchar(100)"); // Tipo de dados e precisão
            builder.HasOne(x => x.Turma).WithMany(x => x.Alunos).HasForeignKey(x => x.TurmaId); // FK
            new EntityConfig(); // Aplica as configurações dos atributos
        }
    }
}
