namespace QUẢN_LÝ_SẢN_PHẨM
{
    partial class Frm_PX_SP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PX_SP));
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_ds_pxsp = new System.Windows.Forms.DataGridView();
            this.dgv_ds_pxsp_chitiet = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_pxsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_pxsp_chitiet)).BeginInit();
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
            this.label4.Text = "DANH SÁCH PHIẾU XUẤT SẢN PHẨM";
            // 
            // dgv_ds_pxsp
            // 
            this.dgv_ds_pxsp.AllowUserToAddRows = false;
            this.dgv_ds_pxsp.AllowUserToOrderColumns = true;
            this.dgv_ds_pxsp.AllowUserToResizeRows = false;
            this.dgv_ds_pxsp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ds_pxsp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_ds_pxsp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_ds_pxsp.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ds_pxsp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ds_pxsp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ds_pxsp.ColumnHeadersHeight = 30;
            this.dgv_ds_pxsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ds_pxsp.EnableHeadersVisualStyles = false;
            this.dgv_ds_pxsp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_ds_pxsp.Location = new System.Drawing.Point(13, 26);
            this.dgv_ds_pxsp.MultiSelect = false;
            this.dgv_ds_pxsp.Name = "dgv_ds_pxsp";
            this.dgv_ds_pxsp.ReadOnly = true;
            this.dgv_ds_pxsp.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_ds_pxsp.RowHeadersVisible = false;
            this.dgv_ds_pxsp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_ds_pxsp.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 2, 10, 2);
            this.dgv_ds_pxsp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ds_pxsp.Size = new System.Drawing.Size(633, 235);
            this.dgv_ds_pxsp.TabIndex = 0;
            this.dgv_ds_pxsp.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ds_pxsp_RowEnter);
            // 
            // dgv_ds_pxsp_chitiet
            // 
            this.dgv_ds_pxsp_chitiet.AllowUserToAddRows = false;
            this.dgv_ds_pxsp_chitiet.AllowUserToOrderColumns = true;
            this.dgv_ds_pxsp_chitiet.AllowUserToResizeRows = false;
            this.dgv_ds_pxsp_chitiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ds_pxsp_chitiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_ds_pxsp_chitiet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_ds_pxsp_chitiet.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ds_pxsp_chitiet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ds_pxsp_chitiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ds_pxsp_chitiet.ColumnHeadersHeight = 30;
            this.dgv_ds_pxsp_chitiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ds_pxsp_chitiet.EnableHeadersVisualStyles = false;
            this.dgv_ds_pxsp_chitiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_ds_pxsp_chitiet.Location = new System.Drawing.Point(13, 333);
            this.dgv_ds_pxsp_chitiet.MultiSelect = false;
            this.dgv_ds_pxsp_chitiet.Name = "dgv_ds_pxsp_chitiet";
            this.dgv_ds_pxsp_chitiet.ReadOnly = true;
            this.dgv_ds_pxsp_chitiet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_ds_pxsp_chitiet.RowHeadersVisible = false;
            this.dgv_ds_pxsp_chitiet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_ds_pxsp_chitiet.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 2, 10, 2);
            this.dgv_ds_pxsp_chitiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ds_pxsp_chitiet.Size = new System.Drawing.Size(633, 153);
            this.dgv_ds_pxsp_chitiet.TabIndex = 3;
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
            this.label1.Text = "CHI TIẾT PHIẾU XUẤT";
            // 
            // Frm_PX_SP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btn_thoat;
            this.ClientSize = new System.Drawing.Size(660, 497);
            this.Controls.Add(this.dgv_ds_pxsp_chitiet);
            this.Controls.Add(this.dgv_ds_pxsp);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_reload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_PX_SP";
            this.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHỨNG TỪ - PHIẾU XUẤT SẢN PHẨM";
            this.Load += new System.EventHandler(this.Frm_PX_SP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_pxsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ds_pxsp_chitiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_ds_pxsp;
        private System.Windows.Forms.DataGridView dgv_ds_pxsp_chitiet;
        private System.Windows.Forms.Label label1;
    }
}