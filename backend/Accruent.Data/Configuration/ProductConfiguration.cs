using Accruent.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accruent.Data.Configuration;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("PRODUCT");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").HasColumnType("UNIQUEIDENTIFIER");
        builder.Property(x => x.Code).HasColumnName("CODE").HasColumnType("VARCHAR").IsRequired().HasMaxLength(20);
        builder.Property(x => x.Name).HasColumnName("NAME").HasColumnType("VARCHAR").IsRequired().HasMaxLength(255);
        builder.HasIndex(x => x.Code).IsUnique();
    }
}
