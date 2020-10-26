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
    public partial class Frm_NCC : Form
    {
        public string SQL_CONNECTION_STRING = "";

        public Frm_NCC()
        {
            InitializeComponent();
        }

        private void Frm_NCC_Load(object sender, EventArgs e)
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
            vmk.MS_SQL_QUERY = "SELECT [MA_NCC], (SELECT [TEN_NKH_NCC] FROM [DM_NKH_NCC] WHERE [MA_NKH_NCC] = NHA_CUNG_CAP.MA_NKH_NCC) AS [NKH_NCC], [TEN_NCC], [DIA_CHI], [SDT], [FAX], [EMAIL], [MST], [GHI_CHU] FROM NHA_CUNG_CAP ORDER BY [MA_NCC] ASC";
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

            if (DT.Rows.Count == 0) { dgv_ds_ncc.DataSource = null; dgv_ds_ncc.Columns.Clear(); return; }

            dgv_ds_ncc.DataSource = DT;

            // CHỈNH SỬA TIÊU ĐỀ CÁC CỘT CHO ĐỐI TƯỢNG DATAGRIDVIEW

            dgv_ds_ncc.Columns["MA_NCC"].HeaderText = "MÃ NCC";
            dgv_ds_ncc.Columns["NKH_NCC"].HeaderText = "NHÓM NCC";
            dgv_ds_ncc.Columns["TEN_NCC"].HeaderText = "TÊN NCC";
            dgv_ds_ncc.Columns["DIA_CHI"].HeaderText = "ĐỊA CHỈ";
            dgv_ds_ncc.Columns["SDT"].HeaderText = "SĐT";
            dgv_ds_ncc.Columns["FAX"].HeaderText = "FAX";
            dgv_ds_ncc.Columns["EMAIL"].HeaderText = "EMAIL";
            dgv_ds_ncc.Columns["MST"].HeaderText = "MÃ SỐ THUẾ";
            dgv_ds_ncc.Columns["GHI_CHU"].HeaderText = "GHI CHÚ";
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
			if (dgv_ds_ncc.Rows.Count == 0 || dgv_ds_ncc.SelectedRows.Count == 0){ return; }

            string ma_ncc = dgv_ds_ncc.SelectedRows[0].Cells["MA_NCC"].Value.ToString().Trim();

            if (ma_ncc == "")
            {
                MessageBox.Show("BẠN CHƯA CHỌN DỮ LIỆU CẦN XÓA", "THÔNG BÁO");
                return;
            }

            if (MessageBox.Show("BẠN MUỐN XÓA DỮ LIỆU ĐANG CHỌN ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "DELETE FROM NHA_CUNG_CAP WHERE MA_NCC = @MA_NCC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NCC", ma_ncc, SqlDbType.VarChar);
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

            Frm_NCC_CHI_TIET Frm = new Frm_NCC_CHI_TIET();
            Frm.ID_DATA = "";
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();

            this.Show();

            RELOAD_DATA_FROM_SQL();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
			if (dgv_ds_ncc.Rows.Count == 0 || dgv_ds_ncc.SelectedRows.Count == 0){ return; }

            string ma_ncc = dgv_ds_ncc.SelectedRows[0].Cells["MA_NCC"].Value.ToString().Trim();

            if (ma_ncc == "")
            {
                MessageBox.Show("BẠN CHƯA CHỌN DỮ LIỆU CẦN CHỈNH SỬA", "THÔNG BÁO");
                return;
            }

            this.Hide();

            Frm_NCC_CHI_TIET Frm = new Frm_NCC_CHI_TIET();
            Frm.ID_DATA = ma_ncc;
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();

            this.Show();

            RELOAD_DATA_FROM_SQL();
        }
    }
}