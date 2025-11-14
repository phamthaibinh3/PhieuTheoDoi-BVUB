using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine; // Rất quan trọng để xử lý Report Document

namespace BVUB_PhieuTheoDoi // Đảm bảo namespace này khớp với project của bạn
{
    public partial class fFormReport : Form
    {
        // Giả sử tên control CrystalReportViewer trên Form này là 'crystalReportViewer1'

        // 1. Constructor mặc định (Có thể giữ lại nếu bạn cần mở form trống)
        public fFormReport()
        {
            InitializeComponent();
        }

        // 2. CONSTRUCTOR QUAN TRỌNG NHẤT: Nhận đối tượng ReportDocument đã gán dữ liệu
        /// <summary>
        /// Khởi tạo Form và gán ReportDocument đã được điền dữ liệu vào Report Viewer.
        /// </summary>
        /// <param name="report">Đối tượng Crystal Report đã được gọi SetDataSource.</param>
        public fFormReport(ReportDocument report)
        {
            InitializeComponent();
            this.Text = "Xem Phiếu Theo Dõi"; // Đặt tiêu đề Form

            // Kiểm tra và gán ReportDocument cho CrystalReportViewer
            if (report != null)
            {
                // Tên crystalReportViewer1 phải khớp với tên bạn đặt trong Designer
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            else
            {
                MessageBox.Show("Không thể tải báo cáo: Report Document rỗng.", "Lỗi Report");
            }
        }
    }
}