
namespace QL_GiangVien
{
    partial class GiangVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Giangvien = new System.Windows.Forms.DataGridView();
            this.btn_Insert = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_TeacherID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Fullname = new System.Windows.Forms.TextBox();
            this.txt_TeacherCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_DateOfBirth = new System.Windows.Forms.Label();
            this.txt_DateOffBirth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.cb_UserID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Giangvien)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Giangvien);
            this.groupBox1.Location = new System.Drawing.Point(20, 222);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách giảng viên";
            // 
            // dgv_Giangvien
            // 
            this.dgv_Giangvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Giangvien.Location = new System.Drawing.Point(7, 19);
            this.dgv_Giangvien.Name = "dgv_Giangvien";
            this.dgv_Giangvien.Size = new System.Drawing.Size(522, 218);
            this.dgv_Giangvien.TabIndex = 0;
            this.dgv_Giangvien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Giangvien_CellClick);
            // 
            // btn_Insert
            // 
            this.btn_Insert.Location = new System.Drawing.Point(626, 241);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(90, 33);
            this.btn_Insert.TabIndex = 1;
            this.btn_Insert.Text = "Thêm ";
            this.btn_Insert.UseVisualStyleBackColor = true;
            this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(626, 302);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(90, 33);
            this.btn_Update.TabIndex = 2;
            this.btn_Update.Text = "Sửa";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(626, 362);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(90, 33);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "Xóa";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(626, 426);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(90, 33);
            this.btn_Thoat.TabIndex = 4;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.cb_UserID);
            this.groupBox2.Controls.Add(this.txt_Search);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_DateOffBirth);
            this.groupBox2.Controls.Add(this.txt_DateOfBirth);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_TeacherCode);
            this.groupBox2.Controls.Add(this.txt_Fullname);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_TeacherID);
            this.groupBox2.Location = new System.Drawing.Point(37, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(782, 102);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // txt_TeacherID
            // 
            this.txt_TeacherID.Location = new System.Drawing.Point(95, 20);
            this.txt_TeacherID.Name = "txt_TeacherID";
            this.txt_TeacherID.Size = new System.Drawing.Size(100, 20);
            this.txt_TeacherID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TeacherID: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fullname: ";
            // 
            // txt_Fullname
            // 
            this.txt_Fullname.Location = new System.Drawing.Point(307, 21);
            this.txt_Fullname.Name = "txt_Fullname";
            this.txt_Fullname.Size = new System.Drawing.Size(100, 20);
            this.txt_Fullname.TabIndex = 3;
            // 
            // txt_TeacherCode
            // 
            this.txt_TeacherCode.Location = new System.Drawing.Point(526, 21);
            this.txt_TeacherCode.Name = "txt_TeacherCode";
            this.txt_TeacherCode.Size = new System.Drawing.Size(100, 20);
            this.txt_TeacherCode.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TeacherCode: ";
            // 
            // txt_DateOfBirth
            // 
            this.txt_DateOfBirth.AutoSize = true;
            this.txt_DateOfBirth.Location = new System.Drawing.Point(18, 66);
            this.txt_DateOfBirth.Name = "txt_DateOfBirth";
            this.txt_DateOfBirth.Size = new System.Drawing.Size(65, 13);
            this.txt_DateOfBirth.TabIndex = 6;
            this.txt_DateOfBirth.Text = "DateOfBirth:";
            // 
            // txt_DateOffBirth
            // 
            this.txt_DateOffBirth.Location = new System.Drawing.Point(95, 59);
            this.txt_DateOffBirth.Name = "txt_DateOffBirth";
            this.txt_DateOffBirth.Size = new System.Drawing.Size(100, 20);
            this.txt_DateOffBirth.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "UserID:";
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(541, 63);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(194, 20);
            this.txt_Search.TabIndex = 11;
            // 
            // cb_UserID
            // 
            this.cb_UserID.FormattingEnabled = true;
            this.cb_UserID.Location = new System.Drawing.Point(307, 63);
            this.cb_UserID.Name = "cb_UserID";
            this.cb_UserID.Size = new System.Drawing.Size(121, 21);
            this.cb_UserID.TabIndex = 12;
            this.cb_UserID.SelectedIndexChanged += new System.EventHandler(this.cb_UserID_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(302, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "Danh sách giảng viên";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(481, 63);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 21);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // GiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(841, 506);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Insert);
            this.Controls.Add(this.groupBox1);
            this.Name = "GiangVien";
            this.Text = "Giảng viên";
            this.Load += new System.EventHandler(this.GiangVien_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Giangvien)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_Giangvien;
        private System.Windows.Forms.Button btn_Insert;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_DateOffBirth;
        private System.Windows.Forms.Label txt_DateOfBirth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_TeacherCode;
        private System.Windows.Forms.TextBox txt_Fullname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TeacherID;
        private System.Windows.Forms.ComboBox cb_UserID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSearch;
    }
}