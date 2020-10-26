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
    public partial class Frm_KHO_VT_XUAT : Form
    {
        public string SQL_CONNECTION_STRING = "";

        public Frm_KHO_VT_XUAT()
        {
            InitializeComponent();
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
            vmk.MS_SQL_QUERY = "SELECT MA_BP, TEN_BP FROM DM_BO_PHAN ORDER BY MA_BP ASC";
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

        private void Frm_KHO_VT_XUAT_Load(object sender, EventArgs e)
        {
            // TẠO CONTROL DANH SÁCH BỘ PHẬN

            Make_Combobox_BP();

            // TẠO CONTROL DANH SÁCH KHO

            Make_Combobox_Ds_Kho();

            // TẠO CỘT CHO DATAGRIDVIEW

            dgv_ds_item_chi_tiet.Columns.Add("MA_VT", "MÃ VT");
            dgv_ds_item_chi_tiet.Columns.Add("TEN_VT", "TÊN VT");
            dgv_ds_item_chi_tiet.Columns.Add("MA_KHO", "MÃ KHO");
            dgv_ds_item_chi_tiet.Columns.Add("SO_LUONG", "SỐ LƯỢNG");
        }

        private void btn_xem_item_trong_kho_Click(object sender, EventArgs e)
        {
            string ma_kho = cbo_ma_kho.SelectedValue.ToString().Trim();
            if (ma_kho != "")
            {
                // LẤY DỮ LIỆU TỪ CSDL

                VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
                vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
                vmk.MS_SQL_QUERY = "SELECT MA_VT, TEN_VT, [dbo].[TINH_SO_LUONG_TON_VT_THEO_KHO](MA_VT, @MA_KHO) AS SO_LUONG_TON FROM KHO_VAT_TU WHERE ([dbo].[TINH_SO_LUONG_TON_VT_THEO_KHO](MA_VT, @MA_KHO) > 0) ORDER BY MA_VT DESC";
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

                dgv_ds_item_trong_kho.Columns["MA_VT"].HeaderText = "MÃ VT";
                dgv_ds_item_trong_kho.Columns["TEN_VT"].HeaderText = "TÊN VT";
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

            // KIỂM TRA DANH SÁCH VẬT TƯ TRONG KHO

            if (dgv_ds_item_trong_kho.Rows.Count == 0)
            {
                MessageBox.Show("DANH SÁCH VẬT TƯ TRONG KHO ĐANG RỖNG", "THÔNG BÁO");
                return;
            }

            // LẤY THÔNG TIN VẬT TƯ TRONG KHO ĐANG CHỌN

            string ma_vt_trong_kho = dgv_ds_item_trong_kho.SelectedRows[0].Cells["MA_VT"].Value.ToString().Trim();
            string ten_vt_trong_kho = dgv_ds_item_trong_kho.SelectedRows[0].Cells["TEN_VT"].Value.ToString().Trim();
            double so_luong_trong_kho = double.Parse(dgv_ds_item_trong_kho.SelectedRows[0].Cells["SO_LUONG_TON"].Value.ToString().Trim());

            // TÍNH SỐ LƯỢNG CẦN XUẤT RA KHỎI KHO

            double so_luong_can_xuat = double.Parse(nbric_soluong.Value.ToString());

            for (int i = 0; i < dgv_ds_item_chi_tiet.Rows.Count; i++)
            {
                if (dgv_ds_item_chi_tiet.Rows[i].Cells["MA_VT"].Value.ToString().Trim() == ma_vt_trong_kho
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

            // KIỂM TRA XEM MÃ VẬT TƯ ĐÃ ĐƯỢC CHỌN VÀO DANH SÁCH ĐÃ CHỌN CHƯA
            // NẾU CÓ RỒI THÌ CẬP NHẬT SỐ LƯỢNG
            // NẾU CHƯA CÓ THÌ THÊM MỚI

            int index_row = -1;

            for (int i = 0; i < dgv_ds_item_chi_tiet.Rows.Count; i++)
            {
                if (dgv_ds_item_chi_tiet.Rows[i].Cells["MA_VT"].Value.ToString().Trim() == ma_vt_trong_kho
                    && dgv_ds_item_chi_tiet.Rows[i].Cells["MA_KHO"].Value.ToString().Trim() == ma_kho.ToString()
                )
                {
                    index_row = i;
                }
            }

            if (index_row != -1)
            {
                dgv_ds_item_chi_tiet.Rows[index_row].Cells["MA_VT"].Value = ma_vt_trong_kho;
                dgv_ds_item_chi_tiet.Rows[index_row].Cells["TEN_VT"].Value = ten_vt_trong_kho;
                dgv_ds_item_chi_tiet.Rows[index_row].Cells["MA_KHO"].Value = ma_kho;
                dgv_ds_item_chi_tiet.Rows[index_row].Cells["SO_LUONG"].Value = so_luong_can_xuat;
            }
            else
            {
                dgv_ds_item_chi_tiet.Rows.Add(ma_vt_trong_kho, ten_vt_trong_kho, ma_kho, so_luong_can_xuat);
            }
        }

        private void btn_xoa_item_Click(object sender, EventArgs e)
        {
			if (dgv_ds_item_chi_tiet.Rows.Count == 0 || dgv_ds_item_chi_tiet.SelectedRows.Count == 0){ return; }
			
			int index_row_ma_vt = dgv_ds_item_chi_tiet.SelectedRows[0].Index;
			if (index_row_ma_vt != -1)
			{
				dgv_ds_item_chi_tiet.Rows.RemoveAt(index_row_ma_vt);
			}
        }

        string TAO_PHIEU_XUAT(string ho_ten_nguoi_nhan, string ma_bp)
        {
            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO KHO_VT_PHIEU_XUAT (HO_TEN_NGUOI_NHAN, MA_BP) OUTPUT INSERTED.MA_PHIEU_XUAT VALUES (@HO_TEN_NGUOI_NHAN, @MA_BP)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@HO_TEN_NGUOI_NHAN", ho_ten_nguoi_nhan, SqlDbType.NVarChar);
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

        private void THEM_DU_LIEU_VAO_BANG_CHI_TIET(string ma_phieu_xuat, string ma_vt, string ma_kho, string so_luong)
        {
            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO KHO_VT_CHI_TIET_XUAT (MA_PHIEU_XUAT, MA_VT, MA_KHO, SO_LUONG) VALUES (@MA_PHIEU_XUAT, @MA_VT, @MA_KHO, @SO_LUONG)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_PHIEU_XUAT", ma_phieu_xuat, SqlDbType.Int);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_VT", ma_vt, SqlDbType.Int);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_KHO", ma_kho, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@SO_LUONG", so_luong, SqlDbType.Int);
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
            string ma_bp = cbo_ma_bp.SelectedValue.ToString().Trim();

            if (ho_ten_nguoi_nhan == "")
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

            // KIỂM TRA HỌ TÊN NGƯỜI NHẬN

            if (ho_ten_nguoi_nhan != "" && CFuns.CHECK_CHARACTER(ho_ten_nguoi_nhan, " ", true, true, true) == false)
            {
                MessageBox.Show("HỌ TÊN NGƯỜI NHẬN CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA DANH SÁCH VẬT TƯ CẦN XUẤT

            if (dgv_ds_item_chi_tiet.Rows.Count <= 0)
            {
                MessageBox.Show("DANH SÁCH VẬT TƯ CẦN XUẤT ĐANG RỖNG", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            // TẠO PHIẾU XUẤT TRƯỚC, SAU ĐÓ DÙNG MÃ PHIẾU CÓ ĐƯỢC ĐỂ THÊM CHI TIẾT SAU

            string ma_phieu_xuat = TAO_PHIEU_XUAT(ho_ten_nguoi_nhan, ma_bp);
            if (ma_phieu_xuat != "")
            {
                // SAU KHI CÓ MÃ PHIẾU XUẤT TA TIẾN HÀNH THÊM DỮ LIỆU VÀO BẢNG CHI TIẾT

                for (int i = 0; i < dgv_ds_item_chi_tiet.Rows.Count; i++)
                {
                    string ma_vt = dgv_ds_item_chi_tiet.Rows[i].Cells["MA_VT"].Value.ToString();
                    string ma_kho = dgv_ds_item_chi_tiet.Rows[i].Cells["MA_KHO"].Value.ToString();
                    string so_luong = dgv_ds_item_chi_tiet.Rows[i].Cells["SO_LUONG"].Value.ToString();

                    THEM_DU_LIEU_VAO_BANG_CHI_TIET(ma_phieu_xuat, ma_vt, ma_kho, so_luong);
                }
            }
            else
            {
                MessageBox.Show("KHÔNG TẠO HOẶC LẤY ĐƯỢC MÃ PHIẾU XUẤT", "THÔNG BÁO");
            }

            MessageBox.Show("XUẤT VẬT TƯ THÀNH CÔNG", "THÔNG BÁO");

            this.Close();
        }

        private void cbo_ma_kho_SelectedValueChanged(object sender, EventArgs e)
        {
            btn_xem_item_trong_kho_Click(sender, e);
        }
    }
}
