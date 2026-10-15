using QLSV.DAL;
using QLSV.DAL.Entities;
using QLSV.DAL.Repositories;

namespace QLSV.BLL;

public class StudentService
{
    public const double DiemDat = 5.0;   // từ 5 điểm trở lên là "đạt"

    private readonly IStudentRepository _repo;

    public StudentService() : this(new StudentRepository()) { }

    public StudentService(IStudentRepository repo) => _repo = repo;

    public void InitializeDatabase() => DatabaseInitializer.Initialize();

    public List<Student> GetAll() => _repo.GetAll();

    public List<Student> GetPassed() => _repo.GetByGradeAtLeast(DiemDat);

    public void Add(string fullName, double grade)
    {
        Validate(fullName, grade);
        _repo.Add(new Student { FullName = fullName.Trim(), Grade = grade });
    }

    public void Update(int id, string fullName, double grade)
    {
        Validate(fullName, grade);
        _repo.Update(new Student { Id = id, FullName = fullName.Trim(), Grade = grade });
    }

    public void Delete(int id) => _repo.Delete(id);

    // ===== Quy tắc nghiệp vụ =====
    private static void Validate(string fullName, double grade)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new BusinessException("Vui lòng nhập họ tên!");
        if (fullName.Trim().Length > 100)
            throw new BusinessException("Họ tên tối đa 100 ký tự!");
        if (grade < 0 || grade > 10)
            throw new BusinessException("Điểm phải nằm trong khoảng 0 - 10!");
    }
}
