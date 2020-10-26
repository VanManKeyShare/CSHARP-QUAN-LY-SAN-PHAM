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
    public partial class Frm_KHO_SP_CHI_TIET : Form
    {
        public string ID_DATA = "";
        public string MODE_CHANGE_DATA = "";
        public string SQL_CONNECTION_STRING = "";

        public Frm_KHO_SP_CHI_TIET()
        {
            InitializeComponent();
            nbric_dongia_xuat.Controls.RemoveAt(0);
        }

        private void Make_Combobox_Nhom_Hang()
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_NH, TEN_NH FROM DM_NHOM_HANG ORDER BY MA_NH ASC";
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

            cbo_ma_nh.DataSource = DT;
            cbo_ma_nh.DisplayMember = "TEN_NH";
            cbo_ma_nh.ValueMember = "MA_NH";
        }

        private void Make_Combobox_DVT()
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_DVT, TEN_DVT FROM DM_DON_VI_TINH ORDER BY MA_DVT ASC";
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

            cbo_ma_dvt.DataSource = DT;
            cbo_ma_dvt.DisplayMember = "TEN_DVT";
            cbo_ma_dvt.ValueMember = "MA_DVT";
        }

        private void Frm_KHO_SP_CHI_TIET_Load(object sender, EventArgs e)
        {
            // TẠO CONTROL DANH SÁCH NHÓM HÀNG

            Make_Combobox_Nhom_Hang();

            // TẠO CONTROL DANH SÁCH ĐƠN VỊ TÍNH

            Make_Combobox_DVT();

            // KIỂM TRA BIẾN ID_DATA ĐƯỢC TRUYỀN ĐẾN. NẾU RỖNG NGHĨA LÀ THÊM MỚI, NGƯỢC LẠI LÀ CẬP NHẬT

            if (ID_DATA.Trim() != "")
            {
                MODE_CHANGE_DATA = "CAP_NHAT";
                XEM_CSDL_THEO_ID(ID_DATA);
                btn_capnhat.Visible = true;
                btn_them.Visible = false;
                txt_ma_sp.Enabled = false;
            }
            else
            {
                MODE_CHANGE_DATA = "THEM_MOI";
                btn_capnhat.Visible = false;
                btn_them.Visible = true;
                txt_ma_sp.Enabled = false;
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void XEM_CSDL_THEO_ID(string ID_DATA)
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_SP, MA_NH, MA_DVT, TEN_SP, MO_TA, DON_GIA_XUAT FROM KHO_SAN_PHAM WHERE (MA_SP = @MA_SP) ORDER BY MA_SP ASC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_SP", ID_DATA, SqlDbType.VarChar);
            ArrayList KQ = vmk.MS_SQL_SELECT();

            if (KQ[0].ToString() == "ERROR")
            {
                MessageBox.Show(KQ[1].ToString(), "THÔNG BÁO");
                return;
            }

            DataTable DT = (DataTable)KQ[2];

            // SAU ĐÓ NẠP VÀO CÁC CONTROL

            if (DT.Rows.Count != 0)
            {
                txt_ma_sp.Text = DT.Rows[0]["MA_SP"].ToString().Trim();
                cbo_ma_nh.SelectedValue = DT.Rows[0]["MA_NH"].ToString().Trim();
                cbo_ma_dvt.SelectedValue = DT.Rows[0]["MA_DVT"].ToString().Trim();
                txt_ten_sp.Text = DT.Rows[0]["TEN_SP"].ToString().Trim();
                txt_mo_ta.Text = DT.Rows[0]["MO_TA"].ToString().Trim();
                nbric_dongia_xuat.Value = int.Parse(DT.Rows[0]["DON_GIA_XUAT"].ToString().Trim());
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (MODE_CHANGE_DATA != "THEM_MOI") { return; }

            Class_Funcs CFuns = new Class_Funcs();

            // LẤY VÀ KIỂM TRA DỮ LIỆU TỪ FORM

            string ma_nh = cbo_ma_nh.SelectedValue.ToString();
            string ma_dvt = cbo_ma_dvt.SelectedValue.ToString();
            string ten_sp = txt_ten_sp.Text.Trim();
            string mo_ta = txt_mo_ta.Text.Trim();
            string don_gia_xuat = nbric_dongia_xuat.Value.ToString().Trim();

            if (ma_nh == "" || ma_dvt == "" || ten_sp == "" || don_gia_xuat == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ NHÓM HÀNG

            if (ma_nh != "" && CFuns.CHECK_CHARACTER(ma_nh, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ NHÓM HÀNG CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ ĐƠN VỊ TÍNH

            if (ma_dvt != "" && CFuns.CHECK_CHARACTER(ma_dvt, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ ĐƠN VỊ TÍNH CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA TÊN SẢN PHẨM

            if (ten_sp != "" && CFuns.CHECK_CHARACTER(ten_sp, " (;/\\.-)", true, true, true) == false)
            {
                MessageBox.Show("TÊN SẢN PHẨM CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÔ TẢ

            if (mo_ta != "" && CFuns.CHECK_CHARACTER(mo_ta, " (;/\\.-)" + "\r\n", true, true, true) == false)
            {
                MessageBox.Show("MÔ TẢ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA ĐƠN GIÁ XUẤT

            if (don_gia_xuat != "" && CFuns.CHECK_CHARACTER(don_gia_xuat, "", true, false, false) == false)
            {
                MessageBox.Show("ĐƠN GIÁ XUẤT CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            if (don_gia_xuat == "0")
            {
                MessageBox.Show("ĐƠN GIÁ XUẤT PHẢI LỚN HƠN 0", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO KHO_SAN_PHAM (MA_NH, MA_DVT, TEN_SP, MO_TA, DON_GIA_XUAT) VALUES (@MA_NH, @MA_DVT, @TEN_SP, @MO_TA, @DON_GIA_XUAT)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NH", ma_nh, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_DVT", ma_dvt, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@TEN_SP", ten_sp, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MO_TA", mo_ta, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@DON_GIA_XUAT", don_gia_xuat, SqlDbType.Int);
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

            MessageBox.Show("THÊM DỮ LIỆU MỚI THÀNH CÔNG", "THÔNG BÁO");

            this.Close();
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            if (MODE_CHANGE_DATA != "CAP_NHAT") { return; }

            Class_Funcs CFuns = new Class_Funcs();

            // LẤY VÀ KIỂM TRA DỮ LIỆU TỪ FORM

            string ma_sp = ID_DATA.Trim();
            string ma_nh = cbo_ma_nh.SelectedValue.ToString();
            string ma_dvt = cbo_ma_dvt.SelectedValue.ToString();
            string ten_sp = txt_ten_sp.Text.Trim();
            string mo_ta = txt_mo_ta.Text.Trim();
            string don_gia_xuat = nbric_dongia_xuat.Value.ToString();

            if (ma_sp == "" || ma_nh == "" || ma_dvt == "" || ten_sp == "" || don_gia_xuat == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ SẢN PHẨM

            if (ma_sp != "" && CFuns.CHECK_CHARACTER(ma_sp, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ SẢN PHẨM CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ NHÓM HÀNG

            if (ma_nh != "" && CFuns.CHECK_CHARACTER(ma_nh, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ NHÓM HÀNG CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ ĐƠN VỊ TÍNH

            if (ma_dvt != "" && CFuns.CHECK_CHARACTER(ma_dvt, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ ĐƠN VỊ TÍNH CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA TÊN SẢN PHẨM

            if (ten_sp != "" && CFuns.CHECK_CHARACTER(ten_sp, " (;/\\.-)", true, true, true) == false)
            {
                MessageBox.Show("TÊN SẢN PHẨM CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÔ TẢ

            if (mo_ta != "" && CFuns.CHECK_CHARACTER(mo_ta, " (;/\\.-)" +"\r\n", true, true, true) == false)
            {
                MessageBox.Show("MÔ TẢ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA ĐƠN GIÁ XUẤT

            if (don_gia_xuat != "" && CFuns.CHECK_CHARACTER(don_gia_xuat, "", true, false, false) == false)
            {
                MessageBox.Show("ĐƠN GIÁ XUẤT CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            if (don_gia_xuat == "0")
            {
                MessageBox.Show("ĐƠN GIÁ XUẤT PHẢI LỚN HƠN 0", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "UPDATE KHO_SAN_PHAM SET MA_NH = @MA_NH, MA_DVT = @MA_DVT, TEN_SP = @TEN_SP, MO_TA = @MO_TA, DON_GIA_XUAT = @DON_GIA_XUAT WHERE MA_SP = @MA_SP";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_SP", ma_sp, SqlDbType.Int);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NH", ma_nh, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_DVT", ma_dvt, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@TEN_SP", ten_sp, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MO_TA", mo_ta, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@DON_GIA_XUAT", don_gia_xuat, SqlDbType.Int);
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

            MessageBox.Show("CẬP NHẬT DỮ LIỆU THÀNH CÔNG", "THÔNG BÁO");

            this.Close();
        }
    }
}