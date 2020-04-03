using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class QuestaoAvaliacaoConfiguration : IEntityTypeConfiguration<QuestaoAvaliacao>
    {
        public void Configure(EntityTypeBuilder<QuestaoAvaliacao> builder)
        {
            builder.Property(x => x.Tipo).IsRequired().HasColumnType("int");
            builder.Property(x => x.Enunciado).IsRequired().HasColumnType("varchar(100)");
            builder.HasOne(x => x.Avaliacao).WithMany(x => x.Questoes).HasForeignKey(x => x.AvaliacaoId);
        }
    }
}
