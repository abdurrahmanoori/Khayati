﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Infrastructure.EntityConfigurations
{
    public class EmbellishmentConfiguration : IEntityTypeConfiguration<Embellishment>
    {
        public void Configure(EntityTypeBuilder<Embellishment> builder)
        {
            //builder.HasOne(e => e.EmbellishmentType)
            //    .WithMany(et => et.Embellishmentes)
            //    .HasForeignKey(e => e.EmbellishmentTypeId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
