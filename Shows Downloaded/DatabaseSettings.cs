using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;
using System.Data.OleDb;
using System.Data;


namespace Shows_Downloaded
{
    static class DatabaseSettings
    {
        public static AppSettings settings = new AppSettings();
        public static string connectionString { get; set; }

        public static void LoadAppSettings()
        {
            String tableName = "Settings";
            String query = "select * from Settings";
            DataSet ds = new DataSet();
            OleDbConnection conn = new OleDbConnection(connectionString);

            try
            {
                //Open Database Connection
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                OleDbCommandBuilder cmdB = new OleDbCommandBuilder(da);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                //Fill the DataSet
                da.Fill(ds, tableName);

                if (ds.Tables["Settings"].Rows.Count > 0)
                {
                    settings = JsonConvert.DeserializeObject<AppSettings>(ds.Tables["Settings"].Rows[0]["AppSettings"].ToString());
                }
            }
            catch (OleDbException exp)
            {
                System.Windows.Forms.MessageBox.Show("Database Error:" + exp.Message.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public static void SaveAppSettings()
        {
            String tableName = "Settings";
            String query = String.Format("select * from [{0}] where [ID] = {1}", tableName, 1);
            string userDataString = JsonConvert.SerializeObject(settings);
            DataSet ds = new DataSet();
            OleDbConnection conn = new OleDbConnection(connectionString);

            try
            {
                //Open Database Connection
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                OleDbCommandBuilder cmdB = new OleDbCommandBuilder(da);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                //Fill the DataSet
                da.Fill(ds, tableName);

                if (ds.Tables["Settings"].Rows.Count > 0)
                {
                    ds.Tables["Settings"].Rows[0]["AppSettings"] = userDataString;
                    da.Update(ds, "Settings");
                }
            }
            catch (OleDbException exp)
            {
                System.Windows.Forms.MessageBox.Show("Database Error:" + exp.Message.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }

}
