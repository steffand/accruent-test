using Accruent.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accruent.Data.Configuration;

public class MovementConfiguration : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> builder)
    {
        builder.ToTable("MOVEMENT");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").HasColumnType("UNIQUEIDENTIFIER");
        builder.Property(x => x.ProductId).HasColumnName("PRODUCT_ID").HasColumnType("UNIQUEIDENTIFIER").IsRequired();
        builder.Property(x => x.Type).HasColumnName("TYPE").HasColumnType("VARCHAR").HasMaxLength(10).IsRequired();
        builder.Property(x => x.CreatedOn).HasColumnName("CREATED_ON").HasColumnType("DATE").IsRequired();
        builder.Property(x => x.Quantity).HasColumnName("QUANTITY").HasColumnType("INTEGER").IsRequired();
        builder.HasOne(x => x.Product).WithMany(x => x.Movements).HasForeignKey(x => x.ProductId);
    }
}
