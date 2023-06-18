using QL_GiangVien.Modify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_GiangVien
{
    public partial class GiangVien : Form
    {
        ModifyAll Modify_Giangvien = new ModifyAll();
        private int loggedInUserId;
        private string username;
        
        public GiangVien(int userId)
        {
            InitializeComponent();
            loggedInUserId = userId;
        }
        private bool CheckText()
        {
            
                if (cb_UserID.SelectedIndex == -1)
                {
                    MessageBox.Show("Mời bạn chọn UserID!");
                    return false;
                }
                if (txt_TeacherID.Text == "" || txt_Fullname.Text == "" || txt_DateOffBirth.Text == "" || txt_TeacherCode.Text == "")
                 
                {
                    MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                    return false;
                }

                return true;

            

        }

        private void GiangVien_Load(object sender, EventArgs e)
        {
            try
            {
                dgv_Giangvien.DataSource = Modify_Giangvien.Table(" select * from Teachers");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            LoadUserIds();

            
            string userType = GetUserType(loggedInUserId);
            if (userType == "Teacher")
            {
                btn_Delete.Enabled = false;

            }
            if (userType == "Student")
            {
                btn_Delete.Enabled = false;
                btn_Insert.Enabled = false;
                btn_Update.Enabled = false;

            }


        }


        private void dgv_Giangvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Giangvien.Rows.Count > 1)
            {
                txt_TeacherID.Text = dgv_Giangvien.SelectedRows[0].Cells[0].Value.ToString();
                txt_Fullname.Text = dgv_Giangvien.SelectedRows[0].Cells[1].Value.ToString();
                txt_TeacherCode.Text = dgv_Giangvien.SelectedRows[0].Cells[2].Value.ToString();
                txt_DateOffBirth.Text = dgv_Giangvien.SelectedRows[0].Cells[3].Value.ToString();
               cb_UserID.Text = dgv_Giangvien.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();

                    // Kiểm tra xem Mã sách đã tồn tại hay chưa
                    string checkQuery = "SELECT TeacherID FROM Teachers WHERE TeacherID = @TeacherID";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                    {
                        checkCommand.Parameters.AddWithValue("@TeacherID", txt_TeacherID.Text);
                        object result = checkCommand.ExecuteScalar();
                        if (result != null)
                        {
                            MessageBox.Show("Mã sách đã tồn tại");
                            return;
                        }
                    }

                    // Thực hiện truy vấn INSERT
                    string insertQuery = "INSERT INTO Teachers (TeacherID, Fullname, TeacherCode, DateOfBirth,UserId) VALUES (@TeacherID,  @Fullname, @TeacherCode, @DateOffBirth, @UserID)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn))
                    {
                        insertCommand.Parameters.AddWithValue("@TeacherID", txt_TeacherID.Text);
                        insertCommand.Parameters.AddWithValue("@Fullname", txt_Fullname.Text);
                        insertCommand.Parameters.AddWithValue("@TeacherCode", txt_TeacherCode.Text);
                        insertCommand.Parameters.AddWithValue("@DateOffBirth", txt_DateOffBirth.Text);
                        insertCommand.Parameters.AddWithValue("@UserID", cb_UserID.Text);
                      

                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bạn đã thêm 1 sách thành công!");
                            GiangVien_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_Giangvien.Rows.Count > 1)
            {
                string choose = dgv_Giangvien.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE Teachers ";
                query += " WHERE TeacherID = '" + choose + "'";
                try
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection connection = Connection.GetSqlConnection()) // Thay YourConnectionFunction() bằng hàm kết nối riêng của bạn
                        {
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MaSach", choose);
                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Bạn đã xóa 1 sách thành công!");
                                    GiangVien_Load(sender, e);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void cb_UserID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadUserIds()
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();

                    string query = "SELECT UserId FROM Users where UserType= 'Teacher'";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        // Xóa các mục hiện tại trong ComboBox
                        cb_UserID.Items.Clear();

                        while (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            cb_UserID.Items.Add(userId);
                        }

                        reader.Close();

                        // Chọn mục đầu tiên trong ComboBox (nếu có)
                        if (cb_UserID.Items.Count > 0)
                        {
                            cb_UserID.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                SqlConnection conn = Connection.GetSqlConnection();
                string sqlCheck = "SELECT COUNT(*) FROM Teachers WHERE TeacherId = @TeacherID";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@TeacherID", txt_TeacherID.Text);
                conn.Open();
                int count = (int)cmdCheck.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Mã sách không tồn tại");
                    return;
                }

             
                string sqlUpdate = "UPDATE Teachers SET Fullname = @Fullname, TeacherCode = @TeacherCode, DateOfBirth = @DateOffBirth, UserId = @UserId WHERE TeacherID = @TeacherID";
                SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn);
               cmdUpdate.Parameters.AddWithValue("@TeacherID", txt_TeacherID.Text);
               cmdUpdate.Parameters.AddWithValue("@Fullname", txt_Fullname.Text);
                cmdUpdate.Parameters.AddWithValue("@TeacherCode", txt_TeacherCode.Text);
                cmdUpdate.Parameters.AddWithValue("@DateOffBirth", txt_DateOffBirth.Text);
                cmdUpdate.Parameters.AddWithValue("@UserID", cb_UserID.Text);
                int rowsAffected = cmdUpdate.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Bạn đã sửa thông tin sách thành công!");
                    GiangVien_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Lỗi sửa thông tin sách");
                }
            }

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {

            // Ẩn form GiangVien
           // Kiểm tra nếu form TrangChu đã được mở
            TrangChu trangChuForm = Application.OpenForms.OfType<TrangChu>().FirstOrDefault();
            if (trangChuForm != null)
            {
                // Đưa form TrangChu lên phía trước
                trangChuForm.BringToFront();
            }
            else
            {
                // Nếu form TrangChu chưa được mở, tạo một instance mới và hiển thị
                TrangChu newTrangChuForm = new TrangChu(loggedInUserId, username);
                newTrangChuForm.Show();
            }

            // Đóng và giải phóng tài nguyên của form GiangVien
            this.Dispose();



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txt_Search.Text.Trim();
            if (name == "")
            {
                GiangVien_Load(sender, e);
            }
            else
            {
                string query = "SELECT * FROM Teachers WHERE Fullname LIKE @Name";
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", "%" + name + "%");
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgv_Giangvien.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy kết quả phù hợp.");
                        }
                    }
                }
            }

        }
        private string GetUserType(int userId)
        {
            string userType = string.Empty;

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                string query = "SELECT UserType FROM Users WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userType = reader.GetString(0);
                        }
                    }
                }
            }

            return userType;
        }


    }
}
