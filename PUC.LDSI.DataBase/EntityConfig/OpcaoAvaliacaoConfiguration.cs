using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class OpcaoAvaliacaoConfiguration : IEntityTypeConfiguration<OpcaoAvaliacao>
    {
        public void Configure(EntityTypeBuilder<OpcaoAvaliacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.DataCriacao).IsRequired().HasColumnType("datetime");

            builder.Property(x => x.Descricao).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Descricao).HasColumnType("varchar(100)"); // Tipo de dados e precisão

            builder.Property(x => x.Verdadeira).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Verdadeira).HasColumnType("bool"); // Tipo de dados e precisão

            builder.HasOne(x => x.Questao).WithMany(x => x.OpcoesAvaliacao).HasForeignKey(x => x.QuestaoId); // FK
            new OpcaoAvaliacaoConfiguration();
        }
    }
}
