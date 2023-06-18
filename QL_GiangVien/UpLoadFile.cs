using QL_GiangVien.Modify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_GiangVien
{
    public partial class UpLoadFile : Form
    {
        ModifyAll Modify_File = new ModifyAll();
        //private int loggedInUserId;
        private string username;
        private string loggedInUsername;
        private int loggedInUserID;

        public string LoggedInUsername
        {
            get { return loggedInUsername; }
            set { loggedInUsername = value; }
        }

        public int LoggedInUserID
        {
            get { return loggedInUserID; }
            set { loggedInUserID = value; }
        }

        public UpLoadFile(int userID, string username)
        {
            InitializeComponent();

            loggedInUsername = username;
            loggedInUserID = userID;
            if (loggedInUserID == 0)
            {
                loggedInUserID = -1;
            }
        }


        private void UpLoadFile_Load(object sender, EventArgs e)
        {
            try
            {
                dgv_Show.DataSource = Modify_File.Table("SELECT * FROM Files");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            label1.Text = "Logged in as: " + loggedInUserID;

        }

        private string GetUniqueFileName(string fileName, string destinationPath)
        {
            string uniqueFileName = fileName;
            int count = 1;
            string extension = Path.GetExtension(fileName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string destinationFile = Path.Combine(destinationPath, uniqueFileName); // Đường dẫn đích để kiểm tra trùng tên
            while (File.Exists(destinationFile))
            {
                uniqueFileName = $"{fileNameWithoutExtension}_{count}{extension}";
                destinationFile = Path.Combine(destinationPath, uniqueFileName);
                count++;
            }
            return uniqueFileName;
        }

        private void DownloadFile(string filePath, string fileName)
        {
            /* SaveFileDialog saveFileDialog = new SaveFileDialog();
             saveFileDialog.FileName = GetUniqueFileName(fileName, Path.GetDirectoryName(filePath));*/
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = GetUniqueFileName(fileName, Path.GetDirectoryName(filePath));
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Đặt thư mục ban đầu là Desktop
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string destinationPath = saveFileDialog.FileName;

                    // Kiểm tra xem file đã tồn tại trên máy tính hay chưa
                    if (File.Exists(destinationPath))
                    {
                        MessageBox.Show("Tên file đã tồn tại trên máy tính. Vui lòng đổi tên file trước khi tải xuống.");
                        return;
                    }

                    try
                    {
                        // Tải xuống file
                        File.Copy(filePath, destinationPath);

                        MessageBox.Show("File downloaded successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while downloading file: {ex.Message}");
                    }
                }
        }

        private void SaveFileToDatabase(string fileName, string filePath)
        {
            // Kiểm tra xem loggedInUserID có giá trị hợp lệ hay không
            if (loggedInUserID == 0)

            {
                MessageBox.Show("Lỗi: Chưa có giá trị cho loggedInUserID.");
                return;
            }

            // Thực hiện INSERT vào bảng Files
            string insertQuery = "INSERT INTO Files (FileName, FilePath, OwnerId) VALUES (@FileName, @FilePath, @OwnerId)";

            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn))
                {
                   

                    insertCommand.Parameters.AddWithValue("@FileName", fileName);
                    insertCommand.Parameters.AddWithValue("@FilePath", filePath);
                    insertCommand.Parameters.AddWithValue("@OwnerId", loggedInUserID);

                    conn.Open();
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm file thành công!");
                        UpLoadFile_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi thêm file!");
                    }
                }
            }

        }

        private void btn_dowload_Click(object sender, EventArgs e)
        {
            if (dgv_Show.SelectedRows.Count > 0)
            {
                // Lấy thông tin file được chọn từ DataGridView
                int fileId = Convert.ToInt32(dgv_Show.SelectedRows[0].Cells["FileId"].Value);
                string fileName = dgv_Show.SelectedRows[0].Cells["FileName"].Value.ToString();
                string filePath = dgv_Show.SelectedRows[0].Cells["FilePath"].Value.ToString();

                // Thực hiện tải xuống file
                DownloadFile(filePath, fileName);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một file để tải xuống.");
            }
        }

        private void btnUpfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.SafeFileName;
                string filePath = openFileDialog.FileName;

                // Lưu thông tin file vào cơ sở dữ liệu
                SaveFileToDatabase(fileName, filePath);

                // Hoặc tùy chỉnh thêm hành động sau khi lưu file, ví dụ hiển thị thông báo thành công, làm mới danh sách file, v.v.
                MessageBox.Show("File uploaded successfully!");
            }
        }

        private void btb_Search_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(keyword))
            {
                string searchQuery = "SELECT * FROM Files WHERE FileName LIKE '%' + @FileName + '%'";

                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    using (SqlCommand searchCommand = new SqlCommand(searchQuery, conn))
                    {
                        searchCommand.Parameters.AddWithValue("@FileName", keyword);

                        conn.Open();
                        SqlDataReader reader = searchCommand.ExecuteReader();

                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        dgv_Show.DataSource = dataTable;

                        reader.Close();
                    }
                }
            }
            else
            {
                // Hiển thị tất cả các tệp tin nếu không có từ khóa được nhập
                dgv_Show.DataSource = Modify_File.Table("SELECT * FROM Files");
            }
        }

        private void btn_ReLoad_Click(object sender, EventArgs e)
        {
            UpLoadFile_Load(sender, e);
        }

        private void btn_Back_Click_1(object sender, EventArgs e)
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
                TrangChu newTrangChuForm = new TrangChu(loggedInUserID, loggedInUsername);
                newTrangChuForm.Show();
            }

            // Đóng và giải phóng tài nguyên của form GiangVien
            this.Dispose();
        }
    }
}
