using BVUB_PhieuTheoDoi.DAO;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;
using System.Drawing; // Thêm thư viện này cho DataGridViewCellStyle

namespace BVUB_PhieuTheoDoi
{
    public partial class Form1 : Form
    {
        // =========================================================
        //                 KHAI BÁO BIẾN CỐ ĐỊNH (Tên Bảng)
        // =========================================================
        private DataTable allSheetData; // Lưu trữ tất cả dữ liệu phiếu theo dõi của BN hiện tại
        private DataTable dtReportData; // Biến này dùng cho báo cáo (nếu có)

        private const string PatientTable = "BenhNhan";
        private const string MonitoringSheetTable = "TheoDoi";
        private const string KhoaTable = "Khoa";
        private const string DieuDuongTable = "DieuDuong"; // Cần cho việc lấy HoTenDieuDuong

        // =========================================================
        //                 CONSTRUCTOR & KHỞI TẠO
        // =========================================================
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            // Đăng ký sự kiện
            if (cmbMaBenhNhan != null)
            {
                this.cmbMaBenhNhan.SelectedIndexChanged += cmbMaBenhNhan_SelectedIndexChanged;
            }
            this.dgvTheoDoi.SelectionChanged += dgvTheoDoi_SelectionChanged;

            this.btnAddPatient.Click += btnAddPatient_Click; // Tên hàm đã được sửa gọn
            this.btnUpdatePatient.Click += btnUpdatePatient_Click;
            this.btnResetColumns.Click += btnResetColumns_Click;
            // Nếu có nút btnReport, bạn cần đăng ký sự kiện ở đây
            // this.btnReport.Click += btnReport_Click; 
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. Thiết lập DataGridView
            SetupDataGridView();

            // 2. Tải dữ liệu ban đầu
            LoadPatientList();

            if (cmbMaBenhNhan.Items.Count > 0)
            {
                cmbMaBenhNhan.SelectedIndex = 0;
            }
            else
            {
                ClearPatientDetails();
                SetPatientInfoReadOnly(true);
            }
        }

        // =========================================================
        //                 LOGIC TẢI DỮ LIỆU
        // =========================================================

        /// <summary>
        /// Tải danh sách bệnh nhân và đưa vào ComboBox.
        /// </summary>
        private void LoadPatientList()
        {
            string query = $"SELECT MaBenhNhan, HoTen FROM {PatientTable} ORDER BY MaBenhNhan DESC";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            string currentSelectedId = cmbMaBenhNhan.SelectedValue?.ToString();

            cmbMaBenhNhan.DataSource = dt;
            cmbMaBenhNhan.DisplayMember = "HoTen";
            cmbMaBenhNhan.ValueMember = "MaBenhNhan";

            // Giữ lại bệnh nhân đang được chọn sau khi tải lại
            if (!string.IsNullOrEmpty(currentSelectedId) && dt.AsEnumerable().Any(row => row.Field<string>("MaBenhNhan") == currentSelectedId))
            {
                cmbMaBenhNhan.SelectedValue = currentSelectedId;
            }
            else if (dt.Rows.Count > 0)
            {
                cmbMaBenhNhan.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Tải thông tin chi tiết Bệnh nhân lên các TextBox.
        /// </summary>
        private void LoadPatientInfo(string maBenhNhan)
        {
            try
            {
                string query = $@"
                    SELECT 
                        bn.*, 
                        k.TenKhoa 
                    FROM {PatientTable} bn
                    JOIN {KhoaTable} k ON bn.KhoaID = k.KhoaID
                    WHERE bn.MaBenhNhan = @MaBenhNhan";

                Dictionary<string, object> parameters = new Dictionary<string, object> { { "MaBenhNhan", maBenhNhan } };
                DataTable dt = DataProvider.Instance.ExecuteQueryWithParams(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    // Ánh xạ dữ liệu vào các controls (Giả định các controls này tồn tại)
                    txtMaBenhNhan.Text = row["MaBenhNhan"].ToString();
                    txtHoTen.Text = row["HoTen"].ToString();
                    txtTuoi.Text = row["Tuoi"].ToString();
                    // Giả định có txtGioiTinh và txtTenKhoa trong Designer
                    txtGioiTinh.Text = row["GioiTinh"].ToString();
                    txtTenKhoa.Text = row["TenKhoa"].ToString();
                    txtPhong.Text = row["Phong"].ToString();
                    txtGiuong.Text = row["Giuong"].ToString();
                    txtChanDoan.Text = row["ChuanDoan"].ToString();
                    txtTienSuDiUng.Text = row["TienSuDiUng"].ToString();

                    // Cập nhật CheckBox Dị ứng
                    string diUng = row["TienSuDiUng"].ToString();
                    chkDiUngKhong.Checked = diUng == "Không dị ứng";
                    chkDiUngCo.Checked = !string.IsNullOrEmpty(diUng) && diUng != "Không dị ứng";

                    SetPatientInfoReadOnly(true);
                }
                else
                {
                    ClearPatientDetails();
                    SetPatientInfoReadOnly(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin bệnh nhân: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải các phiếu theo dõi của bệnh nhân và đưa vào DataGridView.
        /// </summary>
        private void LoadMonitoringSheets(string maBenhNhan)
        {
            try
            {
                string query = $@"
                    SELECT 
                        td.*, 
                        dd.HoTen AS HoTenDieuDuong 
                    FROM {MonitoringSheetTable} td
                    LEFT JOIN {DieuDuongTable} dd ON td.MaDieuDuong = dd.MaDieuDuong
                    WHERE td.MaBenhNhan = @MaBenhNhan
                    ORDER BY td.ThoiGianGhiNhan DESC";

                Dictionary<string, object> parameters = new Dictionary<string, object> { { "MaBenhNhan", maBenhNhan } };
                allSheetData = DataProvider.Instance.ExecuteQueryWithParams(query, parameters);

                dgvTheoDoi.DataSource = allSheetData;
                ConfigureDGVColumns();

                // Xóa chi tiết chẩn đoán/can thiệp cũ
                rtbChanDoanDD.Clear();
                rtbCanThiepDD.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải phiếu theo dõi: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dgvTheoDoi.DataSource is DataTable dt)
                {
                    dt.Clear();
                }
            }
        }

        // =========================================================
        //                 LOGIC XỬ LÝ SỰ KIỆN
        // =========================================================

        private void cmbMaBenhNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaBenhNhan.SelectedValue is string maBenhNhan && !string.IsNullOrEmpty(maBenhNhan))
            {
                LoadPatientInfo(maBenhNhan);
                LoadMonitoringSheets(maBenhNhan);
            }
            else
            {
                ClearPatientDetails();
                if (dgvTheoDoi.DataSource is DataTable dt)
                {
                    dt.Clear();
                }
            }
        }

        private void dgvTheoDoi_SelectionChanged(object sender, EventArgs e)
        {
            // Tránh lỗi khi DataGridView đang bị cập nhật hoặc không có dòng nào
            if (dgvTheoDoi.SelectedRows.Count == 0 || allSheetData == null)
            {
                rtbChanDoanDD.Clear();
                rtbCanThiepDD.Clear();
                return;
            }

            DataGridViewRow selectedRow = dgvTheoDoi.SelectedRows[0];

            // Lấy TheoDoiID (khóa chính của phiếu theo dõi)
            object theoDoiIDValue = selectedRow.Cells["TheoDoiID"].Value;
            if (theoDoiIDValue == null || !long.TryParse(theoDoiIDValue.ToString(), out long theoDoiID)) return;

            // Tìm DataRow tương ứng trong DataTable nguồn
            DataRow row = allSheetData.AsEnumerable().FirstOrDefault(r => r.Field<long>("TheoDoiID") == theoDoiID);

            if (row != null)
            {
                // Hiển thị chi tiết Chẩn đoán và Can thiệp
                rtbChanDoanDD.Text = "CDDD 1: " + row["CDDD1"].ToString() + Environment.NewLine +
                                     "Mục tiêu 1: " + row["MucTieuCDDD1"].ToString() + Environment.NewLine +
                                     "CDDD 2: " + row["CDDD2"].ToString() + Environment.NewLine +
                                     "Mục tiêu 2: " + row["MucTieuCDDD2"].ToString();

                rtbCanThiepDD.Text = "Thực hiện Y Lệnh: " + row["ThucHienYLenh"].ToString() + Environment.NewLine +
                                     "Can Thiệp Cận Lâm Sàng: " + row["ThucHienCanLS"].ToString() + Environment.NewLine +
                                     "Chăm Sóc Điều Dưỡng: " + row["ChamSocDieuDuong"].ToString();
            }
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            // Mở Form Thêm mới
            // Giả định fFormAddPatient có constructor không tham số cho chế độ Thêm mới
            using (fFormAddPatient f = new fFormAddPatient())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadPatientList(); // Tải lại danh sách BN
                }
            }
        }

        private void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            if (cmbMaBenhNhan.SelectedValue is string maBenhNhan && !string.IsNullOrEmpty(maBenhNhan))
            {
                // Mở Form Cập nhật, truyền MaBenhNhan vào constructor
                using (fFormAddPatient f = new fFormAddPatient())
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        // Sau khi cập nhật thành công, tải lại dữ liệu hiện tại
                        LoadPatientInfo(maBenhNhan);
                        LoadMonitoringSheets(maBenhNhan);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bệnh nhân để Cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnResetColumns_Click(object sender, EventArgs e)
        {
            LoadPatientList();
            if (cmbMaBenhNhan.SelectedValue is string maBenhNhan && !string.IsNullOrEmpty(maBenhNhan))
            {
                LoadPatientInfo(maBenhNhan);
                LoadMonitoringSheets(maBenhNhan);
            }
            else
            {
                ClearPatientDetails();
            }
        }

        // =========================================================
        //                 HÀM HỖ TRỢ HIỂN THỊ
        // =========================================================

        /// <summary>
        /// Thiết lập cấu trúc cột ban đầu cho DataGridView.
        /// </summary>
        private void SetupDataGridView()
        {
            dgvTheoDoi.AutoGenerateColumns = false;
            dgvTheoDoi.AllowUserToAddRows = false;
            dgvTheoDoi.MultiSelect = false;
            dgvTheoDoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTheoDoi.ReadOnly = true;

            // Khai báo các cột cần hiển thị
            dgvTheoDoi.Columns.Clear();
            dgvTheoDoi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID Phiếu", DataPropertyName = "TheoDoiID", Name = "TheoDoiID", Visible = false });
            dgvTheoDoi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thời Gian Ghi Nhận", DataPropertyName = "ThoiGianGhiNhan", Name = "ThoiGianGhiNhan", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvTheoDoi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đ/D Ký Tên", DataPropertyName = "HoTenDieuDuong", Name = "HoTenDieuDuong", Width = 150 });
            dgvTheoDoi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mạch", DataPropertyName = "TanSoMach", Name = "TanSoMach", Width = 60 });
            dgvTheoDoi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "HA (mmHg)", DataPropertyName = "HuyetAp", Name = "HuyetAp", Width = 90 });
            dgvTheoDoi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tri Giác", DataPropertyName = "TriGiac", Name = "TriGiac", Width = 100 });
            dgvTheoDoi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "CDDD (1)", DataPropertyName = "CDDD1", Name = "CDDD1", Width = 250 });
            // Thêm các cột quan trọng khác tùy theo nhu cầu hiển thị tóm tắt
        }

        /// <summary>
        /// Đảm bảo các cột DGV được ẩn và format đúng sau khi tải dữ liệu.
        /// </summary>
        private void ConfigureDGVColumns()
        {
            // Nếu dùng SetupDataGridView, hàm này chỉ để đảm bảo nếu có thay đổi.
            // Trong trường hợp này, SetupDataGridView đã làm hết, nên hàm này có thể rỗng hoặc được dùng để tối ưu hóa hiển thị.
        }

        private void ClearPatientDetails()
        {
            txtMaBenhNhan.Clear();
            txtHoTen.Clear();
            txtTuoi.Clear();
            txtGioiTinh.Clear();
            txtTenKhoa.Clear();
            txtPhong.Clear();
            txtGiuong.Clear();
            txtChanDoan.Clear();
            txtTienSuDiUng.Clear();
            chkDiUngCo.Checked = false;
            chkDiUngKhong.Checked = false;
            rtbChanDoanDD.Clear();
            rtbCanThiepDD.Clear();
        }

        private void SetPatientInfoReadOnly(bool isReadOnly)
        {
            // Toàn bộ thông tin hành chính là ReadOnly, chỉ dùng để hiển thị
            txtMaBenhNhan.ReadOnly = isReadOnly;
            txtHoTen.ReadOnly = isReadOnly;
            txtTuoi.ReadOnly = isReadOnly;
            txtGioiTinh.ReadOnly = isReadOnly;
            txtTenKhoa.ReadOnly = isReadOnly;
            txtPhong.ReadOnly = isReadOnly;
            txtGiuong.ReadOnly = isReadOnly;
            txtChanDoan.ReadOnly = isReadOnly;
            txtTienSuDiUng.ReadOnly = isReadOnly;

            // Checkbox và RichTextBox cũng phải ReadOnly/Disabled
            chkDiUngCo.Enabled = !isReadOnly;
            chkDiUngKhong.Enabled = !isReadOnly;
            rtbChanDoanDD.ReadOnly = true;
            rtbCanThiepDD.ReadOnly = true;
        }

        // ... (Nếu có btnReport_Click, bạn sẽ thêm logic xuất báo cáo Crystal Report vào đây) ...
    }
}