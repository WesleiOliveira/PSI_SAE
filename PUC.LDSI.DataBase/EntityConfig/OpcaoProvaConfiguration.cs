using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class OpcaoProvaConfiguration : IEntityTypeConfiguration<OpcaoProva>
    {
        public void Configure(EntityTypeBuilder<OpcaoProva> builder)
        {
            builder.Property(x => x.Resposta).IsRequired().HasColumnType("bool");
            builder.HasOne(x => x.QuestaoProva).WithMany(x => x.opcaoProvas).HasForeignKey(x => x.QuestaoProvaId);
            builder.HasOne(x => x.opcaoAvaliacao).WithMany(x => x.opcaoProvas).HasForeignKey(x => x.OpcaoAvaliacaoId);


        }
    }
}

