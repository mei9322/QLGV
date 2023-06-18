
namespace QL_GiangVien
{
    partial class UpLoadFile
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
            this.dgv_Show = new System.Windows.Forms.DataGridView();
            this.btnUpfile = new System.Windows.Forms.Button();
            this.btn_dowload = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.labell = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ReLoad = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Show)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Show
            // 
            this.dgv_Show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Show.Location = new System.Drawing.Point(16, 62);
            this.dgv_Show.Name = "dgv_Show";
            this.dgv_Show.Size = new System.Drawing.Size(606, 267);
            this.dgv_Show.TabIndex = 0;
            // 
            // btnUpfile
            // 
            this.btnUpfile.Location = new System.Drawing.Point(661, 80);
            this.btnUpfile.Name = "btnUpfile";
            this.btnUpfile.Size = new System.Drawing.Size(96, 35);
            this.btnUpfile.TabIndex = 1;
            this.btnUpfile.Text = "Upload_File";
            this.btnUpfile.UseVisualStyleBackColor = true;
            this.btnUpfile.Click += new System.EventHandler(this.btnUpfile_Click);
            // 
            // btn_dowload
            // 
            this.btn_dowload.Location = new System.Drawing.Point(661, 147);
            this.btn_dowload.Name = "btn_dowload";
            this.btn_dowload.Size = new System.Drawing.Size(96, 35);
            this.btn_dowload.TabIndex = 4;
            this.btn_dowload.Text = "DowLoad_File";
            this.btn_dowload.UseVisualStyleBackColor = true;
            this.btn_dowload.Click += new System.EventHandler(this.btn_dowload_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(661, 278);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(96, 35);
            this.btn_Back.TabIndex = 5;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click_1);
            // 
            // labell
            // 
            this.labell.AutoSize = true;
            this.labell.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold);
            this.labell.Location = new System.Drawing.Point(312, 33);
            this.labell.Name = "labell";
            this.labell.Size = new System.Drawing.Size(198, 26);
            this.labell.TabIndex = 6;
            this.labell.Text = "Danh sách tài liệu ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ReLoad);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Controls.Add(this.dgv_Show);
            this.groupBox1.Controls.Add(this.btnUpfile);
            this.groupBox1.Controls.Add(this.btn_Back);
            this.groupBox1.Controls.Add(this.btn_dowload);
            this.groupBox1.Location = new System.Drawing.Point(12, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(805, 344);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kho";
            // 
            // btn_ReLoad
            // 
            this.btn_ReLoad.Location = new System.Drawing.Point(661, 217);
            this.btn_ReLoad.Name = "btn_ReLoad";
            this.btn_ReLoad.Size = new System.Drawing.Size(96, 35);
            this.btn_ReLoad.TabIndex = 8;
            this.btn_ReLoad.Text = "ReLoad";
            this.btn_ReLoad.UseVisualStyleBackColor = true;
            this.btn_ReLoad.Click += new System.EventHandler(this.btn_ReLoad_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(239, 33);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(166, 20);
            this.txtSearch.TabIndex = 7;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(424, 31);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 6;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btb_Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // UpLoadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(841, 506);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labell);
            this.Name = "UpLoadFile";
            this.Text = "UpLoadFile";
            this.Load += new System.EventHandler(this.UpLoadFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Show)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Show;
        private System.Windows.Forms.Button btnUpfile;
        private System.Windows.Forms.Button btn_dowload;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label labell;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_ReLoad;
        private System.Windows.Forms.Label label1;
    }
}