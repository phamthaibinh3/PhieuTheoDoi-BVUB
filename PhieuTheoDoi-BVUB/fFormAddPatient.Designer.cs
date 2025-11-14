namespace BVUB_PhieuTheoDoi
{
    partial class fFormAddPatient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            // Khai báo components
            this.components = new System.ComponentModel.Container();

            // =========================================================
            //                 KHAI BÁO CONTROLS ĐẦY ĐỦ
            // =========================================================

            // --- Hành chính (groupBox1) ---
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelMaBN = new System.Windows.Forms.Label();
            this.lblMaBenhNhanValue = new System.Windows.Forms.Label();
            this.labelHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.labelTuoi = new System.Windows.Forms.Label();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.labelGioiTinh = new System.Windows.Forms.Label();
            this.rdbNam = new System.Windows.Forms.RadioButton();
            this.rdbNu = new System.Windows.Forms.RadioButton();
            this.labelPhong = new System.Windows.Forms.Label();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.labelGiuong = new System.Windows.Forms.Label();
            this.txtGiuong = new System.Windows.Forms.TextBox();
            this.labelKhoa = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.labelChanDoan = new System.Windows.Forms.Label();
            this.txtChanDoan = new System.Windows.Forms.TextBox();
            this.labelTienSu = new System.Windows.Forms.Label();
            this.chkDiUngCo = new System.Windows.Forms.CheckBox();
            this.chkDiUngKhong = new System.Windows.Forms.CheckBox();
            this.txtTienSuDiUng = new System.Windows.Forms.TextBox();

            // --- Phiếu Theo Dõi (groupBox2) ---
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControlMonitoring = new System.Windows.Forms.TabControl();

            // Tab Pages
            this.tabToanTrang = new System.Windows.Forms.TabPage(); // I
            this.tabSinhTon = new System.Windows.Forms.TabPage(); // II
            this.tabCSCT = new System.Windows.Forms.TabPage(); // III
            this.tabTuanHoan = new System.Windows.Forms.TabPage(); // V
            this.tabHoHap = new System.Windows.Forms.TabPage(); // VI
            this.tabTieuHoa = new System.Windows.Forms.TabPage(); // VII
            this.tabDinhDuong = new System.Windows.Forms.TabPage(); // VIII
            this.tabTietNieu = new System.Windows.Forms.TabPage(); // IX
            this.tabThanKinh = new System.Windows.Forms.TabPage(); // X
            this.tabCoXuongKhop = new System.Windows.Forms.TabPage(); // XII
            this.tabNhanDinhKhac = new System.Windows.Forms.TabPage(); // XIII
            this.tabChanDoanCanThiep = new System.Windows.Forms.TabPage(); // XIV - XVII

            // Controls Tab I: Toàn Trạng 
            this.labelTriGiac = new System.Windows.Forms.Label();
            this.rtbTriGiac = new System.Windows.Forms.RichTextBox();
            this.labelDaNiemMac = new System.Windows.Forms.Label();
            this.rtbDaNiemMac = new System.Windows.Forms.RichTextBox();
            this.labelTinhTrangPhu = new System.Windows.Forms.Label();
            this.rtbTinhTrangPhu = new System.Windows.Forms.RichTextBox();

            // Controls Tab II: Sinh Tồn 
            this.labelMach = new System.Windows.Forms.Label();
            this.txtMach = new System.Windows.Forms.TextBox();
            this.labelNhietDo = new System.Windows.Forms.Label();
            this.txtNhietDo = new System.Windows.Forms.TextBox();
            this.labelHuyetAp = new System.Windows.Forms.Label();
            this.txtHuyetAp = new System.Windows.Forms.TextBox();
            this.labelTSTho = new System.Windows.Forms.Label();
            this.txtTSTho = new System.Windows.Forms.TextBox();
            this.labelSpO2 = new System.Windows.Forms.Label();
            this.txtSpO2 = new System.Windows.Forms.TextBox();

            // Controls Tab III, V-X, XII, XIII
            this.rtbCSCT = new System.Windows.Forms.RichTextBox();
            this.rtbTuanHoan = new System.Windows.Forms.RichTextBox();
            this.rtbHoHap = new System.Windows.Forms.RichTextBox();
            this.rtbTieuHoa = new System.Windows.Forms.RichTextBox();
            this.rtbDinhDuong = new System.Windows.Forms.RichTextBox();
            this.rtbTietNieu = new System.Windows.Forms.RichTextBox();
            this.rtbThanKinh = new System.Windows.Forms.RichTextBox();
            this.rtbCoXuongKhop = new System.Windows.Forms.RichTextBox();
            this.rtbNhanDinhKhac = new System.Windows.Forms.RichTextBox();

            // Controls Tab XIV-XVII: Chẩn Đoán/Can Thiệp ĐD 
            this.labelChanDoanDD = new System.Windows.Forms.Label();
            this.rtbChanDoanDD = new System.Windows.Forms.RichTextBox();
            this.labelCanThiepDD = new System.Windows.Forms.Label();
            this.rtbCanThiepDD = new System.Windows.Forms.RichTextBox();


            // Controls Button
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();


            // Bắt đầu cấu hình
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControlMonitoring.SuspendLayout();
            this.tabToanTrang.SuspendLayout();
            this.tabSinhTon.SuspendLayout();
            this.tabCSCT.SuspendLayout();
            this.tabTuanHoan.SuspendLayout();
            this.tabHoHap.SuspendLayout();
            this.tabTieuHoa.SuspendLayout();
            this.tabDinhDuong.SuspendLayout();
            this.tabTietNieu.SuspendLayout();
            this.tabThanKinh.SuspendLayout();
            this.tabCoXuongKhop.SuspendLayout();
            this.tabNhanDinhKhac.SuspendLayout();
            this.tabChanDoanCanThiep.SuspendLayout();
            this.SuspendLayout();

            // 
            // fFormAddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "fFormAddPatient";
            this.Text = "Thêm/Cập Nhật Phiếu Theo Dõi";

            // 
            // groupBox1 (Thông tin Hành Chính)
            // 
            this.groupBox1.Controls.Add(this.txtTienSuDiUng);
            this.groupBox1.Controls.Add(this.chkDiUngKhong);
            this.groupBox1.Controls.Add(this.chkDiUngCo);
            this.groupBox1.Controls.Add(this.labelTienSu);
            this.groupBox1.Controls.Add(this.txtChanDoan);
            this.groupBox1.Controls.Add(this.labelChanDoan);
            this.groupBox1.Controls.Add(this.cboKhoa);
            this.groupBox1.Controls.Add(this.labelKhoa);
            this.groupBox1.Controls.Add(this.txtGiuong);
            this.groupBox1.Controls.Add(this.labelGiuong);
            this.groupBox1.Controls.Add(this.txtPhong);
            this.groupBox1.Controls.Add(this.labelPhong);
            this.groupBox1.Controls.Add(this.rdbNu);
            this.groupBox1.Controls.Add(this.rdbNam);
            this.groupBox1.Controls.Add(this.labelGioiTinh);
            this.groupBox1.Controls.Add(this.txtTuoi);
            this.groupBox1.Controls.Add(this.labelTuoi);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.labelHoTen);
            this.groupBox1.Controls.Add(this.lblMaBenhNhanValue);
            this.groupBox1.Controls.Add(this.labelMaBN);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Size = new System.Drawing.Size(980, 180);
            this.groupBox1.Text = "Thông tin Bệnh nhân";

            // --- Cấu hình chi tiết các Controls trong groupBox1 ---

            // Mã BN
            this.labelMaBN.Location = new System.Drawing.Point(20, 30);
            this.labelMaBN.Text = "Mã BN:";
            this.labelMaBN.AutoSize = true;
            this.lblMaBenhNhanValue.Location = new System.Drawing.Point(120, 30);
            this.lblMaBenhNhanValue.Size = new System.Drawing.Size(150, 16);

            // Họ Tên
            this.labelHoTen.Location = new System.Drawing.Point(300, 30);
            this.labelHoTen.Text = "Họ Tên:";
            this.labelHoTen.AutoSize = true;
            this.txtHoTen.Location = new System.Drawing.Point(400, 27);
            this.txtHoTen.Size = new System.Drawing.Size(250, 22);

            // Tuổi
            this.labelTuoi.Location = new System.Drawing.Point(680, 30);
            this.labelTuoi.Text = "Tuổi:";
            this.labelTuoi.AutoSize = true;
            this.txtTuoi.Location = new System.Drawing.Point(750, 27);
            this.txtTuoi.Size = new System.Drawing.Size(50, 22);

            // Giới tính 
            this.labelGioiTinh.Location = new System.Drawing.Point(820, 30);
            this.labelGioiTinh.Text = "Giới tính:";
            this.labelGioiTinh.AutoSize = true;
            this.rdbNam.Location = new System.Drawing.Point(890, 30);
            this.rdbNam.Text = "Nam";
            this.rdbNam.AutoSize = true;
            this.rdbNu.Location = new System.Drawing.Point(950, 30);
            this.rdbNu.Text = "Nữ";
            this.rdbNu.AutoSize = true;


            // Phòng
            this.labelPhong.Location = new System.Drawing.Point(20, 60);
            this.labelPhong.Text = "Phòng:";
            this.labelPhong.AutoSize = true;
            this.txtPhong.Location = new System.Drawing.Point(120, 57);
            this.txtPhong.Size = new System.Drawing.Size(150, 22);

            // Giường
            this.labelGiuong.Location = new System.Drawing.Point(300, 60);
            this.labelGiuong.Text = "Giường:";
            this.labelGiuong.AutoSize = true;
            this.txtGiuong.Location = new System.Drawing.Point(400, 57);
            this.txtGiuong.Size = new System.Drawing.Size(250, 22);

            // Khoa
            this.labelKhoa.Location = new System.Drawing.Point(680, 60);
            this.labelKhoa.Text = "Khoa:";
            this.labelKhoa.AutoSize = true;
            this.cboKhoa.Location = new System.Drawing.Point(750, 57);
            this.cboKhoa.Size = new System.Drawing.Size(220, 24);

            // Chẩn đoán
            this.labelChanDoan.Location = new System.Drawing.Point(20, 90);
            this.labelChanDoan.Text = "Chẩn đoán:";
            this.labelChanDoan.AutoSize = true;
            this.txtChanDoan.Location = new System.Drawing.Point(120, 87);
            this.txtChanDoan.Size = new System.Drawing.Size(850, 22);

            // Tiền sử dị ứng 
            this.labelTienSu.Location = new System.Drawing.Point(20, 120);
            this.labelTienSu.Text = "Tiền sử dị ứng:";
            this.labelTienSu.AutoSize = true;
            this.chkDiUngCo.Location = new System.Drawing.Point(150, 120);
            this.chkDiUngCo.Text = "Có";
            this.chkDiUngCo.AutoSize = true;
            this.chkDiUngKhong.Location = new System.Drawing.Point(220, 120);
            this.chkDiUngKhong.Text = "Không";
            this.chkDiUngKhong.AutoSize = true;
            this.txtTienSuDiUng.Location = new System.Drawing.Point(320, 117);
            this.txtTienSuDiUng.Size = new System.Drawing.Size(650, 22);
            this.txtTienSuDiUng.Enabled = false;


            // 
            // groupBox2 (Phần Tabs)
            // 
            this.groupBox2.Controls.Add(this.tabControlMonitoring);
            this.groupBox2.Location = new System.Drawing.Point(10, 200);
            this.groupBox2.Size = new System.Drawing.Size(980, 480);
            this.groupBox2.Text = "Phiếu Theo Dõi";

            // 
            // tabControlMonitoring
            // 
            this.tabControlMonitoring.Controls.Add(this.tabToanTrang);
            this.tabControlMonitoring.Controls.Add(this.tabSinhTon);
            this.tabControlMonitoring.Controls.Add(this.tabCSCT);
            this.tabControlMonitoring.Controls.Add(this.tabTuanHoan);
            this.tabControlMonitoring.Controls.Add(this.tabHoHap);
            this.tabControlMonitoring.Controls.Add(this.tabTieuHoa);
            this.tabControlMonitoring.Controls.Add(this.tabDinhDuong);
            this.tabControlMonitoring.Controls.Add(this.tabTietNieu);
            this.tabControlMonitoring.Controls.Add(this.tabThanKinh);
            this.tabControlMonitoring.Controls.Add(this.tabCoXuongKhop);
            this.tabControlMonitoring.Controls.Add(this.tabNhanDinhKhac);
            this.tabControlMonitoring.Controls.Add(this.tabChanDoanCanThiep);
            this.tabControlMonitoring.Location = new System.Drawing.Point(6, 21);
            this.tabControlMonitoring.Size = new System.Drawing.Size(968, 450);
            this.tabControlMonitoring.SelectedIndex = 0;


            // =========================================================
            //               CẤU HÌNH CÁC TAB PAGES 
            // =========================================================

            // 
            // tabToanTrang (I) 
            // 
            this.tabToanTrang.Controls.Add(this.rtbTinhTrangPhu);
            this.tabToanTrang.Controls.Add(this.labelTinhTrangPhu);
            this.tabToanTrang.Controls.Add(this.rtbDaNiemMac);
            this.tabToanTrang.Controls.Add(this.labelDaNiemMac);
            this.tabToanTrang.Controls.Add(this.rtbTriGiac);
            this.tabToanTrang.Controls.Add(this.labelTriGiac);
            this.tabToanTrang.Location = new System.Drawing.Point(4, 25);
            this.tabToanTrang.Size = new System.Drawing.Size(960, 421);
            this.tabToanTrang.Text = "I. Toàn Trạng";

            // Tri Giác
            this.labelTriGiac.Location = new System.Drawing.Point(10, 20);
            this.labelTriGiac.Text = "Tri Giác:";
            this.labelTriGiac.AutoSize = true;
            this.rtbTriGiac.Location = new System.Drawing.Point(150, 17);
            this.rtbTriGiac.Size = new System.Drawing.Size(780, 50);

            // Da và Niêm Mạc
            this.labelDaNiemMac.Location = new System.Drawing.Point(10, 80);
            this.labelDaNiemMac.Text = "Da và Niêm mạc:";
            this.labelDaNiemMac.AutoSize = true;
            this.rtbDaNiemMac.Location = new System.Drawing.Point(150, 77);
            this.rtbDaNiemMac.Size = new System.Drawing.Size(780, 50);

            // Tình trạng Phù
            this.labelTinhTrangPhu.Location = new System.Drawing.Point(10, 140);
            this.labelTinhTrangPhu.Text = "Tình trạng Phù:";
            this.labelTinhTrangPhu.AutoSize = true;
            this.rtbTinhTrangPhu.Location = new System.Drawing.Point(150, 137);
            this.rtbTinhTrangPhu.Size = new System.Drawing.Size(780, 50);


            // 
            // tabSinhTon (II) 
            // 
            this.tabSinhTon.Controls.Add(this.txtSpO2);
            this.tabSinhTon.Controls.Add(this.labelSpO2);
            this.tabSinhTon.Controls.Add(this.txtTSTho);
            this.tabSinhTon.Controls.Add(this.labelTSTho);
            this.tabSinhTon.Controls.Add(this.txtHuyetAp);
            this.tabSinhTon.Controls.Add(this.labelHuyetAp);
            this.tabSinhTon.Controls.Add(this.txtNhietDo);
            this.tabSinhTon.Controls.Add(this.labelNhietDo);
            this.tabSinhTon.Controls.Add(this.txtMach);
            this.tabSinhTon.Controls.Add(this.labelMach);
            this.tabSinhTon.Location = new System.Drawing.Point(4, 25);
            this.tabSinhTon.Size = new System.Drawing.Size(960, 421);
            this.tabSinhTon.Text = "II. Sinh Tồn";

            // Mạch
            this.labelMach.Location = new System.Drawing.Point(10, 20);
            this.labelMach.Text = "Mạch (lần/phút):";
            this.labelMach.AutoSize = true;
            this.txtMach.Location = new System.Drawing.Point(150, 17);
            this.txtMach.Size = new System.Drawing.Size(100, 22);

            // Nhiệt độ
            this.labelNhietDo.Location = new System.Drawing.Point(280, 20);
            this.labelNhietDo.Text = "Nhiệt độ (oC):";
            this.labelNhietDo.AutoSize = true;
            this.txtNhietDo.Location = new System.Drawing.Point(400, 17);
            this.txtNhietDo.Size = new System.Drawing.Size(100, 22);

            // Huyết áp
            this.labelHuyetAp.Location = new System.Drawing.Point(530, 20);
            this.labelHuyetAp.Text = "Huyết áp (mmHg):";
            this.labelHuyetAp.AutoSize = true;
            this.txtHuyetAp.Location = new System.Drawing.Point(680, 17);
            this.txtHuyetAp.Size = new System.Drawing.Size(150, 22);

            // Tần số thở
            this.labelTSTho.Location = new System.Drawing.Point(10, 50);
            this.labelTSTho.Text = "Tần số thở (lần/phút):";
            this.labelTSTho.AutoSize = true;
            this.txtTSTho.Location = new System.Drawing.Point(150, 47);
            this.txtTSTho.Size = new System.Drawing.Size(100, 22);

            // SpO2
            this.labelSpO2.Location = new System.Drawing.Point(280, 50);
            this.labelSpO2.Text = "SpO2 (%):";
            this.labelSpO2.AutoSize = true;
            this.txtSpO2.Location = new System.Drawing.Point(400, 47);
            this.txtSpO2.Size = new System.Drawing.Size(100, 22);


            // 
            // tabCSCT (III)
            // 
            this.tabCSCT.Controls.Add(this.rtbCSCT);
            this.tabCSCT.Location = new System.Drawing.Point(4, 25);
            this.tabCSCT.Size = new System.Drawing.Size(960, 421);
            this.tabCSCT.Text = "III. Chăm Sóc Cơ Thể";
            this.rtbCSCT.Location = new System.Drawing.Point(10, 10);
            this.rtbCSCT.Size = new System.Drawing.Size(940, 400);

            // 
            // tabTuanHoan (V) 
            // 
            this.tabTuanHoan.Controls.Add(this.rtbTuanHoan);
            this.tabTuanHoan.Location = new System.Drawing.Point(4, 25);
            this.tabTuanHoan.Size = new System.Drawing.Size(960, 421);
            this.tabTuanHoan.Text = "V. Tuần Hoàn";
            this.rtbTuanHoan.Location = new System.Drawing.Point(10, 10);
            this.rtbTuanHoan.Size = new System.Drawing.Size(940, 400);


            // 
            // tabHoHap (VI) 
            // 
            this.tabHoHap.Controls.Add(this.rtbHoHap);
            this.tabHoHap.Location = new System.Drawing.Point(4, 25);
            this.tabHoHap.Size = new System.Drawing.Size(960, 421);
            this.tabHoHap.Text = "VI. Hô Hấp";
            this.rtbHoHap.Location = new System.Drawing.Point(10, 10);
            this.rtbHoHap.Size = new System.Drawing.Size(940, 400);


            // 
            // tabTieuHoa (VII) 
            // 
            this.tabTieuHoa.Controls.Add(this.rtbTieuHoa);
            this.tabTieuHoa.Location = new System.Drawing.Point(4, 25);
            this.tabTieuHoa.Size = new System.Drawing.Size(960, 421);
            this.tabTieuHoa.Text = "VII. Tiêu Hóa";
            this.rtbTieuHoa.Location = new System.Drawing.Point(10, 10);
            this.rtbTieuHoa.Size = new System.Drawing.Size(940, 400);

            // 
            // tabDinhDuong (VIII) 
            // 
            this.tabDinhDuong.Controls.Add(this.rtbDinhDuong);
            this.tabDinhDuong.Location = new System.Drawing.Point(4, 25);
            this.tabDinhDuong.Size = new System.Drawing.Size(960, 421);
            this.tabDinhDuong.Text = "VIII. Dinh Dưỡng";
            this.rtbDinhDuong.Location = new System.Drawing.Point(10, 10);
            this.rtbDinhDuong.Size = new System.Drawing.Size(940, 400);


            // 
            // tabTietNieu (IX) 
            // 
            this.tabTietNieu.Controls.Add(this.rtbTietNieu);
            this.tabTietNieu.Location = new System.Drawing.Point(4, 25);
            this.tabTietNieu.Size = new System.Drawing.Size(960, 421);
            this.tabTietNieu.Text = "IX. Tiết Niệu - Sinh Dục";
            this.rtbTietNieu.Location = new System.Drawing.Point(10, 10);
            this.rtbTietNieu.Size = new System.Drawing.Size(940, 400);


            // 
            // tabThanKinh (X) 
            // 
            this.tabThanKinh.Controls.Add(this.rtbThanKinh);
            this.tabThanKinh.Location = new System.Drawing.Point(4, 25);
            this.tabThanKinh.Size = new System.Drawing.Size(960, 421);
            this.tabThanKinh.Text = "X. Thần Kinh - Giác Quan";
            this.rtbThanKinh.Location = new System.Drawing.Point(10, 10);
            this.rtbThanKinh.Size = new System.Drawing.Size(940, 400);


            // 
            // tabCoXuongKhop (XII) 
            // 
            this.tabCoXuongKhop.Controls.Add(this.rtbCoXuongKhop);
            this.tabCoXuongKhop.Location = new System.Drawing.Point(4, 25);
            this.tabCoXuongKhop.Size = new System.Drawing.Size(960, 421);
            this.tabCoXuongKhop.Text = "XII. Cơ Xương Khớp";
            this.rtbCoXuongKhop.Location = new System.Drawing.Point(10, 10);
            this.rtbCoXuongKhop.Size = new System.Drawing.Size(940, 400);


            // 
            // tabNhanDinhKhac (XIII) 
            // 
            this.tabNhanDinhKhac.Controls.Add(this.rtbNhanDinhKhac);
            this.tabNhanDinhKhac.Location = new System.Drawing.Point(4, 25);
            this.tabNhanDinhKhac.Size = new System.Drawing.Size(960, 421);
            this.tabNhanDinhKhac.Text = "XIII. Nhận Định Khác/Nhập Xuất";
            this.rtbNhanDinhKhac.Location = new System.Drawing.Point(10, 10);
            this.rtbNhanDinhKhac.Size = new System.Drawing.Size(940, 400);


            // 
            // tabChanDoanCanThiep (XIV - XVII) 
            // 
            this.tabChanDoanCanThiep.Controls.Add(this.rtbCanThiepDD);
            this.tabChanDoanCanThiep.Controls.Add(this.labelCanThiepDD);
            this.tabChanDoanCanThiep.Controls.Add(this.rtbChanDoanDD);
            this.tabChanDoanCanThiep.Controls.Add(this.labelChanDoanDD);
            this.tabChanDoanCanThiep.Location = new System.Drawing.Point(4, 25);
            this.tabChanDoanCanThiep.Size = new System.Drawing.Size(960, 421);
            this.tabChanDoanCanThiep.Text = "XIV - XVII. Chẩn Đoán/Can Thiệp ĐD";

            // Chẩn đoán Điều Dưỡng
            this.labelChanDoanDD.Location = new System.Drawing.Point(10, 10);
            this.labelChanDoanDD.Text = "Chẩn đoán Điều Dưỡng:";
            this.labelChanDoanDD.AutoSize = true;
            this.rtbChanDoanDD.Location = new System.Drawing.Point(10, 30);
            this.rtbChanDoanDD.Size = new System.Drawing.Size(940, 170);

            // Can thiệp Điều Dưỡng
            this.labelCanThiepDD.Location = new System.Drawing.Point(10, 210);
            this.labelCanThiepDD.Text = "Can Thiệp Điều Dưỡng:";
            this.labelCanThiepDD.AutoSize = true;
            this.rtbCanThiepDD.Location = new System.Drawing.Point(10, 230);
            this.rtbCanThiepDD.Size = new System.Drawing.Size(940, 170);

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(780, 700);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;

            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(890, 700);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;


            // --- Resume Layouts ---
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControlMonitoring.ResumeLayout(false);
            this.tabToanTrang.ResumeLayout(false);
            this.tabToanTrang.PerformLayout();
            this.tabSinhTon.ResumeLayout(false);
            this.tabSinhTon.PerformLayout();
            this.tabCSCT.ResumeLayout(false);
            this.tabCSCT.PerformLayout();
            this.tabTuanHoan.ResumeLayout(false);
            this.tabTuanHoan.PerformLayout();
            this.tabHoHap.ResumeLayout(false);
            this.tabHoHap.PerformLayout();
            this.tabTieuHoa.ResumeLayout(false);
            this.tabTieuHoa.PerformLayout();
            this.tabDinhDuong.ResumeLayout(false);
            this.tabDinhDuong.PerformLayout();
            this.tabTietNieu.ResumeLayout(false);
            this.tabTietNieu.PerformLayout();
            this.tabThanKinh.ResumeLayout(false);
            this.tabThanKinh.PerformLayout();
            this.tabCoXuongKhop.ResumeLayout(false);
            this.tabCoXuongKhop.PerformLayout();
            this.tabNhanDinhKhac.ResumeLayout(false);
            this.tabNhanDinhKhac.PerformLayout();
            this.tabChanDoanCanThiep.ResumeLayout(false);
            this.tabChanDoanCanThiep.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion

        // =========================================================
        //                 KHAI BÁO BIẾN CHO CONTROLS
        // =========================================================

        // Hành chính (groupBox1)
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelMaBN;
        public System.Windows.Forms.Label lblMaBenhNhanValue;
        private System.Windows.Forms.Label labelHoTen;
        public System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label labelTuoi;
        public System.Windows.Forms.TextBox txtTuoi;
        private System.Windows.Forms.Label labelGioiTinh;
        public System.Windows.Forms.RadioButton rdbNam;
        public System.Windows.Forms.RadioButton rdbNu;
        private System.Windows.Forms.Label labelPhong;
        public System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label labelGiuong;
        public System.Windows.Forms.TextBox txtGiuong;
        private System.Windows.Forms.Label labelKhoa;
        public System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label labelChanDoan;
        public System.Windows.Forms.TextBox txtChanDoan;
        private System.Windows.Forms.Label labelTienSu;
        public System.Windows.Forms.CheckBox chkDiUngCo;
        public System.Windows.Forms.CheckBox chkDiUngKhong;
        public System.Windows.Forms.TextBox txtTienSuDiUng;

        // Phiếu Theo Dõi (groupBox2)
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControlMonitoring;

        // Tab Pages
        private System.Windows.Forms.TabPage tabToanTrang;
        private System.Windows.Forms.TabPage tabSinhTon;
        private System.Windows.Forms.TabPage tabCSCT;
        private System.Windows.Forms.TabPage tabTuanHoan;
        private System.Windows.Forms.TabPage tabHoHap;
        private System.Windows.Forms.TabPage tabTieuHoa;
        private System.Windows.Forms.TabPage tabDinhDuong;
        private System.Windows.Forms.TabPage tabTietNieu;
        private System.Windows.Forms.TabPage tabThanKinh;
        private System.Windows.Forms.TabPage tabCoXuongKhop;
        private System.Windows.Forms.TabPage tabNhanDinhKhac;
        private System.Windows.Forms.TabPage tabChanDoanCanThiep;

        // Controls Tab I: Toàn Trạng
        private System.Windows.Forms.Label labelTriGiac;
        public System.Windows.Forms.RichTextBox rtbTriGiac;
        private System.Windows.Forms.Label labelDaNiemMac;
        public System.Windows.Forms.RichTextBox rtbDaNiemMac;
        private System.Windows.Forms.Label labelTinhTrangPhu;
        public System.Windows.Forms.RichTextBox rtbTinhTrangPhu;

        // Controls Tab II: Sinh Tồn
        private System.Windows.Forms.Label labelMach;
        public System.Windows.Forms.TextBox txtMach;
        private System.Windows.Forms.Label labelNhietDo;
        public System.Windows.Forms.TextBox txtNhietDo;
        private System.Windows.Forms.Label labelHuyetAp;
        public System.Windows.Forms.TextBox txtHuyetAp;
        private System.Windows.Forms.Label labelTSTho;
        public System.Windows.Forms.TextBox txtTSTho;
        private System.Windows.Forms.Label labelSpO2;
        public System.Windows.Forms.TextBox txtSpO2;

        // Controls Tab III, V-X, XII, XIII
        public System.Windows.Forms.RichTextBox rtbCSCT;
        public System.Windows.Forms.RichTextBox rtbTuanHoan;
        public System.Windows.Forms.RichTextBox rtbHoHap;
        public System.Windows.Forms.RichTextBox rtbTieuHoa;
        public System.Windows.Forms.RichTextBox rtbDinhDuong;
        public System.Windows.Forms.RichTextBox rtbTietNieu;
        public System.Windows.Forms.RichTextBox rtbThanKinh;
        public System.Windows.Forms.RichTextBox rtbCoXuongKhop;
        public System.Windows.Forms.RichTextBox rtbNhanDinhKhac;

        // Controls Tab XIV-XVII
        private System.Windows.Forms.Label labelChanDoanDD;
        public System.Windows.Forms.RichTextBox rtbChanDoanDD;
        private System.Windows.Forms.Label labelCanThiepDD;
        public System.Windows.Forms.RichTextBox rtbCanThiepDD;


        // Controls Button
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}