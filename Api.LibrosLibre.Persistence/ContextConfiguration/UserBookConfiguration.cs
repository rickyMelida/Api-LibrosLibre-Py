namespace Api.LibrosLibre.Persistence {
    using Api.LibrosLibre.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserBookConfiguration : IEntityTypeConfiguration<UserBook>
    {
        public void Configure(EntityTypeBuilder<UserBook> builder)
        {
            builder.ToTable("users_book", "public");

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.User).HasColumnName("user").IsRequired();
            builder.Property(x => x.Book).HasColumnName("book").IsRequired();
        }
    }

}