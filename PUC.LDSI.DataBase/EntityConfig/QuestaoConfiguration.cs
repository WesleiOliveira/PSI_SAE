using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class QuestaoConfiguration : IEntityTypeConfiguration<Questao>
    {
        public void Configure(EntityTypeBuilder<Questao> builder)
        {
            builder.Property(x => x.Tipo).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Tipo).HasColumnType("int"); // Tipo de dados e precisão

            builder.Property(x => x.Enunciado).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Enunciado).HasColumnType("varchar(500)"); // Tipo de dados e precisão

            builder.HasOne(x => x.Avaliacao).WithMany(x => x.Questoes).HasForeignKey(x => x.AvaliacaoId); // FK
            new EntityConfig(); // Aplica as configurações dos atributos
        }
    }
}
