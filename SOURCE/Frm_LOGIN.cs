using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.Collections;

namespace QUẢN_LÝ_SẢN_PHẨM
{
    public partial class Frm_LOGIN : Form
    {
        public Frm_MAIN FMain = null;

        string File_LOGIN_XML = "";

        public string SQL_CONNECTION_STRING = "";

        public Frm_LOGIN()
        {
            InitializeComponent();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            // LẤY TÊN TÀI KHOẢN NẾU CÓ CHỌN NHỚ TÀI KHOẢN

            LOAD_LOGIN_SETTING();
        }

        private void LOAD_LOGIN_SETTING()
        {
            Class_Funcs Funcs = new Class_Funcs();
            string CurrDir = Funcs.GET_CURRENT_APP_PATH();
            File_LOGIN_XML = CurrDir + "LOGIN.XML";

            if (System.IO.File.Exists(File_LOGIN_XML))
            {
                txt_acc.Text = Funcs.GET_XML_VALUE("ACCOUNT_NAME", File_LOGIN_XML);
                string WinAu = Funcs.GET_XML_VALUE("REMEMBER_ACCOUNT", File_LOGIN_XML);
                if (WinAu == "1") { checkBox1.Checked = true; } else { checkBox1.Checked = false; }
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // LƯU TÊN TÀI KHOẢN ĐĂNG NHẬP NẾU CHỌN NHỚ TÀI KHOẢN

            if (checkBox1.Checked == false)
            {
                if (System.IO.File.Exists(File_LOGIN_XML))
                {
                    System.IO.File.Delete(File_LOGIN_XML);
                }
            }
            else
            {
                XmlWriterSettings Xml_Writer_Setting = new XmlWriterSettings();
                Xml_Writer_Setting.Indent = true;
                XmlWriter Xml_Writer = XmlWriter.Create(File_LOGIN_XML, Xml_Writer_Setting);
                Xml_Writer.WriteStartDocument();
                Xml_Writer.WriteStartElement("LOGIN");
                Xml_Writer.WriteElementString("ACCOUNT_NAME", txt_acc.Text.Trim());
                if (checkBox1.Checked == true)
                {
                    Xml_Writer.WriteElementString("REMEMBER_ACCOUNT", "1");
                }
                else
                {
                    Xml_Writer.WriteElementString("REMEMBER_ACCOUNT", "0");
                }
                Xml_Writer.WriteEndElement();
                Xml_Writer.WriteEndDocument();
                Xml_Writer.Flush();
                Xml_Writer.Close();
            }

            // TIẾN HÀNH ĐĂNG NHẬP

            string acc = txt_acc.Text.Trim();
            string pass = txt_pass.Text.Trim();

            VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();
            vmk.MS_SQL_CONNECTION_STRING = SQL_CONNECTION_STRING;
            vmk.MS_SQL_QUERY = "SELECT ACC, TEN_TK, MA_QH FROM TAI_KHOAN, DM_NHOM_TAI_KHOAN WHERE (TAI_KHOAN.MA_NTK = DM_NHOM_TAI_KHOAN.MA_NTK) AND (ACC = @ACC) AND (PASS = @PASS COLLATE SQL_LATIN1_GENERAL_CP1_CS_AS)";
            vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();
            vmk.MS_SQL_PARAMETERS.Clear();
            vmk.MS_SQL_PARAMETERS.Rows.Add("@ACC", acc, SqlDbType.VarChar);
            vmk.MS_SQL_PARAMETERS.Rows.Add("@PASS", pass, SqlDbType.VarChar);
            ArrayList KQ = vmk.MS_SQL_SELECT();

            if (KQ[0].ToString() == "ERROR")
            {
                Console.WriteLine(KQ[1].ToString());
                MessageBox.Show(KQ[1].ToString(),"THÔNG BÁO");
                return;
            }

            DataTable DT = (DataTable)KQ[2];

            if (DT.Rows.Count == 0)
            {
                MessageBox.Show("THÔNG TIN ĐĂNG NHẬP KHÔNG ĐÚNG","THÔNG BÁO");
                return;
            }

            // NẾU ĐĂNG NHẬP THÀNH CÔNG, THÌ ĐÓNG FORM LOGIN VÀ SET CÁC BIẾN TRONG FORM MAIN

            FMain.Acc_Logged = DT.Rows[0]["ACC"].ToString().Trim();
            FMain.Ho_Ten_Acc = DT.Rows[0]["TEN_TK"].ToString().Trim();

            string Quyen_Han_From_CSDL = DT.Rows[0]["MA_QH"].ToString().Trim();
            FMain.Quyen_Han = Quyen_Han_From_CSDL;

            FMain.Logged = true;

            MessageBox.Show("ĐĂNG NHẬP THÀNH CÔNG", "THÔNG BÁO");

            this.Close();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
