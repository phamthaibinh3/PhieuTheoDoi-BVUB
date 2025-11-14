using BVUB_PhieuTheoDoi.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace BVUB_PhieuTheoDoi
{
    public partial class fFormUpdatePatient : Form
    {
        // =========================================================
        //                 KHAI BÁO BIẾN CỐ ĐỊNH (Tên Bảng)
        // =========================================================
        private const string PatientTable = "BenhNhan";
        private const string KhoaTable = "Khoa";
        private const string DieuDuongTable = "DieuDuong";

        // Biến lưu Mã Bệnh nhân và Mã Điều dưỡng đang đăng nhập
        private string CurrentMaBenhNhan;
        // **LƯU Ý QUAN TRỌNG:** Bạn cần truyền hoặc khởi tạo giá trị này từ Form đăng nhập/Form chính.
        private string MaDieuDuongLoggedIn = "DD001"; // <--- CẦN THAY ĐỔI THEO THỰC TẾ 

        // =========================================================
        //                 CONSTRUCTOR & KHỞI TẠO
        // =========================================================
        // Constructor chấp nhận MaBenhNhan cần cập nhật
        public fFormUpdatePatient(string maBenhNhan)
        {
            InitializeComponent();
            this.CurrentMaBenhNhan = maBenhNhan;

            this.Load += fFormUpdatePatient_Load;
            this.btnSave.Click += btnSave_Click;

            // Đăng ký sự kiện CheckBox Dị ứng
            // Cần kiểm tra Null để tránh lỗi nếu designer chưa hoàn thiện
            if (chkDiUngCo != null) this.chkDiUngCo.CheckedChanged += ChkDiUng_CheckedChanged;
            if (chkDiUngKhong != null) this.chkDiUngKhong.CheckedChanged += ChkDiUng_CheckedChanged;

            // Thiết lập giá trị mặc định cho ComboBox nếu cần
            if (cboGioiTinh != null) cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ", "Khác" });
            if (cboPhanCapCS != null) cboPhanCapCS.Items.AddRange(new string[] { "Cấp I", "Cấp II", "Cấp III" });
        }

        // =========================================================
        //                 SỰ KIỆN LOAD FORM
        // =========================================================
        private void fFormUpdatePatient_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentMaBenhNhan))
            {
                MessageBox.Show("Không tìm thấy Mã Bệnh nhân để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // 1. Tải dữ liệu Khoa
            LoadKhoaData();

            // 2. Hiển thị thông tin Điều dưỡng ký tên (Read-only)
            DisplayLoggedInNurseName();

            // 3. Tải và hiển thị dữ liệu Bệnh nhân
            LoadPatientData(CurrentMaBenhNhan);

            // 4. Khởi tạo trạng thái hiển thị dị ứng
            SetTienSuDiUngVisibility();
        }

        // =========================================================
        //                 HÀM TẢI DỮ LIỆU
        // =========================================================

        private void LoadKhoaData()
        {
            // Kiểm tra control cboTenKhoa trước khi thao tác
            if (cboTenKhoa == null) return;

            try
            {
                string query = $"SELECT * FROM {KhoaTable}";
                DataTable dt = DataProvider.Instance.ExecuteQuery(query);

                cboTenKhoa.DataSource = dt;
                cboTenKhoa.DisplayMember = "TenKhoa";
                cboTenKhoa.ValueMember = "KhoaID";

                // Mặc định chọn item đầu tiên nếu có dữ liệu
                if (cboTenKhoa.Items.Count > 0 && cboTenKhoa.SelectedIndex == -1)
                {
                    cboTenKhoa.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayLoggedInNurseName()
        {
            // Kiểm tra control txtDieuDuongKyTen trước khi thao tác
            if (txtDieuDuongKyTen == null) return;

            // Hiển thị tên điều dưỡng đang đăng nhập
            try
            {
                string query = $"SELECT HoTen FROM {DieuDuongTable} WHERE MaDieuDuong = @MaDieuDuong";
                DataTable result = DataProvider.Instance.ExecuteQueryWithParams(query, new Dictionary<string, object> { { "MaDieuDuong", MaDieuDuongLoggedIn } });
                if (result.Rows.Count > 0)
                {
                    txtDieuDuongKyTen.Text = result.Rows[0]["HoTen"].ToString();
                    txtDieuDuongKyTen.ReadOnly = true; // Không cho sửa tên người ký
                }
                else
                {
                    txtDieuDuongKyTen.Text = "Không tìm thấy điều dưỡng";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin Điều dưỡng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPatientData(string maBenhNhan)
        {
            // Kiểm tra controls cần thiết
            if (txtMaBenhNhan == null || txtHoTen == null || cboTenKhoa == null || chkDiUngCo == null || chkDiUngKhong == null || txtTienSuDiUng == null) return;

            try
            {
                string query = $@"
                    SELECT BN.*, K.TenKhoa 
                    FROM {PatientTable} BN
                    LEFT JOIN {KhoaTable} K ON BN.KhoaID = K.KhoaID
                    WHERE BN.MaBenhNhan = @MaBenhNhan";

                DataTable dt = DataProvider.Instance.ExecuteQueryWithParams(query,
                    new Dictionary<string, object> { { "MaBenhNhan", maBenhNhan } });

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Thông tin hành chính
                    txtMaBenhNhan.Text = row["MaBenhNhan"].ToString();
                    txtHoTen.Text = row["HoTen"].ToString();
                    txtTuoi.Text = row["Tuoi"] != DBNull.Value ? row["Tuoi"].ToString() : "";

                    // Lựa chọn Giới tính
                    if (cboGioiTinh != null)
                    {
                        cboGioiTinh.SelectedItem = row["GioiTinh"] != DBNull.Value ? row["GioiTinh"].ToString() : null;
                    }

                    txtPhong.Text = row["Phong"] != DBNull.Value ? row["Phong"].ToString() : "";
                    txtGiuong.Text = row["Giuong"] != DBNull.Value ? row["Giuong"].ToString() : "";
                    if (rtbChanDoan != null) rtbChanDoan.Text = row["ChuanDoan"] != DBNull.Value ? row["ChuanDoan"].ToString() : "";
                    txtSoVaoVien.Text = row["SoVaoVien"] != DBNull.Value ? row["SoVaoVien"].ToString() : "";
                    if (txtSoTo != null) txtSoTo.Text = row["SoTo"] != DBNull.Value ? row["SoTo"].ToString() : "";

                    // Khoa
                    if (cboTenKhoa.DataSource != null)
                    {
                        cboTenKhoa.SelectedValue = row["KhoaID"] != DBNull.Value ? row["KhoaID"] : null;
                    }

                    // Tiền sử dị ứng
                    string tienSuDiUng = row["TienSuDiUng"] != DBNull.Value ? row["TienSuDiUng"].ToString() : string.Empty;
                    if (string.Equals(tienSuDiUng, "Không", StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(tienSuDiUng))
                    {
                        chkDiUngKhong.Checked = true;
                        chkDiUngCo.Checked = false;
                        txtTienSuDiUng.Text = string.Empty;
                    }
                    else
                    {
                        chkDiUngCo.Checked = true;
                        chkDiUngKhong.Checked = false;
                        txtTienSuDiUng.Text = tienSuDiUng;
                    }

                    // Mã BN và Số Vào Viện KHÔNG CHO SỬA
                    txtMaBenhNhan.ReadOnly = true;
                    txtSoVaoVien.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu bệnh nhân.", "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Bệnh nhân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        //                 LOGIC ẨN/HIỆN TIỀN SỬ DỊ ỨNG
        // =========================================================

        private void SetTienSuDiUngVisibility()
        {
            // Kiểm tra controls cần thiết
            if (txtTienSuDiUng == null || chkDiUngCo == null) return;

            // Textbox dị ứng chỉ hiện khi checkbox 'Có' được chọn
            txtTienSuDiUng.Visible = chkDiUngCo.Checked;

            // Nếu không hiện (tức là chọn 'Không'), xóa nội dung
            if (!chkDiUngCo.Checked)
            {
                txtTienSuDiUng.Text = string.Empty;
            }
        }

        private void ChkDiUng_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra controls cần thiết
            if (chkDiUngCo == null || chkDiUngKhong == null) return;

            CheckBox current = sender as CheckBox;

            if (current == chkDiUngCo && current.Checked)
            {
                // Nếu chọn 'Có', bỏ chọn 'Không'
                chkDiUngKhong.Checked = false;
            }
            else if (current == chkDiUngKhong && current.Checked)
            {
                // Nếu chọn 'Không', bỏ chọn 'Có'
                chkDiUngCo.Checked = false;
            }

            // Cập nhật trạng thái hiển thị
            SetTienSuDiUngVisibility();
        }

        // =========================================================
        //                 SỰ KIỆN LƯU (UPDATE)
        // =========================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            // *** BƯỚC KHẮC PHỤC LỖI NULLREFERENCEEXCEPTION ***
            // Kiểm tra các Controls quan trọng có bị null do lỗi Designer không
            if (txtHoTen == null || cboTenKhoa == null || chkDiUngCo == null || txtTienSuDiUng == null)
            {
                MessageBox.Show("LỖI: Các controls giao diện chưa được khởi tạo đúng cách. Vui lòng kiểm tra file fFormUpdatePatient.Designer.cs.", "Lỗi Controls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ************************************************

            // 1. Kiểm tra thông tin bắt buộc
            if (string.IsNullOrEmpty(txtHoTen.Text) || cboTenKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc (Họ Tên, Khoa).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra chi tiết dị ứng
            if (chkDiUngCo.Checked && string.IsNullOrEmpty(txtTienSuDiUng.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập chi tiết tiền sử dị ứng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UpdatePatientData();
                MessageBox.Show("Cập nhật thông tin Bệnh nhân thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Báo cho Form gọi biết đã cập nhật thành công
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật Bệnh nhân: " + ex.Message, "Lỗi chung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        //                 HÀM UPDATE BENHNHAN
        // =========================================================
        private int UpdatePatientData()
        {
            string query = $@"
                UPDATE {PatientTable} 
                SET HoTen = @HoTen, 
                    Tuoi = @Tuoi, 
                    GioiTinh = @GioiTinh, 
                    Phong = @Phong, 
                    Giuong = @Giuong, 
                    ChuanDoan = @ChuanDoan, 
                    TienSuDiUng = @TienSuDiUng, 
                    KhoaID = @KhoaID, 
                    SoTo = @SoTo
                WHERE MaBenhNhan = @MaBenhNhan
            ";

            // Đảm bảo tất cả controls được dùng trong Dictionary đều đã được kiểm tra Null trong btnSave_Click

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "MaBenhNhan", CurrentMaBenhNhan }, // Dùng mã bệnh nhân hiện tại để update
                { "HoTen", txtHoTen.Text.Trim() },
                { "Tuoi", ParseInt(txtTuoi.Text) },
                { "GioiTinh", cboGioiTinh?.SelectedItem?.ToString() ?? (object)DBNull.Value }, // Kiểm tra Null an toàn
                { "Phong", txtPhong.Text },
                { "Giuong", txtGiuong.Text },
                { "ChuanDoan", rtbChanDoan?.Text ?? "" },
                { "TienSuDiUng", GetTienSuDiUng() }, // Hàm xử lý checkbox
                { "KhoaID", cboTenKhoa.SelectedValue ?? (object)DBNull.Value }, // Kiểm tra Null an toàn
                { "SoTo", txtSoTo?.Text ?? "" }
            };

            // Sử dụng ExecuteNonQueryWithParams
            return DataProvider.Instance.ExecuteNonQueryWithParams(query, parameters);
        }

        // =========================================================
        //                 HÀM HỖ TRỢ CHUYỂN ĐỔI DỮ LIỆU
        // =========================================================

        // Xử lý TienSuDiUng từ CheckBox
        private string GetTienSuDiUng()
        {
            if (chkDiUngKhong != null && chkDiUngKhong.Checked) return "Không";
            if (chkDiUngCo != null && chkDiUngCo.Checked) return txtTienSuDiUng?.Text.Trim() ?? "";
            return null;
        }

        // Chuyển đổi string sang INT (Có thể NULL)
        private object ParseInt(string text)
        {
            if (int.TryParse(text, out int value))
            {
                return value;
            }
            return DBNull.Value;
        }

        // Chuyển đổi string sang DECIMAL (Có thể NULL)
        private object ParseDecimal(string text)
        {
            if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
            {
                return value;
            }
            return DBNull.Value;
        }

        // Chuyển đổi CheckBox sang BIT (1/0)
        private int ToBit(CheckBox chk)
        {
            return chk != null && chk.Checked ? 1 : 0;
        }
    }
}