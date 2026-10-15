using Microsoft.EntityFrameworkCore;
using QLSV.DAL.Entities;

namespace QLSV.DAL.Repositories;

public class StudentRepository : IStudentRepository
{
    // READ: lấy danh sách sinh viên từ CSDL
    public List<Student> GetAll()
    {
        using var db = new AppDbContext();
        return db.Students.AsNoTracking().OrderBy(s => s.Id).ToList();
    }

    // READ (LINQ to Entities): sinh viên có điểm >= minGrade, điểm cao xếp trước
    public List<Student> GetByGradeAtLeast(double minGrade)
    {
        using var db = new AppDbContext();
        return db.Students.AsNoTracking()
                 .Where(s => s.Grade >= minGrade)
                 .OrderByDescending(s => s.Grade)
                 .ToList();
    }

    // CREATE
    public void Add(Student student)
    {
        using var db = new AppDbContext();
        db.Students.Add(student);
        db.SaveChanges();
    }

    // UPDATE
    public void Update(Student student)
    {
        using var db = new AppDbContext();
        var entity = db.Students.Find(student.Id)
                     ?? throw new KeyNotFoundException("Không tìm thấy sinh viên trong CSDL.");
        entity.FullName = student.FullName;
        entity.Grade = student.Grade;
        db.SaveChanges();
    }

    // DELETE
    public void Delete(int id)
    {
        using var db = new AppDbContext();
        var entity = db.Students.Find(id);
        if (entity == null) return;
        db.Students.Remove(entity);
        db.SaveChanges();
    }
}
