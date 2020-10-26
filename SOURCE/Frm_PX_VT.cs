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
    public partial class Frm_PX_VT : Form
    {
        public string SQL_CONNECTION_STRING = "";

        public Frm_PX_VT()
        {
            InitializeComponent();
        }

        private void Frm_PX_VT_Load(object sender, EventArgs e)
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
            vmk.MS_SQL_QUERY = "SELECT MA_PHIEU_XUAT, HO_TEN_NGUOI_NHAN, (SELECT TEN_BP FROM DM_BO_PHAN WHERE MA_BP = KHO_VT_PHIEU_XUAT.MA_BP) AS BO_PHAN, THOI_GIAN_XUAT FROM KHO_VT_PHIEU_XUAT ORDER BY THOI_GIAN_XUAT DESC";
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

            if (DT.Rows.Count == 0) { dgv_ds_pxvt.DataSource = null; dgv_ds_pxvt.Columns.Clear(); return; }

            dgv_ds_pxvt.DataSource = DT;

            // CHỈNH SỬA TIÊU ĐỀ CÁC CỘT CHO ĐỐI TƯỢNG DATAGRIDVIEW

            dgv_ds_pxvt.Columns["MA_PHIEU_XUAT"].HeaderText = "MÃ PHIẾU";
            dgv_ds_pxvt.Columns["HO_TEN_NGUOI_NHAN"].HeaderText = "NGƯỜI NHẬN";
            dgv_ds_pxvt.Columns["BO_PHAN"].HeaderText = "BỘ PHẬN";
            dgv_ds_pxvt.Columns["THOI_GIAN_XUAT"].HeaderText = "THỜI GIAN XUẤT";
        }

        private void LAY_CHI_TIET_TU_CSDL_THEO_MA_PHIEU(string ma_phieu)
        {
            if (ma_phieu.Trim() == "") { return; }

            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_VT, (SELECT TEN_VT FROM KHO_VAT_TU WHERE MA_VT = KHO_VT_CHI_TIET_XUAT.MA_VT) AS TEN_VT, (SELECT TEN_KHO FROM DM_KHO_HANG WHERE MA_KHO = KHO_VT_CHI_TIET_XUAT.MA_KHO) AS KHO, SO_LUONG FROM KHO_VT_CHI_TIET_XUAT WHERE MA_PHIEU_XUAT = @MA_PHIEU_XUAT";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_PHIEU_XUAT", ma_phieu, SqlDbType.Int);
            ArrayList KQ = vmk.MS_SQL_SELECT();

            if (KQ[0].ToString() == "ERROR")
            {
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return;
            }

            DataTable DT = (DataTable)KQ[2];

            // SAU ĐÓ NẠP VÀO DATAGRIDVIEW

            if (DT.Rows.Count == 0) { dgv_ds_pxvt_chitiet.DataSource = null; dgv_ds_pxvt_chitiet.Columns.Clear(); return; }

            dgv_ds_pxvt_chitiet.DataSource = DT;

            // CHỈNH SỬA TIÊU ĐỀ CÁC CỘT CHO ĐỐI TƯỢNG DATAGRIDVIEW

            dgv_ds_pxvt_chitiet.Columns["MA_VT"].HeaderText = "MÃ VT";
            dgv_ds_pxvt_chitiet.Columns["TEN_VT"].HeaderText = "TÊN VT";
            dgv_ds_pxvt_chitiet.Columns["KHO"].HeaderText = "TÊN KHO";
            dgv_ds_pxvt_chitiet.Columns["SO_LUONG"].HeaderText = "SỐ LƯỢNG";
        }

        private void dgv_ds_pxvt_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_ds_pxvt.Rows.Count != 0)
            {
                if (e.RowIndex > -1)
                {
                    string ma_phieu = dgv_ds_pxvt.Rows[e.RowIndex].Cells["MA_PHIEU_XUAT"].Value.ToString();
                    LAY_CHI_TIET_TU_CSDL_THEO_MA_PHIEU(ma_phieu);
                }
            }
        }
    }
}