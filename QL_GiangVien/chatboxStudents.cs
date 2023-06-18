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
    public partial class chatboxStudents : Form
    {
        private int loggedInUserId;
        private string loggedInUserName;
        public int UserId { get; set; }

        public chatboxStudents(int loggedInUserId)
        {
            InitializeComponent();
            this.loggedInUserId = loggedInUserId;
            // this.loggedInUserName = loggedInUserName;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            Loadstudents();
        }
        private void Loadstudents()
        {
           
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                string query = "SELECT StudentId , Fullname FROM Students WHERE UserId != @LoggedInUserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoggedInUserId", loggedInUserId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentID = Convert.ToInt32(reader["StudentId"]);
                            string fullName = Convert.ToString(reader["FullName"]);

                            // Kiểm tra nếu giáo viên không phải là người dùng đăng nhập, thì mới thêm vào comboBox1
                            if (studentID != loggedInUserId)
                            {
                                comboBox1.Items.Add(new Students(studentID, fullName));
                            }
                        }
                    }
                }
            }
        }
        public class Students
        {
            public int StudentId { get; set; }
            public string FullName { get; set; }

            public Students(int studentID, string fullName)
            {
                StudentId = studentID;
                FullName = fullName;
            }

            public override string ToString()
            {
                return FullName;
            }

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
                Students selectedTeacher = comboBox1.SelectedItem as Students;
                int receiverId = selectedTeacher.StudentId;

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
                                listBox1.Items.Insert(0, message);  // Chèn tin nhắn mới nhất vào đầu của ListView
                            }
                        }
                    }
                }
            }
        }
        private string GetUserName(int userId)
        {
            string username = string.Empty;

            using (SqlConnection connection = Connection.GetSqlConnection())
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
       
        private void btnSent_Click(object sender, EventArgs e)
        {
           Students receiver = comboBox1.SelectedItem as Students;
            if (receiver != null)
            {
                string messageContent = txtcontents.Text;
                DateTime dateTime = DateTime.Now;

                SaveMessage(loggedInUserId, receiver.StudentId, messageContent, dateTime);
                string senderName = GetUserName(loggedInUserId);
                string message = $"[{dateTime}] {senderName}: {messageContent}";
                listBox1.Items.Add(message);

                txtcontents.Clear();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            LoadChatMessages();
        }
    }
}
