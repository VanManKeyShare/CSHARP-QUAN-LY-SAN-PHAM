namespace QUẢN_LÝ_SẢN_PHẨM
{
    partial class Frm_KHO_SP_NHAP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_KHO_SP_NHAP));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_ma_bp = new System.Windows.Forms.ComboBox();
            this.txt_hoten_nguoi_giao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_ds_sp_chi_tiet = new System.Windows.Forms.DataGridView();
            this.nbric_dongia = new System.Windows.Forms.NumericUpDown();
            this.nbric_soluong = new System.Windows.Forms.NumericUpDown();
            this.btn_xoa_item = new System.Windows.Forms.Button();
            this.btn_them_item = new System.Windows.Forms.Button();
            this.cbo_ma_kho = new System.Windows.Forms.ComboBox();
            this.cbo_ma_sp = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_nhap = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_sp_chi_tiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbric_dongia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbric_soluong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbo_ma_bp);
            this.groupBox1.Controls.Add(this.txt_hoten_nguoi_giao);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(803, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " THÔNG TIN PHIẾU NHẬP SẢN PHẨM";
            // 
            // cbo_ma_bp
            // 
            this.cbo_ma_bp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ma_bp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_ma_bp.FormattingEnabled = true;
            this.cbo_ma_bp.Location = new System.Drawing.Point(157, 50);
            this.cbo_ma_bp.Name = "cbo_ma_bp";
            this.cbo_ma_bp.Size = new System.Drawing.Size(630, 21);
            this.cbo_ma_bp.TabIndex = 1;
            // 
            // txt_hoten_nguoi_giao
            // 
            this.txt_hoten_nguoi_giao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_hoten_nguoi_giao.Location = new System.Drawing.Point(157, 23);
            this.txt_hoten_nguoi_giao.Name = "txt_hoten_nguoi_giao";
            this.txt_hoten_nguoi_giao.Size = new System.Drawing.Size(630, 21);
            this.txt_hoten_nguoi_giao.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "BỘ PHẬN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HỌ TÊN NGƯỜI GIAO";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.nbric_dongia);
            this.groupBox2.Controls.Add(this.nbric_soluong);
            this.groupBox2.Controls.Add(this.btn_xoa_item);
            this.groupBox2.Controls.Add(this.btn_them_item);
            this.groupBox2.Controls.Add(this.cbo_ma_kho);
            this.groupBox2.Controls.Add(this.cbo_ma_sp);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(803, 362);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " DANH SÁCH SẢN PHẨM CẦN NHẬP ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgv_ds_sp_chi_tiet);
            this.panel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(6, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 252);
            this.panel1.TabIndex = 11;
            // 
            // dgv_ds_sp_chi_tiet
            // 
            this.dgv_ds_sp_chi_tiet.AllowUserToAddRows = false;
            this.dgv_ds_sp_chi_tiet.AllowUserToOrderColumns = true;
            this.dgv_ds_sp_chi_tiet.AllowUserToResizeRows = false;
            this.dgv_ds_sp_chi_tiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ds_sp_chi_tiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_ds_sp_chi_tiet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_ds_sp_chi_tiet.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ds_sp_chi_tiet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ds_sp_chi_tiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ds_sp_chi_tiet.ColumnHeadersHeight = 30;
            this.dgv_ds_sp_chi_tiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ds_sp_chi_tiet.EnableHeadersVisualStyles = false;
            this.dgv_ds_sp_chi_tiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_ds_sp_chi_tiet.Location = new System.Drawing.Point(8, 3);
            this.dgv_ds_sp_chi_tiet.MultiSelect = false;
            this.dgv_ds_sp_chi_tiet.Name = "dgv_ds_sp_chi_tiet";
            this.dgv_ds_sp_chi_tiet.ReadOnly = true;
            this.dgv_ds_sp_chi_tiet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_ds_sp_chi_tiet.RowHeadersVisible = false;
            this.dgv_ds_sp_chi_tiet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_ds_sp_chi_tiet.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 2, 10, 2);
            this.dgv_ds_sp_chi_tiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ds_sp_chi_tiet.Size = new System.Drawing.Size(773, 243);
            this.dgv_ds_sp_chi_tiet.TabIndex = 8;
            // 
            // nbric_dongia
            // 
            this.nbric_dongia.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.nbric_dongia.Location = new System.Drawing.Point(90, 77);
            this.nbric_dongia.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nbric_dongia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbric_dongia.Name = "nbric_dongia";
            this.nbric_dongia.Size = new System.Drawing.Size(185, 21);
            this.nbric_dongia.TabIndex = 4;
            this.nbric_dongia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nbric_soluong
            // 
            this.nbric_soluong.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.nbric_soluong.Location = new System.Drawing.Point(355, 77);
            this.nbric_soluong.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nbric_soluong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbric_soluong.Name = "nbric_soluong";
            this.nbric_soluong.Size = new System.Drawing.Size(157, 21);
            this.nbric_soluong.TabIndex = 5;
            this.nbric_soluong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_xoa_item
            // 
            this.btn_xoa_item.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_xoa_item.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa_item.Location = new System.Drawing.Point(651, 49);
            this.btn_xoa_item.Name = "btn_xoa_item";
            this.btn_xoa_item.Size = new System.Drawing.Size(137, 50);
            this.btn_xoa_item.TabIndex = 7;
            this.btn_xoa_item.Text = "&XÓA RA KHỎI DS";
            this.btn_xoa_item.UseVisualStyleBackColor = true;
            this.btn_xoa_item.Click += new System.EventHandler(this.btn_xoa_item_Click);
            // 
            // btn_them_item
            // 
            this.btn_them_item.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_them_item.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them_item.Location = new System.Drawing.Point(518, 49);
            this.btn_them_item.Name = "btn_them_item";
            this.btn_them_item.Size = new System.Drawing.Size(126, 50);
            this.btn_them_item.TabIndex = 6;
            this.btn_them_item.Text = "&THÊM VÀO DS";
            this.btn_them_item.UseVisualStyleBackColor = true;
            this.btn_them_item.Click += new System.EventHandler(this.btn_them_item_Click);
            // 
            // cbo_ma_kho
            // 
            this.cbo_ma_kho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ma_kho.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_ma_kho.FormattingEnabled = true;
            this.cbo_ma_kho.Location = new System.Drawing.Point(90, 50);
            this.cbo_ma_kho.Name = "cbo_ma_kho";
            this.cbo_ma_kho.Size = new System.Drawing.Size(422, 21);
            this.cbo_ma_kho.TabIndex = 3;
            // 
            // cbo_ma_sp
            // 
            this.cbo_ma_sp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ma_sp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_ma_sp.FormattingEnabled = true;
            this.cbo_ma_sp.Location = new System.Drawing.Point(90, 23);
            this.cbo_ma_sp.Name = "cbo_ma_sp";
            this.cbo_ma_sp.Size = new System.Drawing.Size(697, 21);
            this.cbo_ma_sp.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(11, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "ĐƠN GIÁ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(281, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "SỐ LƯỢNG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(11, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "KHO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(11, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "SẢN PHẨM";
            // 
            // btn_thoat
            // 
            this.btn_thoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_thoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_thoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_thoat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.Location = new System.Drawing.Point(717, 475);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(100, 31);
            this.btn_thoat.TabIndex = 10;
            this.btn_thoat.Text = "&THOÁT";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_nhap
            // 
            this.btn_nhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_nhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_nhap.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nhap.Location = new System.Drawing.Point(12, 475);
            this.btn_nhap.Name = "btn_nhap";
            this.btn_nhap.Size = new System.Drawing.Size(214, 31);
            this.btn_nhap.TabIndex = 9;
            this.btn_nhap.Text = "&TIẾN HÀNH NHẬP SẢN PHẨM";
            this.btn_nhap.UseVisualStyleBackColor = true;
            this.btn_nhap.Click += new System.EventHandler(this.btn_nhap_Click);
            // 
            // Frm_KHO_SP_NHAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_thoat;
            this.ClientSize = new System.Drawing.Size(829, 517);
            this.Controls.Add(this.btn_nhap);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_KHO_SP_NHAP";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHẬP KHO SẢN PHẨM";
            this.Load += new System.EventHandler(this.Frm_KHO_SP_NHAP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_sp_chi_tiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbric_dongia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbric_soluong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_hoten_nguoi_giao;
        private System.Windows.Forms.ComboBox cbo_ma_bp;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_nhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_ma_kho;
        private System.Windows.Forms.ComboBox cbo_ma_sp;
        private System.Windows.Forms.Button btn_xoa_item;
        private System.Windows.Forms.Button btn_them_item;
        private System.Windows.Forms.NumericUpDown nbric_dongia;
        private System.Windows.Forms.NumericUpDown nbric_soluong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_ds_sp_chi_tiet;
    }
}