/***
    -------

    VMK_DAO_FOR_MS_SQL by ManMan89

    Version 2.0 

    Release 2015.06.06

    -------

    EXAMPLE SELECT

		using System.Collections;

        VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();

        vmk.MS_SQL_CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=DATABASE_NAME;Integrated Security=True";

        vmk.MS_SQL_QUERY = "SELECT vmk_value FROM manman89 WHERE vmk_key = @vmk_key";

        vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();

        vmk.MS_SQL_PARAMETERS.Clear();

        vmk.MS_SQL_PARAMETERS.Rows.Add("@vmk_key", "12-05-1989", SqlDbType.VarChar);

        ArrayList KQ = vmk.MS_SQL_SELECT();

        MessageBox.Show(KQ[0].ToString());
        MessageBox.Show(KQ[1].ToString());

        DGV1.DataSource = (DataTable)KQ[2];

        // KQ[0] -> "OK" or "ERROR"
        // KQ[1] -> "" or "ERROR MESSAGE"
        // KQ[2] -> DATATABLE or EMPTY DATATABLE

    -------

    EXAMPLE INSERT

        VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();

        vmk.MS_SQL_CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=DATABASE_NAME;Integrated Security=True";

        vmk.MS_SQL_QUERY = "INSERT INTO manman89 (vmk_key, vmk_value) VALUES (@vmk_key, @vmk_value)";

        vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();

        vmk.MS_SQL_PARAMETERS.Clear();

        vmk.MS_SQL_PARAMETERS.Rows.Add("@vmk_key", "12-05-1989", SqlDbType.VarChar);
        vmk.MS_SQL_PARAMETERS.Rows.Add("@vmk_value", "Have a nice day", SqlDbType.NVarChar);

        String[] KQ = vmk.MS_SQL_INSERT_DELETE_UPDATE();

        MessageBox.Show(KQ[0].ToString());
        MessageBox.Show(KQ[1].ToString());

        // KQ[0] -> "OK" or "ERROR"
        // KQ[1] -> "SQL STATUS > 0" or "ERROR MESSAGE"

    -------

    EXAMPLE INSERT RETURN OUTPUT

        VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();

        vmk.MS_SQL_CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=DATABASE_NAME;Integrated Security=True";

        // QUERY FOR SQL SERVER 2005+ //

        vmk.MS_SQL_QUERY = "INSERT INTO manman89 (vmk_key, vmk_value) OUTPUT INSERTED.vmk_key VALUES (@vmk_key, @vmk_value)";

        // QUERY FOR SQL SERVER 2000 //

        // vmk.MS_SQL_QUERY = "INSERT INTO manman89 (vmk_key, vmk_value) VALUES (@vmk_key, @vmk_value); SELECT SCOPE_IDENTITY()";

        vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();

        vmk.MS_SQL_PARAMETERS.Clear();

        vmk.MS_SQL_PARAMETERS.Rows.Add("@vmk_key", "12-05-1989", SqlDbType.VarChar);
        vmk.MS_SQL_PARAMETERS.Rows.Add("@vmk_value", "Have a nice day", SqlDbType.NVarChar);

        String[] KQ = vmk.MS_SQL_INSERT_RETURN_OUTPUT();

        MessageBox.Show(KQ[0].ToString());
        MessageBox.Show(KQ[1].ToString());

        // KQ[0] -> "OK" or "ERROR"
        // KQ[1] -> "SQL STATUS > 0" or "ERROR MESSAGE"

    -------

    EXAMPLE DELETE

        VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();

        vmk.MS_SQL_CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=DATABASE_NAME;Integrated Security=True";

        vmk.MS_SQL_QUERY = "DELETE FROM manman89 WHERE vmk_key = @vmk_key";

        vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();

        vmk.MS_SQL_PARAMETERS.Clear();

        vmk.MS_SQL_PARAMETERS.Rows.Add("@vmk_key", "12-05-1989", SqlDbType.VarChar);

        String[] KQ = vmk.MS_SQL_INSERT_DELETE_UPDATE();

        MessageBox.Show(KQ[0].ToString());
        MessageBox.Show(KQ[1].ToString());

        // KQ[0] -> "OK" or "ERROR"
        // KQ[1] -> "SQL STATUS > 0" or "ERROR MESSAGE"

    -------

    EXAMPLE UPDATE

        VMK_DAO_FOR_MS_SQL vmk = new VMK_DAO_FOR_MS_SQL();

        vmk.MS_SQL_CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=DATABASE_NAME;Integrated Security=True";

        vmk.MS_SQL_QUERY = "UPDATE manman89 SET vmk_value = @vmk_value WHERE vmk_key = @vmk_key";

        vmk.MS_SQL_PARAMETERS = vmk.CREATE_MS_SQL_PARAMETERS();

        vmk.MS_SQL_PARAMETERS.Clear();

        vmk.MS_SQL_PARAMETERS.Rows.Add("@vmk_key", "12-05-1989", SqlDbType.VarChar);
        vmk.MS_SQL_PARAMETERS.Rows.Add("@vmk_value", "Have a good day", SqlDbType.NVarChar);

        String[] KQ = vmk.MS_SQL_INSERT_DELETE_UPDATE();

        MessageBox.Show(KQ[0].ToString());
        MessageBox.Show(KQ[1].ToString());

        // KQ[0] -> "OK" or "ERROR"
        // KQ[1] -> "SQL STATUS > 0" or "ERROR MESSAGE"

    -------
***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace QUẢN_LÝ_SẢN_PHẨM
{
    public class VMK_DAO_FOR_MS_SQL
    {
        public string MS_SQL_QUERY = "";
        public DataTable MS_SQL_PARAMETERS;
        public string MS_SQL_CONNECTION_STRING = "";
        
        public DataTable CREATE_MS_SQL_PARAMETERS()
        {
            DataTable MS_SQL_PARAMETERS = new DataTable();
            MS_SQL_PARAMETERS.Columns.Add("KEY", typeof(string));
            MS_SQL_PARAMETERS.Columns.Add("VALUE", typeof(string));
            MS_SQL_PARAMETERS.Columns.Add("TYPE_OF_DATA", typeof(int));
            return MS_SQL_PARAMETERS;
        }

        public ArrayList MS_SQL_SELECT()
        {
            ArrayList DATA_RETURN = new ArrayList(3);
            DataTable DATA_TABLE_RETURN = new DataTable();
            try
            {
                // MỞ KẾT NỐI CSDL

                SqlConnection MS_SQL_CONNECTION = new SqlConnection(MS_SQL_CONNECTION_STRING);
                MS_SQL_CONNECTION.Open();

                // THỰC HIỆN TRUY VẤN CSDL

                SqlCommand MS_SQL_COMMAND = new SqlCommand(MS_SQL_QUERY, MS_SQL_CONNECTION);
                MS_SQL_COMMAND.Parameters.Clear();

                for (int i = 0; i < MS_SQL_PARAMETERS.Rows.Count; i++)
                {
                    MS_SQL_COMMAND.Parameters.Add(new SqlParameter(MS_SQL_PARAMETERS.Rows[i][0].ToString(), MS_SQL_PARAMETERS.Rows[i][2]));
                    MS_SQL_COMMAND.Parameters[MS_SQL_PARAMETERS.Rows[i][0].ToString()].Value = MS_SQL_PARAMETERS.Rows[i][1];
                }

                SqlDataReader MS_SQL_DATA_READER = MS_SQL_COMMAND.ExecuteReader();

                // LẤY DỮ LIỆU CÓ ĐƯỢC TỪ TRUY VẤN ĐƯA VÀO ĐỐI TƯỢNG DATA TABLE

                DATA_TABLE_RETURN.Load(MS_SQL_DATA_READER);

                // ĐÓNG KẾT NỐI CSDL

                MS_SQL_CONNECTION.Close();

                DATA_RETURN.Clear();
                DATA_RETURN.Add("OK");
                DATA_RETURN.Add("");
                DATA_RETURN.Add(DATA_TABLE_RETURN);
            }
            catch (Exception ex)
            {
                DATA_RETURN.Clear();
                DATA_RETURN.Add("ERROR");
                DATA_RETURN.Add(ex.ToString());
                DATA_RETURN.Add(DATA_TABLE_RETURN);
            }

            return DATA_RETURN;
        }

        public string[] MS_SQL_INSERT_DELETE_UPDATE()
        {
            string[] DATA_RETURN = { "", "" };
            try
            {
                // MỞ KẾT NỐI CSDL

                SqlConnection MS_SQL_CONNECTION = new SqlConnection(MS_SQL_CONNECTION_STRING);
                MS_SQL_CONNECTION.Open();

                // THỰC HIỆN TRUY VẤN CSDL

                SqlCommand MS_SQL_COMMAND = new SqlCommand(MS_SQL_QUERY, MS_SQL_CONNECTION);
                MS_SQL_COMMAND.Parameters.Clear();

                for (int i = 0; i < MS_SQL_PARAMETERS.Rows.Count; i++)
                {
                    MS_SQL_COMMAND.Parameters.Add(new SqlParameter(MS_SQL_PARAMETERS.Rows[i][0].ToString(), MS_SQL_PARAMETERS.Rows[i][2]));
                    MS_SQL_COMMAND.Parameters[MS_SQL_PARAMETERS.Rows[i][0].ToString()].Value = MS_SQL_PARAMETERS.Rows[i][1];
                }

                int MS_SQL_COMMAND_RESULT = MS_SQL_COMMAND.ExecuteNonQuery();

                // ĐÓNG KẾT NỐI CSDL

                MS_SQL_CONNECTION.Close();

                DATA_RETURN[0] = "OK";
                DATA_RETURN[1] = MS_SQL_COMMAND_RESULT.ToString();
            }
            catch (Exception ex)
            {
                DATA_RETURN[0] = "ERROR";
                DATA_RETURN[1] = ex.ToString();
            }

            return DATA_RETURN;
        }

        public string[] MS_SQL_INSERT_RETURN_OUTPUT()
        {
            string[] DATA_RETURN = { "", "" };
            try
            {
                // MỞ KẾT NỐI CSDL

                SqlConnection MS_SQL_CONNECTION = new SqlConnection(MS_SQL_CONNECTION_STRING);
                MS_SQL_CONNECTION.Open();

                // THỰC HIỆN TRUY VẤN CSDL

                SqlCommand MS_SQL_COMMAND = new SqlCommand(MS_SQL_QUERY, MS_SQL_CONNECTION);
                MS_SQL_COMMAND.Parameters.Clear();

                for (int i = 0; i < MS_SQL_PARAMETERS.Rows.Count; i++)
                {
                    MS_SQL_COMMAND.Parameters.Add(new SqlParameter(MS_SQL_PARAMETERS.Rows[i][0].ToString(), MS_SQL_PARAMETERS.Rows[i][2]));
                    MS_SQL_COMMAND.Parameters[MS_SQL_PARAMETERS.Rows[i][0].ToString()].Value = MS_SQL_PARAMETERS.Rows[i][1];
                }

                string MS_SQL_COMMAND_RESULT = Convert.ToString(MS_SQL_COMMAND.ExecuteScalar());

                // ĐÓNG KẾT NỐI CSDL

                MS_SQL_CONNECTION.Close();

                DATA_RETURN[0] = "OK";
                DATA_RETURN[1] = MS_SQL_COMMAND_RESULT.ToString();


            }
            catch (Exception ex)
            {
                DATA_RETURN[0] = "ERROR";
                DATA_RETURN[1] = ex.ToString();
            }

            return DATA_RETURN;
        }
    }
}
