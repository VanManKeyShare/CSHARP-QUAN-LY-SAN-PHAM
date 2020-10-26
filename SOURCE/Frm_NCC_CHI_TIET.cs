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
    public partial class Frm_NCC_CHI_TIET : Form
    {
        public string ID_DATA = "";
        public string MODE_CHANGE_DATA = "";
        public string SQL_CONNECTION_STRING = "";

        public Frm_NCC_CHI_TIET()
        {
            InitializeComponent();
        }

        private void Make_Combobox_Nhom_KH_NCC()
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_NKH_NCC, TEN_NKH_NCC FROM DM_NKH_NCC ORDER BY MA_NKH_NCC ASC";
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

            cbo_ma_nkhncc.DataSource = DT;
            cbo_ma_nkhncc.DisplayMember = "TEN_NKH_NCC";
            cbo_ma_nkhncc.ValueMember = "MA_NKH_NCC";
        }

        private void Frm_NCC_CHI_TIET_Load(object sender, EventArgs e)
        {
            // TẠO CONTROL DANH SÁCH NHÓM KHÁCH HÀNG & NHÀ CUNG CẤP

            Make_Combobox_Nhom_KH_NCC();

            // KIỂM TRA BIẾN ID_DATA ĐƯỢC TRUYỀN ĐẾN. NẾU RỖNG NGHĨA LÀ THÊM MỚI, NGƯỢC LẠI LÀ CẬP NHẬT

            if (ID_DATA.Trim() != "")
            {
                MODE_CHANGE_DATA = "CAP_NHAT";
                XEM_CSDL_THEO_ID(ID_DATA);
                btn_capnhat.Visible = true;
                btn_them.Visible = false;
                txt_ma_ncc.Enabled = false;
            }
            else
            {
                MODE_CHANGE_DATA = "THEM_MOI";
                btn_capnhat.Visible = false;
                btn_them.Visible = true;
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
            vmk.MS_SQL_QUERY = "SELECT [MA_NCC], [MA_NKH_NCC], [TEN_NCC], [DIA_CHI], [SDT], [FAX], [EMAIL], [MST], [GHI_CHU] FROM NHA_CUNG_CAP WHERE (MA_NCC = @MA_NCC) ORDER BY MA_NCC ASC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NCC", ID_DATA, SqlDbType.VarChar);
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
                txt_ma_ncc.Text = DT.Rows[0]["MA_NCC"].ToString().Trim();
                cbo_ma_nkhncc.SelectedValue = DT.Rows[0]["MA_NKH_NCC"].ToString().Trim();
                txt_ten_ncc.Text = DT.Rows[0]["TEN_NCC"].ToString().Trim();
                txt_dia_chi.Text = DT.Rows[0]["DIA_CHI"].ToString().Trim();
                txt_sdt.Text = DT.Rows[0]["SDT"].ToString().Trim();
                txt_fax.Text = DT.Rows[0]["FAX"].ToString().Trim();
                txt_email.Text = DT.Rows[0]["EMAIL"].ToString().Trim();
                txt_mst.Text = DT.Rows[0]["MST"].ToString().Trim();
                txt_ghi_chu.Text = DT.Rows[0]["GHI_CHU"].ToString().Trim();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (MODE_CHANGE_DATA != "THEM_MOI") { return; }

            Class_Funcs CFuns = new Class_Funcs();

            // LẤY VÀ KIỂM TRA DỮ LIỆU TỪ FORM

            string ma_ncc = txt_ma_ncc.Text.Trim().ToUpper();
            string ma_nkh_ncc = cbo_ma_nkhncc.SelectedValue.ToString();
            string ten_ncc = txt_ten_ncc.Text.Trim();
            string dia_chi = txt_dia_chi.Text.Trim();
            string sdt = txt_sdt.Text.Trim();
            string fax = txt_fax.Text.Trim();
            string email = txt_email.Text.Trim();
            string mst = txt_mst.Text.Trim();
            string ghi_chu = txt_ghi_chu.Text.Trim();

            if (ma_ncc == "" || ma_nkh_ncc == "" || ten_ncc == "" || dia_chi == "")
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

            // KIỂM TRA MÃ NHÓM NHÀ CUNG CẤP

            if (ma_nkh_ncc != "" && CFuns.CHECK_CHARACTER(ma_nkh_ncc, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ NHÓM NHÀ CUNG CẤP CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA TÊN NHÀ CUNG CẤP

            if (ten_ncc != "" && CFuns.CHECK_CHARACTER(ten_ncc, " ", true, true, true) == false)
            {
                MessageBox.Show("TÊN NHÀ CUNG CẤP CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA ĐỊA CHỈ

            if (dia_chi != "" && CFuns.CHECK_CHARACTER(dia_chi, " /,.-" + "\r\n", true, true, true) == false)
            {
                MessageBox.Show("ĐỊA CHỈ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA SĐT

            if (sdt != "" && CFuns.CHECK_CHARACTER(sdt, "", true, false, false) == false)
            {
                MessageBox.Show("SỐ ĐIỆN THOẠI CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA FAX

            if (fax != "" && CFuns.CHECK_CHARACTER(fax, "", true, false, false) == false)
            {
                MessageBox.Show("SỐ FAX CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA EMAIL

            if (email != "" && CFuns.CHECK_CHARACTER(email, "@._", true, true, false) == false)
            {
                MessageBox.Show("EMAIL CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MST

            if (mst != "" && CFuns.CHECK_CHARACTER(mst, "", true, false, false) == false)
            {
                MessageBox.Show("MÃ SỐ THUẾ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA GHI CHÚ

            if (ghi_chu != "" && CFuns.CHECK_CHARACTER(ghi_chu, " " + "\r\n", true, true, true) == false)
            {
                MessageBox.Show("GHI CHÚ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO [NHA_CUNG_CAP] ([MA_NCC], [MA_NKH_NCC], [TEN_NCC], [DIA_CHI], [SDT], [FAX], [EMAIL], [MST], [GHI_CHU]) VALUES (@MA_NCC, @MA_NKH_NCC, @TEN_NCC, @DIA_CHI, @SDT, @FAX, @EMAIL, @MST, @GHI_CHU)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NCC", ma_ncc, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NKH_NCC", ma_nkh_ncc, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@TEN_NCC", ten_ncc, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@DIA_CHI", dia_chi, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@SDT", sdt, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@FAX", fax, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@EMAIL", email, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MST", mst, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@GHI_CHU", ghi_chu, SqlDbType.NVarChar);
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

            string ma_ncc = ID_DATA.Trim();
            string ma_nkh_ncc = cbo_ma_nkhncc.SelectedValue.ToString();
            string ten_ncc = txt_ten_ncc.Text.Trim();
            string dia_chi = txt_dia_chi.Text.Trim();
            string sdt = txt_sdt.Text.Trim();
            string fax = txt_fax.Text.Trim();
            string email = txt_email.Text.Trim();
            string mst = txt_mst.Text.Trim();
            string ghi_chu = txt_ghi_chu.Text.Trim();

            if (ma_ncc == "" || ma_nkh_ncc == "" || ten_ncc == "" || dia_chi == "")
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

            // KIỂM TRA MÃ NHÓM NHÀ CUNG CẤP

            if (ma_nkh_ncc != "" && CFuns.CHECK_CHARACTER(ma_nkh_ncc, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ NHÓM NHÀ CUNG CẤP CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA TÊN NHÀ CUNG CẤP

            if (ten_ncc != "" && CFuns.CHECK_CHARACTER(ten_ncc, " ", true, true, true) == false)
            {
                MessageBox.Show("TÊN NHÀ CUNG CẤP CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA ĐỊA CHỈ

            if (dia_chi != "" && CFuns.CHECK_CHARACTER(dia_chi, " /,.-" + "\r\n", true, true, true) == false)
            {
                MessageBox.Show("ĐỊA CHỈ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA SĐT

            if (sdt != "" && CFuns.CHECK_CHARACTER(sdt, "", true, false, false) == false)
            {
                MessageBox.Show("SỐ ĐIỆN THOẠI CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA FAX

            if (fax != "" && CFuns.CHECK_CHARACTER(fax, "", true, false, false) == false)
            {
                MessageBox.Show("SỐ FAX CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA EMAIL

            if (email != "" && CFuns.CHECK_CHARACTER(email, "@._", true, true, false) == false)
            {
                MessageBox.Show("EMAIL CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MST

            if (mst != "" && CFuns.CHECK_CHARACTER(mst, "", true, false, false) == false)
            {
                MessageBox.Show("MÃ SỐ THUẾ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA GHI CHÚ

            if (ghi_chu != "" && CFuns.CHECK_CHARACTER(ghi_chu, " " + "\r\n", true, true, true) == false)
            {
                MessageBox.Show("GHI CHÚ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "UPDATE NHA_CUNG_CAP SET [MA_NKH_NCC] = @MA_NKH_NCC, [TEN_NCC] = @TEN_NCC, [DIA_CHI] = @DIA_CHI, [SDT] = @SDT, [FAX] = @FAX, [EMAIL] = @EMAIL, [MST] = @MST, [GHI_CHU] = @GHI_CHU WHERE [MA_NCC] = @MA_NCC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NCC", ma_ncc, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NKH_NCC", ma_nkh_ncc, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@TEN_NCC", ten_ncc, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@DIA_CHI", dia_chi, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@SDT", sdt, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@FAX", fax, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@EMAIL", email, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MST", mst, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@GHI_CHU", ghi_chu, SqlDbType.NVarChar);
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