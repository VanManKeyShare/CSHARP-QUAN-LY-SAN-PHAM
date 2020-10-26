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
    public partial class Frm_KHO_SP_NHAP : Form
    {
        public string SQL_CONNECTION_STRING = "";

        public Frm_KHO_SP_NHAP()
        {
            InitializeComponent();
            nbric_dongia.Controls.RemoveAt(0);
            nbric_soluong.Controls.RemoveAt(0);
            
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void Make_Combobox_BP()
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_BP, TEN_BP FROM DM_BO_PHAN ORDER BY TEN_BP ASC";
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

            cbo_ma_bp.DataSource = DT;
            cbo_ma_bp.DisplayMember = "TEN_BP";
            cbo_ma_bp.ValueMember = "MA_BP";

            cbo_ma_bp.SelectedValue = "";
        }

        private void Make_Combobox_Ds_SP()
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_SP, TEN_SP FROM KHO_SAN_PHAM ORDER BY TEN_SP ASC";
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

            cbo_ma_sp.DataSource = DT;
            cbo_ma_sp.DisplayMember = "TEN_SP";
            cbo_ma_sp.ValueMember = "MA_SP";
        }

        private void Make_Combobox_Ds_Kho()
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_KHO, TEN_KHO FROM DM_KHO_HANG WHERE (LOAI_KHO = 1) ORDER BY TEN_KHO ASC";
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

        private void Frm_KHO_SP_NHAP_Load(object sender, EventArgs e)
        {
            // TẠO CONTROL DANH SÁCH BỘ PHẬN

            Make_Combobox_BP();

            // TẠO CONTROL DANH SÁCH SẢN PHẨM

            Make_Combobox_Ds_SP();

            // TẠO CONTROL DANH SÁCH KHO

            Make_Combobox_Ds_Kho();

            // TẠO CỘT CHO DATAGRIDVIEW

            dgv_ds_sp_chi_tiet.Columns.Add("MA_SP", "MÃ SP");
            dgv_ds_sp_chi_tiet.Columns.Add("TEN_SP", "TÊN SP");
            dgv_ds_sp_chi_tiet.Columns.Add("MA_KHO", "MÃ KHO");
            dgv_ds_sp_chi_tiet.Columns.Add("TEN_KHO", "TÊN KHO");
            dgv_ds_sp_chi_tiet.Columns.Add("SO_LUONG", "SỐ LƯỢNG");
            dgv_ds_sp_chi_tiet.Columns.Add("DON_GIA", "ĐƠN GIÁ");
            dgv_ds_sp_chi_tiet.Columns.Add("THANH_TIEN", "THÀNH TIỀN");
        }

        private void btn_them_item_Click(object sender, EventArgs e)
        {
            Class_Funcs CFuns = new Class_Funcs();

            // LẤY VÀ KIỂM TRA DỮ LIỆU TỪ FORM

            string ma_sp = cbo_ma_sp.SelectedValue.ToString().Trim();
            string ten_sp = cbo_ma_sp.Text.Trim();
            string ma_kho = cbo_ma_kho.SelectedValue.ToString().Trim();
            string ten_kho = cbo_ma_kho.Text.Trim();
            Int32 so_luong = Int32.Parse(nbric_soluong.Value.ToString());
            double don_gia = double.Parse(nbric_dongia.Value.ToString());

            if (ma_sp == "" || ten_sp == "" || ma_kho == "" || ten_kho == "" || so_luong <= 0 || don_gia <= 0)
            {
                MessageBox.Show("BẠN CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU HOẶC SỐ LƯỢNG, ĐƠN GIÁ <= 0", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ SẢN PHẨM

            if (ma_sp != "" && CFuns.CHECK_CHARACTER(ma_sp, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ SẢN PHẨM CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ KHO

            if (ma_kho != "" && CFuns.CHECK_CHARACTER(ma_kho, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ KHO CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM VÀO DANH SÁCH

            // KIỂM TRA MÃ SP ĐÃ CÓ TRONG DANH SÁCH CHƯA

            int index_row = -1;

            for (int i = 0; i < dgv_ds_sp_chi_tiet.Rows.Count; i++)
            {
                if (dgv_ds_sp_chi_tiet.Rows[i].Cells["MA_SP"].Value.ToString().Trim() == ma_sp
                    && dgv_ds_sp_chi_tiet.Rows[i].Cells["MA_KHO"].Value.ToString().Trim() == ma_kho.ToString()
                    && dgv_ds_sp_chi_tiet.Rows[i].Cells["DON_GIA"].Value.ToString().Trim() == don_gia.ToString()
                )
                {
                    index_row = i;
                }
            }

            // NẾU CÓ RỒI THÌ CẬP NHẬT SỐ LƯỢNG VÀ ĐƠN GIÁ
            // NẾU CHƯA CÓ THÌ TIẾN HÀNH THÊM MỚI

            if (index_row != -1)
            {
                dgv_ds_sp_chi_tiet.Rows[index_row].Cells["TEN_SP"].Value = ten_sp;
                dgv_ds_sp_chi_tiet.Rows[index_row].Cells["MA_KHO"].Value = ma_kho;
                dgv_ds_sp_chi_tiet.Rows[index_row].Cells["TEN_KHO"].Value = ten_kho;

                Int32 so_luong_temp = Int32.Parse(dgv_ds_sp_chi_tiet.Rows[index_row].Cells["SO_LUONG"].Value.ToString());
                so_luong_temp = so_luong_temp + so_luong;
                dgv_ds_sp_chi_tiet.Rows[index_row].Cells["SO_LUONG"].Value = so_luong_temp;

                dgv_ds_sp_chi_tiet.Rows[index_row].Cells["DON_GIA"].Value = don_gia;
            }
            else
            {
                dgv_ds_sp_chi_tiet.Rows.Add(ma_sp, ten_sp, ma_kho, ten_kho, so_luong, don_gia, "0");
            }

            // TIẾN HÀNH CẬP NHẬT THÀNH TIỀN CHO DANH SÁCH

            for (int i = 0; i < dgv_ds_sp_chi_tiet.Rows.Count; i++)
            {
                Int32 so_luong_temp = Int32.Parse(dgv_ds_sp_chi_tiet.Rows[i].Cells["SO_LUONG"].Value.ToString());
                double don_gia_temp = double.Parse(dgv_ds_sp_chi_tiet.Rows[i].Cells["DON_GIA"].Value.ToString());
                dgv_ds_sp_chi_tiet.Rows[i].Cells["THANH_TIEN"].Value = (don_gia_temp * so_luong_temp).ToString();
            }
        }

        private void btn_xoa_item_Click(object sender, EventArgs e)
        {
			if (dgv_ds_sp_chi_tiet.Rows.Count == 0 || dgv_ds_sp_chi_tiet.SelectedRows.Count == 0){ return; }

			int index_row_ma_sp = dgv_ds_sp_chi_tiet.SelectedRows[0].Index;
			if (index_row_ma_sp != -1)
			{
				dgv_ds_sp_chi_tiet.Rows.RemoveAt(index_row_ma_sp);
			}
        }

        string TAO_PHIEU_NHAP(string ho_ten_nguoi_giao, string ma_bp)
        {
            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO KHO_SP_PHIEU_NHAP (HO_TEN_NGUOI_GIAO, MA_BP) OUTPUT INSERTED.MA_PHIEU_NHAP VALUES (@HO_TEN_NGUOI_GIAO, @MA_BP)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@HO_TEN_NGUOI_GIAO", ho_ten_nguoi_giao, SqlDbType.NVarChar);
            if (ma_bp != "")
            {
                vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_BP", ma_bp, SqlDbType.VarChar);
            }
            else
            {
                vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_BP", DBNull.Value, SqlDbType.VarChar);
            }
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

        private void THEM_DU_LIEU_VAO_BANG_CHI_TIET(string ma_phieu_nhap, string ma_sp, string ma_kho, string so_luong, string don_gia)
        {
            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO KHO_SP_CHI_TIET_NHAP (MA_PHIEU_NHAP, MA_SP, MA_KHO, SO_LUONG, DON_GIA) VALUES (@MA_PHIEU_NHAP, @MA_SP, @MA_KHO, @SO_LUONG, @DON_GIA)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_PHIEU_NHAP", ma_phieu_nhap, SqlDbType.Int);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_SP", ma_sp, SqlDbType.Int);
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
            string ma_bp = cbo_ma_bp.SelectedValue.ToString().Trim();

            if (ho_ten_nguoi_giao == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ BỘ PHẬN

            if (ma_bp != "" && CFuns.CHECK_CHARACTER(ma_bp, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ BỘ PHẬN CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA HỌ TÊN NGƯỜI GIAO

            if (ho_ten_nguoi_giao != "" && CFuns.CHECK_CHARACTER(ho_ten_nguoi_giao, " ", true, true, true) == false)
            {
                MessageBox.Show("HỌ TÊN NGƯỜI GIAO CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA DANH SÁCH SẢN PHẨM CẦN NHẬP

            if (dgv_ds_sp_chi_tiet.Rows.Count <= 0)
            {
                MessageBox.Show("DANH SÁCH SẢN PHẨM CẦN NHẬP ĐANG RỖNG", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            // TẠO PHIẾU NHẬP TRƯỚC, SAU ĐÓ DÙNG MÃ PHIẾU CÓ ĐƯỢC ĐỂ THÊM CHI TIẾT SAU

            string ma_phieu_nhap = TAO_PHIEU_NHAP(ho_ten_nguoi_giao, ma_bp);
            if (ma_phieu_nhap != "")
            {
                // SAU KHI CÓ MÃ PHIẾU NHẬP TA TIẾN HÀNH THÊM DỮ LIỆU VÀO BẢNG CHI TIẾT

                for (int i = 0; i < dgv_ds_sp_chi_tiet.Rows.Count; i++)
                {
                    string ma_sp = dgv_ds_sp_chi_tiet.Rows[i].Cells["MA_SP"].Value.ToString();
                    string ma_kho = dgv_ds_sp_chi_tiet.Rows[i].Cells["MA_KHO"].Value.ToString();
                    string so_luong = dgv_ds_sp_chi_tiet.Rows[i].Cells["SO_LUONG"].Value.ToString();
                    string don_gia = dgv_ds_sp_chi_tiet.Rows[i].Cells["DON_GIA"].Value.ToString();

                    THEM_DU_LIEU_VAO_BANG_CHI_TIET(ma_phieu_nhap, ma_sp, ma_kho, so_luong, don_gia);
                }
            }
            else
            {
                MessageBox.Show("KHÔNG TẠO HOẶC LẤY ĐƯỢC MÃ PHIẾU NHẬP", "THÔNG BÁO");
            }

            MessageBox.Show("NHẬP SẢN PHẨM THÀNH CÔNG", "THÔNG BÁO");

            this.Close();
        }
    }
}
