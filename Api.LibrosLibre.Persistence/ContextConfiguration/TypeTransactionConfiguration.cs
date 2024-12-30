using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.LibrosLibre.Persistence
{
    public class TypeTransactionConfiguration : IEntityTypeConfiguration<TypeTransaction>
    {
        public void Configure(EntityTypeBuilder<TypeTransaction> builder)
        {
            builder.ToTable("type_transaction", "public");

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Description).HasColumnName("description");
        }
    }
}