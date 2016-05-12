using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;

namespace Shows_Downloaded
{
	public static class DatabaseLogs
	{
		public static string connectionString { get; set; }
		public static int MultipleShowConstant = 10000;
		private static Dictionary<string, int> statusdic = new Dictionary<string, int>();
        public static List<Logs> LogCollection = new List<Logs>();
		private static int LastID = -1;

        public static void WriteToLog (DateTime newDate, string newStatus)
		{
			if(DatabaseSettings.settings.KeepLog == true)
			{
				string txtLine = String.Format("{0:G}", newDate) + "\t" + newStatus + Environment.NewLine;

				File.AppendAllText(DatabaseSettings.settings.LogFileLocation, txtLine);

				if(DatabaseSettings.settings.LogToDatabase == true)
				{
					int saveID = -1;
					foreach(var pair in statusdic)
					{
						if(pair.Key.Equals(newStatus)) saveID = pair.Value;
					}
					if(saveID == -1)
					{
						LastID += 1;
						saveID = LastID;
						SaveNewStatus(LastID, newStatus);
					}
					String tableName = "Logs";
					String query = String.Format("select * from [{0}]", tableName);
					DataSet ds = new DataSet();
					OleDbConnection conn = new OleDbConnection(DatabaseSettings.connectionString);

					string strSql = "INSERT INTO Logs ([Time], [StatusLookup_ID]) " + "VALUES (?, ?)";

					using(OleDbConnection newConn = new OleDbConnection(DatabaseSettings.connectionString))
					{
						using(OleDbCommand dbCmd = new OleDbCommand(strSql, newConn))
						{
							dbCmd.CommandType = CommandType.Text;
							dbCmd.Parameters.AddWithValue("[Time]", newDate.ToString());
							dbCmd.Parameters.AddWithValue("[StatusLookup_ID]", saveID);
							newConn.Open();
							dbCmd.ExecuteNonQuery();
						}
						if(newConn.State == ConnectionState.Open)
							newConn.Close();
					}
				}
			}
		}

		public static void LoadStatuses()
		{
			String tableName = "StatusLookup";
			String query = String.Format("select * from [{0}] order by ID desc", tableName);
			DataSet ds = new DataSet();
            int TableIndexCount = -1;
            int nID;
            string strStatus;
			OleDbConnection conn = new OleDbConnection(connectionString);

			statusdic.Clear();
			try
			{
				//Open Database Connection
				conn.Open();
				OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
				OleDbCommandBuilder cmdB = new OleDbCommandBuilder(da);
				da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

				//Fill the DataSet
				da.Fill(ds, tableName);

                TableIndexCount = ds.Tables["StatusLookup"].Rows.Count;
                for (int i = 0; i < TableIndexCount; i++)
				{
                    nID = Convert.ToInt32(ds.Tables["StatusLookup"].Rows[i]["ID"]);
                    strStatus= ds.Tables["StatusLookup"].Rows[i]["Status"].ToString();

                    statusdic.Add(strStatus, nID);
                    if (LastID < nID) LastID = nID;
                }
			}
			catch(OleDbException exp)
			{
				System.Windows.Forms.MessageBox.Show("Database Error:" + exp.Message.ToString());
			}
			finally
			{
				if(conn.State == ConnectionState.Open)
				{
					conn.Close();
				}
			}
		}

        public static void LoadLogs()
        {
            String query = String.Format("SELECT Logs.Time, Logs.StatusLookup_ID, StatusLookup.Status FROM Logs LEFT JOIN StatusLookup ON Logs.StatusLookup_ID = StatusLookup.ID ORDER BY Logs.Time");
            DataSet ds = new DataSet();
            OleDbConnection conn = new OleDbConnection(connectionString);

            LogCollection.Clear();
            try
            {
                //Open Database Connection
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                OleDbCommandBuilder cmdB = new OleDbCommandBuilder(da);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                //Fill the DataSet
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Logs newLog = new Logs();
					newLog.LogDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Time"]);
                    newLog.Status = ds.Tables[0].Rows[i]["Status"].ToString();
					LogCollection.Add(newLog);
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

        private static void SaveNewStatus(int newID, string newStatus)
		{
            String tableName = "StatusLookup";
			String query = String.Format("select * from [{0}]", tableName);
			DataSet ds = new DataSet();
			OleDbConnection conn = new OleDbConnection(DatabaseSettings.connectionString);

			string strSql = "INSERT INTO StatusLookup ([ID], [Status]) " + "VALUES (?, ?)";

			using(OleDbConnection newConn = new OleDbConnection(DatabaseSettings.connectionString))
			{
				using(OleDbCommand dbCmd = new OleDbCommand(strSql, newConn))
				{
					dbCmd.CommandType = CommandType.Text;
					dbCmd.Parameters.AddWithValue("[ID]", newID);
					dbCmd.Parameters.AddWithValue("[Status]", newStatus);
					newConn.Open();
					dbCmd.ExecuteNonQuery();
				}
				if(newConn.State == ConnectionState.Open)
					newConn.Close();
			}
			statusdic.Add(newStatus, newID);
		}
	}
}
