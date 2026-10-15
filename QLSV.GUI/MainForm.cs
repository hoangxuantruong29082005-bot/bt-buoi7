using System.Globalization;
using QLSV.BLL;
using QLSV.DAL.Entities;

namespace QLSV.GUI;

public partial class MainForm : Form
{
    // GUI chỉ gọi lớp BLL, không làm việc trực tiếp với CSDL
    private readonly StudentService _service = new();

    public MainForm()
    {
        InitializeComponent();
    }

    // ================= Hỗ trợ =================
    private static bool TryParseDiem(string text, out double diem)
        => double.TryParse(text.Trim().Replace(',', '.'), NumberStyles.Float,
                           CultureInfo.InvariantCulture, out diem);

    private void HienThi(string msg, bool loi = false)
    {
        lblTrangThai.Text = msg;
        lblTrangThai.ForeColor = loi ? Color.Red : Color.DarkGreen;
    }

    private void XoaONhap()
    {
        txtHoTen.Clear();
        txtDiem.Clear();
    }

    private void BaoLoi(Exception ex)
    {
        if (ex is BusinessException)
            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        else
            HienThi("Lỗi: " + ex.Message, true);
    }

    // ================= READ: đổ dữ liệu lên DataGridView =================
    private void HienThiDanhSach(List<Student> danhSach, string thongBao)
    {
        dgvSinhVien.DataSource = null;
        dgvSinhVien.DataSource = danhSach;

        foreach (DataGridViewColumn col in dgvSinhVien.Columns)
        {
            switch (col.Name)
            {
                case nameof(Student.Id): col.HeaderText = "Mã SV"; col.FillWeight = 40; break;
                case nameof(Student.FullName): col.HeaderText = "Họ tên"; col.FillWeight = 150; break;
                case nameof(Student.Grade): col.HeaderText = "Điểm"; col.FillWeight = 50; break;
            }
        }
        HienThi(thongBao);
    }

    private void TaiDanhSach(string? thongBao = null)
    {
        var ds = _service.GetAll();
        HienThiDanhSach(ds, thongBao ?? $"Đã tải {ds.Count} sinh viên.");
    }

    // ================= Sự kiện =================
    private void MainForm_Load(object? sender, EventArgs e)
    {
        try
        {
            _service.InitializeDatabase();   // tạo CSDL + dữ liệu mẫu lần đầu
            TaiDanhSach();
        }
        catch (Exception ex)
        {
            HienThi("Không kết nối được CSDL: " + ex.Message, true);
        }
    }

    private void dgvSinhVien_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvSinhVien.CurrentRow?.DataBoundItem is Student sv)
        {
            txtHoTen.Text = sv.FullName;
            txtDiem.Text = sv.Grade.ToString(CultureInfo.InvariantCulture);
        }
    }

    private void btnTaiLai_Click(object? sender, EventArgs e)
    {
        try { TaiDanhSach(); }
        catch (Exception ex) { BaoLoi(ex); }
    }

    // ===== CREATE =====
    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!TryParseDiem(txtDiem.Text, out double diem))
        {
            MessageBox.Show("Điểm không hợp lệ!");
            return;
        }
        try
        {
            _service.Add(txtHoTen.Text, diem);
            XoaONhap();
            TaiDanhSach("Đã thêm sinh viên mới!");
        }
        catch (Exception ex) { BaoLoi(ex); }
    }

    // ===== UPDATE =====
    private void btnSua_Click(object? sender, EventArgs e)
    {
        if (dgvSinhVien.CurrentRow?.DataBoundItem is not Student dangChon)
        {
            MessageBox.Show("Vui lòng chọn một dòng để sửa!");
            return;
        }
        if (!TryParseDiem(txtDiem.Text, out double diem))
        {
            MessageBox.Show("Điểm không hợp lệ!");
            return;
        }
        try
        {
            _service.Update(dangChon.Id, txtHoTen.Text, diem);
            TaiDanhSach("Đã cập nhật thông tin!");
        }
        catch (Exception ex) { BaoLoi(ex); }
    }

    // ===== DELETE =====
    private void btnXoa_Click(object? sender, EventArgs e)
    {
        if (dgvSinhVien.CurrentRow?.DataBoundItem is not Student dangChon)
        {
            MessageBox.Show("Vui lòng chọn một dòng để xóa!");
            return;
        }
        var ketQua = MessageBox.Show($"Bạn có chắc muốn xóa \"{dangChon.FullName}\"?",
                                     "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (ketQua != DialogResult.Yes) return;

        try
        {
            _service.Delete(dangChon.Id);
            XoaONhap();
            TaiDanhSach("Đã xóa sinh viên!");
        }
        catch (Exception ex) { BaoLoi(ex); }
    }

    // ===== LINQ to Entities: lọc sinh viên đạt (>= 5) =====
    private void btnLocDat_Click(object? sender, EventArgs e)
    {
        try
        {
            var ds = _service.GetPassed();
            HienThiDanhSach(ds, $"Tìm thấy {ds.Count} sinh viên đạt (>= {StudentService.DiemDat}).");
        }
        catch (Exception ex) { BaoLoi(ex); }
    }
}
