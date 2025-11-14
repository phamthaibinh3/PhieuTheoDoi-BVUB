using BVUB_PhieuTheoDoi.DAO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PhieuTheoDoi_BVUB;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace BVUB_PhieuTheoDoi
{
    public partial class Form1 : Form
    {
        // =========================================================
        //                 KHAI BÁO BIẾN CỐ ĐỊNH (Tên Bảng)
        // =========================================================
        private DataTable allSheetData;
        private DataTable dtReportData;

        private const string PatientTable = "BenhNhan";
        private const string MonitoringSheetTable = "TheoDoi";

        // =========================================================
        //                 CONSTRUCTOR & KHỞI TẠO
        // =========================================================
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            if (cmbMaBenhNhan != null)
            {
                this.cmbMaBenhNhan.SelectedIndexChanged += cmbMaBenhNhan_SelectedIndexChanged;
            }
            this.dgvTheoDoi.SelectionChanged += dgvTheoDoi_SelectionChanged;

            this.btnAddPatient.Click += btnAddPatient_Click_1;
            this.btnUpdatePatient.Click += btnUpdatePatient_Click;
            // SỬA: Đồng bộ nút Xuất báo cáo với Designer (btnReport)
            this.btnReport.Click += btnReport_Click;
            this.btnResetColumns.Click += btnResetColumns_Click;

            SetPatientInfoReadOnly(true);
        }

        // =========================================================
        //                 SỰ KIỆN FORM VÀ HÀM TẢI DỮ LIỆU
        // =========================================================

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllSheetsToGridView();
            LoadPatientComboBox();

            if (dgvTheoDoi.Rows.Count > 0)
            {
                dgvTheoDoi_SelectionChanged(sender, e);
            }
        }

        /// <summary>
        /// Tải toàn bộ danh sách phiếu theo dõi (TheoDoi) và thông tin bệnh nhân lên DataGridView.
        /// </summary>
        private void LoadAllSheetsToGridView()
        {
            try
            {
                // Truy vấn liệt kê đầy đủ các cột để hiển thị tất cả thông tin của bảng TheoDoi
                string query = $@"
                    SELECT 
                        -- Các cột cơ bản cho hiển thị/lọc
                        td.TheoDoiID,         
                        p.MaBenhNhan,         
                        p.HoTen,              
                        td.ThoiGianGhiNhan,   
                        
                        -- Thông tin cơ bản khác của bệnh nhân (tùy chọn)
                        p.Tuoi, 
                        p.GioiTinh,

                        -- TẤT CẢ các cột chi tiết từ bảng TheoDoi
                        td.MaDieuDuong, td.TriGiac, td.DaNiemMac, td.Phu, 
                        td.TanSoMach, td.HuyetAp, td.TanSoTho, td.NhietDo, td.Spo2,
                        td.ChieuCao, td.CanNang, td.BMI,
                        td.TinhChatMach, td.DHKhacTuanHoan,
                        td.TinhTrangHoHap, td.KieuTho, td.Ho, td.CheDoTho, td.DungTichSongVt, td.ApLucHoTroPS, 
                        td.PEEP, td.TanSoThoMay, td.Fio2,
                        td.TinhTrangBung, td.RoiLoanNuot, td.DayBungKhoTieu, td.Non, td.NhuDongRuot, td.DaiTien, td.HauMonNhanTao,
                        td.NguyCoSDD, td.CheDoAn, td.TinhTrangAn, td.DuongAn,
                        td.HinhThucDiTieu, td.MauSacNuocTieu, td.SoLuongNuocTieu, td.TieuRatBuot, td.BoPhanSinhDuc,
                        td.LoiNoi, td.YeuLiet, td.RoiLoanVanDong, td.DHKhacThanKinh,
                        td.TinhThan, td.GiacNgu,
                        td.VanDong, td.VanDeKhacCXK,
                        td.Dau, td.VetThuongLoet, td.DanLuu, td.NguyCoNga, td.CanhBaoSom,
                        td.TongNhap, td.TongXuat,
                        td.PhanCapChamSoc,
                        td.CDDD1, td.MucTieuCDDD1, td.CDDD2, td.MucTieuCDDD2, td.CDDD3, td.MucTieuCDDD3, td.CDDD4, td.MucTieuCDDD4,
                        td.ThucHienYLenh, td.ThucHienCanLS, td.ChamSocDieuDuong, td.BanGiao

                    FROM {PatientTable} p
                    INNER JOIN {MonitoringSheetTable} td ON p.MaBenhNhan = td.MaBenhNhan 
                    ORDER BY td.ThoiGianGhiNhan DESC;";

                DataTable dtSheets = DataProvider.Instance.ExecuteQuery(query);

                if (dtSheets != null)
                {
                    allSheetData = dtSheets;
                    dgvTheoDoi.DataSource = allSheetData;

                    // Tùy chỉnh hiển thị tiêu đề các cột quan trọng
                    dgvTheoDoi.Columns["TheoDoiID"].HeaderText = "ID Phiếu";
                    dgvTheoDoi.Columns["MaBenhNhan"].HeaderText = "Mã BN";
                    dgvTheoDoi.Columns["HoTen"].HeaderText = "Họ Tên";
                    dgvTheoDoi.Columns["ThoiGianGhiNhan"].HeaderText = "Thời Gian Ghi Nhận";
                }
                else
                {
                    allSheetData = new DataTable();
                    dgvTheoDoi.DataSource = allSheetData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phiếu theo dõi: {ex.Message}", "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allSheetData = new DataTable();
                dgvTheoDoi.DataSource = allSheetData;
            }
        }

        /// <summary>
        /// Tải danh sách Mã Bệnh Nhân từ bảng BenhNhan lên ComboBox (cmbMaBenhNhan).
        /// </summary>
        private void LoadPatientComboBox()
        {
            try
            {
                string query = $"SELECT MaBenhNhan, HoTen FROM {PatientTable} ORDER BY MaBenhNhan ASC";
                DataTable dtPatients = DataProvider.Instance.ExecuteQuery(query);

                if (dtPatients != null)
                {
                    cmbMaBenhNhan.DataSource = null;

                    DataRow allRow = dtPatients.NewRow();
                    allRow["MaBenhNhan"] = "Tất cả";
                    dtPatients.Rows.InsertAt(allRow, 0);

                    cmbMaBenhNhan.DisplayMember = "MaBenhNhan";
                    cmbMaBenhNhan.DataSource = dtPatients;

                    cmbMaBenhNhan.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách Mã Bệnh Nhân: {ex.Message}", "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        //                 SỰ KIỆN NÚT VÀ CONTROL
        // =========================================================

        private void cmbMaBenhNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allSheetData == null || allSheetData.Rows.Count == 0)
            {
                return;
            }

            string selectedMaBN = cmbMaBenhNhan.Text;

            if (selectedMaBN == "Tất cả")
            {
                dgvTheoDoi.DataSource = allSheetData;
            }
            else
            {
                DataTable filteredData = allSheetData.AsEnumerable()
                    .Where(r => r.Field<string>("MaBenhNhan") == selectedMaBN)
                    .CopyToDataTable();

                dgvTheoDoi.DataSource = filteredData;
            }

            if (dgvTheoDoi.Rows.Count > 0)
            {
                dgvTheoDoi_SelectionChanged(sender, e);
            }
            else
            {
                ClearPatientDetails();
            }
        }

        private void btnAddPatient_Click_1(object sender, EventArgs e)
        {
            fFormAddPatient frmAddPatient = new fFormAddPatient();

            if (frmAddPatient.ShowDialog() == DialogResult.OK)
            {
                LoadAllSheetsToGridView();
                LoadPatientComboBox();
            }
        }

        /// <summary>
        /// Lấy thông tin chi tiết bệnh nhân (kèm Tên Khoa) và điền vào GroupBox.
        /// </summary>
        private void dgvTheoDoi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTheoDoi.CurrentRow != null)
            {
                try
                {
                    string maBenhNhan = dgvTheoDoi.CurrentRow.Cells["MaBenhNhan"].Value.ToString();

                    // JOIN với bảng Khoa để lấy tên Khoa (TenKhoa)
                    string query = $@"
                        SELECT 
                            p.*, k.TenKhoa 
                        FROM {PatientTable} p
                        INNER JOIN Khoa k ON p.KhoaID = k.KhoaID
                        WHERE p.MaBenhNhan = '{maBenhNhan}'";

                    DataTable dtPatientDetails = DataProvider.Instance.ExecuteQuery(query);

                    if (dtPatientDetails != null && dtPatientDetails.Rows.Count > 0)
                    {
                        DataRow row = dtPatientDetails.Rows[0];

                        txtMaBenhNhan.Text = row["MaBenhNhan"].ToString();
                        txtHoTen.Text = row["HoTen"].ToString();
                        txtTuoi.Text = row["Tuoi"].ToString();
                        // Gán tên Khoa vào control mới
                        txtTenKhoa.Text = row["TenKhoa"].ToString();
                        txtPhong.Text = row["Phong"].ToString();
                        txtGiuong.Text = row["Giuong"].ToString();
                        txtGioiTinh.Text = row["GioiTinh"].ToString();
                        txtChanDoan.Text = row["ChuanDoan"].ToString();
                        txtTienSuDiUng.Text = row["TienSuDiUng"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải thông tin chi tiết bệnh nhân: {ex.Message}", "Lỗi Tải Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ClearPatientDetails();
            }
        }

        // =========================================================
        //                 XUẤT BÁO CÁO 
        // =========================================================

        // SỬA: Đổi tên sự kiện thành btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            CreateReportAndExport();
        }

        private void CreateReportAndExport()
        {
            if (dgvTheoDoi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu theo dõi để xuất báo cáo.", "Thiếu Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int selectedTheoDoiID = Convert.ToInt32(dgvTheoDoi.CurrentRow.Cells["TheoDoiID"].Value);

                // Truy vấn đầy đủ các cột cho báo cáo, bao gồm TenKhoa
                string query = $@"
                    SELECT 
                        -- 1. Thông tin Bệnh nhân (p)
                        p.MaBenhNhan, p.HoTen, p.Tuoi, p.GioiTinh, p.Phong, p.Giuong, 
                        p.ChuanDoan, p.TienSuDiUng, p.SoVaoVien, p.SoTo,
                        k.TenKhoa, -- Lấy Tên Khoa

                        -- 2. Thông tin Phiếu Theo Dõi (td)
                        td.*
                        
                    FROM {PatientTable} p  
                    LEFT JOIN {MonitoringSheetTable} td ON p.MaBenhNhan = td.MaBenhNhan
                    INNER JOIN Khoa k ON p.KhoaID = k.KhoaID
                    WHERE td.TheoDoiID = {selectedTheoDoiID}";

                dtReportData = DataProvider.Instance.ExecuteQuery(query);

                if (dtReportData == null || dtReportData.Rows.Count == 0)
                {
                    MessageBox.Show("Không lấy được dữ liệu chi tiết cho phiếu theo dõi này.", "Lỗi Truy vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CrystalReport1 report = new CrystalReport1();
                report.SetDataSource(dtReportData);

                ExportReportToPDF(report);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xử lý báo cáo: {ex.Message}.\\nLỗi thường do:\\n1. Tên cột 'TheoDoiID' không tồn tại trong DataGridView.\\n2. Lỗi cấu hình Crystal Report (CrystalReport1).", "Lỗi Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        //                 HÀM PHỤ TRỢ 
        // =========================================================

        private void ExportReportToPDF(ReportDocument report)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF files (*.pdf)|*.pdf";
            sfd.FileName = $"PhieuTheoDoi_{txtMaBenhNhan.Text}_{txtHoTen.Text}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    report.ExportToDisk(ExportFormatType.PortableDocFormat, sfd.FileName);
                    MessageBox.Show("Xuất báo cáo sang PDF thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất file PDF: {ex.Message}", "Lỗi Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // SỬA: Thêm txtTenKhoa.Clear()
        private void ClearPatientDetails()
        {
            txtMaBenhNhan.Clear();
            txtHoTen.Clear();
            txtTuoi.Clear();
            txtTenKhoa.Clear();
            txtPhong.Clear();
            txtGiuong.Clear();
            txtGioiTinh.Clear();
            txtChanDoan.Clear();
            txtTienSuDiUng.Clear();
        }

        // SỬA: Thêm txtTenKhoa.ReadOnly
        private void SetPatientInfoReadOnly(bool isReadOnly)
        {
            txtMaBenhNhan.ReadOnly = isReadOnly;
            txtHoTen.ReadOnly = isReadOnly;
            txtTuoi.ReadOnly = isReadOnly;
            txtTenKhoa.ReadOnly = isReadOnly;
            txtPhong.ReadOnly = isReadOnly;
            txtGiuong.ReadOnly = isReadOnly;
            txtGioiTinh.ReadOnly = isReadOnly;
            txtChanDoan.ReadOnly = isReadOnly;
            txtTienSuDiUng.ReadOnly = isReadOnly;
        }

        private void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            // Logic mở Form fFormAddPatient ở chế độ Cập nhật
            // ...
        }

        private void btnResetColumns_Click(object sender, EventArgs e)
        {
            LoadAllSheetsToGridView();

            if (cmbMaBenhNhan.Items.Count > 0)
            {
                cmbMaBenhNhan.SelectedIndex = 0;
            }
        }
    }
}