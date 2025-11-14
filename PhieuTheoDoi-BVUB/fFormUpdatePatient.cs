using BVUB_PhieuTheoDoi.DAO; // Giả sử DataProvider nằm trong namespace này
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BVUB_PhieuTheoDoi
{
    public partial class fFormUpdatePatient : Form
    {
        private int currentSheetID;

        // Constructor đã được sử dụng đúng cách
        public fFormUpdatePatient(int sheetId)
        {
            InitializeComponent();
            this.currentSheetID = sheetId;
            this.Text = $"Cập nhật Phiếu Theo Dõi #{sheetId}";

            this.Load += fFormUpdatePatient_Load;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;

            this.chkDiUngCo.CheckedChanged += chkDiUng_CheckedChanged;
            this.chkDiUngKhong.CheckedChanged += chkDiUng_CheckedChanged;

            SetPatientInfoReadOnly(true);
        }

        private void fFormUpdatePatient_Load(object sender, EventArgs e)
        {
            LoadMonitoringSheetData(currentSheetID);
        }

        // =========================================================
        // 1. HÀM TẢI DỮ LIỆU SỬ DỤNG DataProvider TRỰC TIẾP
        // =========================================================
        private void LoadMonitoringSheetData(int sheetId)
        {
            try
            {
                // Sử dụng câu truy vấn SELECT bạn đã cung cấp để tải dữ liệu
                string query = $@"
                    SELECT
                        P.PatientID, P.MaBenhNhan, P.HoTen, P.Tuoi, P.Phong, P.Giuong, P.ChanDoan, P.TienSuDiUng,
                        MS.SheetID, MS.ThoiGianTao,
                        MS.SinhTon_TanSoTho, MS.SinhTon_HuyetAp, MS.ToanTrang_TriGiac, MS.SinhTon_Mach, MS.SinhTon_HuyetAp,
                        MS.SinhTon_NhietDo, MS.SinhTon_SpO2, MS.SinhTon_TanSoTho, MS.CSCT_CanNang, MS.CSCT_ChieuCao, MS.CSCT_BMI,
                        MS.TuanHoan_TinhChatMach, MS.TuanHoan_Khac, MS.HoHap_TuTho, MS.HoHap_CheDoTho, MS.HoHap_DungTichSong,
                        MS.HoHap_ApLucPS, MS.HoHap_ApLucPEEP, MS.HoHap_TanSoThoMay, MS.HoHap_FIO2, MS.TieuHoa_TinhTrangBung,
                        MS.TieuHoa_Non, MS.TieuHoa_NhuDongRuot, MS.TieuHoa_DaiTien,
                        MS.DinhDuong_HauMonNhanTao, MS.DinhDuong_CheDoAn, MS.DinhDuong_TinhTrangAn,
                        MS.TietNieu_HinhThucDiTieu, MS.TietNieu_MauSacNT, MS.TietNieu_SoLuongNT, MS.TietNieu_TieuRatBuot,
                        MS.TietNieu_BPSD, 
                        MS.ThanKinh_LoiNoi, MS.ThanKinh_YeuLiet, MS.ThanKinh_Khac,
                        MS.CXK_GiacNgu, MS.CXK_VanDongCoXuong, MS.CXK_Khac,
                        MS.NDK_VetThuongLoet, MS.NDK_NhanDinhKhac, MS.NDK_TheoDoiNhapXuat,
                        MS.TieuHoa_RoiLoanMuoiNuoc, MS.TieuHoa_DayBung
                        ,MS.ChanDoanDieuDuong, MS.CanThiepDieuDuong
                    FROM Patient AS P
                    JOIN MonitoringSheet AS MS ON P.PatientID = MS.PatientID
                    WHERE MS.SheetID = {sheetId}
                ";

                DataTable dt = DataProvider.Instance.ExecuteQuery(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu phiếu theo dõi này.", "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                DataRow row = dt.Rows[0];

                // --- Load thông tin Hành chính ---
                lblMaBenhNhanValue.Text = row["MaBenhNhan"].ToString();
                txtHoTen.Text = row["HoTen"].ToString();
                txtTuoi.Text = row["Tuoi"].ToString();
                txtPhong.Text = row["Phong"].ToString();
                txtGiuong.Text = row["Giuong"].ToString();
                txtChanDoan.Text = row["ChanDoan"].ToString();

                string diUng = row["TienSuDiUng"].ToString();
                bool coDiUng = !string.IsNullOrWhiteSpace(diUng) && diUng.ToLower() != "không";
                chkDiUngCo.Checked = coDiUng;
                chkDiUngKhong.Checked = !coDiUng;
                txtTienSuDiUng.Text = diUng;
                txtTienSuDiUng.Enabled = coDiUng;

                // --- Load dữ liệu Phiếu Theo Dõi ---

                // Tab 1. Toàn Trạng
                txtTriGiac.Text = row["ToanTrang_TriGiac"]?.ToString() ?? string.Empty;
                // Lưu ý: Cột 'DaNiem' và 'Phu' không có trong SELECT list bạn cung cấp.
                // Nếu chúng tồn tại, bạn cần kiểm tra lại tên cột. Tôi tạm thời để trống.
                // txtDaNiem.Text = row["DaNiem"]?.ToString() ?? string.Empty; 
                // txtPhu.Text = row["Phu"]?.ToString() ?? string.Empty;

                // Tab 2. Sinh Tồn
                txtMach.Text = row["SinhTon_Mach"]?.ToString() ?? string.Empty;
                txtHuyetAp.Text = row["SinhTon_HuyetAp"]?.ToString() ?? string.Empty;
                txtNhietDo.Text = row["SinhTon_NhietDo"]?.ToString() ?? string.Empty;
                txtSpO2.Text = row["SinhTon_SpO2"]?.ToString() ?? string.Empty;
                txtTanSoTho.Text = row["SinhTon_TanSoTho"]?.ToString() ?? string.Empty;

                // Tab Chẩn đoán/Can thiệp
                rtbChanDoanDD.Text = row["ChanDoanDieuDuong"]?.ToString() ?? string.Empty;
                rtbCanThiepDD.Text = row["CanThiepDieuDuong"]?.ToString() ?? string.Empty;

                // ***** BẠN PHẢI TỰ BỔ SUNG CÁC TRƯỜNG CÒN LẠI VÀO CÁC CONTROLS TƯƠNG ỨNG *****
                // Ví dụ: txtCanNang.Text = row["CSCT_CanNang"]?.ToString() ?? string.Empty;
                // **************************************************************************
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết phiếu theo dõi: Vui lòng kiểm tra lại tên cột SQL và lỗi Login Failed. Chi tiết: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // 2. HÀM XỬ LÝ NÚT LƯU - DÙNG DataProvider TRỰC TIẾP
        // =========================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            // --- B1: Lấy dữ liệu mới từ các Controls và xử lý dấu nháy đơn ---
            string triGiac = txtTriGiac.Text.Replace("'", "''");
            string daNiem = ""; // Bạn cần lấy giá trị từ control tương ứng (thiếu trong designer bạn gửi)
            string phu = "";    // Bạn cần lấy giá trị từ control tương ứng (thiếu trong designer bạn gửi)
            string mach = txtMach.Text.Replace("'", "''");
            string huyetAp = txtHuyetAp.Text.Replace("'", "''");
            string nhietDo = txtNhietDo.Text.Replace("'", "''");
            string spO2 = txtSpO2.Text.Replace("'", "''");
            string tanSoTho = txtTanSoTho.Text.Replace("'", "''");
            string chanDoanDD = rtbChanDoanDD.Text.Replace("'", "''");
            string canThiepDD = rtbCanThiepDD.Text.Replace("'", "''");

            // Xử lý tiền sử dị ứng
            string tienSuDiUng = chkDiUngCo.Checked ? txtTienSuDiUng.Text.Replace("'", "''") : "Không";

            // ***** BẠN PHẢI TỰ BỔ SUNG CÁC TRƯỜNG CÒN LẠI TẠI ĐÂY *****
            // string canNang = txtCanNang.Text.Replace("'", "''");
            // string chieuCao = txtChieuCao.Text.Replace("'", "''");
            // ...
            // *********************************************************

            // --- B2: Tạo câu lệnh SQL UPDATE (Multiple commands) ---
            string updateQuery = $@"
                -- Cập nhật bảng MonitoringSheet
                UPDATE MonitoringSheet 
                SET 
                    ToanTrang_TriGiac = N'{triGiac}',
                    -- Bạn cần cập nhật các cột 'DaNiem' và 'Phu' nếu chúng tồn tại
                    SinhTon_Mach = N'{mach}',
                    SinhTon_HuyetAp = N'{huyetAp}',
                    SinhTon_NhietDo = N'{nhietDo}',
                    SinhTon_SpO2 = N'{spO2}',
                    SinhTon_TanSoTho = N'{tanSoTho}',
                    ChanDoanDieuDuong = N'{chanDoanDD}',
                    CanThiepDieuDuong = N'{canThiepDD}',
                    -- ***** CẦN THÊM TẤT CẢ 20+ CỘT CÒN LẠI VÀO ĐÂY *****
                    ThoiGianTao = GETDATE() -- Cập nhật thời gian sửa đổi
                WHERE SheetID = {currentSheetID};

                -- Cập nhật bảng Patient (Chỉ cập nhật Tiền sử dị ứng)
                UPDATE Patient 
                SET 
                    TienSuDiUng = N'{tienSuDiUng}'
                WHERE PatientID = (SELECT PatientID FROM MonitoringSheet WHERE SheetID = {currentSheetID});
            ";

            try
            {
                // --- B3: Thực thi query ---
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(updateQuery);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật phiếu theo dõi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật phiếu theo dõi thất bại! Không có dữ liệu nào được thay đổi hoặc lỗi ở database.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật SQL: Vui lòng kiểm tra lại cú pháp SQL, tên cột và kết nối database. Chi tiết: {ex.Message}", "Lỗi Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =========================================================
        // 3. HÀM HỖ TRỢ
        // =========================================================

        private void SetPatientInfoReadOnly(bool readOnly)
        {
            txtHoTen.ReadOnly = readOnly;
            txtTuoi.ReadOnly = readOnly;
            txtPhong.ReadOnly = readOnly;
            txtGiuong.ReadOnly = readOnly;
            txtChanDoan.ReadOnly = readOnly;

            chkDiUngCo.Enabled = !readOnly;
            chkDiUngKhong.Enabled = !readOnly;
            txtTienSuDiUng.ReadOnly = readOnly;
        }

        private void chkDiUng_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == chkDiUngCo && chkDiUngCo.Checked)
            {
                chkDiUngKhong.Checked = false;
                txtTienSuDiUng.Enabled = true;
                txtTienSuDiUng.Focus();
            }
            else if (sender == chkDiUngKhong && chkDiUngKhong.Checked)
            {
                chkDiUngCo.Checked = false;
                txtTienSuDiUng.Enabled = false;
                txtTienSuDiUng.Text = "Không";
            }
        }
    }
}