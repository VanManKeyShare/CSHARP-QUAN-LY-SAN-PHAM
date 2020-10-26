using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.Data.SqlClient;

namespace QUẢN_LÝ_SẢN_PHẨM
{
    public partial class Frm_CHCSDL : Form
    {
        string File_CSDL_XML = "";

        public Frm_CHCSDL()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txt_account.Enabled = !checkBox1.Checked;
            txt_password.Enabled = !checkBox1.Checked;
        }

        private void btn_test_and_save_connection_Click(object sender, EventArgs e)
        {
            // TẠO CHUỖI KẾT NỐI CSDL DỰA VÀO CÁC THÔNG SỐ ĐƯỢC CUNG CẤP

            string SQL_CONNECTION_STRING = "";

            if (checkBox1.Checked == false)
            {
                SQL_CONNECTION_STRING = SQL_CONNECTION_STRING + "Server=" + txt_server_name.Text.Trim() + ";";
                SQL_CONNECTION_STRING = SQL_CONNECTION_STRING + "Database=" + txt_database_name.Text.Trim() + ";";
                SQL_CONNECTION_STRING = SQL_CONNECTION_STRING + "User Id=" + txt_account.Text.Trim() + ";";
                SQL_CONNECTION_STRING = SQL_CONNECTION_STRING + "Password=" + txt_password.Text.Trim() + ";";
            }
            else
            {
                SQL_CONNECTION_STRING = SQL_CONNECTION_STRING + "Data Source=" + txt_server_name.Text.Trim() + ";";
                SQL_CONNECTION_STRING = SQL_CONNECTION_STRING + "Initial Catalog=" + txt_database_name.Text.Trim() + ";";
                SQL_CONNECTION_STRING = SQL_CONNECTION_STRING + "Integrated Security=True";
            }

            // TIẾN HÀNH KIỂM TRA KẾT NỐI VỚI CSDL

            SqlConnection MS_SQL_CONNECTION = new SqlConnection(SQL_CONNECTION_STRING);
            try
            {
                MS_SQL_CONNECTION.Open();
                MS_SQL_CONNECTION.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("KHÔNG KẾT NỐI ĐƯỢC CSDL. XIN XEM LẠI THÔNG SỐ KẾT NỐI","THÔNG BÁO");
                Console.WriteLine(ex.ToString());
                return;
            }

            // NẾU KẾT NỐI THÀNH CÔNG THÌ TIẾN HÀNH CẬP NHẬT CONTROL CHUỖI KẾT NỐI

            txt_sql_connection_string.Text = SQL_CONNECTION_STRING;

            // SAU ĐÓ LƯU THÔNG SỐ KẾT NỐI RA FILE XML

            XmlWriterSettings Xml_Writer_Setting = new XmlWriterSettings();
            Xml_Writer_Setting.Indent = true;
            XmlWriter Xml_Writer = XmlWriter.Create(File_CSDL_XML, Xml_Writer_Setting);
            Xml_Writer.WriteStartDocument();
            Xml_Writer.WriteStartElement("CSDL");
            Xml_Writer.WriteElementString("SERVER_NAME", txt_server_name.Text.Trim());
            Xml_Writer.WriteElementString("DATABASE_NAME", txt_database_name.Text.Trim());
            if (checkBox1.Checked == true)
            {
                Xml_Writer.WriteElementString("WINDOWS_AUTHENTICATION", "1");
            }
            else
            {
                Xml_Writer.WriteElementString("WINDOWS_AUTHENTICATION", "0");
            }
            Xml_Writer.WriteElementString("ACCOUNT", txt_account.Text.Trim());
            Xml_Writer.WriteElementString("PASSWORD", txt_password.Text.Trim());
            Xml_Writer.WriteElementString("SQL_CONNECTION_STRING", txt_sql_connection_string.Text.Trim());
            Xml_Writer.WriteEndElement();
            Xml_Writer.WriteEndDocument();
            Xml_Writer.Flush();
            Xml_Writer.Close();

            // THÔNG BÁO THÀNH CÔNG ĐẾN NGƯỜI DÙNG

            MessageBox.Show("LƯU CẤU HÌNH KẾT NỐI CSDL THÀNH CÔNG","THÔNG BÁO");
        }

        private void btn_reset_default_Click(object sender, EventArgs e)
        {
            txt_server_name.Text = @".\SQLEXPRESS";
            txt_database_name.Text = "QUAN_LY_SAN_PHAM";
            checkBox1.Checked = true;
            txt_account.Text = "SA";
            txt_password.Text = "";
            txt_sql_connection_string.Text = @"Data Source=.\SQLEXPRESS;Initial Catalog=QUAN_LY_SAN_PHAM;Integrated Security=True";
        }

        private void Frm_CHCSDL_Load(object sender, EventArgs e)
        {
            LOAD_CSDL_SETTING();
        }

        private void LOAD_CSDL_SETTING()
        {
            Class_Funcs Funcs = new Class_Funcs();
            string CurrDir = Funcs.GET_CURRENT_APP_PATH();
            File_CSDL_XML = CurrDir + "CSDL.XML";

            if (System.IO.File.Exists(File_CSDL_XML))
            {
                txt_server_name.Text = Funcs.GET_XML_VALUE("SERVER_NAME", File_CSDL_XML);
                txt_database_name.Text = Funcs.GET_XML_VALUE("DATABASE_NAME", File_CSDL_XML);

                string WinAu = Funcs.GET_XML_VALUE("WINDOWS_AUTHENTICATION", File_CSDL_XML);
                if (WinAu == "1") { checkBox1.Checked = true; } else { checkBox1.Checked = false; }

                txt_account.Text = Funcs.GET_XML_VALUE("ACCOUNT", File_CSDL_XML);
                txt_password.Text = Funcs.GET_XML_VALUE("PASSWORD", File_CSDL_XML);
                txt_sql_connection_string.Text = Funcs.GET_XML_VALUE("SQL_CONNECTION_STRING", File_CSDL_XML);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
