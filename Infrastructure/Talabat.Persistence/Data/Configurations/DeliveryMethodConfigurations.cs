using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.DomainLayer.Models.OrderModule;

namespace Talabat.Persistence.Data.Configurations
{
    class DeliveryMethodConfigurations : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.ToTable("DeliveryMethods");
            builder.Property(D => D.Price)
                .HasColumnType("decimal(18,2)");
            builder.Property(D => D.ShortName)
                .HasColumnType("varchar(50)");
            builder.Property(D => D.Description)
                .HasColumnType("varchar(200)");
            builder.Property(D => D.DeliveryTime)
                .HasColumnType("varchar(50)");

        }
    }
}
