using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class QuestaoProvaConfiguration : IEntityTypeConfiguration<QuestaoProva>
    {
        public void Configure(EntityTypeBuilder<QuestaoProva> builder)
        {
            builder.Property(x => x.Nota).IsRequired().HasColumnType("decimal");
            builder.HasOne(x => x.QuestaoAvaliacao).WithMany(x => x.QuestaoProvas).HasForeignKey(x => x.QuestaoId);
            builder.HasOne(x => x.Prova).WithMany(x => x.QuestaoProvas).HasForeignKey(x => x.ProvaId);
        }
    }
}
