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
	public class DatabaseShows
	{
		public string connectionString { get; set; }
		public int MultipleShowConstant = 10000;

		public void LoadDatabase (ref List<Shows> list, out int NextID)
		{
			String tableName = "Shows";
			String query = "select * from Shows";
			string tempShowname;
			int tempShowID;
			DataSet ds = new DataSet();
			OleDbConnection conn = new OleDbConnection(connectionString);

			list.Clear();
			NextID = 1;
			try
			{
				//Open Database Connection
				conn.Open();
				OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
				OleDbCommandBuilder cmdB = new OleDbCommandBuilder(da);
				da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

				//Fill the DataSet
				da.Fill(ds, tableName);

				for(int i = 0; i < ds.Tables["Shows"].Rows.Count; i++)
				{
					Shows tempShow = new Shows();

					if(Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["MultipleShowings"]) == true)
					{
						tempShowname = ds.Tables["Shows"].Rows[i]["Show_Name"].ToString();
						tempShowID = Convert.ToInt32(ds.Tables["Shows"].Rows[i]["ID"]);
						DatabaseMultipleShows multidb = new DatabaseMultipleShows();
						multidb.connectionString = connectionString;
						multidb.SaveMultipleShow(ref list, tempShowname, tempShowID);

						foreach(Shows x in list)
						{
							if(x.ID - MultipleShowConstant == tempShowID)
							{
								//                                x.ID = tempShowID;
								x.StartDate = Convert.ToDateTime(ds.Tables["Shows"].Rows[i]["Start_Date"]);
								x.SeasonEnd = Convert.ToDateTime(ds.Tables["Shows"].Rows[i]["Season_End"]);
								x.OnHiatus = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["OnHiatus"]);
								x.ShowCancelled = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["Cancelled"]);
								x.ShowDeleted = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["Deleted"]);
								x.ShowMissedLastWeek = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["MissedLastWeek"]);
								x.MultipleShowTimes = false;
								x.SingleShowing = false;
								x.ChangesMade = false;
								Console.WriteLine("Loading MultiShow {0}", x.ShowName);
								//                                x.DoNotSave = true;
							}
						}
					}
					tempShow.ID = Convert.ToInt32(ds.Tables["Shows"].Rows[i]["ID"]);
					if(tempShow.ID > NextID) NextID = tempShow.ID;
					tempShow.ShowName = ds.Tables["Shows"].Rows[i]["Show_Name"].ToString();
					tempShow.ShowDay = ds.Tables["Shows"].Rows[i]["DayText"].ToString();
					tempShow.DayIndex = GetDayofWeekFromName(tempShow.ShowDay);
					tempShow.Downloaded = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["Downloaded"]);
					tempShow.ShowTime = ds.Tables["Shows"].Rows[i]["TimeText"].ToString();
					tempShow.TimeIndex = GetTimeFromName(tempShow.ShowTime);
					tempShow.SkipWeek = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["No_Download_Week"]);
					tempShow.StartDate = Convert.ToDateTime(ds.Tables["Shows"].Rows[i]["Start_Date"]);
					tempShow.SeasonEnd = Convert.ToDateTime(ds.Tables["Shows"].Rows[i]["Season_End"]);
					tempShow.OnHiatus = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["OnHiatus"]);
					tempShow.ShowCancelled = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["Cancelled"]);
					tempShow.ShowDeleted = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["Deleted"]);
					tempShow.ShowMissedLastWeek = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["MissedLastWeek"]);
					tempShow.MultipleShowTimes = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["MultipleShowings"]);
					tempShow.SingleShowing = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["SingleShowing"]);
					tempShow.DoNotSave = false;
					tempShow.ChangesMade = false;
					tempShow.DatabaseRow = i;
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

		public void SaveDatabase (ref List<Shows> list)
		{
			String tableName = "Shows";
			String query = String.Format("select * from [{0}]", tableName);
			Shows tempShow = new Shows();
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

				for(int i = 0; i < ds.Tables["Shows"].Rows.Count; i++)
				{
					for(int x = 0; x < list.Count; x++)
					{
						if(list[x].ID == Convert.ToInt32(ds.Tables["Shows"].Rows[i]["ID"]) && list[x].DoNotSave == false)
							tempShow = list[x];
					}
					if(tempShow != null)
					{
						if(tempShow.ChangesMade == true)
						{
                            DateTime dt = DateTime.Now;
                            DatabaseLogs.WriteToLog(dt, "Saving changes to " + tempShow.ShowName);
							Console.WriteLine("Updating {0}", tempShow.ShowName);
							ds.Tables["Shows"].Rows[i]["Show_Name"] = tempShow.ShowName;
							ds.Tables["Shows"].Rows[i]["DayText"] = tempShow.ShowDay;
							ds.Tables["Shows"].Rows[i]["Downloaded"] = tempShow.Downloaded;
							ds.Tables["Shows"].Rows[i]["TimeText"] = tempShow.ShowTime;
							ds.Tables["Shows"].Rows[i]["No_Download_Week"] = tempShow.SkipWeek;
							ds.Tables["Shows"].Rows[i]["Start_Date"] = tempShow.StartDate.ToShortDateString();
							ds.Tables["Shows"].Rows[i]["Season_End"] = tempShow.SeasonEnd.ToShortDateString();
							ds.Tables["Shows"].Rows[i]["OnHiatus"] = tempShow.OnHiatus;
							ds.Tables["Shows"].Rows[i]["SingleShowing"] = tempShow.SingleShowing;
							ds.Tables["Shows"].Rows[i]["Cancelled"] = tempShow.ShowCancelled;
							ds.Tables["Shows"].Rows[i]["Deleted"] = tempShow.ShowDeleted;
							ds.Tables["Shows"].Rows[i]["MissedLastWeek"] = tempShow.ShowMissedLastWeek;
							ds.Tables["Shows"].Rows[i]["MultipleShowings"] = tempShow.MultipleShowTimes;

							if(tempShow.MultipleShowTimes == true)
							{
								Console.WriteLine("Branching to SavingMultipleShows");
								SaveMultipleShowsToAccessDatabase(ref list, tempShow.ID);
							}
							tempShow.ChangesMade = false;
						}
					}
				}
				da.Update(ds, "Shows");
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

        public void SaveMultipleShowsToAccessDatabase(ref List<Shows> list, int multiID)
        {
            DeleteMultipleShowsFromAccessDatabase(multiID);

            String tableName = "Shows_Multiday";
            String query = String.Format("select * from [{0}]", tableName);
            DataSet ds = new DataSet();
            OleDbConnection conn =
                  new OleDbConnection(connectionString);

            string strSql = "INSERT INTO Shows_Multiday ([ID], [ShowID], [MultiDay], [MultiDownloaded], [MultiTime], [MultiSkipWeek]) "
                + "VALUES (?, ?, ?, ?, ?, ?)";

            using (OleDbConnection newConn = new OleDbConnection(connectionString))
            {
                for (int x = 0; x < list.Count; x++)
                {
                    if (list[x].ID == multiID + MultipleShowConstant)
                    {
                        using (OleDbCommand dbCmd = new OleDbCommand(strSql, newConn))
                        {
                            dbCmd.CommandType = CommandType.Text;
                            Guid messageId = System.Guid.NewGuid();
                            dbCmd.Parameters.AddWithValue("[ID]", messageId.ToString());
                            dbCmd.Parameters.AddWithValue("[ShowID]", multiID);
                            dbCmd.Parameters.AddWithValue("[MultiDay]", list[x].ShowDay);
                            dbCmd.Parameters.AddWithValue("[MultiDownloaded", list[x].Downloaded);
                            dbCmd.Parameters.AddWithValue("[MultiTime]", list[x].ShowTime);
                            dbCmd.Parameters.AddWithValue("[MultiSkipWeek]", list[x].SkipWeek);
                            if (newConn.State != ConnectionState.Open) newConn.Open();
                            dbCmd.ExecuteNonQuery();
                        }
                    }
                }
                if (newConn.State == ConnectionState.Open)
                    newConn.Close();
            }
        }

        public void DeleteMultipleShowsFromAccessDatabase(int showID)
        {
            string sql = "DELETE FROM Shows_Multiday WHERE [ShowID] =" + showID.ToString();
            using (OleDbConnection My_Connection = new OleDbConnection(connectionString))
            {
                My_Connection.Open();
                OleDbCommand My_Command = new OleDbCommand(sql, My_Connection);
                My_Command.ExecuteNonQuery();
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
        public void AddShowToDatabase(Shows newShow)
        {
            String tableName = "Shows";
            String query = String.Format("select * from [{0}]", tableName);
            DataSet ds = new DataSet();
            OleDbConnection conn = new OleDbConnection(connectionString);

            string strSql = "INSERT INTO Shows ([ID], [Show_Name], [DayText], [Downloaded], [TimeText], [No_Download_Week], [Start_Date], [Season_End], [OnHiatus], [Cancelled], [Deleted], [MissedLastWeek], [MultipleShowings], [SingleShowing]) "
                + "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

            using (OleDbConnection newConn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand dbCmd = new OleDbCommand(strSql, newConn))
                {
                    dbCmd.CommandType = CommandType.Text;
                    dbCmd.Parameters.AddWithValue("[ID]", newShow.ID);
                    dbCmd.Parameters.AddWithValue("[Show_Name]", newShow.ShowName);
                    dbCmd.Parameters.AddWithValue("[DayText]", newShow.ShowDay);
                    dbCmd.Parameters.AddWithValue("[Download", newShow.Downloaded);
                    dbCmd.Parameters.AddWithValue("[TimeText]", newShow.ShowTime);
                    dbCmd.Parameters.AddWithValue("[No_Download_Week]", newShow.SkipWeek);
                    dbCmd.Parameters.AddWithValue("[Start_Date]", newShow.StartDate.ToShortDateString());
                    dbCmd.Parameters.AddWithValue("[Season_End]", newShow.SeasonEnd.ToShortDateString());
                    dbCmd.Parameters.AddWithValue("[OnHiatus]", newShow.OnHiatus);
                    dbCmd.Parameters.AddWithValue("[Cancelled]", newShow.ShowCancelled);
                    dbCmd.Parameters.AddWithValue("[Deleted]", newShow.ShowDeleted);
                    dbCmd.Parameters.AddWithValue("[MissedLastWeek]", newShow.ShowMissedLastWeek);
                    dbCmd.Parameters.AddWithValue("[MultipleShowings]", newShow.MultipleShowTimes);
					dbCmd.Parameters.AddWithValue("[SingleShowing]", newShow.SingleShowing);
					newConn.Open();
                    dbCmd.ExecuteNonQuery();
                }
                if (newConn.State == ConnectionState.Open) newConn.Close();
                if (newShow.MultipleShowTimes == true) AddMultipleShows(newShow);
                newShow.ChangesMade = true;
            }
        }

        public void AddMultipleShows(Shows newShow)
        {
            String tableName = "Shows_Multiday";
            String query = String.Format(
                          "select * from [{0}]", tableName);
            DataSet ds = new DataSet();
            OleDbConnection conn =
                  new OleDbConnection(connectionString);

            string strSql = "INSERT INTO Shows_Multiday ([ShowID], [MultiDay], [MultiTime], [MultiDownloaded], [MultiSkipWeek]) "
                + "VALUES (?, ?, ?, ?, ?)";

            using (OleDbConnection newConn = new OleDbConnection(connectionString))
            {
                for (int x = 0; x < newShow.MultiDays.Count(); x++)
                {
                    using (OleDbCommand dbCmd = new OleDbCommand(strSql, newConn))
                    {
                        dbCmd.CommandType = CommandType.Text;
                        dbCmd.Parameters.AddWithValue("[ShowID]", newShow.ID);
                        dbCmd.Parameters.AddWithValue("[MultiDay]", newShow.MultiDays[x]);
                        dbCmd.Parameters.AddWithValue("[MultiTime]", newShow.MultiTimes[x]);
                        dbCmd.Parameters.AddWithValue("[MultiDownloaded]", false);
                        dbCmd.Parameters.AddWithValue("[MultiSkipWeek]", false);
                        newConn.Open();
                        dbCmd.ExecuteNonQuery();
                    }
                }
                if (newConn.State == ConnectionState.Open)
                    newConn.Close();
            }
        }
    }
}
