using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class AvaliacaoConfiguration : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.Property(x => x.Disciplina).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Disciplina).HasColumnType("varchar(100)"); // Tipo de dados e precisão

            builder.Property(x => x.Materia).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Materia).HasColumnType("varchar(100)"); // Tipo de dados e precisão

            builder.Property(x => x.Descricao).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Descricao).HasColumnType("varchar(100)"); // Tipo de dados e precisão

            builder.HasOne(x => x.Professor).WithMany(x => x.Avaliacoes).HasForeignKey(x => x.ProfessorId); // FK
            new EntityConfig(); // Aplica as configurações dos atributos
        }
    }
}
