using System.Drawing;
using System.Windows.Forms;

namespace BVUB_PhieuTheoDoi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // =========================================================
        //                 KHAI BÁO CONTROLS ĐẦY ĐỦ
        // =========================================================
        private System.Windows.Forms.DataGridView dgvTheoDoi;
        private System.Windows.Forms.ComboBox cmbMaBenhNhan;
        private System.Windows.Forms.TextBox txtMaBenhNhan;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtTuoi;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.TextBox txtGiuong;
        private System.Windows.Forms.TextBox txtChanDoan;
        private System.Windows.Forms.TextBox txtTienSuDiUng;
        private System.Windows.Forms.CheckBox chkDiUngCo;
        private System.Windows.Forms.CheckBox chkDiUngKhong;
        private System.Windows.Forms.RichTextBox rtbChanDoanDD;
        private System.Windows.Forms.RichTextBox rtbCanThiepDD;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.Button btnUpdatePatient;
        private System.Windows.Forms.Button btnResetColumns;
        private System.Windows.Forms.Label lblMaBenhNhan;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblTuoi;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblGiuong;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.Label lblChanDoan;
        private System.Windows.Forms.Label lblTienSuDiUng;
        private System.Windows.Forms.Label lblChanDoanHeader;
        private System.Windows.Forms.Label lblCanThiepHeader;
        private System.Windows.Forms.GroupBox groupBoxPatientInfo;
        private System.Windows.Forms.GroupBox groupBoxCDCT;
        private System.Windows.Forms.Button btnReport;

        // CONTROLS CHO KHOA ĐÃ THIẾT KẾ LẠI
        private System.Windows.Forms.Label lblTenKhoa;
        private System.Windows.Forms.TextBox txtTenKhoa;


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
            this.dgvTheoDoi = new System.Windows.Forms.DataGridView();
            this.cmbMaBenhNhan = new System.Windows.Forms.ComboBox();
            this.txtMaBenhNhan = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.txtGiuong = new System.Windows.Forms.TextBox();
            this.txtChanDoan = new System.Windows.Forms.TextBox();
            this.txtTienSuDiUng = new System.Windows.Forms.TextBox();
            this.chkDiUngCo = new System.Windows.Forms.CheckBox();
            this.chkDiUngKhong = new System.Windows.Forms.CheckBox();
            this.rtbChanDoanDD = new System.Windows.Forms.RichTextBox();
            this.rtbCanThiepDD = new System.Windows.Forms.RichTextBox();
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.btnUpdatePatient = new System.Windows.Forms.Button();
            this.btnResetColumns = new System.Windows.Forms.Button();
            this.lblMaBenhNhan = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblTuoi = new System.Windows.Forms.Label();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblGiuong = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.lblChanDoan = new System.Windows.Forms.Label();
            this.lblTienSuDiUng = new System.Windows.Forms.Label();
            this.lblChanDoanHeader = new System.Windows.Forms.Label();
            this.lblCanThiepHeader = new System.Windows.Forms.Label();
            this.groupBoxPatientInfo = new System.Windows.Forms.GroupBox();
            this.groupBoxCDCT = new System.Windows.Forms.GroupBox();
            this.btnReport = new System.Windows.Forms.Button();

            // Khởi tạo controls mới cho Khoa
            this.lblTenKhoa = new System.Windows.Forms.Label();
            this.txtTenKhoa = new System.Windows.Forms.TextBox();

            // Lấy lại các controls trong GroupBox
            this.groupBoxPatientInfo.SuspendLayout();
            this.groupBoxCDCT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheoDoi)).BeginInit();
            this.SuspendLayout();

            // 
            // Cấu hình Form chung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800); // Kích thước form
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnResetColumns);
            this.Controls.Add(this.btnUpdatePatient);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.cmbMaBenhNhan);
            this.Controls.Add(this.groupBoxCDCT);
            this.Controls.Add(this.groupBoxPatientInfo);
            this.Controls.Add(this.dgvTheoDoi);
            this.Name = "Form1";
            this.Text = "Quản Lý Phiếu Theo Dõi";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // 
            // dgvTheoDoi
            // 
            this.dgvTheoDoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTheoDoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTheoDoi.Location = new System.Drawing.Point(12, 50);
            this.dgvTheoDoi.Name = "dgvTheoDoi";
            this.dgvTheoDoi.RowHeadersWidth = 51;
            this.dgvTheoDoi.RowTemplate.Height = 24;
            this.dgvTheoDoi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTheoDoi.Size = new System.Drawing.Size(1176, 350);
            this.dgvTheoDoi.TabIndex = 0;

            // 
            // cmbMaBenhNhan
            // 
            this.cmbMaBenhNhan.FormattingEnabled = true;
            this.cmbMaBenhNhan.Location = new System.Drawing.Point(12, 17);
            this.cmbMaBenhNhan.Name = "cmbMaBenhNhan";
            this.cmbMaBenhNhan.Size = new System.Drawing.Size(150, 26);
            this.cmbMaBenhNhan.TabIndex = 1;

            // 
            // groupBoxPatientInfo (ĐÃ CẬP NHẬT DESIGN)
            // 
            this.groupBoxPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPatientInfo.Controls.Add(this.lblTenKhoa);
            this.groupBoxPatientInfo.Controls.Add(this.txtTenKhoa);
            this.groupBoxPatientInfo.Controls.Add(this.txtMaBenhNhan);
            this.groupBoxPatientInfo.Controls.Add(this.lblMaBenhNhan);
            this.groupBoxPatientInfo.Controls.Add(this.txtHoTen);
            this.groupBoxPatientInfo.Controls.Add(this.lblHoTen);
            this.groupBoxPatientInfo.Controls.Add(this.txtTuoi);
            this.groupBoxPatientInfo.Controls.Add(this.lblTuoi);
            this.groupBoxPatientInfo.Controls.Add(this.txtGioiTinh);
            this.groupBoxPatientInfo.Controls.Add(this.lblGioiTinh);
            this.groupBoxPatientInfo.Controls.Add(this.txtPhong);
            this.groupBoxPatientInfo.Controls.Add(this.lblPhong);
            this.groupBoxPatientInfo.Controls.Add(this.txtGiuong);
            this.groupBoxPatientInfo.Controls.Add(this.lblGiuong);
            this.groupBoxPatientInfo.Controls.Add(this.txtChanDoan);
            this.groupBoxPatientInfo.Controls.Add(this.lblChanDoan);
            this.groupBoxPatientInfo.Controls.Add(this.txtTienSuDiUng);
            this.groupBoxPatientInfo.Controls.Add(this.lblTienSuDiUng);
            this.groupBoxPatientInfo.Controls.Add(this.chkDiUngCo);
            this.groupBoxPatientInfo.Controls.Add(this.chkDiUngKhong);
            this.groupBoxPatientInfo.Location = new System.Drawing.Point(12, 415);
            this.groupBoxPatientInfo.Name = "groupBoxPatientInfo";
            this.groupBoxPatientInfo.Size = new System.Drawing.Size(700, 365);
            this.groupBoxPatientInfo.TabIndex = 2;
            this.groupBoxPatientInfo.TabStop = false;
            this.groupBoxPatientInfo.Text = "Thông Tin Hành Chính Bệnh Nhân (Xem)";

            // --- Cấu hình vị trí Controls trong GroupBoxPatientInfo (2 CỘT) ---
            int labelWidth = 100;
            int controlWidth = 190;
            int startX1 = 15;
            int startY = 25;
            int spacingY = 30;
            int startX2 = startX1 + labelWidth + controlWidth + 30; // Cột thứ 2

            // Cột 1: Mã BN, Họ Tên, Tuổi/Giới Tính

            // lblMaBenhNhan
            this.lblMaBenhNhan.AutoSize = true;
            this.lblMaBenhNhan.Location = new System.Drawing.Point(startX1, startY);
            this.lblMaBenhNhan.Text = "Mã Bệnh nhân:";
            // txtMaBenhNhan
            this.txtMaBenhNhan.Location = new System.Drawing.Point(startX1 + labelWidth, startY - 3);
            this.txtMaBenhNhan.Size = new System.Drawing.Size(controlWidth, 24);
            this.txtMaBenhNhan.ReadOnly = true;

            // lblHoTen
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(startX1, startY + spacingY);
            this.lblHoTen.Text = "Họ Tên:";
            // txtHoTen
            this.txtHoTen.Location = new System.Drawing.Point(startX1 + labelWidth, startY + spacingY - 3);
            this.txtHoTen.Size = new System.Drawing.Size(controlWidth, 24);
            this.txtHoTen.ReadOnly = true;

            // lblTuoi
            this.lblTuoi.AutoSize = true;
            this.lblTuoi.Location = new System.Drawing.Point(startX1, startY + 2 * spacingY);
            this.lblTuoi.Text = "Tuổi:";
            // txtTuoi
            this.txtTuoi.Location = new System.Drawing.Point(startX1 + labelWidth, startY + 2 * spacingY - 3);
            this.txtTuoi.Size = new System.Drawing.Size(80, 24);
            this.txtTuoi.ReadOnly = true;

            // lblGioiTinh
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(startX1 + labelWidth + 90, startY + 2 * spacingY);
            this.lblGioiTinh.Text = "Giới tính:";
            // txtGioiTinh
            this.txtGioiTinh.Location = new System.Drawing.Point(startX1 + labelWidth + 150, startY + 2 * spacingY - 3);
            this.txtGioiTinh.Size = new System.Drawing.Size(80, 24);
            this.txtGioiTinh.ReadOnly = true;

            // Cột 2: Khoa, Phòng, Giường

            // lblTenKhoa (MỚI - LÀM NỔI BẬT)
            this.lblTenKhoa.AutoSize = true;
            this.lblTenKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKhoa.Location = new System.Drawing.Point(startX2, startY);
            this.lblTenKhoa.Text = "KHOA:";
            // txtTenKhoa
            this.txtTenKhoa.Location = new System.Drawing.Point(startX2 + labelWidth - 10, startY - 3);
            this.txtTenKhoa.Size = new System.Drawing.Size(controlWidth, 24);
            this.txtTenKhoa.ReadOnly = true;

            // lblPhong
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(startX2, startY + spacingY);
            this.lblPhong.Text = "Phòng:";
            // txtPhong
            this.txtPhong.Location = new System.Drawing.Point(startX2 + labelWidth - 10, startY + spacingY - 3);
            this.txtPhong.Size = new System.Drawing.Size(controlWidth, 24);
            this.txtPhong.ReadOnly = true;

            // lblGiuong
            this.lblGiuong.AutoSize = true;
            this.lblGiuong.Location = new System.Drawing.Point(startX2, startY + 2 * spacingY);
            this.lblGiuong.Text = "Giường:";
            // txtGiuong
            this.txtGiuong.Location = new System.Drawing.Point(startX2 + labelWidth - 10, startY + 2 * spacingY - 3);
            this.txtGiuong.Size = new System.Drawing.Size(controlWidth, 24);
            this.txtGiuong.ReadOnly = true;

            // Chẩn đoán và Dị ứng (Dải ngang)

            // lblChanDoan
            this.lblChanDoan.AutoSize = true;
            this.lblChanDoan.Location = new System.Drawing.Point(startX1, startY + 3 * spacingY);
            this.lblChanDoan.Text = "Chẩn đoán bệnh:";
            // txtChanDoan
            this.txtChanDoan.Location = new System.Drawing.Point(startX1 + labelWidth, startY + 3 * spacingY - 3);
            this.txtChanDoan.Size = new System.Drawing.Size(controlWidth * 2 + labelWidth, 24); // Chiếm cả 2 cột
            this.txtChanDoan.ReadOnly = true;

            // lblTienSuDiUng
            int yDiUng = startY + 4 * spacingY + 10;
            this.lblTienSuDiUng.AutoSize = true;
            this.lblTienSuDiUng.Location = new System.Drawing.Point(startX1, yDiUng);
            this.lblTienSuDiUng.Text = "Tiền sử Dị ứng:";

            // chkDiUngCo (Enabled = false)
            this.chkDiUngCo.AutoSize = true;
            this.chkDiUngCo.Enabled = false;
            this.chkDiUngCo.Location = new System.Drawing.Point(startX1 + labelWidth, yDiUng);
            this.chkDiUngCo.Text = "Có";

            // chkDiUngKhong (Enabled = false)
            this.chkDiUngKhong.AutoSize = true;
            this.chkDiUngKhong.Enabled = false;
            this.chkDiUngKhong.Location = new System.Drawing.Point(startX1 + labelWidth + 50, yDiUng);
            this.chkDiUngKhong.Text = "Không";

            // txtTienSuDiUng
            this.txtTienSuDiUng.Location = new System.Drawing.Point(startX1 + labelWidth, yDiUng + spacingY - 5);
            this.txtTienSuDiUng.Size = new System.Drawing.Size(controlWidth * 2 + labelWidth, 24);
            this.txtTienSuDiUng.ReadOnly = true;


            // 
            // groupBoxCDCT (Chẩn đoán & Can thiệp)
            // 
            this.groupBoxCDCT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCDCT.Controls.Add(this.lblChanDoanHeader);
            this.groupBoxCDCT.Controls.Add(this.rtbChanDoanDD);
            this.groupBoxCDCT.Controls.Add(this.lblCanThiepHeader);
            this.groupBoxCDCT.Controls.Add(this.rtbCanThiepDD);
            this.groupBoxCDCT.Location = new System.Drawing.Point(725, 415);
            this.groupBoxCDCT.Name = "groupBoxCDCT";
            this.groupBoxCDCT.Size = new System.Drawing.Size(463, 365);
            this.groupBoxCDCT.TabIndex = 3;
            this.groupBoxCDCT.TabStop = false;
            this.groupBoxCDCT.Text = "Chẩn đoán và Can thiệp Điều dưỡng (Mới nhất)";

            // 
            // lblChanDoanHeader
            // 
            this.lblChanDoanHeader.AutoSize = true;
            this.lblChanDoanHeader.Location = new System.Drawing.Point(6, 25);
            this.lblChanDoanHeader.Text = "Chẩn đoán Điều dưỡng (Mục XV):";

            // 
            // rtbChanDoanDD
            // 
            this.rtbChanDoanDD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChanDoanDD.Location = new System.Drawing.Point(6, 47);
            this.rtbChanDoanDD.Size = new System.Drawing.Size(451, 140);
            this.rtbChanDoanDD.ReadOnly = true;

            // 
            // lblCanThiepHeader
            // 
            this.lblCanThiepHeader.AutoSize = true;
            this.lblCanThiepHeader.Location = new System.Drawing.Point(6, 195);
            this.lblCanThiepHeader.Text = "Can thiệp Điều dưỡng (Mục XVI):";

            // 
            // rtbCanThiepDD
            // 
            this.rtbCanThiepDD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCanThiepDD.Location = new System.Drawing.Point(6, 217);
            this.rtbCanThiepDD.Size = new System.Drawing.Size(451, 140);
            this.rtbCanThiepDD.ReadOnly = true;

            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Location = new System.Drawing.Point(170, 15);
            this.btnAddPatient.Size = new System.Drawing.Size(120, 30);
            this.btnAddPatient.Text = "Thêm Phiếu Mới";
            // Ghi chú: Sự kiện Click sẽ được định nghĩa trong Form1.cs

            // 
            // btnUpdatePatient
            // 
            this.btnUpdatePatient.Location = new System.Drawing.Point(296, 15);
            this.btnUpdatePatient.Size = new System.Drawing.Size(120, 30);
            this.btnUpdatePatient.Text = "Cập Nhật Phiếu";
            // Ghi chú: Sự kiện Click sẽ được định nghĩa trong Form1.cs

            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(422, 15);
            this.btnReport.Size = new System.Drawing.Size(120, 30);
            this.btnReport.Text = "Xuất Báo Cáo";
            // Ghi chú: Sự kiện Click sẽ được định nghĩa trong Form1.cs

            // 
            // btnResetColumns
            // 
            this.btnResetColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetColumns.Location = new System.Drawing.Point(1068, 15);
            this.btnResetColumns.Size = new System.Drawing.Size(120, 30);
            this.btnResetColumns.Text = "Tải Lại Dữ Liệu";
            // Ghi chú: Sự kiện Click sẽ được định nghĩa trong Form1.cs


            // --- Resume Layout ---
            this.groupBoxPatientInfo.ResumeLayout(false);
            this.groupBoxPatientInfo.PerformLayout();
            this.groupBoxCDCT.ResumeLayout(false);
            this.groupBoxCDCT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheoDoi)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        // ...
    }
}