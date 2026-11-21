using Microsoft.EntityFrameworkCore;
using TechTest.Models;

namespace TechTest.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<OtpSetting> OtpSettings => Set<OtpSetting>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entity = modelBuilder.Entity<OtpSetting>();
        entity.ToTable("OtpSettings");
        entity.HasKey(e => e.Id);
        entity.HasIndex(e => e.ActionCode).IsUnique();
        entity.Property(e => e.ActionCode).HasMaxLength(50).IsRequired();
        entity.Property(e => e.ActionName).HasMaxLength(100).IsRequired();

        entity.HasData(
            new OtpSetting { Id = 1, ActionCode = "WITHDRAWAL", ActionName = "Withdrawal", IsEmailEnabled = false, IsWhatsappEnabled = false, UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new OtpSetting { Id = 2, ActionCode = "FORGOT_PASSWORD", ActionName = "Forgot Password", IsEmailEnabled = false, IsWhatsappEnabled = false, UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new OtpSetting { Id = 3, ActionCode = "RESET_PASSWORD", ActionName = "Reset Password", IsEmailEnabled = false, IsWhatsappEnabled = false, UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}
