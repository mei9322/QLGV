
namespace QL_GiangVien
{
    partial class FormChatBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_sendmes = new System.Windows.Forms.Button();
            this.btn_sent = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_sent);
            this.panel1.Controls.Add(this.btn_sendmes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 38);
            this.panel1.TabIndex = 0;
            // 
            // btn_sendmes
            // 
            this.btn_sendmes.Location = new System.Drawing.Point(12, 3);
            this.btn_sendmes.Name = "btn_sendmes";
            this.btn_sendmes.Size = new System.Drawing.Size(100, 32);
            this.btn_sendmes.TabIndex = 0;
            this.btn_sendmes.Text = "Gửi tin nhắn ";
            this.btn_sendmes.UseVisualStyleBackColor = true;
            // 
            // btn_sent
            // 
            this.btn_sent.Location = new System.Drawing.Point(128, 3);
            this.btn_sent.Name = "btn_sent";
            this.btn_sent.Size = new System.Drawing.Size(100, 32);
            this.btn_sent.TabIndex = 1;
            this.btn_sent.Text = "Hộp thư đến";
            this.btn_sent.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(841, 468);
            this.panel2.TabIndex = 1;
            // 
            // FormChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(841, 506);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormChatBox";
            this.Text = "FormChatBox";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_sent;
        private System.Windows.Forms.Button btn_sendmes;
        private System.Windows.Forms.Panel panel2;
    }
}