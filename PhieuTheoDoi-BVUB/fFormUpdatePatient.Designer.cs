namespace BVUB_PhieuTheoDoi
{
    partial class fFormUpdatePatient
    {
        // Khai báo components (KHẮC PHỤC LỖI CS1061/CS0103)
        private System.ComponentModel.IContainer components = null;

        // Khai báo các Controls (Giữ nguyên tên theo yêu cầu)
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        // Thông tin Hành chính
        private System.Windows.Forms.Label lblMaBenhNhanValue;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtTuoi;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.TextBox txtGiuong;
        private System.Windows.Forms.TextBox txtChanDoan;
        private System.Windows.Forms.Label labelMaBN;
        private System.Windows.Forms.Label labelHoTen;
        private System.Windows.Forms.Label labelTuoi;
        private System.Windows.Forms.Label labelPhong;
        private System.Windows.Forms.Label labelGiuong;
        private System.Windows.Forms.Label labelChanDoan;
        private System.Windows.Forms.Label labelTienSu;
        private System.Windows.Forms.CheckBox chkDiUngCo;
        private System.Windows.Forms.CheckBox chkDiUngKhong;
        private System.Windows.Forms.TextBox txtTienSuDiUng;

        // Thông tin Theo dõi Ban đầu (Tab Control)
        private System.Windows.Forms.TabControl tabControlMonitoring;
        private System.Windows.Forms.TabPage tabToanTrang;
        private System.Windows.Forms.TabPage tabSinhTon;
        private System.Windows.Forms.TabPage tabChanDoanCanThiep;
        private System.Windows.Forms.TabPage tabCSCT;
        private System.Windows.Forms.TabPage tabTuanHoan;
        private System.Windows.Forms.TabPage tabHoHap;
        private System.Windows.Forms.TabPage tabTieuHoa;
        private System.Windows.Forms.TabPage tabDinhDuong;
        private System.Windows.Forms.TabPage tabTietNieu;
        private System.Windows.Forms.TabPage tabThanKinh;
        private System.Windows.Forms.TabPage tabCoXuongKhop;
        private System.Windows.Forms.TabPage tabNhanDinhKhac;

        // Controls bên trong Tab Toàn Trạng
        private System.Windows.Forms.TextBox txtTriGiac;
        private System.Windows.Forms.TextBox txtDaNiem;
        private System.Windows.Forms.TextBox txtPhu;
        private System.Windows.Forms.Label labelTriGiac;
        private System.Windows.Forms.Label labelDaNiem;
        private System.Windows.Forms.Label labelPhu;

        // Controls bên trong Tab Sinh Tồn
        private System.Windows.Forms.TextBox txtMach;
        private System.Windows.Forms.TextBox txtHuyetAp;
        private System.Windows.Forms.TextBox txtNhietDo;
        private System.Windows.Forms.TextBox txtSpO2;
        private System.Windows.Forms.TextBox txtTanSoTho; // Bổ sung Tần số thở
        private System.Windows.Forms.Label labelMach;
        private System.Windows.Forms.Label labelHuyetAp;
        private System.Windows.Forms.Label labelNhietDo;
        private System.Windows.Forms.Label labelSpO2;
        private System.Windows.Forms.Label labelTanSoTho; // Bổ sung Label

        // Controls bên trong Tab Chẩn đoán/Can thiệp
        private System.Windows.Forms.RichTextBox rtbChanDoanDD;
        private System.Windows.Forms.RichTextBox rtbCanThiepDD;
        private System.Windows.Forms.Label labelChanDoanDD;
        private System.Windows.Forms.Label labelCanThiepDD;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            // Cần System.Drawing nếu file này thiếu
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            System.Drawing.Size size = new System.Drawing.Size(0, 0);

            // 1. KHỞI TẠO CÁC OBJECTS
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // Hành chính
            this.lblMaBenhNhanValue = new System.Windows.Forms.Label();
            this.labelMaBN = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.labelHoTen = new System.Windows.Forms.Label();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.labelTuoi = new System.Windows.Forms.Label();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.labelPhong = new System.Windows.Forms.Label();
            this.txtGiuong = new System.Windows.Forms.TextBox();
            this.labelGiuong = new System.Windows.Forms.Label();
            this.txtChanDoan = new System.Windows.Forms.TextBox();
            this.labelChanDoan = new System.Windows.Forms.Label();
            this.labelTienSu = new System.Windows.Forms.Label();
            this.chkDiUngCo = new System.Windows.Forms.CheckBox();
            this.chkDiUngKhong = new System.Windows.Forms.CheckBox();
            this.txtTienSuDiUng = new System.Windows.Forms.TextBox();

            // Theo dõi Ban đầu (Tab Control)
            this.tabControlMonitoring = new System.Windows.Forms.TabControl();

            // Khởi tạo tất cả các Tab Page
            this.tabToanTrang = new System.Windows.Forms.TabPage();
            this.tabSinhTon = new System.Windows.Forms.TabPage();
            this.tabCSCT = new System.Windows.Forms.TabPage();
            this.tabTuanHoan = new System.Windows.Forms.TabPage();
            this.tabHoHap = new System.Windows.Forms.TabPage();
            this.tabTieuHoa = new System.Windows.Forms.TabPage();
            this.tabDinhDuong = new System.Windows.Forms.TabPage();
            this.tabTietNieu = new System.Windows.Forms.TabPage();
            this.tabThanKinh = new System.Windows.Forms.TabPage();
            this.tabCoXuongKhop = new System.Windows.Forms.TabPage();
            this.tabNhanDinhKhac = new System.Windows.Forms.TabPage();
            this.tabChanDoanCanThiep = new System.Windows.Forms.TabPage();

            // Controls bên trong tabToanTrang
            this.txtTriGiac = new System.Windows.Forms.TextBox();
            this.labelTriGiac = new System.Windows.Forms.Label();
            this.txtDaNiem = new System.Windows.Forms.TextBox();
            this.labelDaNiem = new System.Windows.Forms.Label();
            this.txtPhu = new System.Windows.Forms.TextBox();
            this.labelPhu = new System.Windows.Forms.Label();

            // Controls bên trong tabSinhTon
            this.txtMach = new System.Windows.Forms.TextBox();
            this.labelMach = new System.Windows.Forms.Label();
            this.txtHuyetAp = new System.Windows.Forms.TextBox();
            this.labelHuyetAp = new System.Windows.Forms.Label();
            this.txtNhietDo = new System.Windows.Forms.TextBox();
            this.labelNhietDo = new System.Windows.Forms.Label();
            this.txtSpO2 = new System.Windows.Forms.TextBox();
            this.labelSpO2 = new System.Windows.Forms.Label();
            this.txtTanSoTho = new System.Windows.Forms.TextBox();
            this.labelTanSoTho = new System.Windows.Forms.Label();

            // Controls bên trong tabChanDoanCanThiep
            this.rtbChanDoanDD = new System.Windows.Forms.RichTextBox();
            this.labelChanDoanDD = new System.Windows.Forms.Label();
            this.rtbCanThiepDD = new System.Windows.Forms.RichTextBox();
            this.labelCanThiepDD = new System.Windows.Forms.Label();

            // Bắt đầu gộp GroupBox
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControlMonitoring.SuspendLayout();
            this.tabToanTrang.SuspendLayout();
            this.tabSinhTon.SuspendLayout();
            this.tabChanDoanCanThiep.SuspendLayout();
            this.SuspendLayout();

            // 2. THIẾT LẬP THUỘC TÍNH FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 750);
            this.Text = "Cập nhật Phiếu Theo Dõi";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;

            // Thêm GroupBox vào Form
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);

            // 3. THIẾT LẬP GROUPBOX 1 (Hành chính)
            this.groupBox1.Controls.Add(this.txtTienSuDiUng);
            this.groupBox1.Controls.Add(this.chkDiUngCo);
            this.groupBox1.Controls.Add(this.chkDiUngKhong);
            this.groupBox1.Controls.Add(this.labelTienSu);
            this.groupBox1.Controls.Add(this.txtChanDoan);
            this.groupBox1.Controls.Add(this.labelChanDoan);
            this.groupBox1.Controls.Add(this.txtGiuong);
            this.groupBox1.Controls.Add(this.labelGiuong);
            this.groupBox1.Controls.Add(this.txtPhong);
            this.groupBox1.Controls.Add(this.labelPhong);
            this.groupBox1.Controls.Add(this.txtTuoi);
            this.groupBox1.Controls.Add(this.labelTuoi);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.labelHoTen);
            this.groupBox1.Controls.Add(this.lblMaBenhNhanValue);
            this.groupBox1.Controls.Add(this.labelMaBN);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(926, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Thông tin Hành chính";

            // Định vị các controls trong GroupBox1
            // Ma Benh Nhan (Dùng Label)
            this.labelMaBN.AutoSize = true;
            this.labelMaBN.Location = new System.Drawing.Point(20, 30);
            this.labelMaBN.Text = "Mã BN:";
            this.lblMaBenhNhanValue.Location = new System.Drawing.Point(130, 27);
            this.lblMaBenhNhanValue.Name = "lblMaBenhNhanValue";
            this.lblMaBenhNhanValue.Size = new System.Drawing.Size(120, 22);
            this.lblMaBenhNhanValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaBenhNhanValue.Text = "BNxxxx";
            this.lblMaBenhNhanValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Ho Ten
            this.labelHoTen.AutoSize = true;
            this.labelHoTen.Location = new System.Drawing.Point(300, 30);
            this.labelHoTen.Text = "Họ Tên:";
            this.txtHoTen.Location = new System.Drawing.Point(410, 27);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 22);

            // Tuoi
            this.labelTuoi.AutoSize = true;
            this.labelTuoi.Location = new System.Drawing.Point(650, 30);
            this.labelTuoi.Text = "Tuổi:";
            this.txtTuoi.Location = new System.Drawing.Point(750, 27);
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.Size = new System.Drawing.Size(100, 22);

            // Phong
            this.labelPhong.AutoSize = true;
            this.labelPhong.Location = new System.Drawing.Point(20, 70);
            this.labelPhong.Text = "Phòng:";
            this.txtPhong.Location = new System.Drawing.Point(130, 67);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(120, 22);

            // Giuong
            this.labelGiuong.AutoSize = true;
            this.labelGiuong.Location = new System.Drawing.Point(300, 70);
            this.labelGiuong.Text = "Giường:";
            this.txtGiuong.Location = new System.Drawing.Point(410, 67);
            this.txtGiuong.Name = "txtGiuong";
            this.txtGiuong.Size = new System.Drawing.Size(100, 22);

            // Chan Doan
            this.labelChanDoan.AutoSize = true;
            this.labelChanDoan.Location = new System.Drawing.Point(20, 110);
            this.labelChanDoan.Text = "Chẩn đoán:";
            this.txtChanDoan.Location = new System.Drawing.Point(130, 107);
            this.txtChanDoan.Name = "txtChanDoan";
            this.txtChanDoan.Size = new System.Drawing.Size(780, 22);

            // Tien Su Di Ung (Checkbox + TextBox)
            this.labelTienSu.AutoSize = true;
            this.labelTienSu.Location = new System.Drawing.Point(20, 150);
            this.labelTienSu.Text = "Tiền sử Dị ứng:";

            this.chkDiUngCo.AutoSize = true;
            this.chkDiUngCo.Location = new System.Drawing.Point(130, 150);
            this.chkDiUngCo.Name = "chkDiUngCo";
            this.chkDiUngCo.Text = "Có";
            this.chkDiUngCo.Size = new System.Drawing.Size(46, 20);
            this.chkDiUngCo.UseVisualStyleBackColor = true;
            // Sự kiện này sẽ được gán trong fFormUpdatePatient.cs

            this.chkDiUngKhong.AutoSize = true;
            this.chkDiUngKhong.Location = new System.Drawing.Point(200, 150);
            this.chkDiUngKhong.Name = "chkDiUngKhong";
            this.chkDiUngKhong.Text = "Không";
            this.chkDiUngKhong.Checked = true;
            this.chkDiUngKhong.Size = new System.Drawing.Size(71, 20);
            this.chkDiUngKhong.UseVisualStyleBackColor = true;
            // Sự kiện này sẽ được gán trong fFormUpdatePatient.cs

            this.txtTienSuDiUng.Location = new System.Drawing.Point(280, 147);
            this.txtTienSuDiUng.Name = "txtTienSuDiUng";
            this.txtTienSuDiUng.Size = new System.Drawing.Size(630, 22);
            this.txtTienSuDiUng.Enabled = false;


            // 4. THIẾT LẬP GROUPBOX 2 (Theo dõi Ban đầu)
            this.groupBox2.Controls.Add(this.tabControlMonitoring);
            this.groupBox2.Location = new System.Drawing.Point(12, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(926, 450);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Thông tin Theo dõi Ban đầu";

            // tabControlMonitoring
            this.tabControlMonitoring.Controls.Add(this.tabToanTrang);
            this.tabControlMonitoring.Controls.Add(this.tabSinhTon);
            this.tabControlMonitoring.Controls.Add(this.tabChanDoanCanThiep); // Đưa tab quan trọng lên đầu
            this.tabControlMonitoring.Controls.Add(this.tabCSCT);
            this.tabControlMonitoring.Controls.Add(this.tabTuanHoan);
            this.tabControlMonitoring.Controls.Add(this.tabHoHap);
            this.tabControlMonitoring.Controls.Add(this.tabTieuHoa);
            this.tabControlMonitoring.Controls.Add(this.tabDinhDuong);
            this.tabControlMonitoring.Controls.Add(this.tabTietNieu);
            this.tabControlMonitoring.Controls.Add(this.tabThanKinh);
            this.tabControlMonitoring.Controls.Add(this.tabCoXuongKhop);
            this.tabControlMonitoring.Controls.Add(this.tabNhanDinhKhac);

            this.tabControlMonitoring.Location = new System.Drawing.Point(10, 25);
            this.tabControlMonitoring.Name = "tabControlMonitoring";
            this.tabControlMonitoring.SelectedIndex = 0;
            this.tabControlMonitoring.Size = new System.Drawing.Size(906, 410);
            this.tabControlMonitoring.TabIndex = 0;

            // Thiết lập các Tab Page
            // Tab Toàn Trạng
            this.tabToanTrang.Location = new System.Drawing.Point(4, 25);
            this.tabToanTrang.Name = "tabToanTrang";
            this.tabToanTrang.Padding = new System.Windows.Forms.Padding(3);
            this.tabToanTrang.Text = "1. Toàn Trạng";
            this.tabToanTrang.UseVisualStyleBackColor = true;

            // Tab Sinh Tồn
            this.tabSinhTon.Location = new System.Drawing.Point(4, 25);
            this.tabSinhTon.Name = "tabSinhTon";
            this.tabSinhTon.Padding = new System.Windows.Forms.Padding(3);
            this.tabSinhTon.Text = "2. Dấu hiệu Sinh tồn";
            this.tabSinhTon.UseVisualStyleBackColor = true;

            // Tab Chẩn đoán/Can thiệp
            this.tabChanDoanCanThiep.Location = new System.Drawing.Point(4, 25);
            this.tabChanDoanCanThiep.Name = "tabChanDoanCanThiep";
            this.tabChanDoanCanThiep.Padding = new System.Windows.Forms.Padding(3);
            this.tabChanDoanCanThiep.Text = "Chẩn đoán/Can thiệp ĐD";
            this.tabChanDoanCanThiep.UseVisualStyleBackColor = true;

            // Các Tab Khác (Giữ nguyên cấu trúc đã cung cấp)
            this.tabCSCT.Name = "tabCSCT";
            this.tabCSCT.Text = "3. Chỉ Số Cơ Thể";
            this.tabTuanHoan.Name = "tabTuanHoan";
            this.tabTuanHoan.Text = "4. Tuần Hoàn";
            this.tabHoHap.Name = "tabHoHap";
            this.tabHoHap.Text = "5. Hô Hấp & Thông Khí Cơ Học";
            this.tabTieuHoa.Name = "tabTieuHoa";
            this.tabTieuHoa.Text = "6. Tiêu Hóa";
            this.tabDinhDuong.Name = "tabDinhDuong";
            this.tabDinhDuong.Text = "7. Dinh Dưỡng";
            this.tabTietNieu.Name = "tabTietNieu";
            this.tabTietNieu.Text = "8. Tiết Niệu - Sinh Dục";
            this.tabThanKinh.Name = "tabThanKinh";
            this.tabThanKinh.Text = "9. Thần Kinh";
            this.tabCoXuongKhop.Name = "tabCoXuongKhop";
            this.tabCoXuongKhop.Text = "10. Tình Thần & Cơ Xương Khớp";
            this.tabNhanDinhKhac.Name = "tabNhanDinhKhac";
            this.tabNhanDinhKhac.Text = "11. Nhận Định Khác & Theo Dõi Nhập/Xuất";


            // --- Controls trong tabToanTrang ---
            this.tabToanTrang.Controls.Add(this.labelTriGiac);
            this.tabToanTrang.Controls.Add(this.txtTriGiac);
            this.tabToanTrang.Controls.Add(this.labelDaNiem);
            this.tabToanTrang.Controls.Add(this.txtDaNiem);
            this.tabToanTrang.Controls.Add(this.labelPhu);
            this.tabToanTrang.Controls.Add(this.txtPhu);

            this.labelTriGiac.Location = new System.Drawing.Point(10, 10);
            this.labelTriGiac.Text = "Tri giác:";
            this.txtTriGiac.Location = new System.Drawing.Point(150, 10);
            this.txtTriGiac.Name = "txtTriGiac";
            this.txtTriGiac.Size = new System.Drawing.Size(700, 22);

            this.labelDaNiem.Location = new System.Drawing.Point(10, 50);
            this.labelDaNiem.Text = "Da niêm:";
            this.txtDaNiem.Location = new System.Drawing.Point(150, 50);
            this.txtDaNiem.Name = "txtDaNiem";
            this.txtDaNiem.Size = new System.Drawing.Size(700, 22);

            this.labelPhu.Location = new System.Drawing.Point(10, 90);
            this.labelPhu.Text = "Tình trạng phù:";
            this.txtPhu.Location = new System.Drawing.Point(150, 90);
            this.txtPhu.Name = "txtPhu";
            this.txtPhu.Size = new System.Drawing.Size(700, 22);


            // --- Controls trong tabSinhTon ---
            this.tabSinhTon.Controls.Add(this.labelMach);
            this.tabSinhTon.Controls.Add(this.txtMach);
            this.tabSinhTon.Controls.Add(this.labelHuyetAp);
            this.tabSinhTon.Controls.Add(this.txtHuyetAp);
            this.tabSinhTon.Controls.Add(this.labelNhietDo);
            this.tabSinhTon.Controls.Add(this.txtNhietDo);
            this.tabSinhTon.Controls.Add(this.labelSpO2);
            this.tabSinhTon.Controls.Add(this.txtSpO2);
            this.tabSinhTon.Controls.Add(this.labelTanSoTho); // Bổ sung Tần số thở
            this.tabSinhTon.Controls.Add(this.txtTanSoTho); // Bổ sung Tần số thở

            // Cột 1
            this.labelMach.Location = new System.Drawing.Point(10, 10);
            this.labelMach.Text = "Tần số mạch (lần/phút):";
            this.txtMach.Location = new System.Drawing.Point(200, 10);
            this.txtMach.Name = "txtMach";
            this.txtMach.Size = new System.Drawing.Size(150, 22);

            this.labelNhietDo.Location = new System.Drawing.Point(10, 50);
            this.labelNhietDo.Text = "Nhiệt độ (°C):";
            this.txtNhietDo.Location = new System.Drawing.Point(200, 50);
            this.txtNhietDo.Name = "txtNhietDo";
            this.txtNhietDo.Size = new System.Drawing.Size(150, 22);

            // Cột 2
            this.labelHuyetAp.Location = new System.Drawing.Point(400, 10);
            this.labelHuyetAp.Text = "Huyết áp (mmHg):";
            this.txtHuyetAp.Location = new System.Drawing.Point(550, 10);
            this.txtHuyetAp.Name = "txtHuyetAp";
            this.txtHuyetAp.Size = new System.Drawing.Size(150, 22);

            this.labelSpO2.Location = new System.Drawing.Point(400, 50);
            this.labelSpO2.Text = "SpO2 (%):";
            this.txtSpO2.Location = new System.Drawing.Point(550, 50);
            this.txtSpO2.Name = "txtSpO2";
            this.txtSpO2.Size = new System.Drawing.Size(150, 22);

            // Cột 3 (Tần số thở)
            this.labelTanSoTho.Location = new System.Drawing.Point(750, 10);
            this.labelTanSoTho.Text = "Tần số thở (lần/phút):";
            this.txtTanSoTho.Location = new System.Drawing.Point(750, 30); // Đặt ở vị trí khác để tránh trùng lặp, giả định vị trí này
            this.txtTanSoTho.Name = "txtTanSoTho";
            this.txtTanSoTho.Size = new System.Drawing.Size(100, 22);


            // --- Controls trong tabChanDoanCanThiep ---
            this.tabChanDoanCanThiep.Controls.Add(this.labelChanDoanDD);
            this.tabChanDoanCanThiep.Controls.Add(this.rtbChanDoanDD);
            this.tabChanDoanCanThiep.Controls.Add(this.labelCanThiepDD);
            this.tabChanDoanCanThiep.Controls.Add(this.rtbCanThiepDD);

            this.labelChanDoanDD.Location = new System.Drawing.Point(10, 10);
            this.labelChanDoanDD.Text = "14. Chẩn đoán Điều dưỡng:";
            this.rtbChanDoanDD.Location = new System.Drawing.Point(10, 30);
            this.rtbChanDoanDD.Name = "rtbChanDoanDD";
            this.rtbChanDoanDD.Size = new System.Drawing.Size(870, 150);

            this.labelCanThiepDD.Location = new System.Drawing.Point(10, 190);
            this.labelCanThiepDD.Text = "16. Can thiệp và Chăm sóc Dinh dưỡng:";
            this.rtbCanThiepDD.Location = new System.Drawing.Point(10, 210);
            this.rtbCanThiepDD.Name = "rtbCanThiepDD";
            this.rtbCanThiepDD.Size = new System.Drawing.Size(870, 150);


            // 5. THIẾT LẬP NÚT ĐIỀU KHIỂN (Footer)
            this.btnSave.Location = new System.Drawing.Point(730, 690);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.Text = "Lưu Cập Nhật";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            // Sự kiện Click được gán trong fFormUpdatePatient.cs

            this.btnCancel.Location = new System.Drawing.Point(838, 690);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // Sự kiện Click được gán trong fFormUpdatePatient.cs

            // Kết thúc gộp GroupBox
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControlMonitoring.ResumeLayout(false);
            this.tabToanTrang.ResumeLayout(false);
            this.tabToanTrang.PerformLayout();
            this.tabSinhTon.ResumeLayout(false);
            this.tabSinhTon.PerformLayout();
            this.tabChanDoanCanThiep.ResumeLayout(false);
            this.tabChanDoanCanThiep.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}