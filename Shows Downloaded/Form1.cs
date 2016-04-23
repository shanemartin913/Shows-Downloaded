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
using GlacialComponents.Controls;
using System.IO;
using LumenWorks.Framework.IO.Csv;

namespace Shows_Downloaded
{
    public partial class ShowsForm : Form
    {
//        public List<Shows> showslist = new List<Shows>();
        public List<Shows> masterlist = new List<Shows>();
        public int NextID = 0;
        public int mouseX = 0, mouseY = 0;
        public int listRowSelected = -1;
        public int sortonColumn = 2;
        public bool LoadingList = false;
        public bool FirstLoad = true;
        public string connectionString =
             @"Provider=Microsoft.ACE.OLEDB.12.0;Data"
           + @" Source=C:\Users\Shane\OneDrive\Projects\Shows To Download.accdb";
        public string DatabaseConn = "C:\\Users\\Shane\\OneDrive\\Projects\\Shows.csv";
        public string TempDatabaseConn = "C:\\Users\\Shane\\OneDrive\\Projects\\TempShows.csv";

        public ShowsForm()
        {
            InitializeComponent();
            cmbDayofWeek.SelectedIndex = 0;
        }

        private void cmbDayofWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetShowList();

        }

        private void ShowsForm_Load(object sender, EventArgs e)
        {
            ribbonShowOnHiatus.Checked = Properties.Settings.Default.ShowOnHiatus;
            ribbonShowCancelled.Checked = Properties.Settings.Default.ShowCancelled;
            ribbonShowSkipWeek.Checked = Properties.Settings.Default.ShowSkippedWeek;
            colorDownloaded.BackColor = Properties.Settings.Default.ColorDownloaded;
            colorNotDownloaded.BackColor = Properties.Settings.Default.ColorNotDownloaded;
            colorSkipped.BackColor = Properties.Settings.Default.ColorSkipped;
            colorMissedWeek.BackColor = Properties.Settings.Default.ColorMissedWeek;
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
                    Showfrm.changeShow.ID = NextID + 1;
                    masterlist.Add(Showfrm.changeShow);
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
                listShow.Items.ClearSelection();

                Console.WriteLine("Subitem changed at row {0} masterlist {1}", nRow, listindex);
                GLItem item;

                item = listShow.Items[nRow];
                if (masterlist[listindex].ShowMissedLastWeek == true && (masterlist[listindex].Downloaded == false && item.SubItems[3].Checked)) masterlist[listindex].ShowMissedLastWeek = false;
                masterlist[listindex].Downloaded = item.SubItems[3].Checked;
                masterlist[listindex].SkipWeek = item.SubItems[5].Checked;
                masterlist[listindex].OnHiatus = item.SubItems[8].Checked;
                masterlist[listindex].ShowCancelled = item.SubItems[9].Checked;
                if (masterlist[listindex].Downloaded == true) item.BackColor = Properties.Settings.Default.ColorDownloaded;
                else if (masterlist[listindex].SkipWeek == true) item.BackColor = Properties.Settings.Default.ColorSkipped;
                else item.BackColor = Properties.Settings.Default.ColorNotDownloaded;
            }
        }

        public void GetShowList()
        {
            string[] DoW = new string[] { " ", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            GLItem item;

            LoadingList = true;
            listShow.Items.Clear();
            listShow.Refresh();
//            showslist.Clear();
            for(int x = 0; x < masterlist.Count; x++)
            {
                if (Properties.Settings.Default.ShowCancelled == false && masterlist[x].ShowCancelled == true)
                    continue;
                if (Properties.Settings.Default.ShowOnHiatus == false && masterlist[x].OnHiatus == true)
                    continue;
                if (Properties.Settings.Default.ShowSkippedWeek == false && masterlist[x].SkipWeek == true)
                    continue;
                if (masterlist[x].ShowDeleted == true)
                    continue;
                if(FirstLoad)
                {
                    int dayofweek = (int)System.Globalization.CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(DateTime.Now);
                    cmbDayofWeek.SelectedIndex = dayofweek;
                    FirstLoad = false;
                }
                if (cmbDayofWeek.SelectedIndex == 0 || cmbDayofWeek.Text.Equals(masterlist[x].ShowDay))
                {
                    item = listShow.Items.Add(Convert.ToString(masterlist[x].ID));
                    item.Tag = x;
                    item.SubItems[1].Text = masterlist[x].ShowName;

                    ComboBox cb = new ComboBox();
                    for (int i = 1; i < DoW.Length; i++) cb.Items.Add((string)DoW[i]);
                    cb.SelectedIndex = masterlist[x].DayIndex - 1;
                    item.SubItems[2].Control = cb;
//                    item.SubItems[2].Text = DoW[masterlist[x].ShowDay];
                    item.SubItems[3].Checked = masterlist[x].Downloaded;
                    item.SubItems[4].Text = masterlist[x].ShowTime;
                    item.SubItems[5].Checked = masterlist[x].SkipWeek;
                    item.SubItems[6].Text = masterlist[x].StartDate.ToString("MM'/'dd'/'yyyy");
                    item.SubItems[7].Text = masterlist[x].SeasonEnd.ToString("MM'/'dd'/'yyyy");
                    item.SubItems[8].Checked = masterlist[x].OnHiatus;
                    item.SubItems[9].Checked = masterlist[x].ShowCancelled;
                    if (masterlist[x].Downloaded == true) item.BackColor = Properties.Settings.Default.ColorDownloaded;
                    else if (masterlist[x].SkipWeek == true) item.BackColor = Properties.Settings.Default.ColorSkipped;
                    else if (masterlist[x].ShowMissedLastWeek == true) item.BackColor = Properties.Settings.Default.ColorMissedWeek;
                    else item.BackColor = Properties.Settings.Default.ColorNotDownloaded;
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
            Properties.Settings.Default.ShowOnHiatus = ribbonShowOnHiatus.Checked;
            Properties.Settings.Default.ShowCancelled = ribbonShowCancelled.Checked;
            Properties.Settings.Default.ShowSkippedWeek = ribbonShowSkipWeek.Checked;
            Properties.Settings.Default.ColorDownloaded = colorDownloaded.BackColor;
            Properties.Settings.Default.ColorSkipped = colorSkipped.BackColor;
            Properties.Settings.Default.ColorNotDownloaded = colorNotDownloaded.BackColor;
            Properties.Settings.Default.ColorMissedWeek = colorMissedWeek.BackColor;
            Properties.Settings.Default.Save();
            SaveColumnHeaderSizes();

            SaveAccessDatabase();
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
                    AddShowToDatabase(Showfrm.changeShow);
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
                    masterlist[listIndex].ShowName = Showfrm.changeShow.ShowName;
                    masterlist[listIndex].ShowDay = Showfrm.changeShow.ShowDay;
                    masterlist[listIndex].DayIndex = GetDayofWeekFromName(masterlist[listIndex].ShowDay);
                    masterlist[listIndex].ShowTime = Showfrm.changeShow.ShowTime;
                    masterlist[listIndex].TimeIndex = GetTimeFromName(masterlist[listIndex].ShowTime);
                    masterlist[listIndex].StartDate = Showfrm.changeShow.StartDate;
                    masterlist[listIndex].SeasonEnd = Showfrm.changeShow.SeasonEnd;
                    masterlist[listIndex].OnHiatus = Showfrm.changeShow.OnHiatus;
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
                    masterlist[listIndex].ShowDeleted = true;
                    GetShowList();
                }
            }
        }

        private void listmenuClearMissedWeek_Click(object sender, EventArgs e)
        {
            if(listRowSelected != -1)
            {
                int listIndex = (int)listShow.Items[listRowSelected].Tag;
                masterlist[listIndex].ShowMissedLastWeek = false;
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
            string sizes = Properties.Settings.Default.ListColumnSizes;

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
            Properties.Settings.Default.ListColumnSizes = temp;
            Properties.Settings.Default.Save();
        }

        private void ribbonShowCancelled_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowCancelled = ribbonShowCancelled.Checked;

            GetShowList();
        }

        private void ribbonShowOnHiatus_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowOnHiatus = ribbonShowOnHiatus.Checked;

            GetShowList();
        }

        private void ribbonClearChecks_Click(object sender, EventArgs e)
        {
            foreach(Shows temp in masterlist)
            {
                if (temp.Downloaded == false && temp.SkipWeek == false && !temp.ShowCancelled && !temp.OnHiatus && !temp.ShowDeleted)
                    temp.ShowMissedLastWeek = true;
                temp.Downloaded = false;
                temp.SkipWeek = false;
            }
            GetShowList();
        }

        private void ribbonShowSkipWeek_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowSkippedWeek = ribbonShowSkipWeek.Checked;

            GetShowList();
        }

        private void colorDownloaded_Click(object sender, EventArgs e)
        {
            downloadedColorPicker.Color = colorDownloaded.BackColor;
            if (downloadedColorPicker.ShowDialog() == DialogResult.OK)
            {
                colorDownloaded.BackColor = downloadedColorPicker.Color;
                Properties.Settings.Default.ColorDownloaded = downloadedColorPicker.Color;
                Properties.Settings.Default.Save();
            }
        }

        private void colorSkipped_Click(object sender, EventArgs e)
        {
            skippedColorPicker.Color = colorSkipped.BackColor;
            if (skippedColorPicker.ShowDialog() == DialogResult.OK)
            {
                colorSkipped.BackColor = skippedColorPicker.Color;
                Properties.Settings.Default.ColorSkipped = skippedColorPicker.Color;
                Properties.Settings.Default.Save();
            }
        }

        private void colorNotDownloaded_Click(object sender, EventArgs e)
        {
            notdownloadColorPicker.Color = colorNotDownloaded.BackColor;
            if (notdownloadColorPicker.ShowDialog() == DialogResult.OK)
            {
                colorNotDownloaded.BackColor = notdownloadColorPicker.Color;
                Properties.Settings.Default.ColorNotDownloaded = notdownloadColorPicker.Color;
                Properties.Settings.Default.Save();
            }
        }

        private void colorMissedWeek_Click(object sender, EventArgs e)
        {
            missedweekColorPicker.Color = colorMissedWeek.BackColor;
            if (missedweekColorPicker.ShowDialog() == DialogResult.OK)
            {
                colorMissedWeek.BackColor = missedweekColorPicker.Color;
                Properties.Settings.Default.ColorNotDownloaded = missedweekColorPicker.Color;
                Properties.Settings.Default.Save();
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

            if (nOldIndex != -1) item = listShow.Items[nOldIndex];
            else item = listShow.Items[0];
            newitem = listShow.Items[nNewIndex];

            if (item.SubItems[3].Checked)
            {
                item.SubItems[0].BackColor = Properties.Settings.Default.ColorDownloaded;
                item.SubItems[0].ForeColor = Color.Black;
            }
            else if (item.SubItems[5].Checked)
            {
                item.SubItems[0].BackColor = Properties.Settings.Default.ColorSkipped;
                item.SubItems[0].ForeColor = Color.Black;
            }
            else
            {
                if (masterlist[(int)item.Tag].ShowMissedLastWeek == true)
                {
                    item.SubItems[0].BackColor = Properties.Settings.Default.ColorMissedWeek;
                    item.SubItems[0].ForeColor = Color.Black;
                }
                else
                {
                    item.SubItems[0].BackColor = Properties.Settings.Default.ColorNotDownloaded;
                    item.SubItems[0].ForeColor = Color.Black;
                }
            }
            newitem.SubItems[0].BackColor = Color.Blue;
            newitem.SubItems[0].ForeColor = Color.White;
        }

        public void LoadAccessDatabase()
        {
            String tableName = "Shows";
            String query = "select * from Shows";
            string tempShowname;
            int tempShowID;
            DataSet ds = new DataSet();
            OleDbConnection conn = new OleDbConnection(connectionString);

            masterlist.Clear();
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
                    if(Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["MultipleShowings"]) == true)
                    {
                        tempShowname = ds.Tables["Shows"].Rows[i]["Show_Name"].ToString();
                        tempShowID = Convert.ToInt32(ds.Tables["Shows"].Rows[i]["ID"]);
                        AddMultipleShows(tempShowname, tempShowID);
                        foreach(Shows x in masterlist)
                        {
                            if(x.ID == tempShowID)
                            {
                                x.StartDate = Convert.ToDateTime(ds.Tables["Shows"].Rows[i]["Start_Date"]);
                                x.SeasonEnd = Convert.ToDateTime(ds.Tables["Shows"].Rows[i]["Season_End"]);
                                x.OnHiatus = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["OnHiatus"]);
                                x.ShowCancelled = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["Cancelled"]);
                                x.ShowDeleted = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["Deleted"]);
                                x.ShowMissedLastWeek = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["MissedLastWeek"]);
                                x.MultipleShowTimes = Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["MultipleShowings"]);
                            }
                        }
                    }
                    Shows tempShow = new Shows();

                    tempShow.ID = Convert.ToInt32(ds.Tables["Shows"].Rows[i]["ID"]);
                    if (tempShow.ID > NextID) NextID = tempShow.ID;
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
                    tempShow.DatabaseRow = i;
                    masterlist.Add(tempShow);
                }
                SortList(sortonColumn);
            }
            catch (OleDbException exp)
            {
                MessageBox.Show("Database Error:" + exp.Message.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void AddMultipleShows(string ShowName, int ShowID)
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
                for (int i = 0; i < ds.Tables["Shows_Multiday"].Rows.Count; i++)
                {
                    Shows tempShow = new Shows();

                    tempShow.ID = ShowID;
                    tempShow.ShowName = ShowName;
                    tempShow.ShowDay = ds.Tables["Shows_Multiday"].Rows[i]["MultiDay"].ToString();
                    tempShow.DayIndex = GetDayofWeekFromName(tempShow.ShowDay);
                    tempShow.Downloaded = Convert.ToBoolean(ds.Tables["Shows_Multiday"].Rows[i]["MultiDownloaded"]);
                    tempShow.ShowTime = ds.Tables["Shows_Multiday"].Rows[i]["MultiTime"].ToString();
                    tempShow.TimeIndex = GetTimeFromName(tempShow.ShowTime);
                    tempShow.SkipWeek = Convert.ToBoolean(ds.Tables["Shows_Multiday"].Rows[i]["MultiSkipWeek"]);
                    tempShow.MultipleShowID = Convert.ToInt32(ds.Tables["Shows_Multiday"].Rows[i]["ID"]);
                    masterlist.Add(tempShow);
                }
            }
            catch (OleDbException exp)
            {
                MessageBox.Show("Database Error:" + exp.Message.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void SaveAccessDatabase()
        {
            String tableName = "Shows";
            String query = String.Format(
                          "select * from [{0}]", tableName);
            Shows tempShow = new Shows();
            bool bUpdate = false;
            DataSet ds = new DataSet();
            OleDbConnection conn =
                  new OleDbConnection(connectionString);

            try
            {
                //Open Database Connection
                conn.Open();
                OleDbDataAdapter da =
                       new OleDbDataAdapter(query, conn);
                OleDbCommandBuilder cmdB =
                       new OleDbCommandBuilder(da);
                da.MissingSchemaAction =
                       MissingSchemaAction.AddWithKey;

                //Fill the DataSet
                da.Fill(ds, tableName);

                for (int i = 0; i < ds.Tables["Shows"].Rows.Count; i++)
                {
                    tempShow = masterlist.Find(x => x.ID == Convert.ToInt32(ds.Tables["Shows"].Rows[i]["ID"]));
                    if (tempShow != null)
                    {
                        if (!tempShow.ShowName.Equals(ds.Tables["Shows"].Rows[i]["Show_Name"].ToString()))
                        {
                            ds.Tables["Shows"].Rows[i]["Show_Name"] = tempShow.ShowName;
                            bUpdate = true;
                        }
                        if (tempShow.ShowDay.Equals(ds.Tables["Shows"].Rows[i]["DayText"]))
                        {
                            ds.Tables["Shows"].Rows[i]["DayText"] = tempShow.ShowDay;
                            bUpdate = true;
                        }
                        if (tempShow.Downloaded != Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["Downloaded"]))
                        {
                            ds.Tables["Shows"].Rows[i]["Downloaded"] = tempShow.Downloaded;
                            bUpdate = true;
                        }
                        if (tempShow.ShowTime.Equals(ds.Tables["Shows"].Rows[i]["TimeText"]))
                        {
                            ds.Tables["Shows"].Rows[i]["TimeText"] = tempShow.ShowTime;
                            bUpdate = true;
                        }
                        if (tempShow.SkipWeek != Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["No_Download_Week"]))
                        {
                            ds.Tables["Shows"].Rows[i]["No_Download_Week"] = tempShow.SkipWeek;
                            bUpdate = true;
                        }
                        if (tempShow.StartDate != Convert.ToDateTime(ds.Tables["Shows"].Rows[i]["Start_Date"]))
                        {
                            ds.Tables["Shows"].Rows[i]["Start_Date"] = tempShow.StartDate.ToShortDateString();
                            bUpdate = true;
                        }
                        if (tempShow.SeasonEnd != Convert.ToDateTime(ds.Tables["Shows"].Rows[i]["Season_End"]))
                        {
                            ds.Tables["Shows"].Rows[i]["Season_End"] = tempShow.SeasonEnd.ToShortDateString();
                            bUpdate = true;
                        }
                        if (tempShow.OnHiatus != Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["OnHiatus"]))
                        {
                            ds.Tables["Shows"].Rows[i]["OnHiatus"] = tempShow.OnHiatus;
                            bUpdate = true;
                        }
                        if (tempShow.ShowCancelled != Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["Cancelled"]))
                        {
                            ds.Tables["Shows"].Rows[i]["Cancelled"] = tempShow.ShowCancelled;
                            bUpdate = true;
                        }
                        if (tempShow.ShowDeleted != Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["Deleted"]))
                        {
                            ds.Tables["Shows"].Rows[i]["Deleted"] = tempShow.ShowDeleted;
                            bUpdate = true;
                        }
                        if(tempShow.ShowMissedLastWeek != Convert.ToBoolean(ds.Tables["Shows"].Rows[i]["MissedLastWeek"]))
                        {
                            ds.Tables["Shows"].Rows[i]["MissedLastWeek"] = tempShow.ShowMissedLastWeek;
                            bUpdate = true;
                        }
                        if (bUpdate)
                        {
                            da.Update(ds, "Shows");
                            Console.WriteLine("Updating {0}", tempShow.ShowName);
                            bUpdate = false;
                        }
                    }
                }
            }
            catch (OleDbException exp)
            {
                MessageBox.Show("Database Error:" + exp.Message.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void AddShowToDatabase(Shows newShow)
        {
            String tableName = "Shows";
            String query = String.Format(
                          "select * from [{0}]", tableName);
            DataSet ds = new DataSet();
            OleDbConnection conn =
                  new OleDbConnection(connectionString);

            string strSql = "INSERT INTO Shows ([ID], [Show_Name], [DayText], [Downloaded], [TimeText], [No_Download_Week], [Start_Date], [Season_End], [OnHiatus], [Cancelled], [Deleted], [MissedLastWeek]) "
                + "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

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
                    newConn.Open();
                    dbCmd.ExecuteNonQuery();
                }
                if (newConn.State == ConnectionState.Open)
                    newConn.Close();
            }
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

    }
}
