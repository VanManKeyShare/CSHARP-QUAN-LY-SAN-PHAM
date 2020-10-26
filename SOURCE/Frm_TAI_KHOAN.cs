using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;

namespace QUẢN_LÝ_SẢN_PHẨM
{
    public partial class Frm_TAI_KHOAN : Form
    {
        public string Acc_Logged = "";
        public string SQL_CONNECTION_STRING = "";

        public Frm_TAI_KHOAN()
        {
            InitializeComponent();
        }

        private void Frm_TAIKHOAN_Load(object sender, EventArgs e)
        {
            RELOAD_DATA_FROM_SQL();
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            RELOAD_DATA_FROM_SQL();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RELOAD_DATA_FROM_SQL()
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT ACC, PASS, TEN_TK, (SELECT TEN_NTK FROM DM_NHOM_TAI_KHOAN WHERE MA_NTK = TAI_KHOAN.MA_NTK) AS NHOM_TK, DIA_CHI, SDT FROM TAI_KHOAN ORDER BY ACC ASC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            ArrayList KQ = vmk.MS_SQL_SELECT();

            if (KQ[0].ToString() == "ERROR")
            {
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return;
            }

            DataTable DT = (DataTable)KQ[2];

            // SAU ĐÓ NẠP VÀO DATAGRIDVIEW

            if (DT.Rows.Count == 0) { dgv_ds_tk.DataSource = null; dgv_ds_tk.Columns.Clear(); return; }

            dgv_ds_tk.DataSource = DT;

            // CHỈNH SỬA TIÊU ĐỀ CÁC CỘT CHO ĐỐI TƯỢNG DATAGRIDVIEW

            dgv_ds_tk.Columns["ACC"].HeaderText = "TÀI KHOẢN";
            dgv_ds_tk.Columns["PASS"].HeaderText = "MẬT KHẨU";
            dgv_ds_tk.Columns["TEN_TK"].HeaderText = "TÊN TK";
            dgv_ds_tk.Columns["NHOM_TK"].HeaderText = "NHÓM TK";
            dgv_ds_tk.Columns["DIA_CHI"].HeaderText = "ĐỊA CHỈ";
            dgv_ds_tk.Columns["SDT"].HeaderText = "SĐT";
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
			if (dgv_ds_tk.Rows.Count == 0 || dgv_ds_tk.SelectedRows.Count == 0){ return; }

            string acc = dgv_ds_tk.SelectedRows[0].Cells["ACC"].Value.ToString().Trim();

            if (acc == "")
            {
                MessageBox.Show("BẠN CHƯA CHỌN DỮ LIỆU CẦN XÓA", "THÔNG BÁO");
                return;
            }

            if (acc.ToLower() == Acc_Logged.ToLower())
            {
                MessageBox.Show("KHÔNG THỂ XÓA. TÀI KHOẢN ĐANG ĐƯỢC SỬ DỤNG", "THÔNG BÁO");
                return;
            }

            if (MessageBox.Show("BẠN MUỐN XÓA DỮ LIỆU ĐANG CHỌN ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "DELETE FROM TAI_KHOAN WHERE ACC = @ACC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@ACC", acc, SqlDbType.VarChar);
            String[] KQ = vmk.MS_SQL_INSERT_DELETE_UPDATE();

            if (KQ[0].ToString() == "ERROR")
            {
                Console.WriteLine(KQ[1].ToString());
                if (KQ[1].ToLower().Contains("the delete statement conflicted with the reference constraint"))
                {
                    MessageBox.Show("KHÔNG THỂ XÓA. DỮ LIỆU ĐANG ĐƯỢC SỬ DỤNG Ở BẢNG KHÁC", "THÔNG BÁO");
                    return;
                }
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return;
            }

            // NẾU XÓA THÀNH CÔNG THÌ CẬP NHẬT LẠI DỮ LIỆU

            RELOAD_DATA_FROM_SQL();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            this.Hide();

            Frm_TAI_KHOAN_CHI_TIET Frm = new Frm_TAI_KHOAN_CHI_TIET();
            Frm.ID_DATA = "";
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();

            this.Show();

            RELOAD_DATA_FROM_SQL();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
			if (dgv_ds_tk.Rows.Count == 0 || dgv_ds_tk.SelectedRows.Count == 0){ return; }

            string acc = dgv_ds_tk.SelectedRows[0].Cells["ACC"].Value.ToString().Trim();

            if (acc == "")
            {
                MessageBox.Show("BẠN CHƯA CHỌN DỮ LIỆU CẦN CHỈNH SỬA", "THÔNG BÁO");
                return;
            }

            this.Hide();

            Frm_TAI_KHOAN_CHI_TIET Frm = new Frm_TAI_KHOAN_CHI_TIET();
            Frm.ID_DATA = acc;
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();

            this.Show();

            RELOAD_DATA_FROM_SQL();
        }
    }
}