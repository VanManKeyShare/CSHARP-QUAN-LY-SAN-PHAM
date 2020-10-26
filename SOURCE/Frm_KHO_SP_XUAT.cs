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
    public partial class Frm_KHO_SP_XUAT : Form
    {
        public string SQL_CONNECTION_STRING = "";

        public Frm_KHO_SP_XUAT()
        {
            InitializeComponent();
            nbric_soluong.Controls.RemoveAt(0);
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void Make_Combobox_KH()
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_KH, TEN_KH FROM KHACH_HANG ORDER BY MA_KH ASC";
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

            cbo_ma_kh.DataSource = DT;
            cbo_ma_kh.DisplayMember = "TEN_KH";
            cbo_ma_kh.ValueMember = "MA_KH";

            cbo_ma_kh.SelectedValue = "";
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

        private string LAY_DON_GIA_XUAT_THEO_MA_SP(string ma_sp)
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT DON_GIA_XUAT FROM KHO_SAN_PHAM WHERE MA_SP = @MA_SP";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_SP", ma_sp, SqlDbType.Int);
            ArrayList KQ = vmk.MS_SQL_SELECT();

            if (KQ[0].ToString() == "ERROR")
            {
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return "";
            }

            DataTable DT = (DataTable)KQ[2];

            if (DT.Rows.Count == 0) { return ""; }

            return DT.Rows[0][0].ToString().Trim();
        }

        private void Frm_KHO_SP_XUAT_Load(object sender, EventArgs e)
        {
            // TẠO CONTROL DANH SÁCH KHÁCH HÀNG

            Make_Combobox_KH();

            // TẠO CONTROL DANH SÁCH KHO

            Make_Combobox_Ds_Kho();

            // TẠO CỘT CHO DATAGRIDVIEW

            dgv_ds_item_chi_tiet.Columns.Add("MA_SP", "MÃ SP");
            dgv_ds_item_chi_tiet.Columns.Add("TEN_SP", "TÊN SP");
            dgv_ds_item_chi_tiet.Columns.Add("MA_KHO", "MÃ KHO");
            dgv_ds_item_chi_tiet.Columns.Add("SO_LUONG", "SỐ LƯỢNG");
            dgv_ds_item_chi_tiet.Columns.Add("DON_GIA", "ĐƠN GIÁ");
            dgv_ds_item_chi_tiet.Columns.Add("THANH_TIEN", "THÀNH TIỀN");
        }

        private void btn_xem_item_trong_kho_Click(object sender, EventArgs e)
        {
            string ma_kho = cbo_ma_kho.SelectedValue.ToString().Trim();
            if (ma_kho != "")
            {
                // LẤY DỮ LIỆU TỪ CSDL

                VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
                vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
                vmk.MS_SQL_QUERY = "SELECT MA_SP, TEN_SP, [dbo].[TINH_SO_LUONG_TON_SP_THEO_KHO](MA_SP, @MA_KHO) AS SO_LUONG_TON FROM KHO_SAN_PHAM WHERE ([dbo].[TINH_SO_LUONG_TON_SP_THEO_KHO](MA_SP, @MA_KHO) > 0) ORDER BY MA_SP DESC";
                vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
                vmk.MS_SQL_PARAMETERS.Clear();
                vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_KHO", ma_kho, SqlDbType.VarChar);
                ArrayList KQ = vmk.MS_SQL_SELECT();

                if (KQ[0].ToString() == "ERROR")
                {
                    MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                    return;
                }

                DataTable DT = (DataTable)KQ[2];

                // SAU ĐÓ NẠP VÀO DATAGRIDVIEW

                if (DT.Rows.Count == 0) { dgv_ds_item_trong_kho.DataSource = null; dgv_ds_item_trong_kho.Columns.Clear(); return; }

                dgv_ds_item_trong_kho.DataSource = DT;

                // CHỈNH SỬA TIÊU ĐỀ CÁC CỘT CHO ĐỐI TƯỢNG DATAGRIDVIEW

                dgv_ds_item_trong_kho.Columns["MA_SP"].HeaderText = "MÃ SP";
                dgv_ds_item_trong_kho.Columns["TEN_SP"].HeaderText = "TÊN SP";
                dgv_ds_item_trong_kho.Columns["SO_LUONG_TON"].HeaderText = "SỐ LƯỢNG TỒN";
            }
        }

        private void btn_them_item_Click(object sender, EventArgs e)
        {
            // LẤY VÀ KIỂM TRA MÃ KHO

            string ma_kho = cbo_ma_kho.SelectedValue.ToString().Trim();

            if (ma_kho == "")
            {
                MessageBox.Show("BẠN CHƯA CHỌN KHO HÀNG", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA DANH SÁCH SẢN PHẨM TRONG KHO

            if (dgv_ds_item_trong_kho.Rows.Count == 0)
            {
                MessageBox.Show("DANH SÁCH SẢN PHẨM TRONG KHO ĐANG RỖNG", "THÔNG BÁO");
                return;
            }

            // LẤY THÔNG TIN SẢN PHẨM TRONG KHO ĐANG CHỌN

            string ma_sp_trong_kho = dgv_ds_item_trong_kho.SelectedRows[0].Cells["MA_SP"].Value.ToString().Trim();
            string ten_sp_trong_kho = dgv_ds_item_trong_kho.SelectedRows[0].Cells["TEN_SP"].Value.ToString().Trim();
            string don_gia = LAY_DON_GIA_XUAT_THEO_MA_SP(ma_sp_trong_kho);
            double so_luong_trong_kho = double.Parse(dgv_ds_item_trong_kho.SelectedRows[0].Cells["SO_LUONG_TON"].Value.ToString().Trim());

            // TÍNH SỐ LƯỢNG CẦN XUẤT RA KHỎI KHO

            double so_luong_can_xuat = double.Parse(nbric_soluong.Value.ToString());

            for (int i = 0; i < dgv_ds_item_chi_tiet.Rows.Count; i++)
            {
                if (dgv_ds_item_chi_tiet.Rows[i].Cells["MA_SP"].Value.ToString().Trim() == ma_sp_trong_kho
                    && dgv_ds_item_chi_tiet.Rows[i].Cells["MA_KHO"].Value.ToString().Trim() == ma_kho.ToString()
                )
                {
                    so_luong_can_xuat += double.Parse(dgv_ds_item_chi_tiet.Rows[i].Cells["SO_LUONG"].Value.ToString().Trim());
                }
            }

            // KIỂM TRA SỐ LƯỢNG TỒN

            if (so_luong_trong_kho < so_luong_can_xuat)
            {
                MessageBox.Show("SỐ LƯỢNG TỒN TRONG KHO KHÔNG ĐỦ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA XEM MÃ SẢN PHẨM ĐÃ ĐƯỢC CHỌN VÀO DANH SÁCH ĐÃ CHỌN CHƯA
            // NẾU CÓ RỒI THÌ CẬP NHẬT SỐ LƯỢNG
            // NẾU CHƯA CÓ THÌ THÊM MỚI

            int index_row = -1;

            for (int i = 0; i < dgv_ds_item_chi_tiet.Rows.Count; i++)
            {
                if (dgv_ds_item_chi_tiet.Rows[i].Cells["MA_SP"].Value.ToString().Trim() == ma_sp_trong_kho
                    && dgv_ds_item_chi_tiet.Rows[i].Cells["MA_KHO"].Value.ToString().Trim() == ma_kho.ToString()
                )
                {
                    index_row = i;
                }
            }

            if (index_row != -1)
            {
                dgv_ds_item_chi_tiet.Rows[index_row].Cells["MA_SP"].Value = ma_sp_trong_kho;
                dgv_ds_item_chi_tiet.Rows[index_row].Cells["TEN_SP"].Value = ten_sp_trong_kho;
                dgv_ds_item_chi_tiet.Rows[index_row].Cells["MA_KHO"].Value = ma_kho;
                dgv_ds_item_chi_tiet.Rows[index_row].Cells["SO_LUONG"].Value = so_luong_can_xuat;
                dgv_ds_item_chi_tiet.Rows[index_row].Cells["DON_GIA"].Value = don_gia;
                dgv_ds_item_chi_tiet.Rows[index_row].Cells["THANH_TIEN"].Value = "0";
            }
            else
            {
                dgv_ds_item_chi_tiet.Rows.Add(ma_sp_trong_kho, ten_sp_trong_kho, ma_kho, so_luong_can_xuat, don_gia, "0");
            }

            // TIẾN HÀNH CẬP NHẬT THÀNH TIỀN CHO DANH SÁCH

            for (int i = 0; i < dgv_ds_item_chi_tiet.Rows.Count; i++)
            {
                Int32 so_luong_temp = Int32.Parse(dgv_ds_item_chi_tiet.Rows[i].Cells["SO_LUONG"].Value.ToString());
                double don_gia_temp = double.Parse(dgv_ds_item_chi_tiet.Rows[i].Cells["DON_GIA"].Value.ToString());
                dgv_ds_item_chi_tiet.Rows[i].Cells["THANH_TIEN"].Value = (don_gia_temp * so_luong_temp).ToString();
            }
        }

        private void btn_xoa_item_Click(object sender, EventArgs e)
        {
			if (dgv_ds_item_chi_tiet.Rows.Count == 0 || dgv_ds_item_chi_tiet.SelectedRows.Count == 0){ return; }

			int index_row_ma_sp = dgv_ds_item_chi_tiet.SelectedRows[0].Index;
			if (index_row_ma_sp != -1)
			{
				dgv_ds_item_chi_tiet.Rows.RemoveAt(index_row_ma_sp);
			}
        }

        string TAO_PHIEU_XUAT(string ho_ten_nguoi_nhan, string ma_kh, string so_hd)
        {
            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO KHO_SP_PHIEU_XUAT (HO_TEN_NGUOI_NHAN, MA_KH, THEO_SO_HD) OUTPUT INSERTED.MA_PHIEU_XUAT VALUES (@HO_TEN_NGUOI_NHAN, @MA_KH, @THEO_SO_HD)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@HO_TEN_NGUOI_NHAN", ho_ten_nguoi_nhan, SqlDbType.NVarChar);
            if (ma_kh != "")
            {
                vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_KH", ma_kh, SqlDbType.VarChar);
            }
            else
            {
                vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_KH", DBNull.Value, SqlDbType.VarChar);
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

        private void THEM_DU_LIEU_VAO_BANG_CHI_TIET(string ma_phieu_xuat, string ma_sp, string ma_kho, string so_luong, string don_gia)
        {
            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO KHO_SP_CHI_TIET_XUAT (MA_PHIEU_XUAT, MA_SP, MA_KHO, SO_LUONG, DON_GIA) VALUES (@MA_PHIEU_XUAT, @MA_SP, @MA_KHO, @SO_LUONG, @DON_GIA)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_PHIEU_XUAT", ma_phieu_xuat, SqlDbType.Int);
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

        private void btn_xuat_Click(object sender, EventArgs e)
        {
            Class_Funcs CFuns = new Class_Funcs();

            // LẤY VÀ KIỂM TRA DỮ LIỆU TỪ FORM

            string ho_ten_nguoi_nhan = txt_hoten_nguoi_nhan.Text.Trim();
            string ma_kh = cbo_ma_kh.SelectedValue.ToString().Trim();
            string so_hd = txt_theo_hd.Text.Trim();

            if (ho_ten_nguoi_nhan == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ KHÁCH HÀNG

            if (ma_kh != "" && CFuns.CHECK_CHARACTER(ma_kh, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ KHÁCH HÀNG CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA HỌ TÊN NGƯỜI NHẬN

            if (ho_ten_nguoi_nhan != "" && CFuns.CHECK_CHARACTER(ho_ten_nguoi_nhan, " ", true, true, true) == false)
            {
                MessageBox.Show("HỌ TÊN NGƯỜI NHẬN CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA SỐ HÓA ĐƠN

            if (so_hd != "" && CFuns.CHECK_CHARACTER(so_hd, "", true, false, true) == false)
            {
                MessageBox.Show("SỐ HÓA ĐƠN CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA DANH SÁCH SẢN PHẨM CẦN XUẤT

            if (dgv_ds_item_chi_tiet.Rows.Count <= 0)
            {
                MessageBox.Show("DANH SÁCH SẢN PHẨM CẦN XUẤT ĐANG RỖNG", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            // TẠO PHIẾU XUẤT TRƯỚC, SAU ĐÓ DÙNG MÃ PHIẾU CÓ ĐƯỢC ĐỂ THÊM CHI TIẾT SAU

            string ma_phieu_xuat = TAO_PHIEU_XUAT(ho_ten_nguoi_nhan, ma_kh, so_hd);
            if (ma_phieu_xuat != "")
            {
                // SAU KHI CÓ MÃ PHIẾU XUẤT TA TIẾN HÀNH THÊM DỮ LIỆU VÀO BẢNG CHI TIẾT

                for (int i = 0; i < dgv_ds_item_chi_tiet.Rows.Count; i++)
                {
                    string ma_sp = dgv_ds_item_chi_tiet.Rows[i].Cells["MA_SP"].Value.ToString();
                    string ma_kho = dgv_ds_item_chi_tiet.Rows[i].Cells["MA_KHO"].Value.ToString();
                    string so_luong = dgv_ds_item_chi_tiet.Rows[i].Cells["SO_LUONG"].Value.ToString();
                    string don_gia = dgv_ds_item_chi_tiet.Rows[i].Cells["DON_GIA"].Value.ToString();

                    THEM_DU_LIEU_VAO_BANG_CHI_TIET(ma_phieu_xuat, ma_sp, ma_kho, so_luong, don_gia);
                }
            }
            else
            {
                MessageBox.Show("KHÔNG TẠO HOẶC LẤY ĐƯỢC MÃ PHIẾU XUẤT", "THÔNG BÁO");
            }

            MessageBox.Show("XUẤT SẢN PHẨM THÀNH CÔNG", "THÔNG BÁO");

            this.Close();
        }

        private void cbo_ma_kho_SelectedValueChanged(object sender, EventArgs e)
        {
            btn_xem_item_trong_kho_Click(sender, e);
        }
    }
}
