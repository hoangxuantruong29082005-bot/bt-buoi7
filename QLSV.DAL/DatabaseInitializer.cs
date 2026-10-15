using QLSV.DAL.Entities;

namespace QLSV.DAL;

public static class DatabaseInitializer
{
    /// <summary>Tạo database + bảng nếu chưa có, thêm dữ liệu mẫu nếu bảng rỗng.</summary>
    public static void Initialize()
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated();

        if (!db.Students.Any())
        {
            db.Students.AddRange(
                new Student { FullName = "Nguyễn Văn An",   Grade = 8.5 },
                new Student { FullName = "Trần Thị Bình",   Grade = 7.0 },
                new Student { FullName = "Lê Hoàng Cường",  Grade = 4.5 },
                new Student { FullName = "Phạm Minh Dũng",  Grade = 9.0 },
                new Student { FullName = "Võ Thị Hạnh",     Grade = 3.5 },
                new Student { FullName = "Đặng Quốc Khánh", Grade = 6.5 });
            db.SaveChanges();
        }
    }
}
