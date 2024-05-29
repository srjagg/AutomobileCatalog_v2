using AutomobileCatalog.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomobileCatalog.Persistense.ModelsConfiguration
{
    public class CarsConfiguration : IEntityTypeConfiguration<Cars>
    {
        public void Configure(EntityTypeBuilder<Cars> builder)
        {
            builder.ToTable(nameof(Cars));
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Modelo).IsRequired().HasMaxLength(30);
            builder.Property(b => b.Descripción).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Precio).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(b => b.Kilometraje).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(b => b.Kilometraje).IsRequired().HasMaxLength(30);
        }
    }
}
