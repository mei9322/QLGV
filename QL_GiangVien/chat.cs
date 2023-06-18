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
    public partial class chat : Form
    {
        private int loggedInUserId;
       
        
        public chat(int userId)
        {
            InitializeComponent();
            loggedInUserId = userId;
        }

        private void chat_Load(object sender, EventArgs e)
        {
            LoadMessages();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
        private void LoadMessages()
        {
            // Xóa tất cả các tin nhắn đã hiển thị trước đó
            listBox1.Items.Clear();

            // Lấy tất cả các tin nhắn gửi đến người dùng đăng nhập
            string query = "SELECT SenderId, Content, DateTime FROM Messages WHERE ReceiverId = @UserId";
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", loggedInUserId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int senderId = reader.GetInt32(0);
                            string senderName = GetUsername(senderId);
                            string content = reader.GetString(1);
                            DateTime dateTime = reader.GetDateTime(2);

                            string message = $"[{dateTime}] {senderName}: {content}";

                            listBox1.Items.Add(message);
                        }
                    }
                }
            }
        }
       
        private string GetUsername(int userId)
        {
            string username = string.Empty;

            // Lấy tên người dùng dựa trên userId
            string query = "SELECT Username FROM Users WHERE UserId = @UserId";
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        username = result.ToString();
                    }
                }
            }

            return username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (formChatBox == null || formChatBox.IsDisposed)
            {
                formChatBox = new ChatBox(loggedInUserId);
                formChatBox.TopLevel = false;
                formChatBox.FormBorderStyle = FormBorderStyle.None;
                formChatBox.Dock = DockStyle.Fill;
                panel1.Controls.Add(formChatBox);
                formChatBox.BringToFront();
            }
            formChatBox.Show();
*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*if (formChatBoxStudents == null || formChatBoxStudents.IsDisposed)
            {
                formChatBoxStudents = new chatboxStudents(loggedInUserId);
                formChatBoxStudents.TopLevel = false;
                formChatBoxStudents.FormBorderStyle = FormBorderStyle.None;
                formChatBoxStudents.Dock = DockStyle.Fill;
                panel1.Controls.Add(formChatBoxStudents);
                formChatBoxStudents.BringToFront();
            }
            formChatBoxStudents.Show();*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadMessages();
        }
    }
}
