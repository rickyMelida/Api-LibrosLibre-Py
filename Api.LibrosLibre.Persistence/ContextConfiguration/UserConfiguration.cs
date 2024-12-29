namespace Api.LibrosLibre.Persistence {
    using Api.LibrosLibre.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user", "public");

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Email).HasColumnName("email").IsRequired();
            builder.Property(x => x.Phone).HasColumnName("phone_number");

        }
    }

}