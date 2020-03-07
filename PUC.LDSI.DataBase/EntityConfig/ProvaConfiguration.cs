using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class ProvaConfiguration : IEntityTypeConfiguration<Prova>
    {
        public void Configure(EntityTypeBuilder<Prova> builder)
        {
            throw new NotImplementedException();
        }
    }
}
