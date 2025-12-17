using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vigere.domain.Entities;

namespace vigere.infra.Database.EntityMaps;

internal class UserEntityMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id");

        builder.Property(u => u.Identifier)
            .IsRequired()
            .HasColumnName("identifier");
        builder.HasIndex(u => u.Identifier).IsUnique();

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("email");
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnName("password");

        builder.Property(u => u.Role)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("role");

        builder.Property(u => u.ControlDate)
             .HasColumnName("control_date")
             .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
