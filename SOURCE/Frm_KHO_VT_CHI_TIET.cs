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
    public partial class Frm_KHO_VT_CHI_TIET : Form
    {
        public string ID_DATA = "";
        public string MODE_CHANGE_DATA = "";
        public string SQL_CONNECTION_STRING = "";

        public Frm_KHO_VT_CHI_TIET()
        {
            InitializeComponent();
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

        private void Frm_KHO_VT_CHI_TIET_Load(object sender, EventArgs e)
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
                txt_ma_vt.Enabled = false;
            }
            else
            {
                MODE_CHANGE_DATA = "THEM_MOI";
                btn_capnhat.Visible = false;
                btn_them.Visible = true;
                txt_ma_vt.Enabled = false;
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
            vmk.MS_SQL_QUERY = "SELECT MA_VT, MA_NH, MA_DVT, TEN_VT, MO_TA FROM KHO_VAT_TU WHERE (MA_VT = @MA_VT) ORDER BY MA_VT ASC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_VT", ID_DATA, SqlDbType.VarChar);
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
                txt_ma_vt.Text = DT.Rows[0]["MA_VT"].ToString().Trim();
                cbo_ma_nh.SelectedValue = DT.Rows[0]["MA_NH"].ToString().Trim();
                cbo_ma_dvt.SelectedValue = DT.Rows[0]["MA_DVT"].ToString().Trim();
                txt_ten_vt.Text = DT.Rows[0]["TEN_VT"].ToString().Trim();
                txt_mo_ta.Text = DT.Rows[0]["MO_TA"].ToString().Trim();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (MODE_CHANGE_DATA != "THEM_MOI") { return; }

            Class_Funcs CFuns = new Class_Funcs();

            // LẤY VÀ KIỂM TRA DỮ LIỆU TỪ FORM

            string ma_nh = cbo_ma_nh.SelectedValue.ToString();
            string ma_dvt = cbo_ma_dvt.SelectedValue.ToString();
            string ten_vt = txt_ten_vt.Text.Trim();
            string mo_ta = txt_mo_ta.Text.Trim();

            if (ma_nh == "" || ma_dvt == "" || ten_vt == "")
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

            // KIỂM TRA TÊN VẬT TƯ

            if (ten_vt != "" && CFuns.CHECK_CHARACTER(ten_vt, " (;/\\.-)", true, true, true) == false)
            {
                MessageBox.Show("TÊN VẬT TƯ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÔ TẢ

            if (mo_ta != "" && CFuns.CHECK_CHARACTER(mo_ta, " (;/\\.-)" + "\r\n", true, true, true) == false)
            {
                MessageBox.Show("MÔ TẢ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO KHO_VAT_TU (MA_NH, MA_DVT, TEN_VT, MO_TA) VALUES (@MA_NH, @MA_DVT, @TEN_VT, @MO_TA)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NH", ma_nh, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_DVT", ma_dvt, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@TEN_VT", ten_vt, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MO_TA", mo_ta, SqlDbType.NVarChar);
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

            string ma_vt = ID_DATA.Trim();
            string ma_nh = cbo_ma_nh.SelectedValue.ToString();
            string ma_dvt = cbo_ma_dvt.SelectedValue.ToString();
            string ten_vt = txt_ten_vt.Text.Trim();
            string mo_ta = txt_mo_ta.Text.Trim();

            if (ma_vt == "" || ma_nh == "" || ma_dvt == "" || ten_vt == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ VẬT TƯ

            if (ma_vt != "" && CFuns.CHECK_CHARACTER(ma_vt, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ VẬT TƯ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
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

            // KIỂM TRA TÊN VẬT TƯ

            if (ten_vt != "" && CFuns.CHECK_CHARACTER(ten_vt, " (;/\\.-)", true, true, true) == false)
            {
                MessageBox.Show("TÊN VẬT TƯ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÔ TẢ

            if (mo_ta != "" && CFuns.CHECK_CHARACTER(mo_ta, " (;/\\.-)" +"\r\n", true, true, true) == false)
            {
                MessageBox.Show("MÔ TẢ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "UPDATE KHO_VAT_TU SET MA_NH = @MA_NH, MA_DVT = @MA_DVT, TEN_VT = @TEN_VT, MO_TA = @MO_TA WHERE MA_VT = @MA_VT";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_VT", ma_vt, SqlDbType.Int);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NH", ma_nh, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_DVT", ma_dvt, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@TEN_VT", ten_vt, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MO_TA", mo_ta, SqlDbType.NVarChar);
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