
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
    public partial class Login : Form
    {
        public event Action<string, string> LoginSuccess; // Sự kiện khi đăng nhập thành công

        public Login()
        {
            InitializeComponent();
        }

        private string loggedInUsername;
       /* private string UserType;*/

     /*   public string LoggedInUsername
        {
            get { return loggedInUsername; }
        }*/

        private void btn_Login_Click(object sender, EventArgs e)
        {
            /* string username = txtUser.Text;
             string password = txtPassword.Text;
             int loggedInUserId = GetLoggedInUserId();
             if (AuthenticateUser(username, password))   
             {
                 this.Hide();

                 LoginSuccess?.Invoke(loggedInUserId.ToString(), username); // Kích hoạt sự kiện và truyền giá trị
                 ChatBox chatbox = new ChatBox(GetLoggedInUserId());

                 TrangChu trangchu = new TrangChu(loggedInUserId , username);
                 trangchu.Show();
                 loggedInUsername = username; // Gán tên đăng nhập cho thuộc tính LoggedInUsername
             }
             else
             {
                 // Hiển thị thông báo đăng nhập không thành công
                 MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
             }*/
            string username = txtUser.Text;
            string password = txtPassword.Text;
            int loggedInUserId = GetLoggedInUserId();
            string userType = GetUserType(loggedInUserId);

            if (AuthenticateUser(username, password))
            {
                this.Hide();

                string loginMessage = "";

                switch (userType)
                {
                    case "Teacher":
                        loginMessage = "Logged in as a Teacher.";
                        break;
                    case "Student":
                        loginMessage = "Logged in as a Student.";
                        break;
                    case "admin":
                        loginMessage = "Logged in as an Admin.";
                        break;
                    default:
                        loginMessage = "Logged in with an unknown user type.";
                        break;
                }

                MessageBox.Show(loginMessage, "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoginSuccess?.Invoke(loggedInUserId.ToString(), username); // Kích hoạt sự kiện và truyền giá trị
                ChatBox chatbox = new ChatBox(GetLoggedInUserId());
                GiangVien gv = new GiangVien(GetLoggedInUserId());

                TrangChu trangchu = new TrangChu(loggedInUserId, username);
                trangchu.Show();
                loggedInUsername = username; // Gán tên đăng nhập cho thuộc tính LoggedInUsername
            }
            else
            {
                // Hiển thị thông báo đăng nhập không thành công
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        isAuthenticated = true;
                    }
                }
            }

            return isAuthenticated;
        }

        private int GetLoggedInUserId()
        {
            int userId = -1;

            string username = txtUser.Text;
            string password = txtPassword.Text;

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                string query = "SELECT UserId FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        userId = id;
                    }
                }
            }

            return userId;
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
