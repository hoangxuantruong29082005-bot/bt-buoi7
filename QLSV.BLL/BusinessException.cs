namespace QLSV.BLL;

/// <summary>Lỗi nghiệp vụ (dữ liệu nhập không hợp lệ...) để GUI hiển thị cho người dùng.</summary>
public class BusinessException : Exception
{
    public BusinessException(string message) : base(message) { }
}
