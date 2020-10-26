namespace QUẢN_LÝ_SẢN_PHẨM
{
    partial class Frm_KHO_SP_XUAT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_KHO_SP_XUAT));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_ma_kh = new System.Windows.Forms.ComboBox();
            this.txt_theo_hd = new System.Windows.Forms.TextBox();
            this.txt_hoten_nguoi_nhan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nbric_soluong = new System.Windows.Forms.NumericUpDown();
            this.btn_xoa_item = new System.Windows.Forms.Button();
            this.btn_them_item = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_ds_item_trong_kho = new System.Windows.Forms.DataGridView();
            this.dgv_ds_item_chi_tiet = new System.Windows.Forms.DataGridView();
            this.btn_xem_item_trong_kho = new System.Windows.Forms.Button();
            this.cbo_ma_kho = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_xuat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbric_soluong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_item_trong_kho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_item_chi_tiet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbo_ma_kh);
            this.groupBox1.Controls.Add(this.txt_theo_hd);
            this.groupBox1.Controls.Add(this.txt_hoten_nguoi_nhan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(803, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " THÔNG TIN PHIẾU XUẤT SẢN PHẨM";
            // 
            // cbo_ma_kh
            // 
            this.cbo_ma_kh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ma_kh.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_ma_kh.FormattingEnabled = true;
            this.cbo_ma_kh.Location = new System.Drawing.Point(157, 50);
            this.cbo_ma_kh.Name = "cbo_ma_kh";
            this.cbo_ma_kh.Size = new System.Drawing.Size(630, 21);
            this.cbo_ma_kh.TabIndex = 1;
            // 
            // txt_theo_hd
            // 
            this.txt_theo_hd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_theo_hd.Location = new System.Drawing.Point(157, 77);
            this.txt_theo_hd.Name = "txt_theo_hd";
            this.txt_theo_hd.Size = new System.Drawing.Size(630, 21);
            this.txt_theo_hd.TabIndex = 2;
            // 
            // txt_hoten_nguoi_nhan
            // 
            this.txt_hoten_nguoi_nhan.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_hoten_nguoi_nhan.Location = new System.Drawing.Point(157, 23);
            this.txt_hoten_nguoi_nhan.Name = "txt_hoten_nguoi_nhan";
            this.txt_hoten_nguoi_nhan.Size = new System.Drawing.Size(630, 21);
            this.txt_hoten_nguoi_nhan.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(10, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "THEO HĐ SỐ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(10, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "KHÁCH HÀNG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HỌ TÊN NGƯỜI NHẬN";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.btn_xem_item_trong_kho);
            this.groupBox2.Controls.Add(this.cbo_ma_kho);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(803, 390);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " DANH SÁCH SẢN PHẨM CẦN XUẤT";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.nbric_soluong);
            this.panel1.Controls.Add(this.btn_xoa_item);
            this.panel1.Controls.Add(this.btn_them_item);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dgv_ds_item_trong_kho);
            this.panel1.Controls.Add(this.dgv_ds_item_chi_tiet);
            this.panel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(6, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 333);
            this.panel1.TabIndex = 5;
            // 
            // nbric_soluong
            // 
            this.nbric_soluong.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.nbric_soluong.Location = new System.Drawing.Point(80, 164);
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
            this.nbric_soluong.Size = new System.Drawing.Size(108, 21);
            this.nbric_soluong.TabIndex = 6;
            this.nbric_soluong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_xoa_item
            // 
            this.btn_xoa_item.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_xoa_item.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_xoa_item.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa_item.Location = new System.Drawing.Point(584, 162);
            this.btn_xoa_item.Name = "btn_xoa_item";
            this.btn_xoa_item.Size = new System.Drawing.Size(198, 25);
            this.btn_xoa_item.TabIndex = 8;
            this.btn_xoa_item.Text = "&XÓA RA KHỎI DANH SÁCH";
            this.btn_xoa_item.UseVisualStyleBackColor = true;
            this.btn_xoa_item.Click += new System.EventHandler(this.btn_xoa_item_Click);
            // 
            // btn_them_item
            // 
            this.btn_them_item.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_them_item.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them_item.Location = new System.Drawing.Point(194, 162);
            this.btn_them_item.Name = "btn_them_item";
            this.btn_them_item.Size = new System.Drawing.Size(186, 25);
            this.btn_them_item.TabIndex = 7;
            this.btn_them_item.Text = "&THÊM VÀO DANH SÁCH";
            this.btn_them_item.UseVisualStyleBackColor = true;
            this.btn_them_item.Click += new System.EventHandler(this.btn_them_item_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(4, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "SỐ LƯỢNG";
            // 
            // dgv_ds_item_trong_kho
            // 
            this.dgv_ds_item_trong_kho.AllowUserToAddRows = false;
            this.dgv_ds_item_trong_kho.AllowUserToOrderColumns = true;
            this.dgv_ds_item_trong_kho.AllowUserToResizeRows = false;
            this.dgv_ds_item_trong_kho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ds_item_trong_kho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_ds_item_trong_kho.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_ds_item_trong_kho.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ds_item_trong_kho.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ds_item_trong_kho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ds_item_trong_kho.ColumnHeadersHeight = 30;
            this.dgv_ds_item_trong_kho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ds_item_trong_kho.EnableHeadersVisualStyles = false;
            this.dgv_ds_item_trong_kho.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_ds_item_trong_kho.Location = new System.Drawing.Point(7, 3);
            this.dgv_ds_item_trong_kho.MultiSelect = false;
            this.dgv_ds_item_trong_kho.Name = "dgv_ds_item_trong_kho";
            this.dgv_ds_item_trong_kho.ReadOnly = true;
            this.dgv_ds_item_trong_kho.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_ds_item_trong_kho.RowHeadersVisible = false;
            this.dgv_ds_item_trong_kho.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_ds_item_trong_kho.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 2, 10, 2);
            this.dgv_ds_item_trong_kho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ds_item_trong_kho.Size = new System.Drawing.Size(774, 153);
            this.dgv_ds_item_trong_kho.TabIndex = 5;
            // 
            // dgv_ds_item_chi_tiet
            // 
            this.dgv_ds_item_chi_tiet.AllowUserToAddRows = false;
            this.dgv_ds_item_chi_tiet.AllowUserToOrderColumns = true;
            this.dgv_ds_item_chi_tiet.AllowUserToResizeRows = false;
            this.dgv_ds_item_chi_tiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ds_item_chi_tiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_ds_item_chi_tiet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_ds_item_chi_tiet.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ds_item_chi_tiet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ds_item_chi_tiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ds_item_chi_tiet.ColumnHeadersHeight = 30;
            this.dgv_ds_item_chi_tiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ds_item_chi_tiet.EnableHeadersVisualStyles = false;
            this.dgv_ds_item_chi_tiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_ds_item_chi_tiet.Location = new System.Drawing.Point(7, 193);
            this.dgv_ds_item_chi_tiet.MultiSelect = false;
            this.dgv_ds_item_chi_tiet.Name = "dgv_ds_item_chi_tiet";
            this.dgv_ds_item_chi_tiet.ReadOnly = true;
            this.dgv_ds_item_chi_tiet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_ds_item_chi_tiet.RowHeadersVisible = false;
            this.dgv_ds_item_chi_tiet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_ds_item_chi_tiet.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 2, 10, 2);
            this.dgv_ds_item_chi_tiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ds_item_chi_tiet.Size = new System.Drawing.Size(774, 137);
            this.dgv_ds_item_chi_tiet.TabIndex = 9;
            // 
            // btn_xem_item_trong_kho
            // 
            this.btn_xem_item_trong_kho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_xem_item_trong_kho.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xem_item_trong_kho.Location = new System.Drawing.Point(549, 22);
            this.btn_xem_item_trong_kho.Name = "btn_xem_item_trong_kho";
            this.btn_xem_item_trong_kho.Size = new System.Drawing.Size(239, 25);
            this.btn_xem_item_trong_kho.TabIndex = 4;
            this.btn_xem_item_trong_kho.Text = "&XEM SẢN PHẨM TRONG KHO";
            this.btn_xem_item_trong_kho.UseVisualStyleBackColor = true;
            this.btn_xem_item_trong_kho.Click += new System.EventHandler(this.btn_xem_item_trong_kho_Click);
            // 
            // cbo_ma_kho
            // 
            this.cbo_ma_kho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ma_kho.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_ma_kho.FormattingEnabled = true;
            this.cbo_ma_kho.Location = new System.Drawing.Point(92, 24);
            this.cbo_ma_kho.Name = "cbo_ma_kho";
            this.cbo_ma_kho.Size = new System.Drawing.Size(451, 21);
            this.cbo_ma_kho.TabIndex = 3;
            this.cbo_ma_kho.SelectedValueChanged += new System.EventHandler(this.cbo_ma_kho_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(10, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "CHỌN KHO";
            // 
            // btn_thoat
            // 
            this.btn_thoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_thoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_thoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_thoat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.Location = new System.Drawing.Point(717, 529);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(100, 31);
            this.btn_thoat.TabIndex = 11;
            this.btn_thoat.Text = "&THOÁT";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_xuat
            // 
            this.btn_xuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_xuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_xuat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xuat.Location = new System.Drawing.Point(12, 529);
            this.btn_xuat.Name = "btn_xuat";
            this.btn_xuat.Size = new System.Drawing.Size(214, 31);
            this.btn_xuat.TabIndex = 10;
            this.btn_xuat.Text = "&TIẾN HÀNH XUẤT SẢN PHẨM";
            this.btn_xuat.UseVisualStyleBackColor = true;
            this.btn_xuat.Click += new System.EventHandler(this.btn_xuat_Click);
            // 
            // Frm_KHO_SP_XUAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_thoat;
            this.ClientSize = new System.Drawing.Size(829, 571);
            this.Controls.Add(this.btn_xuat);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_KHO_SP_XUAT";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XUẤT KHO SẢN PHẨM";
            this.Load += new System.EventHandler(this.Frm_KHO_SP_XUAT_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbric_soluong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_item_trong_kho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_item_chi_tiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_theo_hd;
        private System.Windows.Forms.TextBox txt_hoten_nguoi_nhan;
        private System.Windows.Forms.ComboBox cbo_ma_kh;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_xuat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_ma_kho;
        private System.Windows.Forms.Button btn_xem_item_trong_kho;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nbric_soluong;
        private System.Windows.Forms.Button btn_xoa_item;
        private System.Windows.Forms.Button btn_them_item;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_ds_item_trong_kho;
        private System.Windows.Forms.DataGridView dgv_ds_item_chi_tiet;
    }
}