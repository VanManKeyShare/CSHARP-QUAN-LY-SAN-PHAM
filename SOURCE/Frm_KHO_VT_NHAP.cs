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
    public partial class Frm_KHO_VT_NHAP : Form
    {
        public string SQL_CONNECTION_STRING = "";

        public Frm_KHO_VT_NHAP()
        {
            InitializeComponent();
            nbric_dongia.Controls.RemoveAt(0);
            nbric_soluong.Controls.RemoveAt(0);
            
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void Make_Combobox_NCC()
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_NCC, TEN_NCC FROM NHA_CUNG_CAP ORDER BY TEN_NCC ASC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            ArrayList KQ = vmk.MS_SQL_SELECT();

            if (KQ[0].ToString() == "ERROR")
            {
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return;
            }

            DataTable DT = (DataTable)KQ[2];

            DT.Rows.Add("", "");

            if (DT.Rows.Count == 0) { DT.Rows.Add("", "KHÔNG CÓ DỮ LIỆU"); }

            // SAU ĐÓ NẠP VÀO CONTROL COMBOBOX

            cbo_ma_ncc.DataSource = DT;
            cbo_ma_ncc.DisplayMember = "TEN_NCC";
            cbo_ma_ncc.ValueMember = "MA_NCC";

            cbo_ma_ncc.SelectedValue = "";
        }

        private void Make_Combobox_Ds_VT()
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_VT, TEN_VT FROM KHO_VAT_TU ORDER BY TEN_VT ASC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            ArrayList KQ = vmk.MS_SQL_SELECT();

            if (KQ[0].ToString() == "ERROR")
            {
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return;
            }

            DataTable DT = (DataTable)KQ[2];

            if (DT.Rows.Count == 0) { DT.Rows.Add("", "KHÔNG CÓ DỮ LIỆU"); }

            // SAU ĐÓ NẠP VÀO CONTROL COMBOBOX

            cbo_ma_vt.DataSource = DT;
            cbo_ma_vt.DisplayMember = "TEN_VT";
            cbo_ma_vt.ValueMember = "MA_VT";
        }

        private void Make_Combobox_Ds_Kho()
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_KHO, TEN_KHO FROM DM_KHO_HANG WHERE (LOAI_KHO = 2) ORDER BY TEN_KHO ASC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            ArrayList KQ = vmk.MS_SQL_SELECT();

            if (KQ[0].ToString() == "ERROR")
            {
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return;
            }

            DataTable DT = (DataTable)KQ[2];

            if (DT.Rows.Count == 0) { DT.Rows.Add("", "KHÔNG CÓ DỮ LIỆU"); }

            // SAU ĐÓ NẠP VÀO CONTROL COMBOBOX

            cbo_ma_kho.DataSource = DT;
            cbo_ma_kho.DisplayMember = "TEN_KHO";
            cbo_ma_kho.ValueMember = "MA_KHO";
        }

        private void Frm_KHO_VT_NHAP_Load(object sender, EventArgs e)
        {
            // TẠO CONTROL DANH SÁCH NHÀ CUNG CẤP

            Make_Combobox_NCC();

            // TẠO CONTROL DANH SÁCH VẬT TƯ

            Make_Combobox_Ds_VT();

            // TẠO CONTROL DANH SÁCH KHO

            Make_Combobox_Ds_Kho();

            // TẠO CỘT CHO DATAGRIDVIEW

            dgv_ds_vt_chi_tiet.Columns.Add("MA_VT", "MÃ VT");
            dgv_ds_vt_chi_tiet.Columns.Add("TEN_VT", "TÊN VT");
            dgv_ds_vt_chi_tiet.Columns.Add("MA_KHO", "MÃ KHO");
            dgv_ds_vt_chi_tiet.Columns.Add("TEN_KHO", "TÊN KHO");
            dgv_ds_vt_chi_tiet.Columns.Add("SO_LUONG", "SỐ LƯỢNG");
            dgv_ds_vt_chi_tiet.Columns.Add("DON_GIA", "ĐƠN GIÁ");
            dgv_ds_vt_chi_tiet.Columns.Add("THANH_TIEN", "THÀNH TIỀN");
        }

        private void btn_them_item_Click(object sender, EventArgs e)
        {
            Class_Funcs CFuns = new Class_Funcs();

            // LẤY VÀ KIỂM TRA DỮ LIỆU TỪ FORM

            string ma_vt = cbo_ma_vt.SelectedValue.ToString().Trim();
            string ten_vt = cbo_ma_vt.Text.Trim();
            string ma_kho = cbo_ma_kho.SelectedValue.ToString().Trim();
            string ten_kho = cbo_ma_kho.Text.Trim();
            Int32 so_luong = Int32.Parse(nbric_soluong.Value.ToString());
            double don_gia = double.Parse(nbric_dongia.Value.ToString());

            if (ma_vt == "" || ten_vt == "" || ma_kho == "" || ten_kho == "" || so_luong <= 0 || don_gia <= 0)
            {
                MessageBox.Show("BẠN CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU HOẶC SỐ LƯỢNG, ĐƠN GIÁ <= 0", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ VẬT TƯ

            if (ma_vt != "" && CFuns.CHECK_CHARACTER(ma_vt, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ VẬT TƯ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ KHO

            if (ma_kho != "" && CFuns.CHECK_CHARACTER(ma_kho, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ KHO CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM VÀO DANH SÁCH

            // KIỂM TRA MÃ VT ĐÃ CÓ TRONG DANH SÁCH CHƯA

            int index_row = -1;

            for (int i = 0; i < dgv_ds_vt_chi_tiet.Rows.Count; i++)
            {
                if (dgv_ds_vt_chi_tiet.Rows[i].Cells["MA_VT"].Value.ToString().Trim() == ma_vt
                    && dgv_ds_vt_chi_tiet.Rows[i].Cells["MA_KHO"].Value.ToString().Trim() == ma_kho.ToString()
                    && dgv_ds_vt_chi_tiet.Rows[i].Cells["DON_GIA"].Value.ToString().Trim() == don_gia.ToString()
                )
                {
                    index_row = i;
                }
            }

            // NẾU CÓ RỒI THÌ CẬP NHẬT SỐ LƯỢNG VÀ ĐƠN GIÁ
            // NẾU CHƯA CÓ THÌ TIẾN HÀNH THÊM MỚI

            if (index_row != -1)
            {
                dgv_ds_vt_chi_tiet.Rows[index_row].Cells["TEN_VT"].Value = ten_vt;
                dgv_ds_vt_chi_tiet.Rows[index_row].Cells["MA_KHO"].Value = ma_kho;
                dgv_ds_vt_chi_tiet.Rows[index_row].Cells["TEN_KHO"].Value = ten_kho;

                Int32 so_luong_temp = Int32.Parse(dgv_ds_vt_chi_tiet.Rows[index_row].Cells["SO_LUONG"].Value.ToString());
                so_luong_temp = so_luong_temp + so_luong;
                dgv_ds_vt_chi_tiet.Rows[index_row].Cells["SO_LUONG"].Value = so_luong_temp;

                dgv_ds_vt_chi_tiet.Rows[index_row].Cells["DON_GIA"].Value = don_gia;
            }
            else
            {
                dgv_ds_vt_chi_tiet.Rows.Add(ma_vt, ten_vt, ma_kho, ten_kho, so_luong, don_gia, "0");
            }

            // TIẾN HÀNH CẬP NHẬT THÀNH TIỀN CHO DANH SÁCH

            for (int i = 0; i < dgv_ds_vt_chi_tiet.Rows.Count; i++)
            {
                Int32 so_luong_temp = Int32.Parse(dgv_ds_vt_chi_tiet.Rows[i].Cells["SO_LUONG"].Value.ToString());
                double don_gia_temp = double.Parse(dgv_ds_vt_chi_tiet.Rows[i].Cells["DON_GIA"].Value.ToString());
                dgv_ds_vt_chi_tiet.Rows[i].Cells["THANH_TIEN"].Value = (don_gia_temp * so_luong_temp).ToString();
            }
        }

        private void btn_xoa_item_Click(object sender, EventArgs e)
        {
			if (dgv_ds_vt_chi_tiet.Rows.Count == 0 || dgv_ds_vt_chi_tiet.SelectedRows.Count == 0){ return; }
			
			int index_row_ma_vt = dgv_ds_vt_chi_tiet.SelectedRows[0].Index;
			if (index_row_ma_vt != -1)
			{
				dgv_ds_vt_chi_tiet.Rows.RemoveAt(index_row_ma_vt);
			}
        }

        string TAO_PHIEU_NHAP(string ho_ten_nguoi_giao, string ma_ncc, string so_hd)
        {
            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO KHO_VT_PHIEU_NHAP (HO_TEN_NGUOI_GIAO, MA_NCC, THEO_SO_HD) OUTPUT INSERTED.MA_PHIEU_NHAP VALUES (@HO_TEN_NGUOI_GIAO, @MA_NCC, @THEO_SO_HD)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@HO_TEN_NGUOI_GIAO", ho_ten_nguoi_giao, SqlDbType.NVarChar);
            if (ma_ncc != "")
            {
                vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NCC", ma_ncc, SqlDbType.VarChar);
            }
            else
            {
                vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NCC", DBNull.Value, SqlDbType.VarChar);
            }
            vmk.MS_SQL_PARAMETERS.Rows.Add("@THEO_SO_HD", so_hd, SqlDbType.VarChar);
            String[] KQ = vmk.MS_SQL_INSERT_RETURN_OUTPUT();
            
            if (KQ[0].ToString() == "ERROR")
            {
                Console.WriteLine(KQ[1].ToString());
                if (KQ[1].ToLower().Contains("the insert statement conflicted with the foreign key constraint"))
                {
                    MessageBox.Show("KHÔNG THỂ THÊM. DỮ LIỆU LIÊN KẾT VỚI BẢNG KHÁC KHÔNG TỒN TẠI", "THÔNG BÁO");
                    return "";
                }
                if (KQ[1].ToLower().Contains("the update statement conflicted with the foreign key constraint"))
                {
                    MessageBox.Show("KHÔNG THỂ CẬP NHẬT. DỮ LIỆU LIÊN KẾT VỚI BẢNG KHÁC KHÔNG TỒN TẠI", "THÔNG BÁO");
                    return "";
                }
                if (KQ[1].ToLower().Contains("cannot insert duplicate key in object"))
                {
                    MessageBox.Show("KHÔNG THỂ THÊM. DỮ LIỆU ĐÃ CÓ RỒI", "THÔNG BÁO");
                    return "";
                }
                if (KQ[1].ToLower().Contains("string or binary data would be truncated"))
                {
                    MessageBox.Show("KHÔNG THỂ THÊM. DỮ LIỆU VƯỢT QUÁ QUY ĐỊNH", "THÔNG BÁO");
                    return "";
                }
                if (KQ[1].ToLower().Contains("<trigger_error>") && KQ[1].ToLower().Contains("</trigger_error>"))
                {
                    int Trigger_Index_Begin_Error = KQ[1].ToLower().IndexOf("<trigger_error>") + 15;
                    int Trigger_Index_End_Error = KQ[1].ToLower().IndexOf("</trigger_error>");
                    string Trigger_Error_Msg = KQ[1].ToLower().Substring(Trigger_Index_Begin_Error, (Trigger_Index_End_Error - Trigger_Index_Begin_Error)).Trim();
                    MessageBox.Show(Trigger_Error_Msg.ToUpper(), "THÔNG BÁO");
                    return "";
                }
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return "";
            }

            return KQ[1];
        }

        private void THEM_DU_LIEU_VAO_BANG_CHI_TIET(string ma_phieu_nhap, string ma_vt, string ma_kho, string so_luong, string don_gia)
        {
            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO KHO_VT_CHI_TIET_NHAP (MA_PHIEU_NHAP, MA_VT, MA_KHO, SO_LUONG, DON_GIA) VALUES (@MA_PHIEU_NHAP, @MA_VT, @MA_KHO, @SO_LUONG, @DON_GIA)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_PHIEU_NHAP", ma_phieu_nhap, SqlDbType.Int);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_VT", ma_vt, SqlDbType.Int);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_KHO", ma_kho, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@SO_LUONG", so_luong, SqlDbType.Int);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@DON_GIA", don_gia, SqlDbType.Int);
            String[] KQ = vmk.MS_SQL_INSERT_DELETE_UPDATE();

            if (KQ[0].ToString() == "ERROR")
            {
                Console.WriteLine(KQ[1].ToString());
                if (KQ[1].ToLower().Contains("the insert statement conflicted with the foreign key constraint"))
                {
                    MessageBox.Show("KHÔNG THỂ THÊM. DỮ LIỆU LIÊN KẾT VỚI BẢNG KHÁC KHÔNG TỒN TẠI", "THÔNG BÁO");
                    return;
                }
                if (KQ[1].ToLower().Contains("the update statement conflicted with the foreign key constraint"))
                {
                    MessageBox.Show("KHÔNG THỂ CẬP NHẬT. DỮ LIỆU LIÊN KẾT VỚI BẢNG KHÁC KHÔNG TỒN TẠI", "THÔNG BÁO");
                    return;
                }
                if (KQ[1].ToLower().Contains("cannot insert duplicate key in object"))
                {
                    MessageBox.Show("KHÔNG THỂ THÊM. DỮ LIỆU ĐÃ CÓ RỒI", "THÔNG BÁO");
                    return;
                }
                if (KQ[1].ToLower().Contains("string or binary data would be truncated"))
                {
                    MessageBox.Show("KHÔNG THỂ THÊM. DỮ LIỆU VƯỢT QUÁ QUY ĐỊNH", "THÔNG BÁO");
                    return;
                }
                if (KQ[1].ToLower().Contains("<trigger_error>") && KQ[1].ToLower().Contains("</trigger_error>"))
                {
                    int Trigger_Index_Begin_Error = KQ[1].ToLower().IndexOf("<trigger_error>") + 15;
                    int Trigger_Index_End_Error = KQ[1].ToLower().IndexOf("</trigger_error>");
                    string Trigger_Error_Msg = KQ[1].ToLower().Substring(Trigger_Index_Begin_Error, (Trigger_Index_End_Error - Trigger_Index_Begin_Error)).Trim();
                    MessageBox.Show(Trigger_Error_Msg.ToUpper(), "THÔNG BÁO");
                    return;
                }
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return;
            }
        }

        private void btn_nhap_Click(object sender, EventArgs e)
        {
            Class_Funcs CFuns = new Class_Funcs();

            // LẤY VÀ KIỂM TRA DỮ LIỆU TỪ FORM

            string ho_ten_nguoi_giao = txt_hoten_nguoi_giao.Text.Trim();
            string ma_ncc = cbo_ma_ncc.SelectedValue.ToString().Trim();
            string so_hd = txt_theo_hd.Text.Trim();

            if (ho_ten_nguoi_giao == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ NHÀ CUNG CẤP

            if (ma_ncc != "" && CFuns.CHECK_CHARACTER(ma_ncc, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ NHÀ CUNG CẤP CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA HỌ TÊN NGƯỜI GIAO

            if (ho_ten_nguoi_giao != "" && CFuns.CHECK_CHARACTER(ho_ten_nguoi_giao, " ", true, true, true) == false)
            {
                MessageBox.Show("HỌ TÊN NGƯỜI GIAO CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA SỐ HÓA ĐƠN

            if (so_hd != "" && CFuns.CHECK_CHARACTER(so_hd, "", true, false, true) == false)
            {
                MessageBox.Show("SỐ HÓA ĐƠN CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA DANH SÁCH VẬT TƯ CẦN NHẬP

            if (dgv_ds_vt_chi_tiet.Rows.Count <= 0)
            {
                MessageBox.Show("DANH SÁCH VẬT TƯ CẦN NHẬP ĐANG RỖNG", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            // TẠO PHIẾU NHẬP TRƯỚC, SAU ĐÓ DÙNG MÃ PHIẾU CÓ ĐƯỢC ĐỂ THÊM CHI TIẾT SAU

            string ma_phieu_nhap = TAO_PHIEU_NHAP(ho_ten_nguoi_giao, ma_ncc, so_hd);
            if (ma_phieu_nhap != "")
            {
                // SAU KHI CÓ MÃ PHIẾU NHẬP TA TIẾN HÀNH THÊM DỮ LIỆU VÀO BẢNG CHI TIẾT

                for (int i = 0; i < dgv_ds_vt_chi_tiet.Rows.Count; i++)
                {
                    string ma_vt = dgv_ds_vt_chi_tiet.Rows[i].Cells["MA_VT"].Value.ToString();
                    string ma_kho = dgv_ds_vt_chi_tiet.Rows[i].Cells["MA_KHO"].Value.ToString();
                    string so_luong = dgv_ds_vt_chi_tiet.Rows[i].Cells["SO_LUONG"].Value.ToString();
                    string don_gia = dgv_ds_vt_chi_tiet.Rows[i].Cells["DON_GIA"].Value.ToString();

                    THEM_DU_LIEU_VAO_BANG_CHI_TIET(ma_phieu_nhap, ma_vt, ma_kho, so_luong, don_gia);
                }
            }
            else
            {
                MessageBox.Show("KHÔNG TẠO HOẶC LẤY ĐƯỢC MÃ PHIẾU NHẬP", "THÔNG BÁO");
            }

            MessageBox.Show("NHẬP THÀNH CÔNG", "THÔNG BÁO");

            this.Close();
        }
    }
}
