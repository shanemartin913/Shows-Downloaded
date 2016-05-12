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
	class DatabaseMultipleShows
	{
		public string connectionString { get; set; }
		public int MultipleShowConstant = 10000;

		public void SaveMultipleShow (ref List<Shows> list, string ShowName, int ShowID)
		{
			String tableName = "Shows_Multiday";
			String query = "select * from Shows_Multiday where [ShowID]=" + ShowID.ToString();
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
				for(int i = 0; i < ds.Tables["Shows_Multiday"].Rows.Count; i++)
				{
					Shows tempShow = new Shows();

					tempShow.ID = ShowID + MultipleShowConstant; // offset the show ID so we know this is a multiple
					tempShow.ShowName = ShowName;
					tempShow.ShowDay = ds.Tables["Shows_Multiday"].Rows[i]["MultiDay"].ToString();
					tempShow.DayIndex = GetDayofWeekFromName(tempShow.ShowDay);
					tempShow.Downloaded = Convert.ToBoolean(ds.Tables["Shows_Multiday"].Rows[i]["MultiDownloaded"]);
					tempShow.ShowTime = ds.Tables["Shows_Multiday"].Rows[i]["MultiTime"].ToString();
					tempShow.TimeIndex = GetTimeFromName(tempShow.ShowTime);
					tempShow.SkipWeek = Convert.ToBoolean(ds.Tables["Shows_Multiday"].Rows[i]["MultiSkipWeek"]);
					tempShow.MultipleShowID = ds.Tables["Shows_Multiday"].Rows[i]["ID"].ToString();
					tempShow.DoNotSave = true;
					tempShow.ChangesMade = true;
					tempShow.MultipleShow = true;
					list.Add(tempShow);
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
		public int GetDayofWeekFromName (string DayName)
		{
			string[] DoW = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
			int[] DoWnum = new int[] { 1, 2, 3, 4, 5, 6, 7 };

			for(int x = 0; x < DoW.Length; x++)
				if(DoW[x].Equals(DayName)) return DoWnum[x];

			return -1;
		}

		public double GetTimeFromName (string TimeName)
		{
			string[] timeText = new string[] { "7:00", "7:30", "8:00", "8:30", "9:00", "9:30", "10:00" };
			double[] timeNum = new double[] { 7, 7.5, 8, 8.5, 9, 9.5, 10 };

			for(int x = 0; x < timeText.Length; x++)
				if(timeText[x].Equals(TimeName)) return timeNum[x];

			return 0;
		}
	}
}
