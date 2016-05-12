using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Newtonsoft.Json;
using GlacialComponents.Controls;
using System.IO;

namespace Shows_Downloaded
{
	public partial class ShowsForm : Form
	{
		public List<Shows> masterlist = new List<Shows>();
		public int NextID = 0;
		public int mouseX = 0, mouseY = 0;
		public int listRowSelected = -1;
		public int sortonColumn = 2;
		public bool LoadingList = false;
		public bool FirstLoad = true;
		public int MultipleShowConstant = 10000;
        public DateTime dateMonday = DateTime.Now;
        public DateTime dateSunday = DateTime.Now;
		public string logFilePath;
		public DatabaseShows showsdb = new DatabaseShows();
		public string connectionStringBeginning = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
		public string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
		public string DatabaseConn = @"C:\Users\Shane\OneDrive\Projects\Shows.csv";
		public string TempDatabaseConn = @"C:\Users\Shane\OneDrive\Projects\TempShows.csv";

		public ShowsForm()
		{
			InitializeComponent();
			cmbDayofWeek.SelectedIndex = 0;
            while (dateMonday.DayOfWeek != DayOfWeek.Monday)
                dateMonday = dateMonday.AddDays(-1);
            while (dateSunday.DayOfWeek != DayOfWeek.Sunday)
                dateSunday = dateSunday.AddDays(1);
        }

		private void cmbDayofWeek_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(FirstLoad == false) GetShowList();
		}

		private void ShowsForm_Load(object sender, EventArgs e)
		{
			connectionString = connectionStringBeginning + @"\\FREENAS\GroupServer\Projects\Shows To Download.accdb";
            DatabaseSettings.connectionString = connectionString;
            DatabaseSettings.LoadAppSettings();
			DatabaseLogs.connectionString = connectionStringBeginning + DatabaseSettings.settings.DatabaseLocation;
			DatabaseLogs.LoadStatuses();
			WriteToLog("Starting Application");
			ribbonShowOnHiatus.Checked = DatabaseSettings.settings.ShowOnHiatus;
			ribbonShowCancelled.Checked = DatabaseSettings.settings.ShowCancelled;
			ribbonShowSkipWeek.Checked = DatabaseSettings.settings.ShowSkippedWeek;
			ribbonOnlyShowNotDownloaded.Checked = DatabaseSettings.settings.OnlyShowNotDownloaded;
			colorDownloaded.BackColor = DatabaseSettings.settings.ColorDownloaded;
			colorNotDownloaded.BackColor = DatabaseSettings.settings.ColorNotDownloaded;
			colorSkipped.BackColor = DatabaseSettings.settings.ColorSkipped;
			colorMissedWeek.BackColor = DatabaseSettings.settings.ColorMissedWeek;
			connectionString = connectionStringBeginning + DatabaseSettings.settings.DatabaseLocation;
            DatabaseSettings.connectionString = connectionString;
			showsdb.connectionString = connectionString;
			DatabaseLogs.connectionString = connectionString;
			LoadColumnHeaderSizes();
			LoadAccessDatabase();
			GetShowList();

		}

		private void btnAddShow_Click(object sender, EventArgs e)
		{
			using (AddShowForm Showfrm = new AddShowForm())
			{
				var result = Showfrm.ShowDialog(this);

				if (result == DialogResult.OK)
				{
					WriteToLog("Added show " + Showfrm.changeShow.ShowName);
					Showfrm.changeShow.ID = NextID + 1;
					masterlist.Add(Showfrm.changeShow);
                    Showfrm.changeShow.ChangesMade = true;
					SortList(sortonColumn);
					GetShowList();
				}
			}
		}

		private void listShow_ItemChangedEvent(object source, ChangedEventArgs e)
		{
			if (LoadingList == false && e.ChangedType == ChangedTypes.SubItemChanged)
			{
				int nRow = GetCursorRow();
				int listindex = (int)listShow.Items[nRow].Tag;
                bool bDownloaded = masterlist[listindex].Downloaded;
                bool bSkipWeek = masterlist[listindex].SkipWeek;
                bool bOnHiatus = masterlist[listindex].OnHiatus;
                bool bShowCancelled = masterlist[listindex].ShowCancelled;
                bool bShowMissedLastWeek = masterlist[listindex].ShowMissedLastWeek;
                string showname;
                GLItem item;
                listShow.Items.ClearSelection();

				item = listShow.Items[nRow];
				if (masterlist[listindex].ShowMissedLastWeek == true && (masterlist[listindex].Downloaded == false && item.SubItems[3].Checked)) masterlist[listindex].ShowMissedLastWeek = false;
				masterlist[listindex].Downloaded = item.SubItems[3].Checked;
				masterlist[listindex].SkipWeek = item.SubItems[5].Checked;
				masterlist[listindex].OnHiatus = item.SubItems[8].Checked;
				masterlist[listindex].ShowCancelled = item.SubItems[9].Checked;
                masterlist[listindex].ChangesMade = true;
				if(masterlist[listindex].ID >= MultipleShowConstant)
				{
					foreach(Shows x in masterlist)
					{
						showname = masterlist[listindex].ShowName;
						if(showname.Equals(x.ShowName) && x.DoNotSave == false)
							x.ChangesMade = true;
					}
				}
                if (bDownloaded != masterlist[listindex].Downloaded)
                {
                    if (bDownloaded) WriteToLog(masterlist[listindex].ShowName + " changed to not downloaded");
                    else WriteToLog(masterlist[listindex].ShowName + " changed to downloaded");
                }
                if (bSkipWeek != masterlist[listindex].SkipWeek)
                {
                    if (bSkipWeek) WriteToLog(masterlist[listindex].ShowName + " changed to not being skipped this week");
                    else WriteToLog(masterlist[listindex].ShowName + " changed to being skipped this week");
                }
                if (bOnHiatus != masterlist[listindex].OnHiatus)
                {
                    if (bOnHiatus) WriteToLog(masterlist[listindex].ShowName + " changed to not being on hiatus");
                    else WriteToLog(masterlist[listindex].ShowName + " changed to being on hiatus");
                }
                if (bShowCancelled != masterlist[listindex].ShowCancelled)
                {
                    if (bShowCancelled) WriteToLog(masterlist[listindex].ShowName + " changed to not being cancelled");
                    else WriteToLog(masterlist[listindex].ShowName + " changed to being cancelled");
                }
                if (bShowMissedLastWeek != masterlist[listindex].ShowMissedLastWeek)
                {
                    if (bShowMissedLastWeek) WriteToLog(masterlist[listindex].ShowName + " changed to not being missed last week");
                    else WriteToLog(masterlist[listindex].ShowName + " changed to being missed this week");
                }
                if (masterlist[listindex].Downloaded == true) item.BackColor = DatabaseSettings.settings.ColorDownloaded;
				else if (masterlist[listindex].SkipWeek == true) item.BackColor = DatabaseSettings.settings.ColorSkipped;
				else item.BackColor = DatabaseSettings.settings.ColorNotDownloaded;
			}
		}

		public void GetShowList()
		{
			string[] DoW = new string[] { " ", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
			GLItem item;
			int ComboIndex = cmbDayofWeek.SelectedIndex;

			LoadingList = true;
			listShow.Items.Clear();
			listShow.Refresh();
			//            showslist.Clear();
//			Console.WriteLine("GetShowList");
			for (int x = 0; x < masterlist.Count; x++)
			{
				if (DatabaseSettings.settings.ShowCancelled == false && masterlist[x].ShowCancelled == true)
					continue;
                if (DatabaseSettings.settings.ShowOnHiatus == false && masterlist[x].OnHiatus == true)
                    continue;
				if (DatabaseSettings.settings.ShowSkippedWeek == false && masterlist[x].SkipWeek == true)
					continue;
				if (masterlist[x].ShowDeleted == true)	continue;
                if (masterlist[x].MultipleShowTimes == true) continue;
                if (DatabaseSettings.settings.OnlyShowNotDownloaded == true && masterlist[x].Downloaded == true)
                    continue;
				if (FirstLoad)
				{
//					Console.WriteLine("First load");
					ComboIndex = (int)System.Globalization.CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(DateTime.Now);
					if (ComboIndex == 0) ComboIndex = 7;
					cmbDayofWeek.SelectedIndex = ComboIndex;
					FirstLoad = false;
				}
				ComboIndex = cmbDayofWeek.SelectedIndex;
				if (cmbDayofWeek.SelectedIndex == 0 || cmbDayofWeek.Items[ComboIndex].Equals(masterlist[x].ShowDay))
				{
					item = listShow.Items.Add(Convert.ToString(masterlist[x].ID));
					item.Tag = x;
					item.SubItems[1].Text = masterlist[x].ShowName;
					item.SubItems[2].Text = masterlist[x].ShowDay;
					item.SubItems[3].Checked = masterlist[x].Downloaded;
					item.SubItems[4].Text = masterlist[x].ShowTime;
					item.SubItems[5].Checked = masterlist[x].SkipWeek;
					item.SubItems[6].Text = masterlist[x].StartDate.ToString("MM'/'dd'/'yyyy");
					item.SubItems[7].Text = masterlist[x].SeasonEnd.ToString("MM'/'dd'/'yyyy");
					item.SubItems[8].Checked = masterlist[x].OnHiatus;
					item.SubItems[9].Checked = masterlist[x].ShowCancelled;
					if (masterlist[x].Downloaded == true) item.BackColor = DatabaseSettings.settings.ColorDownloaded;
					else if (masterlist[x].SkipWeek == true) item.BackColor = DatabaseSettings.settings.ColorSkipped;
					else if (masterlist[x].ShowMissedLastWeek == true) item.BackColor = DatabaseSettings.settings.ColorMissedWeek;
					else item.BackColor = DatabaseSettings.settings.ColorNotDownloaded;
				}
			}
			LoadingList = false;
		}

		public Shows GetRowInformation(int nRow)
		{
			return masterlist[(int)listShow.Items[nRow].Tag];
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveAccessDatabase();
		}

		private void ShowsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveColumnHeaderSizes();
			DatabaseSettings.SaveAppSettings();
			SaveAccessDatabase();

			WriteToLog("Closing Application");
		}

		private void listmenuAddNew_Click(object sender, EventArgs e)
		{
			using (AddShowForm Showfrm = new AddShowForm())
			{
				var result = Showfrm.ShowDialog(this);

				if (result == DialogResult.OK)
				{
					NextID += 1;
					Showfrm.changeShow.ID = NextID;
					WriteToLog("Adding show " + Showfrm.changeShow.ShowName);
					showsdb.AddShowToDatabase(Showfrm.changeShow);
					LoadAccessDatabase();
					GetShowList();
				}
			}

		}

		private void listmenuModify_Click(object sender, EventArgs e)
		{
			int listIndex = (int)listShow.Items[listRowSelected].Tag;
			Shows modifiedShow = new Shows();

			using (AddShowForm Showfrm = new AddShowForm())
			{
				Showfrm.FillDialog(GetRowInformation(listRowSelected));
				var result = Showfrm.ShowDialog(this);

				if (result == DialogResult.OK)
				{
					WriteToLog("Modified show " + Showfrm.changeShow.ShowName);
					masterlist[listIndex].ShowName = Showfrm.changeShow.ShowName;
					masterlist[listIndex].ShowDay = Showfrm.changeShow.ShowDay;
					masterlist[listIndex].DayIndex = GetDayofWeekFromName(masterlist[listIndex].ShowDay);
					masterlist[listIndex].ShowTime = Showfrm.changeShow.ShowTime;
					masterlist[listIndex].TimeIndex = GetTimeFromName(masterlist[listIndex].ShowTime);
					masterlist[listIndex].StartDate = Showfrm.changeShow.StartDate;
					masterlist[listIndex].SeasonEnd = Showfrm.changeShow.SeasonEnd;
					masterlist[listIndex].OnHiatus = Showfrm.changeShow.OnHiatus;
					masterlist[listIndex].SingleShowing = Showfrm.changeShow.SingleShowing;
                    masterlist[listIndex].ChangesMade = true;
					GetShowList();
				}
			}
		}

		private void listmenuDelete_Click(object sender, EventArgs e)
		{
			if (listRowSelected != -1)
			{
				int listIndex = (int)listShow.Items[listRowSelected].Tag;
				string messagestr = "Are you sure you want to delete " + masterlist[listIndex].ShowName + "?";
				if (MessageBox.Show(messagestr, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					WriteToLog("Deleted show " + masterlist[listIndex].ShowName);
					masterlist[listIndex].ShowDeleted = true;
                    masterlist[listIndex].ChangesMade = true;
					GetShowList();
				}
			}
		}

		private void listmenuClearMissedWeek_Click(object sender, EventArgs e)
		{
			if(listRowSelected != -1)
			{
				int listIndex = (int)listShow.Items[listRowSelected].Tag;
                WriteToLog("Cleared missed flag for " + masterlist[listIndex].ShowName);
                masterlist[listIndex].ShowMissedLastWeek = false;
                masterlist[listIndex].ChangesMade = true;
				GetShowList();

				var menuitems = listmenu.Items.Find("listmenuClearMissedWeek", true);
				foreach (var mitem in menuitems)
					mitem.Enabled = false;
			}
		}

		private void listShow_MouseDown(object sender, MouseEventArgs e)
		{
			int nColumn = 0, nCellX = 0, nCellY = 0;
			ListStates eState;
			GLListRegion listRegion;

			int previousRowSelected = listRowSelected;
			listShow.InterpretCoords(e.X, e.Y, out listRegion, out nCellX, out nCellY, out listRowSelected, out nColumn, out eState);

			SelectRow(previousRowSelected, listRowSelected);
		}

		public void LoadColumnHeaderSizes()
		{
			char[] delimiterChars = { ' ', ';' };
			string sizes = DatabaseSettings.settings.ListColumnSizes;

			string[] words = sizes.Split(delimiterChars);

			for(int i = 0; i < words.Length; i++)
			{
				listShow.Columns[i].Width = Convert.ToInt32(words[i]);
			}
		}

		public void SaveColumnHeaderSizes()
		{
			string temp = "";

			for(int i = 0; i < listShow.Columns.Count; i++)
			{
				if (i != 0)
					temp += ";" + listShow.Columns[i].Width.ToString();
				else
					temp += listShow.Columns[i].Width.ToString();
			}
            DatabaseSettings.settings.ListColumnSizes = temp;
//			Properties.Settings.Default.Save();
		}

		private void ribbonShowCancelled_CheckBoxCheckChanged(object sender, EventArgs e)
		{
            DatabaseSettings.settings.ShowCancelled = ribbonShowCancelled.Checked;

			GetShowList();
		}

		private void ribbonShowOnHiatus_CheckBoxCheckChanged(object sender, EventArgs e)
		{
            DatabaseSettings.settings.ShowOnHiatus = ribbonShowOnHiatus.Checked;

			GetShowList();
		}

		private void ribbonClearChecks_Click(object sender, EventArgs e)
		{
            DateTime MondayPrior = dateMonday.AddDays(-7);
            DateTime SundayPrior = dateSunday.AddDays(-7);
            foreach (Shows temp in masterlist)
			{
                if (temp.Downloaded == false && temp.SkipWeek == false && !temp.ShowCancelled && !temp.OnHiatus && !temp.ShowDeleted && !temp.MultipleShowTimes)
                { temp.ShowMissedLastWeek = true; temp.ChangesMade = true; }
                if (temp.Downloaded == true) { temp.Downloaded = false; temp.ChangesMade = true; }
                if (temp.SkipWeek == true) { temp.SkipWeek = false; temp.ChangesMade = true; }
				if(temp.OnHiatus == true && temp.StartDate >= dateMonday && temp.StartDate <= dateSunday)
				{
					temp.OnHiatus = false;
					WriteToLog("Bringing " + temp.ShowName + " out of hiatus");
				}
                if (temp.OnHiatus == false && temp.SingleShowing == false && temp.SeasonEnd >= MondayPrior && temp.SeasonEnd <= SundayPrior)
                {
                    temp.OnHiatus = true;
                    WriteToLog("Putting " + temp.ShowName + " into hiatus");
                }
				if(temp.SingleShowing==true && temp.Downloaded == true && temp.SeasonEnd>=MondayPrior && temp.SeasonEnd<=SundayPrior)
				{
					temp.ShowDeleted = true;
					WriteToLog("Removing " + temp.ShowName + " since it was downloaded");
				}
			}
			WriteToLog("Cleared checks for all shows");
			GetShowList();
		}

		private void ribbonShowSkipWeek_CheckBoxCheckChanged(object sender, EventArgs e)
		{
            DatabaseSettings.settings.ShowSkippedWeek = ribbonShowSkipWeek.Checked;

			GetShowList();
		}

        private void ribbonOnlyShowNotDownloaded_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            DatabaseSettings.settings.OnlyShowNotDownloaded = ribbonOnlyShowNotDownloaded.Checked;

            GetShowList();
        }

		private void ribbonAbout_Click (object sender, EventArgs e)
		{
			AboutBox ab = new AboutBox();

			ab.ShowDialog(this);
		}

		private void ribbonSettings_Click (object sender, EventArgs e)
		{
			Settings settingsfrm = new Settings();

			if(settingsfrm.ShowDialog(this) == DialogResult.OK)
			{
				connectionString = connectionStringBeginning + settingsfrm.strDatabasePath;
                DatabaseSettings.connectionString = connectionString;
                showsdb.connectionString = connectionString;
                DatabaseLogs.connectionString = connectionString;
				Console.WriteLine(connectionString);
				DatabaseSettings.SaveAppSettings();
				LoadAccessDatabase();
				GetShowList();
			}
		}

        private void ribbonShowLog_Click(object sender, EventArgs e)
        {
            LogForm logfrm = new LogForm();

            logfrm.ShowDialog(this);
        }

        private void colorDownloaded_Click(object sender, EventArgs e)
		{
			downloadedColorPicker.Color = colorDownloaded.BackColor;
			if (downloadedColorPicker.ShowDialog() == DialogResult.OK)
			{
				colorDownloaded.BackColor = downloadedColorPicker.Color;
				DatabaseSettings.settings.ColorDownloaded = downloadedColorPicker.Color;
//				Properties.Settings.Default.Save();
			}
		}

		private void colorSkipped_Click(object sender, EventArgs e)
		{
			skippedColorPicker.Color = colorSkipped.BackColor;
			if (skippedColorPicker.ShowDialog() == DialogResult.OK)
			{
				colorSkipped.BackColor = skippedColorPicker.Color;
                DatabaseSettings.settings.ColorSkipped = skippedColorPicker.Color;
//				Properties.Settings.Default.Save();
			}
		}

		private void colorNotDownloaded_Click(object sender, EventArgs e)
		{
			notdownloadColorPicker.Color = colorNotDownloaded.BackColor;
			if (notdownloadColorPicker.ShowDialog() == DialogResult.OK)
			{
				colorNotDownloaded.BackColor = notdownloadColorPicker.Color;
                DatabaseSettings.settings.ColorNotDownloaded = notdownloadColorPicker.Color;
//				Properties.Settings.Default.Save();
			}
		}

		private void colorMissedWeek_Click(object sender, EventArgs e)
		{
			missedweekColorPicker.Color = colorMissedWeek.BackColor;
			if (missedweekColorPicker.ShowDialog() == DialogResult.OK)
			{
				colorMissedWeek.BackColor = missedweekColorPicker.Color;
                DatabaseSettings.settings.ColorNotDownloaded = missedweekColorPicker.Color;
//				Properties.Settings.Default.Save();
			}
		}

		public int GetCursorRow()
		{
			int nRow = 0, nColumn = 0, nCellX = 0, nCellY = 0;
			ListStates eState;
			GLListRegion listRegion;
			listShow.InterpretCoords(mouseX, mouseY, out listRegion, out nCellX, out nCellY, out nRow, out nColumn, out eState);
			Console.WriteLine("MouseX {0}, MouseY {1}, nRow {2}", mouseX, mouseY, nRow);
			return nRow;
		}

		private void listselectiontimer_Tick(object sender, EventArgs e)
		{
			if (listShow.SelectedItems.Count > 0)
				listShow.Items.ClearSelection();
		}

		private void listShow_ColumnClickedEvent(object source, ClickEventArgs e)
		{
			if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2)
			{
				sortonColumn = e.ColumnIndex;
				SortList(sortonColumn);
			}
		}

		private void listShow_MouseMove(object sender, MouseEventArgs e)
		{
			mouseX = e.X;
			mouseY = e.Y;
			
		}

		public void SortList(int nColumn, bool reloadlist = true)
		{
			switch (sortonColumn)
			{
				case 0:
					masterlist = masterlist
						.OrderBy(x => x.ID)
						.ToList();
					if (reloadlist) GetShowList();
					break;
				case 1:
					masterlist = masterlist
						.OrderBy(x => x.ShowName)
						.ToList();
					if (reloadlist) GetShowList();
					break;
				case 2:
					masterlist = masterlist
						.OrderBy(x => x.DayIndex)
						.ThenBy(x => x.TimeIndex)
						.ThenBy(x => x.ShowName)
						.ToList();
					if (reloadlist) GetShowList();
					break;
			}
		}

		private void listShow_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				GLListRegion reg;
				int cellX, cellY;
				int item;
				int col;
				ListStates ls;
				// interpret the x & y coordinates of the event.
				listShow.InterpretCoords( e.X, e.Y, out reg, out cellX, out cellY, out item, out col, out ls);
				// check to see where the right click took place
				if (reg == GLListRegion.client)
				{
					// the user right clicked somewhere in the body of the list
					// select the item in question
					// activate the selected row (indicated by item)
					listShow.FocusedItem = listShow.Items[item];
					listShow.Items[item].Selected = true;

					if (masterlist[(int)listShow.Items[item].Tag].ShowMissedLastWeek == true)
					{
						Console.WriteLine("{0} missed last week", listShow.Items[item].SubItems[1].Text);
						var menuitems = listmenu.Items.Find("listmenuClearMissedWeek", true);
						foreach (var mitem in menuitems)
							mitem.Enabled = true;
					}
					// display the context menu
					listmenu.Show(listShow.PointToScreen(new Point(e.X, e.Y)));
				}
			}
		}

		public void SelectRow(int nOldIndex, int nNewIndex)
		{
			if (nOldIndex == nNewIndex) return;

			GLItem item = new GLItem();
			GLItem newitem = new GLItem();

			if (nOldIndex != -1 && nOldIndex < listShow.Count) item = listShow.Items[nOldIndex];
			else item = listShow.Items[0];
			newitem = listShow.Items[nNewIndex];

			if (item.SubItems[3].Checked)
			{
				item.SubItems[0].BackColor = DatabaseSettings.settings.ColorDownloaded;
				item.SubItems[0].ForeColor = Color.Black;
			}
			else if (item.SubItems[5].Checked)
			{
				item.SubItems[0].BackColor = DatabaseSettings.settings.ColorSkipped;
				item.SubItems[0].ForeColor = Color.Black;
			}
			else
			{
				if (masterlist[(int)item.Tag].ShowMissedLastWeek == true)
				{
					item.SubItems[0].BackColor = DatabaseSettings.settings.ColorMissedWeek;
					item.SubItems[0].ForeColor = Color.Black;
				}
				else
				{
					item.SubItems[0].BackColor = DatabaseSettings.settings.ColorNotDownloaded;
					item.SubItems[0].ForeColor = Color.Black;
				}
			}
			newitem.SubItems[0].BackColor = Color.Blue;
			newitem.SubItems[0].ForeColor = Color.White;
		}

		public void LoadAccessDatabase()
		{
			showsdb.LoadDatabase(ref masterlist, out NextID);
			SortList(sortonColumn, false);
		}

		public void SaveAccessDatabase()
		{
            showsdb.SaveDatabase(ref masterlist);
		}

		public int GetDayofWeekFromName(string DayName)
		{
			string[] DoW = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
			int[] DoWnum = new int[] { 1, 2, 3, 4, 5, 6, 7 };

			for (int x = 0; x < DoW.Length; x++)
				if (DoW[x].Equals(DayName)) return DoWnum[x];

			return -1;
		}

		public double GetTimeFromName(string TimeName)
		{
			string[] timeText = new string[] { "7:00", "7:30", "8:00", "8:30", "9:00", "9:30", "10:00" };
			double[] timeNum = new double[] { 7, 7.5, 8, 8.5, 9, 9.5, 10 };

			for (int x = 0; x < timeText.Length; x++)
				if (timeText[x].Equals(TimeName)) return timeNum[x];

			return 0;
		}

        public void WriteToLog (string LineToWrite)
		{
			DateTime dt = DateTime.Now;
			DatabaseLogs.WriteToLog(dt, LineToWrite);
		}
	}
}
