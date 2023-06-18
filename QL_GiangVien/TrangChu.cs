
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
    public partial class TrangChu : Form
    {
        private int loggedInUserId;
        private string username;
        // private string userType;
        



        public TrangChu(int loggedInUserId, string username )
        {
            InitializeComponent();
            this.loggedInUserId = loggedInUserId;
            this.username = username;
           

        }

        private Form currentFormChild;

        // Sử lí sự kiện bấm vào icon logo
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_show.Controls.Add(childForm);
            panel_show.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
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

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        userType = result.ToString();
                    }
                }
            }

            return userType;
        }


        private void btnGiangVien_Click(object sender, EventArgs e)
        {
           // OpenChildForm(new GiangVien());
        }

        private void btn_Sinhvien_Click(object sender, EventArgs e)
        {
            // Chuyển form SinhVien và truyền loggedInUserId và username
           // OpenChildForm(new SinhVien());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelchat.Visible = false;
            // Chuyển form UpLoadFile và truyền loggedInUserId và username
            OpenChildForm(new UpLoadFile(loggedInUserId, username));
        }

      

        private void btnGiangVien_Click_1(object sender, EventArgs e)
        {
            panelchat.Visible = false;
            OpenChildForm(new GiangVien(loggedInUserId));
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            string userType = GetUserType(loggedInUserId);

            // Ẩn/hiện nút dựa trên UserType
            if (userType == "Student")
            {
               // btnGiangVien.Visible = false;
                btn_account.Visible = false;
            }
            else if (userType == "Teacher")
            {
                btn_account.Visible = false;
            }
            panelchat.Visible = false;
        }
        private void btn_chatBox_Click(object sender, EventArgs e)
        {
            panelchat.Visible = true;
            OpenChildForm(new chat(loggedInUserId));
        }
        private void button4_Click(object sender, EventArgs e)
        {

            // Tạo một instance mới của form đăng nhập (Login)
            Login loginForm = new Login();
            loginForm.Show();

            // Đóng và giải phóng tài nguyên của form hiện tại (GiangVien)
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            OpenChildForm(new ChatBox(loggedInUserId));
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new chatboxStudents(loggedInUserId));
        }
    }
}
