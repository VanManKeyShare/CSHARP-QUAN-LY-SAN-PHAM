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
    public partial class Frm_PN_SP : Form
    {
        public string SQL_CONNECTION_STRING = "";

        public Frm_PN_SP()
        {
            InitializeComponent();
        }

        private void Frm_PN_SP_Load(object sender, EventArgs e)
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
            vmk.MS_SQL_QUERY = "SELECT MA_PHIEU_NHAP, HO_TEN_NGUOI_GIAO, (SELECT TEN_BP FROM DM_BO_PHAN WHERE MA_BP = KHO_SP_PHIEU_NHAP.MA_BP) AS BO_PHAN, THOI_GIAN_NHAP, (SELECT SUM(THANH_TIEN) FROM KHO_SP_CHI_TIET_NHAP WHERE MA_PHIEU_NHAP = KHO_SP_PHIEU_NHAP.MA_PHIEU_NHAP) AS TONG_TIEN FROM KHO_SP_PHIEU_NHAP ORDER BY THOI_GIAN_NHAP DESC";
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

            if (DT.Rows.Count == 0) { dgv_ds_pnsp.DataSource = null; dgv_ds_pnsp.Columns.Clear(); return; }

            dgv_ds_pnsp.DataSource = DT;

            // CHỈNH SỬA TIÊU ĐỀ CÁC CỘT CHO ĐỐI TƯỢNG DATAGRIDVIEW

            dgv_ds_pnsp.Columns["MA_PHIEU_NHAP"].HeaderText = "MÃ PHIẾU";
            dgv_ds_pnsp.Columns["HO_TEN_NGUOI_GIAO"].HeaderText = "NGƯỜI GIAO";
            dgv_ds_pnsp.Columns["BO_PHAN"].HeaderText = "BỘ PHẬN";
            dgv_ds_pnsp.Columns["THOI_GIAN_NHAP"].HeaderText = "THỜI GIAN NHẬP";
            dgv_ds_pnsp.Columns["TONG_TIEN"].HeaderText = "TỔNG TIỀN";
        }

        private void LAY_CHI_TIET_TU_CSDL_THEO_MA_PHIEU(string ma_phieu)
        {
            if (ma_phieu.Trim() == "") { return; }

            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_SP, (SELECT TEN_SP FROM KHO_SAN_PHAM WHERE MA_SP = KHO_SP_CHI_TIET_NHAP.MA_SP) AS TEN_SP, (SELECT TEN_KHO FROM DM_KHO_HANG WHERE MA_KHO = KHO_SP_CHI_TIET_NHAP.MA_KHO) AS KHO, SO_LUONG, DON_GIA, THANH_TIEN FROM KHO_SP_CHI_TIET_NHAP WHERE MA_PHIEU_NHAP = @MA_PHIEU_NHAP";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();            
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_PHIEU_NHAP", ma_phieu, SqlDbType.Int);
            ArrayList KQ = vmk.MS_SQL_SELECT();

            if (KQ[0].ToString() == "ERROR")
            {
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return;
            }

            DataTable DT = (DataTable)KQ[2];

            // SAU ĐÓ NẠP VÀO DATAGRIDVIEW

            if (DT.Rows.Count == 0) { dgv_ds_pnsp_chitiet.DataSource = null; dgv_ds_pnsp_chitiet.Columns.Clear(); return; }

            dgv_ds_pnsp_chitiet.DataSource = DT;

            // CHỈNH SỬA TIÊU ĐỀ CÁC CỘT CHO ĐỐI TƯỢNG DATAGRIDVIEW

            dgv_ds_pnsp_chitiet.Columns["MA_SP"].HeaderText = "MÃ SP";
            dgv_ds_pnsp_chitiet.Columns["TEN_SP"].HeaderText = "TÊN SP";
            dgv_ds_pnsp_chitiet.Columns["KHO"].HeaderText = "TÊN KHO";
            dgv_ds_pnsp_chitiet.Columns["SO_LUONG"].HeaderText = "SỐ LƯỢNG";
            dgv_ds_pnsp_chitiet.Columns["DON_GIA"].HeaderText = "ĐƠN GIÁ";
            dgv_ds_pnsp_chitiet.Columns["THANH_TIEN"].HeaderText = "THÀNH TIỀN";
        }

        private void dgv_ds_pnsp_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_ds_pnsp.Rows.Count != 0)
            {
                if (e.RowIndex > -1)
                {
                    string ma_phieu = dgv_ds_pnsp.Rows[e.RowIndex].Cells["MA_PHIEU_NHAP"].Value.ToString();
                    LAY_CHI_TIET_TU_CSDL_THEO_MA_PHIEU(ma_phieu);
                }
            }
        }
    }
}