using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QUẢN_LÝ_SẢN_PHẨM
{
    public partial class Frm_MAIN : Form
    {
        public string Acc_Logged = "";
        public string Ho_Ten_Acc = "";
        public string Quyen_Han = "";
        public bool Logged = false;

        string SQL_CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=QUAN_LY_SAN_PHAM;Integrated Security=True";

        public Frm_MAIN()
        {
            InitializeComponent();
        }

        private void Disable_Menu()
        {
            Menu_HeThong_TaiKhoan.Enabled = false;
            Menu_HeThong_DangNhap.Enabled = true;
            Menu_HeThong_DangXuat.Enabled = false;

            Menu_QuanLyDanhMuc.Enabled = false;

            Menu_QuanLyKho.Enabled = false;
            Menu_QuanLyKho_KhoSP_NSP.Enabled = false;
            Menu_QuanLyKho_KhoSP_XSP.Enabled = false;
            Menu_QuanLyKho_KhoVatTu_NVT.Enabled = false;
            Menu_QuanLyKho_KhoVatTu_XVT.Enabled = false;

            Menu_QuanLyChungTu.Enabled = false;
        }

        private void Enable_Menu_QuanLy()
        {
            Menu_HeThong_TaiKhoan.Enabled = true;
            Menu_HeThong_DangNhap.Enabled = false;
            Menu_HeThong_DangXuat.Enabled = true;

            Menu_QuanLyDanhMuc.Enabled = true;

            Menu_QuanLyKho.Enabled = true;
            Menu_QuanLyKho_KhoSP_NSP.Enabled = true;
            Menu_QuanLyKho_KhoSP_XSP.Enabled = true;
            Menu_QuanLyKho_KhoVatTu_NVT.Enabled = true;
            Menu_QuanLyKho_KhoVatTu_XVT.Enabled = true;

            Menu_QuanLyChungTu.Enabled = true;
        }

        private void Enable_Menu_NhanVien()
        {
            Menu_HeThong_TaiKhoan.Enabled = false;
            Menu_HeThong_DangNhap.Enabled = false;
            Menu_HeThong_DangXuat.Enabled = true;

            Menu_QuanLyDanhMuc.Enabled = false;

            Menu_QuanLyKho.Enabled = true;
            Menu_QuanLyKho_KhoSP_NSP.Enabled = true;
            Menu_QuanLyKho_KhoSP_XSP.Enabled = true;
            Menu_QuanLyKho_KhoVatTu_NVT.Enabled = true;
            Menu_QuanLyKho_KhoVatTu_XVT.Enabled = true;

            Menu_QuanLyChungTu.Enabled = true;
        }

        private void Enable_Menu_Khach()
        {
            Menu_HeThong_TaiKhoan.Enabled = false;
            Menu_HeThong_DangNhap.Enabled = false;
            Menu_HeThong_DangXuat.Enabled = true;

            Menu_QuanLyDanhMuc.Enabled = false;

            Menu_QuanLyKho.Enabled = true;
            Menu_QuanLyKho_KhoSP_NSP.Enabled = false;
            Menu_QuanLyKho_KhoSP_XSP.Enabled = false;
            Menu_QuanLyKho_KhoVatTu_NVT.Enabled = false;
            Menu_QuanLyKho_KhoVatTu_XVT.Enabled = false;

            Menu_QuanLyChungTu.Enabled = true;
        }

        private void Check_Logged()
        {
            if (Logged == false || Acc_Logged == "" || Quyen_Han == "" || Ho_Ten_Acc == "")
            {
                Disable_Menu();
            }
            else
            {
                if (Quyen_Han == "QUAN_LY_HE_THONG")
                {
                    Enable_Menu_QuanLy();
                }
                else if (Quyen_Han == "QUAN_LY_DU_LIEU")
                {
                    Enable_Menu_NhanVien();
                }
                else if (Quyen_Han == "XEM_DU_LIEU")
                {
                    Enable_Menu_Khach();
                }
                else
                {
                    Disable_Menu();
                }
            }
        }

        private void Lay_Chuoi_Kn_Csdl()
        {
            // LẤY CHUỖI KẾT NỐI CSDL TỪ FILE CSDL.XML

            Class_Funcs Funcs = new Class_Funcs();
            string CurrDir = Funcs.GET_CURRENT_APP_PATH();
            string File_CSDL_XML = CurrDir + "CSDL.XML";

            if (System.IO.File.Exists(File_CSDL_XML))
            {
                string Temp = Funcs.GET_XML_VALUE("SQL_CONNECTION_STRING", File_CSDL_XML).Trim();
                if (Temp != "")
                {
                    SQL_CONNECTION_STRING = Temp;
                }
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Check_Logged();
            Lay_Chuoi_Kn_Csdl();
        }

        private void Menu_HeThong_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_HeThong_CauHinhCSDL_Click(object sender, EventArgs e)
        {
            Frm_CHCSDL Frm = new Frm_CHCSDL();
            Frm.ShowDialog();
            Lay_Chuoi_Kn_Csdl();
        }

        private void Menu_HeThong_DangNhap_Click(object sender, EventArgs e)
        {
            Lay_Chuoi_Kn_Csdl();
            Frm_LOGIN Frm = new Frm_LOGIN();
            Frm.FMain = this;
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
            Check_Logged();
        }

        private void Menu_HeThong_DangXuat_Click(object sender, EventArgs e)
        {
            Acc_Logged = "";
            Ho_Ten_Acc = "";
            Quyen_Han = "";
            Logged = false;

            Check_Logged();
        }

        private void Menu_ThongTin_Click(object sender, EventArgs e)
        {
            Frm_THONG_TIN Frm = new Frm_THONG_TIN();
            Frm.ShowDialog();
        }

        private void Menu_HeThong_TaiKhoan_NTK_Click(object sender, EventArgs e)
        {
            Frm_NTK Frm = new Frm_NTK();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyDanhMuc_NGH_NH_DVT_DVT_Click(object sender, EventArgs e)
        {
            Frm_DVT Frm = new Frm_DVT();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyDanhMuc_NGH_NH_DVT_NGH_Click(object sender, EventArgs e)
        {
            Frm_NGH Frm = new Frm_NGH();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyDanhMuc_NGH_NH_DVT_NH_Click(object sender, EventArgs e)
        {
            Frm_NH Frm = new Frm_NH();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyDanhMuc_NKHNCC_Click(object sender, EventArgs e)
        {
            Frm_NKH_NCC Frm = new Frm_NKH_NCC();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyDanhMuc_KhoHang_Click(object sender, EventArgs e)
        {
            Frm_KHO Frm = new Frm_KHO();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_HeThong_TaiKhoan_DSTK_Click(object sender, EventArgs e)
        {
            Frm_TAI_KHOAN Frm = new Frm_TAI_KHOAN();
            Frm.Acc_Logged = Acc_Logged;
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyDanhMuc_KhachHang_Click(object sender, EventArgs e)
        {
            Frm_KHACH_HANG Frm = new Frm_KHACH_HANG();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyDanhMuc_NhaCungCap_Click(object sender, EventArgs e)
        {
            Frm_NCC Frm = new Frm_NCC();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyKho_KhoVatTu_DSVT_Click(object sender, EventArgs e)
        {
            Frm_KHO_VT Frm = new Frm_KHO_VT();
            Frm.Quyen_Han = Quyen_Han;
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyKho_KhoSP_DSSP_Click(object sender, EventArgs e)
        {
            Frm_KHO_SP Frm = new Frm_KHO_SP();
            Frm.Quyen_Han = Quyen_Han;
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyKho_KhoVatTu_NVT_Click(object sender, EventArgs e)
        {
            Frm_KHO_VT_NHAP Frm = new Frm_KHO_VT_NHAP();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyDanhMuc_BoPhan_Click(object sender, EventArgs e)
        {
            Frm_BP Frm = new Frm_BP();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyKho_KhoVatTu_XVT_Click(object sender, EventArgs e)
        {
            Frm_KHO_VT_XUAT Frm = new Frm_KHO_VT_XUAT();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyKho_KhoSP_NSP_Click(object sender, EventArgs e)
        {
            Frm_KHO_SP_NHAP Frm = new Frm_KHO_SP_NHAP();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyKho_KhoSP_XSP_Click(object sender, EventArgs e)
        {
            Frm_KHO_SP_XUAT Frm = new Frm_KHO_SP_XUAT();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyChungTu_PNVT_Click(object sender, EventArgs e)
        {
            Frm_PN_VT Frm = new Frm_PN_VT();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyChungTu_PXVT_Click(object sender, EventArgs e)
        {
            Frm_PX_VT Frm = new Frm_PX_VT();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyChungTu_PNSP_Click(object sender, EventArgs e)
        {
            Frm_PN_SP Frm = new Frm_PN_SP();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }

        private void Menu_QuanLyChungTu_PXSP_Click(object sender, EventArgs e)
        {
            Frm_PX_SP Frm = new Frm_PX_SP();
            Frm.SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            Frm.ShowDialog();
        }
    }
}
