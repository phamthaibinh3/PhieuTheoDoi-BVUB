using BVUB_PhieuTheoDoi.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace BVUB_PhieuTheoDoi
{
    public partial class fFormAddPatient : Form
    {
        // =========================================================
        //                 KHAI BÁO BIẾN CỐ ĐỊNH (Tên Bảng)
        // =========================================================
        private const string PatientTable = "BenhNhan";
        private const string MonitoringSheetTable = "TheoDoi";
        private const string KhoaTable = "Khoa";
        private const string DieuDuongTable = "DieuDuong";

        // Biến để lưu trữ MaDieuDuong hiện tại (Cần truyền từ Form đăng nhập/Form chính)
        private string MaDieuDuongLoggedIn = "DD001"; // <--- CẦN THAY ĐỔI THEO THỰC TẾ 

        // =========================================================
        //                 CONSTRUCTOR & KHỞI TẠO
        // =========================================================
        public fFormAddPatient()
        {
            InitializeComponent();
            this.Load += fFormAddPatient_Load;
            this.btnSave.Click += btnSave_Click;

            // *** Đăng ký sự kiện CheckBox Dị ứng ***
            this.chkDiUngCo.CheckedChanged += ChkDiUng_CheckedChanged;
            this.chkDiUngKhong.CheckedChanged += ChkDiUng_CheckedChanged;
            // **********************************************

            // Thiết lập giá trị mặc định cho ComboBox nếu cần
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ", "Khác" });
            cboPhanCapCS.Items.AddRange(new string[] { "Cấp I", "Cấp II", "Cấp III" });

            // Mặc định chọn giá trị đầu tiên (hoặc giá trị mong muốn)
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            if (cboPhanCapCS.Items.Count > 0) cboPhanCapCS.SelectedIndex = 0;

            // Mặc định chọn 'Không' cho dị ứng khi form khởi tạo
            if (chkDiUngKhong != null) chkDiUngKhong.Checked = true;
        }

        // =========================================================
        //                 SỰ KIỆN LOAD FORM
        // =========================================================
        private void fFormAddPatient_Load(object sender, EventArgs e)
        {
            LoadKhoaData();
            LoadDieuDuongData();
            DisplayLoggedInNurseName();

            // 1. TỰ ĐỘNG TẠO MÃ BỆNH NHÂN & SỐ VÀO VIỆN
            txtMaBenhNhan.Text = GenerateNewMaBenhNhan();
            txtSoVaoVien.Text = GenerateNewSoVaoVien();
            txtMaBenhNhan.ReadOnly = true; // Không cho sửa
            txtSoVaoVien.ReadOnly = true; // Không cho sửa

            // 2. KHỞI TẠO TRẠNG THÁI HIỂN THỊ DỊ ỨNG
            SetTienSuDiUngVisibility();
        }

        private void DisplayLoggedInNurseName()
        {
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

        private void LoadKhoaData()
        {
            try
            {
                string query = $"SELECT * FROM {KhoaTable}";
                DataTable dt = DataProvider.Instance.ExecuteQuery(query);

                cboTenKhoa.DataSource = dt;
                cboTenKhoa.DisplayMember = "TenKhoa";
                cboTenKhoa.ValueMember = "KhoaID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDieuDuongData()
        {
            try
            {
                string query = $"SELECT MaDieuDuong, HoTen FROM {DieuDuongTable}";
                DataTable dt = DataProvider.Instance.ExecuteQuery(query);
                // Nếu muốn cho phép chọn điều dưỡng ký tên (thay vì dùng MaDieuDuongLoggedIn)
                // cboDieuDuongKyTen.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Điều dưỡng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        //                 HÀM TẠO MÃ TỰ ĐỘNG
        // =========================================================

        private string GenerateNewMaBenhNhan()
        {
            // Lấy mã lớn nhất hiện có
            string query = $"SELECT MAX(MaBenhNhan) FROM {PatientTable}";
            object result = DataProvider.Instance.ExecuteScalar(query);

            string currentMaxID = result != DBNull.Value && result != null ? result.ToString() : "BN0000";

            // Xử lý tăng số
            if (currentMaxID.StartsWith("BN") && currentMaxID.Length > 2)
            {
                if (int.TryParse(currentMaxID.Substring(2), out int number))
                {
                    // Định dạng số 4 chữ số (D4)
                    return "BN" + (number + 1).ToString("D4");
                }
            }
            return "BN0001";
        }

        private string GenerateNewSoVaoVien()
        {
            // Ép kiểu sang BIGINT để đảm bảo an toàn số lớn khi MAX
            string query = $"SELECT MAX(CAST(SoVaoVien AS BIGINT)) FROM {PatientTable} WHERE ISNUMERIC(SoVaoVien) = 1";
            object result = DataProvider.Instance.ExecuteScalar(query);

            if (result != DBNull.Value && result != null && long.TryParse(result.ToString(), out long number))
            {
                return (number + 1).ToString();
            }
            return "100001"; // Giá trị mặc định ban đầu
        }

        // =========================================================
        //                 LOGIC ẨN/HIỆN TIỀN SỬ DỊ ỨNG
        // =========================================================

        private void SetTienSuDiUngVisibility()
        {
            // Textbox dị ứng và Label chỉ hiện khi checkbox 'Có' được chọn
            txtTienSuDiUng.Visible = chkDiUngCo.Checked;
            // Giả sử có labelTienSuDiUng đi kèm
            // labelTienSuDiUng.Visible = chkDiUngCo.Checked; 

            // Nếu không hiện (tức là chọn 'Không'), xóa nội dung
            if (!chkDiUngCo.Checked)
            {
                txtTienSuDiUng.Text = string.Empty;
            }
        }

        private void ChkDiUng_CheckedChanged(object sender, EventArgs e)
        {
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
        //                 SỰ KIỆN LƯU (SAVE)
        // =========================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBenhNhan.Text) || string.IsNullOrEmpty(txtHoTen.Text) ||
                string.IsNullOrEmpty(txtSoVaoVien.Text) || cboTenKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc (Mã BN, Họ Tên, Số Vào Viện, Khoa).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trường hợp chọn 'Có' dị ứng mà chưa nhập chi tiết
            if (chkDiUngCo.Checked && string.IsNullOrEmpty(txtTienSuDiUng.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập chi tiết tiền sử dị ứng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                AddPatientAndSheet();
                MessageBox.Show("Thêm mới Bệnh nhân và Phiếu theo dõi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi thêm thành công
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2627) // Lỗi khóa chính/Unique key
                {
                    MessageBox.Show("Mã Bệnh nhân hoặc Số Vào Viện đã tồn tại. Vui lòng kiểm tra lại.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi SQL khi thêm dữ liệu: " + sqlex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm Bệnh nhân: " + ex.Message, "Lỗi chung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        //                 HÀM THÊM BỆNH NHÂN VÀ PHIẾU
        // =========================================================
        private void AddPatientAndSheet()
        {
            DataProvider.Instance.BeginTransaction(); // Bắt đầu Transaction

            try
            {
                // 1. THÊM VÀO BẢNG BENHNHAN
                int patientResult = InsertPatient();

                // 2. THÊM VÀO BẢNG THEODOI
                int sheetResult = InsertMonitoringSheet();

                if (patientResult > 0 && sheetResult > 0)
                {
                    DataProvider.Instance.CommitTransaction(); // Commit nếu cả hai đều thành công
                }
                else
                {
                    DataProvider.Instance.RollbackTransaction(); // Rollback nếu có vấn đề
                    throw new Exception("Không thể thêm đủ thông tin Bệnh nhân và Phiếu Theo Dõi.");
                }
            }
            catch
            {
                DataProvider.Instance.RollbackTransaction(); // Rollback nếu có lỗi Exception
                throw; // Ném lại lỗi để hàm gọi có thể bắt
            }
        }

        // =========================================================
        //                 HÀM INSERT BENHNHAN
        // =========================================================
        private int InsertPatient()
        {
            string query = $@"
                INSERT INTO {PatientTable} (MaBenhNhan, HoTen, Tuoi, GioiTinh, Phong, Giuong, ChuanDoan, TienSuDiUng, KhoaID, SoVaoVien, SoTo)
                VALUES (@MaBenhNhan, @HoTen, @Tuoi, @GioiTinh, @Phong, @Giuong, @ChuanDoan, @TienSuDiUng, @KhoaID, @SoVaoVien, @SoTo)
            ";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "MaBenhNhan", txtMaBenhNhan.Text.Trim() },
                { "HoTen", txtHoTen.Text.Trim() },
                { "Tuoi", ParseInt(txtTuoi.Text) },
                { "GioiTinh", cboGioiTinh.SelectedItem?.ToString() },
                { "Phong", txtPhong.Text },
                { "Giuong", txtGiuong.Text },
                { "ChuanDoan", rtbChanDoan.Text },
                { "TienSuDiUng", GetTienSuDiUng() }, // Hàm xử lý checkbox
                { "KhoaID", cboTenKhoa.SelectedValue },
                { "SoVaoVien", txtSoVaoVien.Text.Trim() },
                { "SoTo", txtSoTo.Text }
            };

            // Sử dụng ExecuteNonQueryWithParams và Transaction
            return DataProvider.Instance.ExecuteNonQueryWithParams(query, parameters);
        }

        // =========================================================
        //                 HÀM INSERT THEODOI (Phiếu đầu tiên)
        // =========================================================
        private int InsertMonitoringSheet()
        {
            string query = $@"
                INSERT INTO {MonitoringSheetTable} (
                    MaBenhNhan, ThoiGianGhiNhan, MaDieuDuong,
                    TriGiac, DaNiemMac, Phu, TanSoMach, HuyetAp, TanSoTho, NhietDo, Spo2,
                    ChieuCao, CanNang, BMI, TinhChatMach, DHKhacTuanHoan,
                    TinhTrangHoHap, KieuTho, Ho, CheDoTho, DungTichSongVt, ApLucHoTroPS, PEEP, TanSoThoMay, Fio2,
                    TinhTrangBung, RoiLoanNuot, DayBungKhoTieu, Non, NhuDongRuot, DaiTien, HauMonNhanTao,
                    NguyCoSDD, CheDoAn, TinhTrangAn, DuongAn,
                    HinhThucDiTieu, MauSacNuocTieu, SoLuongNuocTieu, TieuRatBuot, BoPhanSinhDuc,
                    LoiNoi, YeuLiet, RoiLoanVanDong, DHKhacThanKinh, TinhThan, GiacNgu,
                    VanDong, VanDeKhacCXK,
                    Dau, VetThuongLoet, DanLuu, NguyCoNga, CanhBaoSom,
                    TongNhap, TongXuat, PhanCapChamSoc,
                    CDDD1, MucTieuCDDD1, CDDD2, MucTieuCDDD2, CDDD3, MucTieuCDDD3, CDDD4, MucTieuCDDD4,
                    ThucHienYLenh, ThucHienCanLS, ChamSocDieuDuong, BanGiao
                )
                VALUES (
                    @MaBenhNhan, @ThoiGianGhiNhan, @MaDieuDuong,
                    @TriGiac, @DaNiemMac, @Phu, @TanSoMach, @HuyetAp, @TanSoTho, @NhietDo, @Spo2,
                    @ChieuCao, @CanNang, @BMI, @TinhChatMach, @DHKhacTuanHoan,
                    @TinhTrangHoHap, @KieuTho, @Ho, @CheDoTho, @DungTichSongVt, @ApLucHoTroPS, @PEEP, @TanSoThoMay, @Fio2,
                    @TinhTrangBung, @RoiLoanNuot, @DayBungKhoTieu, @Non, @NhuDongRuot, @DaiTien, @HauMonNhanTao,
                    @NguyCoSDD, @CheDoAn, @TinhTrangAn, @DuongAn,
                    @HinhThucDiTieu, @MauSacNuocTieu, @SoLuongNuocTieu, @TieuRatBuot, @BoPhanSinhDuc,
                    @LoiNoi, @YeuLiet, @RoiLoanVanDong, @DHKhacThanKinh, @TinhThan, @GiacNgu,
                    @VanDong, @VanDeKhacCXK,
                    @Dau, @VetThuongLoet, @DanLuu, @NguyCoNga, @CanhBaoSom,
                    @TongNhap, @TongXuat, @PhanCapChamSoc,
                    @CDDD1, @MucTieuCDDD1, @CDDD2, @MucTieuCDDD2, @CDDD3, @MucTieuCDDD3, @CDDD4, @MucTieuCDDD4,
                    @ThucHienYLenh, @ThucHienCanLS, @ChamSocDieuDuong, @BanGiao
                )
            ";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                // MỤC CHUNG
                { "MaBenhNhan", txtMaBenhNhan.Text.Trim() },
                { "ThoiGianGhiNhan", DateTime.Now },
                { "MaDieuDuong", MaDieuDuongLoggedIn }, // Lấy từ biến logged in

                // I. TOÀN TRẠNG
                { "TriGiac", rtbTriGiac.Text },
                { "DaNiemMac", rtbDaNiemMac.Text },
                { "Phu", rtbPhu.Text },

                // II. DẤU HIỆU SINH TỒN
                { "TanSoMach", ParseInt(txtTanSoMach.Text) },
                { "HuyetAp", txtHuyetAp.Text },
                { "TanSoTho", ParseInt(txtTanSoTho.Text) },
                { "NhietDo", ParseDecimal(txtNhietDo.Text) },
                { "Spo2", ParseDecimal(txtSpO2.Text) },

                // III. CHỈ SỐ CÂN NẶNG, CHIỀU CAO (Lấy từ Form)
                { "ChieuCao", ParseDecimal(txtChieuCao.Text) },
                { "CanNang", ParseDecimal(txtCanNang.Text) },
                { "BMI", ParseDecimal(txtBMI.Text) },

                // IV. TUẦN HOÀN
                { "TinhChatMach", rtbTuanHoan.Text }, // Gộp TinhChatMach và DHKhacTuanHoan
                { "DHKhacTuanHoan", DBNull.Value }, // Đặt là NULL/Default nếu đã gộp

                // V. HÔ HẤP
                { "TinhTrangHoHap", rtbTinhTrangHoHap.Text },
                { "KieuTho", rtbKieuTho.Text },
                { "Ho", rtbHo.Text },
                { "CheDoTho", rtbCheDoTho.Text },
                { "DungTichSongVt", ParseDecimal(txtDungTichSongVt.Text) },
                { "ApLucHoTroPS", ParseDecimal(txtApLucHoTroPS.Text) },
                { "PEEP", ParseDecimal(txtPEEP.Text) },
                { "TanSoThoMay", ParseInt(txtTanSoThoMay.Text) },
                { "Fio2", ParseDecimal(txtFio2.Text) },

                // VI. TIÊU HÓA
                { "TinhTrangBung", rtbTinhTrangBung.Text },
                { "RoiLoanNuot", ToBit(chkRoiLoanNuot) },
                { "DayBungKhoTieu", ToBit(chkDayBungKhoTieu) },
                { "Non", rtbNon.Text },
                { "NhuDongRuot", rtbNhuDongRuot.Text },
                { "DaiTien", rtbDaiTien.Text },
                { "HauMonNhanTao", ToBit(chkHauMonNhanTao) },

                // VII. DINH DƯỠNG
                { "NguyCoSDD", rtbNguyCoSDD.Text },
                { "CheDoAn", rtbCheDoAn.Text },
                { "TinhTrangAn", rtbTinhTrangAn.Text },
                { "DuongAn", rtbDuongAn.Text },

                // VIII. TIẾT NIỆU SINH DỤC
                { "HinhThucDiTieu", rtbHinhThucDiTieu.Text },
                { "MauSacNuocTieu", rtbMauSacNuocTieu.Text },
                { "SoLuongNuocTieu", ParseDecimal(txtSoLuongNuocTieu.Text) },
                { "TieuRatBuot", ToBit(chkTieuRatBuot) },
                { "BoPhanSinhDuc", rtbBoPhanSD.Text },

                // IX. THẦN KINH, X. TINH THẦN, GIẤC NGỦ (Gộp chung trong Designer)
                { "LoiNoi", rtbThanKinh.Text }, // Dùng chung rtbThanKinh
                { "YeuLiet", DBNull.Value },
                { "RoiLoanVanDong", DBNull.Value },
                { "DHKhacThanKinh", DBNull.Value },
                { "TinhThan", DBNull.Value },
                { "GiacNgu", DBNull.Value },

                // XI. CƠ XƯƠNG KHỚP
                { "VanDong", rtbCoXuongKhop.Text }, // Dùng chung rtbCoXuongKhop
                { "VanDeKhacCXK", DBNull.Value },

                // XII. NHẬN ĐỊNH KHÁC (Đã gộp vào rtbNhanDinhKhac)
                { "Dau", rtbNhanDinhKhac.Text }, // Dùng chung rtbNhanDinhKhac
                { "VetThuongLoet", DBNull.Value },
                { "DanLuu", DBNull.Value },
                { "NguyCoNga", DBNull.Value },
                { "CanhBaoSom", DBNull.Value },

                // XIII. THEO DÕI NHẬP/XUẤT
                { "TongNhap", ParseDecimal(txtTongNhap.Text) },
                { "TongXuat", ParseDecimal(txtTongXuat.Text) },

                // XIV. PHÂN CẤP CHĂM SÓC
                { "PhanCapChamSoc", cboPhanCapCS.SelectedItem?.ToString() },

                // XV. CHẨN ĐOÁN ĐIỀU DƯỠNG (CDDD1-4)
                { "CDDD1", rtbChanDoanDD.Text },
                { "MucTieuCDDD1", rtbMucTieuCDDD1.Text },
                { "CDDD2", rtbChanDoanDD2.Text },
                { "MucTieuCDDD2", rtbMucTieuCDDD2.Text },
                { "CDDD3", rtbChanDoanDD3.Text },
                { "MucTieuCDDD3", rtbMucTieuCDDD3.Text },
                { "CDDD4", rtbChanDoanDD4.Text },
                { "MucTieuCDDD4", rtbMucTieuCDDD4.Text },

                // XVI. CAN THIỆP ĐIỀU DƯỠNG
                { "ThucHienYLenh", rtbCanThiepDD.Text }, // Dùng rtbCanThiepDD cho YLenh
                { "ThucHienCanLS", DBNull.Value },
                { "ChamSocDieuDuong", DBNull.Value },

                // XVII. BÀN GIAO
                { "BanGiao", rtbBanGiao.Text }
            };

            // Sử dụng ExecuteNonQueryWithParams và Transaction
            return DataProvider.Instance.ExecuteNonQueryWithParams(query, parameters);
        }

        // =========================================================
        //                 HÀM HỖ TRỢ CHUYỂN ĐỔI DỮ LIỆU
        // =========================================================

        // Xử lý TienSuDiUng từ CheckBox
        private string GetTienSuDiUng()
        {
            if (chkDiUngKhong.Checked) return "Không";
            if (chkDiUngCo.Checked) return txtTienSuDiUng.Text.Trim();
            return null; // Không chọn
        }

        // Chuyển đổi CheckBox sang BIT (1/0)
        private int ToBit(CheckBox chk)
        {
            return chk != null && chk.Checked ? 1 : 0;
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
            // Sử dụng InvariantCulture để đảm bảo dấu chấm là dấu thập phân (ví dụ: 1.5)
            if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
            {
                return value;
            }
            return DBNull.Value;
        }
    }
}