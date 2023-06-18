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
    public partial class ChatBox : Form
    {
       

        private int loggedInUserId;
        private string loggedInUserName;
        public int UserId { get; set; }
        public ChatBox(int loggedInUserId)
        {
            InitializeComponent();
            this.loggedInUserId = loggedInUserId;
           // this.loggedInUserName = loggedInUserName;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            LoadTeachers();
        }
        private void LoadTeachers()
        {
           
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                string query = "SELECT TeacherId, FullName FROM Teachers WHERE UserId != @LoggedInUserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoggedInUserId", loggedInUserId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int teacherId = Convert.ToInt32(reader["TeacherId"]);
                            string fullName = Convert.ToString(reader["FullName"]);

                            // Kiểm tra nếu giáo viên không phải là người dùng đăng nhập, thì mới thêm vào comboBox1
                            if (teacherId != loggedInUserId)
                            {
                                comboBox1.Items.Add(new Teacher(teacherId, fullName));
                            }
                        }
                    }
                }
            }
        }
        public class Teacher
        {
            public int TeacherId { get; set; }
            public string FullName { get; set; }

            public Teacher(int teacherId, string fullName)
            {
                TeacherId = teacherId;
                FullName = fullName;
            }

            public override string ToString()
            {
                return FullName;
            }
        }

        private void ChatBox_Load(object sender, EventArgs e)
        {

        }
        private void SaveMessage(int senderId, int receiverId, string content, DateTime dateTime)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                string query = "INSERT INTO Messages (SenderId, ReceiverId, Content, DateTime) VALUES (@SenderId, @ReceiverId, @Content, @DateTime)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SenderId", senderId);
                    command.Parameters.AddWithValue("@ReceiverId", receiverId);
                    command.Parameters.AddWithValue("@Content", content);
                    command.Parameters.AddWithValue("@DateTime", dateTime);

                    command.ExecuteNonQuery();
                }
            }
        }
        private void LoadChatMessages()
        {
       
            if (comboBox1.SelectedItem != null)
            {
                Teacher selectedTeacher = comboBox1.SelectedItem as Teacher;
                int receiverId = selectedTeacher.TeacherId;

                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    string query = "SELECT SenderId, Content, DateTime FROM Messages WHERE (SenderId = @SenderId AND ReceiverId = @ReceiverId) OR (SenderId = @ReceiverId AND ReceiverId = @SenderId) ORDER BY DateTime";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SenderId", loggedInUserId);
                        command.Parameters.AddWithValue("@ReceiverId", receiverId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int senderId = Convert.ToInt32(reader["SenderId"]);
                                string senderName = (senderId == loggedInUserId) ? loggedInUserName : GetUserName(senderId);

                                string content = Convert.ToString(reader["Content"]);
                                DateTime dateTime = Convert.ToDateTime(reader["DateTime"]);
                                string message = $"[{dateTime}] {senderName}: {content}";
                                ls_contents.Items.Insert(0, message);  // Chèn tin nhắn mới nhất vào đầu của ListView
                            }
                        }
                    }
                }
            }
        }
        private string GetUserName(int userId)
        {
            string username = string.Empty;

            using (SqlConnection connection =Connection.GetSqlConnection())
            {
                connection.Open();

                string query = "SELECT Username FROM Users WHERE UserId = @UserId";
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
        private int GetLoggedInUserId(string username, string password)
        {
            int userId = -1;
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ls_contents.Items.Clear();
            LoadChatMessages();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            Teacher receiver = comboBox1.SelectedItem as Teacher;
            if (receiver != null)
            {
                string messageContent = txt_contents.Text;
                DateTime dateTime = DateTime.Now;

                SaveMessage(loggedInUserId, receiver.TeacherId, messageContent, dateTime);
                string senderName = GetUserName(loggedInUserId);
                string message = $"[{dateTime}] {senderName}: {messageContent}";
                ls_contents.Items.Add(message);

                txt_contents.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrangChu trangChuForm = Application.OpenForms.OfType<TrangChu>().FirstOrDefault();
            if (trangChuForm != null)
            {
                // Đưa form TrangChu lên phía trước
                trangChuForm.BringToFront();
            }
            else
            {
                // Nếu form TrangChu chưa được mở, tạo một instance mới và hiển thị
                TrangChu newTrangChuForm = new TrangChu(loggedInUserId, loggedInUserName);
                newTrangChuForm.Show();
            }

            // Đóng và giải phóng tài nguyên của form GiangVien
            this.Dispose();
        }
    }
}
