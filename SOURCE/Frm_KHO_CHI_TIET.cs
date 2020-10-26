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
    public partial class Frm_KHO_CHI_TIET : Form
    {
        public string ID_DATA = "";
        public string MODE_CHANGE_DATA = "";
        public string SQL_CONNECTION_STRING = "";

        public Frm_KHO_CHI_TIET()
        {
            InitializeComponent();
        }

        private void Make_Ds_LoaiKho()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("MA_LOAI_KHO", typeof(int));
            DT.Columns.Add("TEN_LOAI_KHO", typeof(string));

            DT.Rows.Add(1, "KHO SẢN PHẨM");
            DT.Rows.Add(2, "KHO VẬT TƯ");

            cbo_loaikho.DataSource = DT;
            cbo_loaikho.DisplayMember = "TEN_LOAI_KHO";
            cbo_loaikho.ValueMember = "MA_LOAI_KHO";
        }

        private void Frm_KHO_CHI_TIET_Load(object sender, EventArgs e)
        {
            // TẠO DANH SÁCH LOẠI KHO

            Make_Ds_LoaiKho();

            // KIỂM TRA BIẾN ID_DATA ĐƯỢC TRUYỀN ĐẾN. NẾU RỖNG NGHĨA LÀ THÊM MỚI, NGƯỢC LẠI LÀ CẬP NHẬT

            if (ID_DATA.Trim() != "")
            {
                MODE_CHANGE_DATA = "CAP_NHAT";
                XEM_CSDL_THEO_ID(ID_DATA);
                btn_capnhat.Visible = true;
                btn_them.Visible = false;
                txt_ma_kho.Enabled = false;
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
            vmk.MS_SQL_QUERY = "SELECT MA_KHO, TEN_KHO, DIA_CHI, GHI_CHU, LOAI_KHO FROM DM_KHO_HANG WHERE (MA_KHO = @MA_KHO) ORDER BY MA_KHO ASC";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_KHO", ID_DATA, SqlDbType.VarChar);
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
                txt_ma_kho.Text = DT.Rows[0]["MA_KHO"].ToString().Trim();
                txt_ten_kho.Text = DT.Rows[0]["TEN_KHO"].ToString().Trim();
                txt_dia_chi.Text = DT.Rows[0]["DIA_CHI"].ToString().Trim();
                txt_ghi_chu.Text = DT.Rows[0]["GHI_CHU"].ToString().Trim();
                cbo_loaikho.SelectedValue = DT.Rows[0]["LOAI_KHO"].ToString().Trim();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (MODE_CHANGE_DATA != "THEM_MOI") { return; }

            Class_Funcs CFuns = new Class_Funcs();

            // LẤY VÀ KIỂM TRA DỮ LIỆU TỪ FORM

            string ma_kho = txt_ma_kho.Text.Trim().ToUpper();
            string ten_kho = txt_ten_kho.Text.Trim();
            string dia_chi = txt_dia_chi.Text.Trim();
            string ghi_chu = txt_ghi_chu.Text.Trim();
            string ma_loai_kho = cbo_loaikho.SelectedValue.ToString().Trim();

            if (ma_kho == "" || ten_kho == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ KHO

            if (ma_kho != "" && CFuns.CHECK_CHARACTER(ma_kho, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ KHO CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ");
                return;
            }

            // KIỂM TRA TÊN KHO

            if (ten_kho != "" && CFuns.CHECK_CHARACTER(ten_kho, " ", true, true, true) == false)
            {
                MessageBox.Show("TÊN KHO CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA ĐỊA CHỈ

            if (dia_chi != "" && CFuns.CHECK_CHARACTER(dia_chi, " /,.-" + "\r\n", true, true, true) == false)
            {
                MessageBox.Show("ĐỊA CHỈ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA GHI CHÚ

            if (ghi_chu != "" && CFuns.CHECK_CHARACTER(ghi_chu, " " + "\r\n", true, true, true) == false)
            {
                MessageBox.Show("GHI CHÚ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ LOẠI KHO

            if (ma_loai_kho != "" && CFuns.CHECK_CHARACTER(ma_loai_kho, "", true, false, false) == false)
            {
                MessageBox.Show("MÃ LOẠI KHO CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "INSERT INTO DM_KHO_HANG (MA_KHO, TEN_KHO, DIA_CHI, GHI_CHU, LOAI_KHO) VALUES (@MA_KHO, @TEN_KHO, @DIA_CHI, @GHI_CHU, @LOAI_KHO)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_KHO", ma_kho, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@TEN_KHO", ten_kho, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@DIA_CHI", dia_chi, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@GHI_CHU", ghi_chu, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@LOAI_KHO", ma_loai_kho, SqlDbType.Int);
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

            string ma_kho = ID_DATA.Trim();
            string ten_kho = txt_ten_kho.Text.Trim();
            string dia_chi = txt_dia_chi.Text.Trim();
            string ghi_chu = txt_ghi_chu.Text.Trim();
            string ma_loai_kho = cbo_loaikho.SelectedValue.ToString().Trim();

            if (ma_kho == "" || ten_kho == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ KHO

            if (ma_kho != "" && CFuns.CHECK_CHARACTER(ma_kho, "_", true, true, false) == false)
            {
                MessageBox.Show("MÃ KHO CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA TÊN KHO

            if (ten_kho != "" && CFuns.CHECK_CHARACTER(ten_kho, " ", true, true, true) == false)
            {
                MessageBox.Show("TÊN KHO CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA ĐỊA CHỈ

            if (dia_chi != "" && CFuns.CHECK_CHARACTER(dia_chi, " /,.-" + "\r\n", true, true, true) == false)
            {
                MessageBox.Show("ĐỊA CHỈ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA GHI CHÚ

            if (ghi_chu != "" && CFuns.CHECK_CHARACTER(ghi_chu, " " + "\r\n", true, true, true) == false)
            {
                MessageBox.Show("GHI CHÚ CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // KIỂM TRA MÃ LOẠI KHO

            if (ma_loai_kho != "" && CFuns.CHECK_CHARACTER(ma_loai_kho, "", true, false, false) == false)
            {
                MessageBox.Show("MÃ LOẠI KHO CÓ CHỨA NHỮNG KÝ TỰ KHÔNG HỢP LỆ", "THÔNG BÁO");
                return;
            }

            // TIẾN HÀNH THÊM DỮ LIỆU VÀO CSDL

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "UPDATE DM_KHO_HANG SET TEN_KHO = @TEN_KHO, DIA_CHI = @DIA_CHI, GHI_CHU = @GHI_CHU, LOAI_KHO = @LOAI_KHO WHERE MA_KHO = @MA_KHO";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@MA_KHO", ma_kho, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@TEN_KHO", ten_kho, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@DIA_CHI", dia_chi, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@GHI_CHU", ghi_chu, SqlDbType.NVarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@LOAI_KHO", ma_loai_kho, SqlDbType.Int);
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