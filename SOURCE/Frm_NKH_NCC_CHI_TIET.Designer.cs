﻿namespace QUẢN_LÝ_SẢN_PHẨM
{
    partial class Frm_NKH_NCC_CHI_TIET
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_NKH_NCC_CHI_TIET));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ma_nkhncc = new System.Windows.Forms.TextBox();
            this.txt_ten_nkhncc = new System.Windows.Forms.TextBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_capnhat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "MÃ NHÓM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(23, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "TÊN NHÓM";
            // 
            // txt_ma_nkhncc
            // 
            this.txt_ma_nkhncc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ma_nkhncc.Location = new System.Drawing.Point(118, 17);
            this.txt_ma_nkhncc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ma_nkhncc.Name = "txt_ma_nkhncc";
            this.txt_ma_nkhncc.Size = new System.Drawing.Size(316, 21);
            this.txt_ma_nkhncc.TabIndex = 0;
            // 
            // txt_ten_nkhncc
            // 
            this.txt_ten_nkhncc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ten_nkhncc.Location = new System.Drawing.Point(118, 42);
            this.txt_ten_nkhncc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ten_nkhncc.Name = "txt_ten_nkhncc";
            this.txt_ten_nkhncc.Size = new System.Drawing.Size(316, 21);
            this.txt_ten_nkhncc.TabIndex = 1;
            // 
            // btn_them
            // 
            this.btn_them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_them.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Location = new System.Drawing.Point(116, 80);
            this.btn_them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(206, 38);
            this.btn_them.TabIndex = 2;
            this.btn_them.Text = "&THÊM MỚI";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_thoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_thoat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.Location = new System.Drawing.Point(332, 80);
            this.btn_thoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(102, 38);
            this.btn_thoat.TabIndex = 3;
            this.btn_thoat.Text = "&HỦY";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_capnhat
            // 
            this.btn_capnhat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_capnhat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_capnhat.Location = new System.Drawing.Point(116, 80);
            this.btn_capnhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_capnhat.Name = "btn_capnhat";
            this.btn_capnhat.Size = new System.Drawing.Size(206, 38);
            this.btn_capnhat.TabIndex = 2;
            this.btn_capnhat.Text = "&CẬP NHẬT";
            this.btn_capnhat.UseVisualStyleBackColor = true;
            this.btn_capnhat.Click += new System.EventHandler(this.btn_capnhat_Click);
            // 
            // Frm_NKH_NCC_CHI_TIET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btn_thoat;
            this.ClientSize = new System.Drawing.Size(457, 136);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_capnhat);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txt_ten_nkhncc);
            this.Controls.Add(this.txt_ma_nkhncc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_NKH_NCC_CHI_TIET";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ DANH MỤC - NKH - NCC - CHI TIẾT";
            this.Load += new System.EventHandler(this.Frm_NKH_NCC_CHI_TIET_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ma_nkhncc;
        private System.Windows.Forms.TextBox txt_ten_nkhncc;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_capnhat;
    }
}