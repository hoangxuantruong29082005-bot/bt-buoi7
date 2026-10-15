using QLSV.DAL.Entities;

namespace QLSV.DAL.Repositories;

public interface IStudentRepository
{
    List<Student> GetAll();
    List<Student> GetByGradeAtLeast(double minGrade);
    void Add(Student student);
    void Update(Student student);
    void Delete(int id);
}
