using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;
using System.Data;
using BVUB_PhieuTheoDoi.DAO;
using System.Data.SqlClient;

namespace BVUB_PhieuTheoDoi
{
    public partial class fFormAddPatient : Form
    {
        // =========================================================
        //                 KHAI BÁO CỐ ĐỊNH & BIẾN (Cập nhật tên bảng)
        // =========================================================
        private const string PatientTable = "BenhNhan";
        private const string MonitoringSheetTable = "TheoDoi"; // Đã đổi từ PhieuTheoDoi sang TheoDoi
        private readonly string _patientIdToUpdate = null;
        private readonly bool _isUpdateMode = false;

        // Cần đảm bảo rằng các TextBox/RichTextBox tương ứng trong Designer đã được đặt tên như sau:
        // txtHoTen, txtTuoi, rdbNam, rdbNu, txtPhong, txtGiuong, cboKhoa, txtChanDoan, 
        // chkDiUngCo, chkDiUngKhong, txtTienSuDiUng (cho ChiTietDiUng),
        // rtbTriGiac, rtbDaNiemMac, rtbTinhTrangPhu, txtMach, txtNhietDo, txtHuyetAp, txtTSTho, txtSpO2,
        // rtbTuanHoan, rtbHoHap, rtbTieuHoa, rtbDinhDuong, rtbTietNieu, rtbThanKinh, rtbCoXuongKhop, rtbNhanDinhKhac (cho NDK_Khac),
        // rtbChanDoanDD, rtbCanThiepDD

        // =========================================================
        //                 CONSTRUCTOR & KHỞI TẠO
        // =========================================================

        // Constructor cho chế độ THÊM mới
        public fFormAddPatient()
        {
            InitializeComponent();
            _isUpdateMode = false;

            LoadKhoaData();
            SetupEventHandlers();

            lblMaBenhNhanValue.Text = GenerateNewPatientId();
            this.Text = "Thêm Phiếu Theo Dõi Mới";
            btnSave.Text = "Thêm Mới";

            chkDiUngKhong.Checked = true;
        }

        // =========================================================
        //                 SETUP VÀ TẢI DỮ LIỆU BAN ĐẦU
        // =========================================================

        private void SetupEventHandlers()
        {
            btnSave.Click += btnSave_Click;
            chkDiUngCo.CheckedChanged += chkDiUngCo_CheckedChanged;
            chkDiUngKhong.CheckedChanged += chkDiUngKhong_CheckedChanged;
            btnCancel.Click += (sender, e) => this.Close();
        }

        private void LoadKhoaData()
        {
            try
            {
                // Cập nhật: Sử dụng KhoaID làm ValueMember
                string query = "SELECT KhoaID, TenKhoa FROM Khoa";
                DataTable dtKhoa = DataProvider.Instance.ExecuteQuery(query);

                if (dtKhoa != null && dtKhoa.Rows.Count > 0)
                {
                    cboKhoa.DataSource = dtKhoa;
                    cboKhoa.DisplayMember = "TenKhoa";
                    cboKhoa.ValueMember = "KhoaID"; // Sửa: KhoaID
                    cboKhoa.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu Khoa: {ex.Message}\nKiểm tra lại chuỗi kết nối Database.", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine("Lỗi LoadKhoaData: " + ex.Message);
            }
        }

        private string GenerateNewPatientId()
        {
            string prefix = "BN" + DateTime.Now.ToString("yyyyMMdd");
            int maxSuffix = 0;

            try
            {
                // Logic tạo mã bệnh nhân dựa trên DB
                string query = $@"
                    SELECT MAX(CAST(SUBSTRING(MaBenhNhan, 11, 3) AS INT)) 
                    FROM {PatientTable} 
                    WHERE MaBenhNhan LIKE '{prefix}%'";

                object result = DataProvider.Instance.ExecuteScalar(query);

                if (result != null && result != DBNull.Value)
                {
                    if (int.TryParse(result.ToString(), out int parsedMaxSuffix))
                    {
                        maxSuffix = parsedMaxSuffix;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GenerateNewPatientId: " + ex.Message);
                maxSuffix = 0;
            }

            return prefix + (maxSuffix + 1).ToString("D3");
        }

        // =========================================================
        //                 XỬ LÝ SỰ KIỆN FORM
        // =========================================================

        private void chkDiUngCo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiUngCo.Checked)
            {
                chkDiUngKhong.Checked = false;
                txtTienSuDiUng.Enabled = true;
                txtTienSuDiUng.Focus();
            }
            else
            {
                if (!chkDiUngKhong.Checked) chkDiUngKhong.Checked = true;
                txtTienSuDiUng.Enabled = false;
                txtTienSuDiUng.Clear();
            }
        }

        private void chkDiUngKhong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiUngKhong.Checked)
            {
                chkDiUngCo.Checked = false;
                txtTienSuDiUng.Enabled = false;
                txtTienSuDiUng.Clear();
            }
            else
            {
                if (!chkDiUngCo.Checked) chkDiUngCo.Checked = true;
                txtTienSuDiUng.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra Dữ liệu Bắt Buộc
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || cboKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập Họ Tên và chọn Khoa.", "Thiếu Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Thu thập dữ liệu từ Form
            Dictionary<string, object> allFormData = CollectFormData();

            // 3. Thực hiện Lưu trữ
            bool saveSuccess = SavePatientRecordInternal(allFormData);

            if (saveSuccess)
            {
                MessageBox.Show($"Đã thêm mới thành công bệnh nhân {txtHoTen.Text} (Mã BN: {lblMaBenhNhanValue.Text}) vào cơ sở dữ liệu.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình lưu dữ liệu. Vui lòng kiểm tra log lỗi (Debug Output) và kết nối database.", "Lỗi Lưu Trữ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        //                 LOGIC THU THẬP VÀ LƯU DỮ LIỆU
        // =========================================================

        private Dictionary<string, object> CollectFormData()
        {
            var data = new Dictionary<string, object>();

            // Hàm chuyển đổi an toàn sang kiểu số (decimal/int)
            Func<string, object> safeInt = (text) => int.TryParse(text, out int val) ? (object)val : DBNull.Value;
            Func<string, object> safeDecimal = (text) => decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val) ? (object)val : DBNull.Value;

            // --- 1. HÀNH CHÍNH & TIỀN SỬ (Cho PatientTable) ---
            data.Add("MaBenhNhan", lblMaBenhNhanValue.Text);
            data.Add("HoTen", txtHoTen.Text);
            data.Add("Tuoi", safeInt(txtTuoi.Text));
            if (rdbNam.Checked)
            {
                data["GioiTinh"] = "Nam";
            }
            else if (rdbNu.Checked)
            {
                data["GioiTinh"] = "Nữ";
            }
            else
            {
                data["GioiTinh"] = DBNull.Value; // <<< Kiểm tra xem việc gán DBNull.Value có hợp lệ không
            }
            data.Add("Phong", txtPhong.Text);
            data.Add("Giuong", txtGiuong.Text);
            data.Add("KhoaID", cboKhoa.SelectedValue ?? DBNull.Value); // Sửa: KhoaID
            data.Add("ChuanDoan", txtChanDoan.Text); // Sửa: ChuanDoan

            // Xử lý TienSuDiUng (gộp 2 trường cũ thành 1)
            string tienSuDiUng = chkDiUngCo.Checked ? txtTienSuDiUng.Text : "Không";
            data.Add("TienSuDiUng", tienSuDiUng);

            // Thêm các trường mới từ schema BenhNhan
            data.Add("SoVaoVien", "N/A"); // Giả định giá trị mặc định nếu không có trường nhập
            data.Add("SoTo", DBNull.Value); // Giả định DBNull nếu không có trường nhập

            // --- 2. DỮ LIỆU PHIẾU THEO DÕI (Cho MonitoringSheetTable/TheoDoi) ---
            // Sửa: ThoiGianGhiNhan
            data.Add("ThoiGianGhiNhan", DateTime.Now);

            // I. TOÀN TRẠNG
            data.Add("TriGiac", rtbTriGiac.Text);
            data.Add("DaNiemMac", rtbDaNiemMac.Text);
            data.Add("Phu", rtbTinhTrangPhu.Text);

            // II. DẤU HIỆU SINH TỒN
            data.Add("TanSoMach", safeInt(txtMach.Text)); // Sửa: TanSoMach
            data.Add("NhietDo", safeDecimal(txtNhietDo.Text));
            data.Add("HuyetAp", txtHuyetAp.Text);
            data.Add("TanSoTho", safeInt(txtTSTho.Text)); // Sửa: TanSoTho
            data.Add("Spo2", safeDecimal(txtSpO2.Text)); // Sửa: Spo2

            // III. CHỈ SỐ CÂN NẶNG, CHIỀU CAO (Giả định N/A nếu form không có)
            data.Add("ChieuCao", DBNull.Value);
            data.Add("CanNang", DBNull.Value);
            data.Add("BMI", DBNull.Value);

            // IV. TUẦN HOÀN (rtbTuanHoan)
            data.Add("TinhChatMach", DBNull.Value); // Giả định N/A
            data.Add("DHKhacTuanHoan", rtbTuanHoan.Text); // Ánh xạ vào đây

            // V. HÔ HẤP (rtbHoHap)
            data.Add("TinhTrangHoHap", rtbHoHap.Text); // Ánh xạ vào đây
            data.Add("KieuTho", DBNull.Value);
            data.Add("Ho", DBNull.Value);
            data.Add("CheDoTho", DBNull.Value);
            data.Add("DungTichSongVt", DBNull.Value);
            data.Add("ApLucHoTroPS", DBNull.Value);
            data.Add("PEEP", DBNull.Value);
            data.Add("TanSoThoMay", DBNull.Value);
            data.Add("Fio2", DBNull.Value);

            // VI. TIÊU HÓA (rtbTieuHoa)
            data.Add("TinhTrangBung", rtbTieuHoa.Text); // Ánh xạ vào đây
            data.Add("RoiLoanNuot", DBNull.Value);
            data.Add("DayBungKhoTieu", DBNull.Value);
            data.Add("Non", DBNull.Value);
            data.Add("NhuDongRuot", DBNull.Value);
            data.Add("DaiTien", DBNull.Value);
            data.Add("HauMonNhanTao", DBNull.Value);

            // VII. DINH DƯỠNG (rtbDinhDuong)
            data.Add("NguyCoSDD", DBNull.Value);
            data.Add("CheDoAn", rtbDinhDuong.Text); // Ánh xạ vào đây
            data.Add("TinhTrangAn", DBNull.Value);
            data.Add("DuongAn", DBNull.Value);

            // VIII. TIẾT NIỆU SINH DỤC (rtbTietNieu)
            data.Add("HinhThucDiTieu", rtbTietNieu.Text); // Ánh xạ vào đây
            data.Add("MauSacNuocTieu", DBNull.Value);
            data.Add("SoLuongNuocTieu", DBNull.Value);
            data.Add("TieuRatBuot", DBNull.Value);
            data.Add("BoPhanSinhDuc", DBNull.Value);

            // IX. THẦN KINH (rtbThanKinh)
            data.Add("LoiNoi", DBNull.Value);
            data.Add("YeuLiet", DBNull.Value);
            data.Add("RoiLoanVanDong", DBNull.Value);
            data.Add("DHKhacThanKinh", rtbThanKinh.Text); // Ánh xạ vào đây

            // X. TINH THẦN, GIẤC NGỦ (rtbThanKinh)
            data.Add("TinhThan", DBNull.Value);
            data.Add("GiacNgu", DBNull.Value);

            // XI. CƠ XƯƠNG KHỚP (rtbCoXuongKhop)
            data.Add("VanDong", rtbCoXuongKhop.Text); // Ánh xạ vào đây
            data.Add("VanDeKhacCXK", DBNull.Value);

            // XII. NHẬN ĐỊNH KHÁC (rtbNhanDinhKhac)
            data.Add("Dau", rtbNhanDinhKhac.Text); // Ánh xạ rtbNhanDinhKhac vào cột Đau
            data.Add("VetThuongLoet", DBNull.Value);
            data.Add("DanLuu", DBNull.Value);
            data.Add("NguyCoNga", DBNull.Value);
            data.Add("CanhBaoSom", DBNull.Value);

            // XIII. THEO DÕI NHẬP/XUẤT
            data.Add("TongNhap", DBNull.Value);
            data.Add("TongXuat", DBNull.Value);

            // XIV. PHÂN CẤP CHĂM SÓC
            data.Add("PhanCapChamSoc", DBNull.Value);

            // XV. CHẨN ĐOÁN ĐIỀU DƯỠNG (rtbChanDoanDD)
            data.Add("CDDD1", rtbChanDoanDD.Text); // Ánh xạ CDD_ChanDoan vào CDDD1
            data.Add("MucTieuCDDD1", DBNull.Value);
            data.Add("CDDD2", DBNull.Value);
            data.Add("MucTieuCDDD2", DBNull.Value);
            data.Add("CDDD3", DBNull.Value);
            data.Add("MucTieuCDDD3", DBNull.Value);
            data.Add("CDDD4", DBNull.Value);
            data.Add("MucTieuCDDD4", DBNull.Value);

            // XVI. CAN THIỆP ĐIỀU DƯỠNG (rtbCanThiepDD)
            data.Add("ThucHienYLenh", DBNull.Value);
            data.Add("ThucHienCanLS", DBNull.Value);
            data.Add("ChamSocDieuDuong", rtbCanThiepDD.Text); // Ánh xạ CanThiepDD vào ChamSocDieuDuong

            // XVII. BÀN GIAO
            data.Add("BanGiao", DBNull.Value);

            // MỤC 18: KÝ TÊN (Giả định chưa có MaDieuDuong)
            data.Add("MaDieuDuong", DBNull.Value);

            return data;
        }

        private bool SavePatientRecordInternal(Dictionary<string, object> allFormData)
        {
            // Tách dữ liệu thành 2 phần: BenhNhan và TheoDoi
            var patientData = new Dictionary<string, object>()
            {
                { "MaBenhNhan", allFormData["MaBenhNhan"] },
                { "HoTen", allFormData["HoTen"] },
                { "Tuoi", allFormData["Tuoi"] },
                { "GioiTinh", allFormData["GioiTinh"] },
                { "Phong", allFormData["Phong"] },
                { "Giuong", allFormData["Giuong"] },
                { "KhoaID", allFormData["KhoaID"] }, // Sửa: KhoaID
                { "ChuanDoan", allFormData["ChuanDoan"] }, // Sửa: ChuanDoan
                { "TienSuDiUng", allFormData["TienSuDiUng"] }, // Sửa: TienSuDiUng (gộp)
                { "SoVaoVien", allFormData["SoVaoVien"] },
                { "SoTo", allFormData["SoTo"] }
            };

            // Tạo Monitoring Sheet Data với các trường của bảng TheoDoi
            var monitoringSheetData = new Dictionary<string, object>()
            {
                { "MaBenhNhan", allFormData["MaBenhNhan"] },
                { "ThoiGianGhiNhan", allFormData["ThoiGianGhiNhan"] },
                { "MaDieuDuong", allFormData["MaDieuDuong"] },
                { "TriGiac", allFormData["TriGiac"] },
                { "DaNiemMac", allFormData["DaNiemMac"] },
                { "Phu", allFormData["Phu"] },
                { "TanSoMach", allFormData["TanSoMach"] },
                { "HuyetAp", allFormData["HuyetAp"] },
                { "TanSoTho", allFormData["TanSoTho"] },
                { "NhietDo", allFormData["NhietDo"] },
                { "Spo2", allFormData["Spo2"] },
                { "ChieuCao", allFormData["ChieuCao"] },
                { "CanNang", allFormData["CanNang"] },
                { "BMI", allFormData["BMI"] },
                { "TinhChatMach", allFormData["TinhChatMach"] },
                { "DHKhacTuanHoan", allFormData["DHKhacTuanHoan"] },
                { "TinhTrangHoHap", allFormData["TinhTrangHoHap"] },
                { "KieuTho", allFormData["KieuTho"] },
                { "Ho", allFormData["Ho"] },
                { "CheDoTho", allFormData["CheDoTho"] },
                { "DungTichSongVt", allFormData["DungTichSongVt"] },
                { "ApLucHoTroPS", allFormData["ApLucHoTroPS"] },
                { "PEEP", allFormData["PEEP"] },
                { "TanSoThoMay", allFormData["TanSoThoMay"] },
                { "Fio2", allFormData["Fio2"] },
                { "TinhTrangBung", allFormData["TinhTrangBung"] },
                { "RoiLoanNuot", allFormData["RoiLoanNuot"] },
                { "DayBungKhoTieu", allFormData["DayBungKhoTieu"] },
                { "Non", allFormData["Non"] },
                { "NhuDongRuot", allFormData["NhuDongRuot"] },
                { "DaiTien", allFormData["DaiTien"] },
                { "HauMonNhanTao", allFormData["HauMonNhanTao"] },
                { "NguyCoSDD", allFormData["NguyCoSDD"] },
                { "CheDoAn", allFormData["CheDoAn"] },
                { "TinhTrangAn", allFormData["TinhTrangAn"] },
                { "DuongAn", allFormData["DuongAn"] },
                { "HinhThucDiTieu", allFormData["HinhThucDiTieu"] },
                { "MauSacNuocTieu", allFormData["MauSacNuocTieu"] },
                { "SoLuongNuocTieu", allFormData["SoLuongNuocTieu"] },
                { "TieuRatBuot", allFormData["TieuRatBuot"] },
                { "BoPhanSinhDuc", allFormData["BoPhanSinhDuc"] },
                { "LoiNoi", allFormData["LoiNoi"] },
                { "YeuLiet", allFormData["YeuLiet"] },
                { "RoiLoanVanDong", allFormData["RoiLoanVanDong"] },
                { "DHKhacThanKinh", allFormData["DHKhacThanKinh"] },
                { "TinhThan", allFormData["TinhThan"] },
                { "GiacNgu", allFormData["GiacNgu"] },
                { "VanDong", allFormData["VanDong"] },
                { "VanDeKhacCXK", allFormData["VanDeKhacCXK"] },
                { "Dau", allFormData["Dau"] },
                { "VetThuongLoet", allFormData["VetThuongLoet"] },
                { "DanLuu", allFormData["DanLuu"] },
                { "NguyCoNga", allFormData["NguyCoNga"] },
                { "CanhBaoSom", allFormData["CanhBaoSom"] },
                { "TongNhap", allFormData["TongNhap"] },
                { "TongXuat", allFormData["TongXuat"] },
                { "PhanCapChamSoc", allFormData["PhanCapChamSoc"] },
                { "CDDD1", allFormData["CDDD1"] },
                { "MucTieuCDDD1", allFormData["MucTieuCDDD1"] },
                { "CDDD2", allFormData["CDDD2"] },
                { "MucTieuCDDD2", allFormData["MucTieuCDDD2"] },
                { "CDDD3", allFormData["CDDD3"] },
                { "MucTieuCDDD3", allFormData["MucTieuCDDD3"] },
                { "CDDD4", allFormData["CDDD4"] },
                { "MucTieuCDDD4", allFormData["MucTieuCDDD4"] },
                { "ThucHienYLenh", allFormData["ThucHienYLenh"] },
                { "ThucHienCanLS", allFormData["ThucHienCanLS"] },
                { "ChamSocDieuDuong", allFormData["ChamSocDieuDuong"] },
                { "BanGiao", allFormData["BanGiao"] }
            };


            try
            {
                // Sử dụng Transaction để đảm bảo BenhNhan và PhieuTheoDoi được lưu đồng thời
                DataProvider.Instance.BeginTransaction();

                // 1. THÊM MỚI BN (Insert into BenhNhan)
                var (insertPatientQuery, insertPatientParams) = CreateInsertQuery(PatientTable, patientData);
                DataProvider.Instance.ExecuteNonQueryWithParams(insertPatientQuery, insertPatientParams);

                // 2. LƯU PHIẾU THEO DÕI (Insert new record into TheoDoi)
                var (insertSheetQuery, insertSheetParams) = CreateInsertQuery(MonitoringSheetTable, monitoringSheetData);
                DataProvider.Instance.ExecuteNonQueryWithParams(insertSheetQuery, insertSheetParams);

                // 3. COMMIT TRANSACTION
                DataProvider.Instance.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                // 4. ROLLBACK khi có lỗi
                DataProvider.Instance.RollbackTransaction();
                System.Diagnostics.Debug.WriteLine("LỖI LƯU DỮ LIỆU (TRANSACTION ROLLED BACK): " + ex.Message);
                return false;
            }
        }

        // --- CÁC HÀM HỖ TRỢ (GIỮ NGUYÊN) ---

        private (string query, Dictionary<string, object> parameters) CreateInsertQuery(string tableName, Dictionary<string, object> data)
        {
            List<string> columns = new List<string>();
            List<string> parameterNames = new List<string>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            foreach (var pair in data)
            {
                columns.Add(pair.Key);
                parameterNames.Add("@" + pair.Key);
                parameters.Add(pair.Key, pair.Value);
            }

            string columnList = string.Join(", ", columns);
            string parameterList = string.Join(", ", parameterNames);

            string query = $"INSERT INTO {tableName} ({columnList}) VALUES ({parameterList})";
            return (query, parameters);
        }

        private (string query, Dictionary<string, object> parameters) CreateUpdateQuery(string tableName, Dictionary<string, object> data, string primaryKeyColumn, object primaryKeyValue)
        {
            List<string> setClauses = new List<string>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            foreach (var pair in data)
            {
                if (pair.Key.Equals(primaryKeyColumn, StringComparison.OrdinalIgnoreCase)) continue;

                setClauses.Add($"{pair.Key} = @{pair.Key}");
                parameters.Add(pair.Key, pair.Value);
            }

            parameters.Add(primaryKeyColumn, primaryKeyValue);

            string setClause = string.Join(", ", setClauses);
            string query = $"UPDATE {tableName} SET {setClause} WHERE {primaryKeyColumn} = @{primaryKeyColumn}";
            return (query, parameters);
        }

        // Placeholder cho các hàm load dữ liệu Cập nhật (nếu cần)
        private void LoadPatientData(string patientId) { }
        private void LoadMonitoringSheetData(string sheetId) { }
    }
}