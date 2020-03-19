using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSqlServerIdentityColumn().IsRequired();
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.TurmaId).IsRequired().HasColumnType("int");
            builder.Property(x => x.DataCriacao).IsRequired().HasColumnType("date");
            new AlunoConfiguration();
        }
    }
}