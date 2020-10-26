namespace QUẢN_LÝ_SẢN_PHẨM
{
    partial class Frm_KHO_CHI_TIET
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_KHO_CHI_TIET));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ma_kho = new System.Windows.Forms.TextBox();
            this.txt_ten_kho = new System.Windows.Forms.TextBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_dia_chi = new System.Windows.Forms.TextBox();
            this.btn_capnhat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ghi_chu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_loaikho = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "MÃ KHO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(23, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "TÊN KHO";
            // 
            // txt_ma_kho
            // 
            this.txt_ma_kho.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ma_kho.Location = new System.Drawing.Point(97, 17);
            this.txt_ma_kho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ma_kho.Name = "txt_ma_kho";
            this.txt_ma_kho.Size = new System.Drawing.Size(362, 21);
            this.txt_ma_kho.TabIndex = 0;
            // 
            // txt_ten_kho
            // 
            this.txt_ten_kho.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ten_kho.Location = new System.Drawing.Point(97, 42);
            this.txt_ten_kho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ten_kho.Name = "txt_ten_kho";
            this.txt_ten_kho.Size = new System.Drawing.Size(362, 21);
            this.txt_ten_kho.TabIndex = 1;
            // 
            // btn_them
            // 
            this.btn_them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_them.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Location = new System.Drawing.Point(96, 274);
            this.btn_them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(221, 38);
            this.btn_them.TabIndex = 5;
            this.btn_them.Text = "&THÊM MỚI";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_thoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_thoat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.Location = new System.Drawing.Point(324, 274);
            this.btn_thoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(136, 38);
            this.btn_thoat.TabIndex = 6;
            this.btn_thoat.Text = "&HỦY";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(23, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "ĐỊA CHỈ";
            // 
            // txt_dia_chi
            // 
            this.txt_dia_chi.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dia_chi.Location = new System.Drawing.Point(97, 94);
            this.txt_dia_chi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_dia_chi.Multiline = true;
            this.txt_dia_chi.Name = "txt_dia_chi";
            this.txt_dia_chi.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_dia_chi.Size = new System.Drawing.Size(362, 77);
            this.txt_dia_chi.TabIndex = 3;
            // 
            // btn_capnhat
            // 
            this.btn_capnhat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_capnhat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_capnhat.Location = new System.Drawing.Point(96, 274);
            this.btn_capnhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_capnhat.Name = "btn_capnhat";
            this.btn_capnhat.Size = new System.Drawing.Size(221, 38);
            this.btn_capnhat.TabIndex = 5;
            this.btn_capnhat.Text = "&CẬP NHẬT";
            this.btn_capnhat.UseVisualStyleBackColor = true;
            this.btn_capnhat.Click += new System.EventHandler(this.btn_capnhat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(23, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "GHI CHÚ";
            // 
            // txt_ghi_chu
            // 
            this.txt_ghi_chu.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ghi_chu.Location = new System.Drawing.Point(97, 175);
            this.txt_ghi_chu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ghi_chu.Multiline = true;
            this.txt_ghi_chu.Name = "txt_ghi_chu";
            this.txt_ghi_chu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_ghi_chu.Size = new System.Drawing.Size(362, 77);
            this.txt_ghi_chu.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(23, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "LOẠI KHO";
            // 
            // cbo_loaikho
            // 
            this.cbo_loaikho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_loaikho.FormattingEnabled = true;
            this.cbo_loaikho.Location = new System.Drawing.Point(97, 68);
            this.cbo_loaikho.Name = "cbo_loaikho";
            this.cbo_loaikho.Size = new System.Drawing.Size(362, 21);
            this.cbo_loaikho.TabIndex = 2;
            // 
            // Frm_KHO_CHI_TIET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btn_thoat;
            this.ClientSize = new System.Drawing.Size(484, 335);
            this.Controls.Add(this.cbo_loaikho);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_capnhat);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txt_ghi_chu);
            this.Controls.Add(this.txt_dia_chi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_ten_kho);
            this.Controls.Add(this.txt_ma_kho);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_KHO_CHI_TIET";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ DANH MỤC - KHO HÀNG - CHI TIẾT";
            this.Load += new System.EventHandler(this.Frm_KHO_CHI_TIET_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ma_kho;
        private System.Windows.Forms.TextBox txt_ten_kho;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_dia_chi;
        private System.Windows.Forms.Button btn_capnhat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ghi_chu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_loaikho;
    }
}