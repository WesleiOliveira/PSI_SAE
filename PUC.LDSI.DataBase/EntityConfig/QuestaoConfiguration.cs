using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class QuestaoConfiguration : IEntityTypeConfiguration<Questao>
    {
        public void Configure(EntityTypeBuilder<Questao> builder)
        {
            builder.Property(x => x.Tipo).IsRequired().HasColumnType("int");
            builder.Property(x => x.Enunciado).IsRequired().HasColumnType("varchar(100)");
            builder.HasOne(x => x.Avaliacao).WithMany(x => x.Questaos).HasForeignKey(x => x.AvaliacaoId);
        }
    }
}
