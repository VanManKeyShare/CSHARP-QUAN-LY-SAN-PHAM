namespace QUẢN_LÝ_SẢN_PHẨM
{
    partial class Frm_CHCSDL
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CHCSDL));
            this.TabC1 = new System.Windows.Forms.TabControl();
            this.TabP1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_account = new System.Windows.Forms.TextBox();
            this.txt_database_name = new System.Windows.Forms.TextBox();
            this.txt_server_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TabP2 = new System.Windows.Forms.TabPage();
            this.txt_sql_connection_string = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_test_and_save_connection = new System.Windows.Forms.Button();
            this.btn_reset_default = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.TabC1.SuspendLayout();
            this.TabP1.SuspendLayout();
            this.TabP2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabC1
            // 
            this.TabC1.Controls.Add(this.TabP1);
            this.TabC1.Controls.Add(this.TabP2);
            this.TabC1.Location = new System.Drawing.Point(12, 12);
            this.TabC1.Name = "TabC1";
            this.TabC1.SelectedIndex = 0;
            this.TabC1.Size = new System.Drawing.Size(525, 195);
            this.TabC1.TabIndex = 0;
            // 
            // TabP1
            // 
            this.TabP1.Controls.Add(this.checkBox1);
            this.TabP1.Controls.Add(this.txt_password);
            this.TabP1.Controls.Add(this.txt_account);
            this.TabP1.Controls.Add(this.txt_database_name);
            this.TabP1.Controls.Add(this.txt_server_name);
            this.TabP1.Controls.Add(this.label5);
            this.TabP1.Controls.Add(this.label4);
            this.TabP1.Controls.Add(this.label3);
            this.TabP1.Controls.Add(this.label2);
            this.TabP1.Controls.Add(this.label1);
            this.TabP1.Location = new System.Drawing.Point(4, 25);
            this.TabP1.Name = "TabP1";
            this.TabP1.Padding = new System.Windows.Forms.Padding(3);
            this.TabP1.Size = new System.Drawing.Size(517, 166);
            this.TabP1.TabIndex = 0;
            this.TabP1.Text = "CƠ BẢN";
            this.TabP1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(130, 77);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(227, 20);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "SỬ DỤNG CHỨNG THỰC WINDOWS";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txt_password
            // 
            this.txt_password.Enabled = false;
            this.txt_password.Location = new System.Drawing.Point(130, 132);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(370, 23);
            this.txt_password.TabIndex = 4;
            // 
            // txt_account
            // 
            this.txt_account.Enabled = false;
            this.txt_account.Location = new System.Drawing.Point(130, 103);
            this.txt_account.Name = "txt_account";
            this.txt_account.Size = new System.Drawing.Size(370, 23);
            this.txt_account.TabIndex = 3;
            this.txt_account.Text = "SA";
            // 
            // txt_database_name
            // 
            this.txt_database_name.Location = new System.Drawing.Point(130, 45);
            this.txt_database_name.Name = "txt_database_name";
            this.txt_database_name.Size = new System.Drawing.Size(370, 23);
            this.txt_database_name.TabIndex = 1;
            this.txt_database_name.Text = "QUAN_LY_SAN_PHAM";
            // 
            // txt_server_name
            // 
            this.txt_server_name.Location = new System.Drawing.Point(130, 16);
            this.txt_server_name.Name = "txt_server_name";
            this.txt_server_name.Size = new System.Drawing.Size(370, 23);
            this.txt_server_name.TabIndex = 0;
            this.txt_server_name.Text = ".\\SQLEXPRESS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "MẬT KHẨU";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "NGƯỜI SỬ DỤNG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "KIỂU XÁC THỰC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "TÊN CSDL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "MÁY CHỦ SQL";
            // 
            // TabP2
            // 
            this.TabP2.Controls.Add(this.txt_sql_connection_string);
            this.TabP2.Controls.Add(this.label6);
            this.TabP2.Location = new System.Drawing.Point(4, 25);
            this.TabP2.Name = "TabP2";
            this.TabP2.Padding = new System.Windows.Forms.Padding(3);
            this.TabP2.Size = new System.Drawing.Size(517, 166);
            this.TabP2.TabIndex = 1;
            this.TabP2.Text = "NÂNG CAO";
            this.TabP2.UseVisualStyleBackColor = true;
            // 
            // txt_sql_connection_string
            // 
            this.txt_sql_connection_string.Location = new System.Drawing.Point(14, 44);
            this.txt_sql_connection_string.Multiline = true;
            this.txt_sql_connection_string.Name = "txt_sql_connection_string";
            this.txt_sql_connection_string.Size = new System.Drawing.Size(488, 106);
            this.txt_sql_connection_string.TabIndex = 0;
            this.txt_sql_connection_string.Text = "Data Source=.\\SQLEXPRESS;Initial Catalog=QUAN_LY_SAN_PHAM;Integrated Security=Tru" +
                "e";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(295, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "CHUỖI KẾT NỐI CSDL - SQL CONNECTION STRING";
            // 
            // btn_test_and_save_connection
            // 
            this.btn_test_and_save_connection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_test_and_save_connection.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_test_and_save_connection.Location = new System.Drawing.Point(12, 213);
            this.btn_test_and_save_connection.Name = "btn_test_and_save_connection";
            this.btn_test_and_save_connection.Size = new System.Drawing.Size(278, 42);
            this.btn_test_and_save_connection.TabIndex = 5;
            this.btn_test_and_save_connection.Text = "&KIỂM TRA KẾT NỐI VÀ LƯU CẤU HÌNH";
            this.btn_test_and_save_connection.UseVisualStyleBackColor = true;
            this.btn_test_and_save_connection.Click += new System.EventHandler(this.btn_test_and_save_connection_Click);
            // 
            // btn_reset_default
            // 
            this.btn_reset_default.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reset_default.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset_default.Location = new System.Drawing.Point(296, 213);
            this.btn_reset_default.Name = "btn_reset_default";
            this.btn_reset_default.Size = new System.Drawing.Size(241, 42);
            this.btn_reset_default.TabIndex = 6;
            this.btn_reset_default.Text = "&SỬ DỤNG CẤU HÌNH MẶC ĐỊNH";
            this.btn_reset_default.UseVisualStyleBackColor = true;
            this.btn_reset_default.Click += new System.EventHandler(this.btn_reset_default_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_thoat.Location = new System.Drawing.Point(639, 213);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(101, 42);
            this.btn_thoat.TabIndex = 7;
            this.btn_thoat.TabStop = false;
            this.btn_thoat.Text = "THOÁT";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // Frm_CHCSDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_thoat;
            this.ClientSize = new System.Drawing.Size(550, 267);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.TabC1);
            this.Controls.Add(this.btn_reset_default);
            this.Controls.Add(this.btn_test_and_save_connection);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Frm_CHCSDL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CẤU HÌNH KẾT NỐI CSDL";
            this.Load += new System.EventHandler(this.Frm_CHCSDL_Load);
            this.TabC1.ResumeLayout(false);
            this.TabP1.ResumeLayout(false);
            this.TabP1.PerformLayout();
            this.TabP2.ResumeLayout(false);
            this.TabP2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabC1;
        private System.Windows.Forms.TabPage TabP1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_account;
        private System.Windows.Forms.TextBox txt_database_name;
        private System.Windows.Forms.TextBox txt_server_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage TabP2;
        private System.Windows.Forms.Button btn_test_and_save_connection;
        private System.Windows.Forms.TextBox txt_sql_connection_string;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_reset_default;
        private System.Windows.Forms.Button btn_thoat;

    }
}