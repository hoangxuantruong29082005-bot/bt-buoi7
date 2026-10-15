using Microsoft.EntityFrameworkCore;
using QLSV.DAL.Entities;

namespace QLSV.DAL;

public class AppDbContext : DbContext
{
    // Chuỗi kết nối tới SQL Server Express trên máy này
    public const string ConnectionString =
        @"Server=LAPTOP-6R5UJ1GK\SQLEXPRESS;Database=QuanLySinhVienCRUD3Lop;Trusted_Connection=True;TrustServerCertificate=True;";

    public DbSet<Student> Students => Set<Student>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(e =>
        {
            e.Property(s => s.FullName).IsRequired().HasMaxLength(100);
        });
    }
}
