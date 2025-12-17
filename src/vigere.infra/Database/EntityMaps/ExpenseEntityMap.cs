using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vigere.domain.Entities;

namespace vigere.infra.Database.EntityMaps;

internal class ExpenseEntityMap : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("expenses");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("title");

        builder.Property(e => e.Description)
            .HasMaxLength(1000)
            .HasColumnName("description");

        builder.Property(e => e.Amount)
            .IsRequired()
            .HasPrecision(18, 2)
            .HasColumnName("amount");

        builder.Property(e => e.Date)
            .IsRequired()
            .HasColumnName("date");

        builder.Property(e => e.ControlDate)
            .HasColumnName("control_date");

        builder.Property(e => e.UserId)
            .HasColumnName("user_id");

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
