namespace QLSV.GUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblDiem = new Label();
            txtDiem = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnTaiLai = new Button();
            btnLocDat = new Button();
            dgvSinhVien = new DataGridView();
            lblTrangThai = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(12, 12);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(676, 40);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÝ SINH VIÊN - EF CORE (CRUD ĐẦY ĐỦ)";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(20, 68);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(48, 15);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(80, 65);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 23);
            txtHoTen.TabIndex = 2;
            // 
            // lblDiem
            // 
            lblDiem.AutoSize = true;
            lblDiem.Location = new Point(410, 68);
            lblDiem.Name = "lblDiem";
            lblDiem.Size = new Size(36, 15);
            lblDiem.TabIndex = 3;
            lblDiem.Text = "Điểm:";
            // 
            // txtDiem
            // 
            txtDiem.Location = new Point(455, 65);
            txtDiem.Name = "txtDiem";
            txtDiem.Size = new Size(90, 23);
            txtDiem.TabIndex = 4;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(20, 102);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 34);
            btnThem.TabIndex = 5;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(130, 102);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 34);
            btnSua.TabIndex = 6;
            btnSua.Text = "✏ Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(240, 102);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 34);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "🗑 Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Location = new Point(350, 102);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(150, 34);
            btnTaiLai.TabIndex = 8;
            btnTaiLai.Text = "🔄 Tải lại danh sách";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // btnLocDat
            // 
            btnLocDat.Location = new Point(510, 102);
            btnLocDat.Name = "btnLocDat";
            btnLocDat.Size = new Size(170, 34);
            btnLocDat.TabIndex = 9;
            btnLocDat.Text = "Lọc SV đạt (LINQ)";
            btnLocDat.UseVisualStyleBackColor = true;
            btnLocDat.Click += btnLocDat_Click;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.BackgroundColor = Color.White;
            dgvSinhVien.Location = new Point(20, 150);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(660, 250);
            dgvSinhVien.TabIndex = 10;
            dgvSinhVien.SelectionChanged += dgvSinhVien_SelectionChanged;
            // 
            // lblTrangThai
            // 
            lblTrangThai.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTrangThai.Location = new Point(20, 415);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(660, 20);
            lblTrangThai.TabIndex = 11;
            lblTrangThai.Text = "Sẵn sàng.";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 450);
            Controls.Add(lblTrangThai);
            Controls.Add(dgvSinhVien);
            Controls.Add(btnLocDat);
            Controls.Add(btnTaiLai);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtDiem);
            Controls.Add(lblDiem);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Controls.Add(lblTieuDe);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(716, 489);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sinh viên - EF Core CRUD";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblDiem;
        private TextBox txtDiem;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnTaiLai;
        private Button btnLocDat;
        private DataGridView dgvSinhVien;
        private Label lblTrangThai;
    }
}
