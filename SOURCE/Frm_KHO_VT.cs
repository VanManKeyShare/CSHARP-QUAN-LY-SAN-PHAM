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
    public partial class Frm_KHO_VT : Form
    {
        public string Quyen_Han = "";
        public string SQL_CONNECTION_STRING = "";

        public Frm_KHO_VT()
        {
            InitializeComponent();
        }

        private void Frm_KHO_VT_Load(object sender, EventArgs e)
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
            if (Quyen_Han == "QUAN_LY_HE_THONG" || Quyen_Han == "QUAN_LY_DU_LIEU")
            {                
                btn_them.Enabled = true;
                btn_xoa.Enabled = true;
                btn_sua.Enabled = true;
            }
            else
            {
                btn_them.Enabled = false;
                btn_xoa.Enabled = false;
                btn_sua.Enabled = false;
            }

            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + "SELECT MA_VT,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " TEN_VT,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " (SELECT TEN_NH FROM DM_NHOM_HANG WHERE MA_NH = KHO_VAT_TU.MA_NH) AS MA_NH,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " (SELECT TEN_DVT FROM DM_DON_VI_TINH WHERE MA_DVT = KHO_VAT_TU.MA_DVT) AS MA_DVT,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " ([dbo].[TINH_SO_LUONG_TON_VT](KHO_VAT_TU.MA_VT)) AS TON_KHO,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " (SELECT SUM(SO_LUONG) FROM KHO_VT_CHI_TIET_NHAP WHERE MA_VT = KHO_VAT_TU.MA_VT) AS TONG_NHAP,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " (SELECT SUM(THANH_TIEN) FROM KHO_VT_CHI_TIET_NHAP WHERE MA_VT = KHO_VAT_TU.MA_VT) AS THANH_TIEN_NHAP,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " (SELECT SUM(SO_LUONG) FROM KHO_VT_CHI_TIET_XUAT WHERE MA_VT = KHO_VAT_TU.MA_VT) AS TONG_XUAT,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " MO_TA";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " FROM KHO_VAT_TU ORDER BY MA_VT ASC";
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

            if (DT.Rows.Count == 0) { dgv_ds_vt.DataSource = null; dgv_ds_vt.Columns.Clear(); return; }

            dgv_ds_vt.DataSource = DT;

            // CHỈNH SỬA TIÊU ĐỀ CÁC CỘT CHO ĐỐI TƯỢNG DATAGRIDVIEW

            dgv_ds_vt.Columns["MA_VT"].HeaderText = "MÃ VT";
            dgv_ds_vt.Columns["MA_NH"].HeaderText = "NHÓM HÀNG";
            dgv_ds_vt.Columns["MA_DVT"].HeaderText = "ĐVT";
            dgv_ds_vt.Columns["TEN_VT"].HeaderText = "TÊN VT";
            dgv_ds_vt.Columns["MO_TA"].HeaderText = "MÔ TẢ";
            dgv_ds_vt.Columns["TONG_NHAP"].HeaderText = "TỔNG NHẬP";
            dgv_ds_vt.Columns["THANH_TIEN_NHAP"].HeaderText = "THÀNH TIỀN NHẬP";
            dgv_ds_vt.Columns["TONG_XUAT"].HeaderText = "TỔNG XUẤT";
            dgv_ds_vt.Columns["TON_KHO"].HeaderText = "TỒN KHO";
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
			if (dgv_ds_vt.Rows.Count == 0 || dgv_ds_vt.SelectedRows.Count == 0){ return; }

            string ma_vt = dgv_ds_vt.SelectedRows[0].Cells["MA_VT"].Value.ToString().Trim();

            if (ma_vt == "")
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
            vmk.MS_SQL_QUERY = "DELETE FROM KHO_VAT_TU WHERE MA_VT = @MA_VT";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_VT", ma_vt, SqlDbType.Int);
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

            Frm_KHO_VT_CHI_TIET Frm = new Frm_KHO_VT_CHI_TIET();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();

            this.Show();

            RELOAD_DATA_FROM_SQL();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
			if (dgv_ds_vt.Rows.Count == 0 || dgv_ds_vt.SelectedRows.Count == 0){ return; }
			
            string ma_vt = dgv_ds_vt.SelectedRows[0].Cells["MA_VT"].Value.ToString().Trim();

            if (ma_vt == "")
            {
                MessageBox.Show("BẠN CHƯA CHỌN DỮ LIỆU CẦN CHỈNH SỬA", "THÔNG BÁO");
                return;
            }

            this.Hide();

            Frm_KHO_VT_CHI_TIET Frm = new Frm_KHO_VT_CHI_TIET();
            Frm.ID_DATA = ma_vt;
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();

            this.Show();

            RELOAD_DATA_FROM_SQL();
        }

        private void LAY_DS_CHI_TIET_NHAP_TU_CSDL(string MA_VT)
        {
            // LẤY DỮ LIỆU CHI TIẾT NHẬP TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + "SELECT MA_PHIEU_NHAP,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " (SELECT TEN_VT FROM KHO_VAT_TU WHERE MA_VT = KHO_VT_CHI_TIET_NHAP.MA_VT) AS TEN_VT,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " (SELECT TEN_KHO FROM DM_KHO_HANG WHERE MA_KHO = KHO_VT_CHI_TIET_NHAP.MA_KHO) AS TEN_KHO,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " SO_LUONG,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " DON_GIA,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " THANH_TIEN,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " (SELECT THOI_GIAN_NHAP FROM KHO_VT_PHIEU_NHAP WHERE MA_PHIEU_NHAP = KHO_VT_CHI_TIET_NHAP.MA_PHIEU_NHAP) AS THOI_GIAN_NHAP";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " FROM KHO_VT_CHI_TIET_NHAP WHERE (MA_VT = @MA_VT) ORDER BY THOI_GIAN_NHAP DESC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_VT", MA_VT, SqlDbType.Int);
            ArrayList KQ = vmk.MS_SQL_SELECT();

            if (KQ[0].ToString() == "ERROR")
            {
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return;
            }

            DataTable DT = (DataTable)KQ[2];

            // SAU ĐÓ NẠP VÀO DATAGRIDVIEW

            if (DT.Rows.Count == 0) { dgv_ds_chitietnhap.DataSource = null; dgv_ds_chitietnhap.Columns.Clear(); return; }

            dgv_ds_chitietnhap.DataSource = DT;

            // CHỈNH SỬA TIÊU ĐỀ CÁC CỘT CHO ĐỐI TƯỢNG DATAGRIDVIEW

            dgv_ds_chitietnhap.Columns["MA_PHIEU_NHAP"].HeaderText = "MÃ PHIẾU NHẬP";
            dgv_ds_chitietnhap.Columns["TEN_VT"].HeaderText = "TÊN VT";
            dgv_ds_chitietnhap.Columns["TEN_KHO"].HeaderText = "TÊN KHO";
            dgv_ds_chitietnhap.Columns["SO_LUONG"].HeaderText = "SỐ LƯỢNG";
            dgv_ds_chitietnhap.Columns["DON_GIA"].HeaderText = "ĐƠN GIÁ";
            dgv_ds_chitietnhap.Columns["THANH_TIEN"].HeaderText = "THÀNH TIỀN";
            dgv_ds_chitietnhap.Columns["THOI_GIAN_NHAP"].HeaderText = "THỜI GIAN NHẬP";
        }

        private void LAY_DS_CHI_TIET_XUAT_TU_CSDL(string MA_VT)
        {
            // LẤY DỮ LIỆU CHI TIẾT NHẬP TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + "SELECT MA_PHIEU_XUAT,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " (SELECT TEN_VT FROM KHO_VAT_TU WHERE MA_VT = KHO_VT_CHI_TIET_XUAT.MA_VT) AS TEN_VT,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " (SELECT TEN_KHO FROM DM_KHO_HANG WHERE MA_KHO = KHO_VT_CHI_TIET_XUAT.MA_KHO) AS TEN_KHO,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " SO_LUONG,";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " (SELECT THOI_GIAN_XUAT FROM KHO_VT_PHIEU_XUAT WHERE MA_PHIEU_XUAT = KHO_VT_CHI_TIET_XUAT.MA_PHIEU_XUAT) AS THOI_GIAN_XUAT";
            vmk.MS_SQL_QUERY = vmk.MS_SQL_QUERY + " FROM KHO_VT_CHI_TIET_XUAT WHERE (MA_VT = @MA_VT) ORDER BY THOI_GIAN_XUAT DESC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_VT", MA_VT, SqlDbType.Int);
            ArrayList KQ = vmk.MS_SQL_SELECT();

            if (KQ[0].ToString() == "ERROR")
            {
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return;
            }

            DataTable DT = (DataTable)KQ[2];

            // SAU ĐÓ NẠP VÀO DATAGRIDVIEW

            if (DT.Rows.Count == 0) { dgv_ds_chitietxuat.DataSource = null; dgv_ds_chitietxuat.Columns.Clear(); return; }

            dgv_ds_chitietxuat.DataSource = DT;

            // CHỈNH SỬA TIÊU ĐỀ CÁC CỘT CHO ĐỐI TƯỢNG DATAGRIDVIEW

            dgv_ds_chitietxuat.Columns["MA_PHIEU_XUAT"].HeaderText = "MÃ PHIẾU XUẤT";
            dgv_ds_chitietxuat.Columns["TEN_VT"].HeaderText = "TÊN VT";
            dgv_ds_chitietxuat.Columns["TEN_KHO"].HeaderText = "TÊN KHO";
            dgv_ds_chitietxuat.Columns["SO_LUONG"].HeaderText = "SỐ LƯỢNG";
            dgv_ds_chitietxuat.Columns["THOI_GIAN_XUAT"].HeaderText = "THỜI GIAN XUẤT";
        }

        private void dgv_ds_vt_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string ma_vt = dgv_ds_vt.Rows[e.RowIndex].Cells["MA_VT"].Value.ToString().Trim();
            if (ma_vt != "")
            {
                LAY_DS_CHI_TIET_NHAP_TU_CSDL(ma_vt);
                LAY_DS_CHI_TIET_XUAT_TU_CSDL(ma_vt);
            }
        }
    }
}