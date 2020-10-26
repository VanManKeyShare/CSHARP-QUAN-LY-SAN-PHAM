namespace QUẢN_LÝ_SẢN_PHẨM
{
    partial class Frm_PN_SP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PN_SP));
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_ds_pnsp = new System.Windows.Forms.DataGridView();
            this.dgv_ds_pnsp_chitiet = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_pnsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_pnsp_chitiet)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_reload
            // 
            this.btn_reload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reload.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reload.Location = new System.Drawing.Point(12, 266);
            this.btn_reload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(166, 36);
            this.btn_reload.TabIndex = 1;
            this.btn_reload.Text = "&CẬP NHẬT DỮ LIỆU";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_thoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_thoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_thoat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.Location = new System.Drawing.Point(551, 266);
            this.btn_thoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(96, 36);
            this.btn_thoat.TabIndex = 2;
            this.btn_thoat.Text = "TH&OÁT";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(10, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "DANH SÁCH PHIẾU NHẬP SẢN PHẨM";
            // 
            // dgv_ds_pnsp
            // 
            this.dgv_ds_pnsp.AllowUserToAddRows = false;
            this.dgv_ds_pnsp.AllowUserToOrderColumns = true;
            this.dgv_ds_pnsp.AllowUserToResizeRows = false;
            this.dgv_ds_pnsp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ds_pnsp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_ds_pnsp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_ds_pnsp.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ds_pnsp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ds_pnsp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ds_pnsp.ColumnHeadersHeight = 30;
            this.dgv_ds_pnsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ds_pnsp.EnableHeadersVisualStyles = false;
            this.dgv_ds_pnsp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_ds_pnsp.Location = new System.Drawing.Point(13, 26);
            this.dgv_ds_pnsp.MultiSelect = false;
            this.dgv_ds_pnsp.Name = "dgv_ds_pnsp";
            this.dgv_ds_pnsp.ReadOnly = true;
            this.dgv_ds_pnsp.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_ds_pnsp.RowHeadersVisible = false;
            this.dgv_ds_pnsp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_ds_pnsp.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 2, 10, 2);
            this.dgv_ds_pnsp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ds_pnsp.Size = new System.Drawing.Size(633, 235);
            this.dgv_ds_pnsp.TabIndex = 0;
            this.dgv_ds_pnsp.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ds_pnsp_RowEnter);
            // 
            // dgv_ds_pnsp_chitiet
            // 
            this.dgv_ds_pnsp_chitiet.AllowUserToAddRows = false;
            this.dgv_ds_pnsp_chitiet.AllowUserToOrderColumns = true;
            this.dgv_ds_pnsp_chitiet.AllowUserToResizeRows = false;
            this.dgv_ds_pnsp_chitiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ds_pnsp_chitiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_ds_pnsp_chitiet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_ds_pnsp_chitiet.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ds_pnsp_chitiet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ds_pnsp_chitiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ds_pnsp_chitiet.ColumnHeadersHeight = 30;
            this.dgv_ds_pnsp_chitiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ds_pnsp_chitiet.EnableHeadersVisualStyles = false;
            this.dgv_ds_pnsp_chitiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_ds_pnsp_chitiet.Location = new System.Drawing.Point(13, 333);
            this.dgv_ds_pnsp_chitiet.MultiSelect = false;
            this.dgv_ds_pnsp_chitiet.Name = "dgv_ds_pnsp_chitiet";
            this.dgv_ds_pnsp_chitiet.ReadOnly = true;
            this.dgv_ds_pnsp_chitiet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_ds_pnsp_chitiet.RowHeadersVisible = false;
            this.dgv_ds_pnsp_chitiet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_ds_pnsp_chitiet.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 2, 10, 2);
            this.dgv_ds_pnsp_chitiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ds_pnsp_chitiet.Size = new System.Drawing.Size(633, 153);
            this.dgv_ds_pnsp_chitiet.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(10, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHI TIẾT PHIẾU NHẬP";
            // 
            // Frm_PN_SP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btn_thoat;
            this.ClientSize = new System.Drawing.Size(660, 497);
            this.Controls.Add(this.dgv_ds_pnsp_chitiet);
            this.Controls.Add(this.dgv_ds_pnsp);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_reload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_PN_SP";
            this.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHỨNG TỪ - PHIẾU NHẬP SẢN PHẨM";
            this.Load += new System.EventHandler(this.Frm_PN_SP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_pnsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_pnsp_chitiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_ds_pnsp;
        private System.Windows.Forms.DataGridView dgv_ds_pnsp_chitiet;
        private System.Windows.Forms.Label label1;
    }
}