using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BVUB_PhieuTheoDoi.DAO
{
    public class DataProvider
    {
        private static DataProvider instance; // Singleton pattern instance

        // Cần thay thế bằng chuỗi kết nối thực tế của bạn
        private string connectionSTR = @"Data Source=THAIBINH\SQLEXPRESS01;Initial Catalog=PhieuTheoDoiBenhNhanBVUB;Integrated Security=True;Encrypt=False";

        private SqlConnection connection;
        private SqlTransaction transaction;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider() { }

        // Mở kết nối nếu chưa mở
        private void OpenConnection()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connectionSTR);
                connection.Open();
            }
        }

        // Đóng kết nối
        private void CloseConnection()
        {
            if (connection != null && connection.State != ConnectionState.Closed && transaction == null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        // Bắt đầu Transaction
        public void BeginTransaction()
        {
            OpenConnection();
            if (transaction != null)
            {
                // Nếu transaction đã tồn tại, hủy bỏ nó trước khi tạo mới (tránh lỗi)
                try { transaction.Rollback(); } catch { }
                transaction = null;
            }
            transaction = connection.BeginTransaction();
        }

        // Commit Transaction
        public void CommitTransaction()
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction = null;
                CloseConnection();
            }
        }

        // Rollback Transaction
        public void RollbackTransaction()
        {
            if (transaction != null)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi rollback nếu cần
                    Console.WriteLine("Lỗi khi Rollback: " + ex.Message);
                }
                finally
                {
                    transaction = null;
                    CloseConnection();
                }
            }
        }

        // Thực thi truy vấn SELECT
        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            OpenConnection(); // Mở kết nối nếu cần

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Nếu đang trong transaction, gán transaction cho command
                if (transaction != null) command.Transaction = transaction;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(data);
                }
            }

            CloseConnection(); // Đóng kết nối nếu không có transaction
            return data;
        }

        // Thực thi truy vấn INSERT, UPDATE, DELETE (Trả về số hàng bị ảnh hưởng)
        public int ExecuteNonQuery(string query)
        {
            int count = 0;
            OpenConnection(); // Mở kết nối nếu cần

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (transaction != null) command.Transaction = transaction;
                count = command.ExecuteNonQuery();
            }

            CloseConnection(); // Đóng kết nối nếu không có transaction
            return count;
        }

        // Thực thi truy vấn trả về giá trị đơn (ví dụ: lấy ID mới nhất)
        public object ExecuteScalar(string query)
        {
            object data = null;
            OpenConnection(); // Mở kết nối nếu cần

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (transaction != null) command.Transaction = transaction;
                data = command.ExecuteScalar();
            }

            // KHÔNG đóng kết nối nếu đang trong transaction (Rollback/Commit sẽ lo)
            if (transaction == null) CloseConnection();
            return data;
        }

        public int ExecuteNonQueryWithParams(string query, Dictionary<string, object> parameters)
        {
            int count = 0;

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Đảm bảo connection đã mở (nếu đang trong transaction, nó đã mở)
                if (connection.State != ConnectionState.Open) OpenConnection();

                // Gán transaction nếu có
                if (transaction != null) command.Transaction = transaction;

                // Thêm parameters
                foreach (var param in parameters)
                {
                    // Xử lý giá trị null hoặc không giá trị (DBNull.Value)
                    object value = param.Value ?? DBNull.Value;
                    command.Parameters.AddWithValue("@" + param.Key, value);
                }

                count = command.ExecuteNonQuery();
            }

            // Chỉ đóng kết nối nếu không có transaction đang quản lý
            if (transaction == null) CloseConnection();

            return count;
        }
    }
}