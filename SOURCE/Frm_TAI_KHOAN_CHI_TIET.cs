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
    public partial class Frm_TAI_KHOAN_CHI_TIET : Form
    {
        public string ID_DATA = "";
        public string MODE_CHANGE_DATA = "";
        public string SQL_CONNECTION_STRING = "";

        public Frm_TAI_KHOAN_CHI_TIET()
        {
            InitializeComponent();
        }

        private void Make_Combobox_Nhom_Tai_Khoan()
        {
            // LẤY DỮ LIỆU TỪ CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT MA_NTK, TEN_NTK FROM DM_NHOM_TAI_KHOAN ORDER BY TEN_NTK ASC";
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

            cbo_ma_ntk.DataSource = DT;
            cbo_ma_ntk.DisplayMember = "TEN_NTK";
            cbo_ma_ntk.ValueMember = "MA_NTK";
        }

        private void Frm_TAIKHOAN_CHI_TIET_Load(object sender, EventArgs e)
        {
            // TẠO CONTROL DANH SÁCH NHÓM TÀI KHOẢN

            Make_Combobox_Nhom_Tai_Khoan();

            // KIỂM TRA BIẾN ID_DATA ĐƯỢC TRUYỀN ĐẾN. NẾU RỖNG NGHĨA LÀ THÊM MỚI, NGƯỢC LẠI LÀ CẬP NHẬT

            if (ID_DATA.Trim() != "")
            {
                MODE_CHANGE_DATA = "CAP_NHAT";
                XEM_CSDL_THEO_ID(ID_DATA);
                btn_capnhat.Visible = true;
                btn_them.Visible = false;
                txt_acc.Enabled = false;
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
            vmk.MS_SQL_QUERY = "SELECT ACC, PASS, TEN_TK, MA_NTK, DIA_CHI, SDT FROM TAI_KHOAN WHERE (ACC = @ACC) ORDER BY ACC ASC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@ACC", ID_DATA, SqlDbType.VarChar);
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
                txt_acc.Text = DT.Rows[0]["ACC"].ToString().Trim();
                txt_pass.Text = DT.Rows[0]["PASS"].ToString().Trim();
                txt_ten_tk.Text = DT.Rows[0]["TEN_TK"].ToString().Trim();
                txt_sdt.Text = DT.Rows[0]["SDT"].ToString().Trim();
                cbo_ma_ntk.SelectedValue = DT.Rows[0]["MA_NTK"].ToString().Trim();
                txt_dia_chi.Text = DT.Rows[0]["DIA_CHI"].ToString().Trim();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (MODE_CHANGE_DATA != "THEM_MOI") { return; }

            Class_Funcs CFuns = new Class_Funcs();

            // LẤY VÀ KIỂM TRA DỮ LIỆU TỪ FORM

            string acc = txt_acc.Text.Trim().ToUpper();
            string pass = txt_pass.Text.Trim();
            string ten_tk = txt_ten_tk.Text.Trim();
            string ma_ntk = cbo_ma_ntk.SelectedValue.ToString();
            string dia_chi = txt_dia_chi.Text.Trim();
            string sdt = txt_sdt.Text.Trim();

            if (acc == "" || pass == "" || ten_tk == "" || ma_ntk == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA ACC

            if (acc != "" && CFuns.CHECK_CHARACTER(acc, "_", true, true, false) == false)
            {
                MessageBox.Show("TÀI KHOẢN CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA PASS

            if (pass != "" && CFuns.CHECK_CHARACTER(pass, " \"!#$%&'()*+,-./:;<=>?@[\\]^_`{|}~", true, true, true) == false)
            {
                MessageBox.Show("MẬT KHẨU CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA TÊN TÀI KHOẢN

            if (ten_tk != "" && CFuns.CHECK_CHARACTER(ten_tk, " ", true, true, true) == false)
            {
                MessageBox.Show("TÊN TÀI KHOẢN CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ NHÓM TÀI KHOẢN

            if (ma_ntk != "" && CFuns.CHECK_CHARACTER(ma_ntk, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ NHÓM TÀI KHOẢN CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
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

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO TAI_KHOAN (ACC, PASS, MA_NTK, TEN_TK, DIA_CHI, SDT) VALUES (@ACC, @PASS, @MA_NTK, @TEN_TK, @DIA_CHI, @SDT)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@ACC", acc, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NTK", ma_ntk, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@PASS", pass, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@TEN_TK", ten_tk, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@DIA_CHI", dia_chi, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@SDT", sdt, SqlDbType.VarChar);
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

            string acc = ID_DATA.Trim();
            string pass = txt_pass.Text.Trim();
            string ten_tk = txt_ten_tk.Text.Trim();
            string ma_ntk = cbo_ma_ntk.SelectedValue.ToString();
            string dia_chi = txt_dia_chi.Text.Trim();
            string sdt = txt_sdt.Text.Trim();

            if (acc == "" || pass == "" || ten_tk == "" || ma_ntk == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA ACC

            if (acc != "" && CFuns.CHECK_CHARACTER(acc, "_", true, true, false) == false)
            {
                MessageBox.Show("TÀI KHOẢN CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA PASS

            if (pass != "" && CFuns.CHECK_CHARACTER(pass, " \"!#$%&'()*+,-./:;<=>?@[\\]^_`{|}~", true, true, true) == false)
            {
                MessageBox.Show("MẬT KHẨU CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA TÊN TÀI KHOẢN

            if (ten_tk != "" && CFuns.CHECK_CHARACTER(ten_tk, " ", true, true, true) == false)
            {
                MessageBox.Show("TÊN TÀI KHOẢN CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ NHÓM TÀI KHOẢN

            if (ma_ntk != "" && CFuns.CHECK_CHARACTER(ma_ntk, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ NHÓM TÀI KHOẢN CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
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

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "UPDATE TAI_KHOAN SET PASS = @PASS, MA_NTK = @MA_NTK, TEN_TK = @TEN_TK, DIA_CHI = @DIA_CHI, SDT = @SDT WHERE ACC = @ACC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@ACC", acc, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_NTK", ma_ntk, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@PASS", pass, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@TEN_TK", ten_tk, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@DIA_CHI", dia_chi, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@SDT", sdt, SqlDbType.VarChar);
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