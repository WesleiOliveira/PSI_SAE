using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class OpcaoProvaConfiguration : IEntityTypeConfiguration<OpcaoProva>
    {
        public void Configure(EntityTypeBuilder<OpcaoProva> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.DataCriacao).IsRequired().HasColumnType("datetime");

            builder.Property(x => x.Resposta).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Resposta).HasColumnType("bool"); // Tipo de dados e precisão

            builder.HasOne(x => x.OpcaoAvaliacao).WithMany(x => x.OpcoesProva).HasForeignKey(x => x.OpcaoAvaliacaoId); // FK
            builder.HasOne(x => x.QuestaoProva).WithMany(x => x.OpcoesProva).HasForeignKey(x => x.QuestaoProvaId); // FK
            new OpcaoProvaConfiguration(); 
        }
    }
}

