using System;
using System.Linq;
using System.Windows.Forms;


namespace Shows_Downloaded
{
    public partial class AddShowForm : Form
    {
        public const int ONHIATUS = 0;
        public const int CANCELLED = 1;
        public const int DELETED = 2;
        public const int MISSEDLASTWEEK = 3;
        public Shows changeShow = new Shows();
        public int MultiRowsShown = 0;
        private ListViewItem item;
        int selectedSubItem = 0;

        public AddShowForm()
        {
            InitializeComponent();
			dateAddSeasonEnd.Value = DateTime.Now;
			dateAddStart.Value = DateTime.Now;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtAddShowName != null)
            {
                if (chkMultipleDays.Checked == true)
                {
                    AddMultipleShows();
                    changeShow.MultipleShowTimes = true;
                    changeShow.ShowName = txtAddShowName.Text;
                    changeShow.StartDate = dateAddStart.Value;
                    changeShow.SeasonEnd = dateAddSeasonEnd.Value;
					changeShow.SingleShowing = false;
                    changeShow.OnHiatus = listAddCheckboxes.GetItemChecked(ONHIATUS);
                    changeShow.ShowCancelled = listAddCheckboxes.GetItemChecked(CANCELLED);
                    changeShow.ShowDeleted = listAddCheckboxes.GetItemChecked(DELETED);
                    changeShow.ShowMissedLastWeek = listAddCheckboxes.GetItemChecked(MISSEDLASTWEEK);
                }
                else
                {
                    changeShow.ShowName = txtAddShowName.Text;
                    changeShow.ShowDay = cmbAddDay.Text;
                    changeShow.ShowTime = cmbAddTime.Text;
                    changeShow.StartDate = dateAddStart.Value;
                    changeShow.SeasonEnd = dateAddSeasonEnd.Value;
					changeShow.SingleShowing = chkSingleShowing.Checked;
                    changeShow.OnHiatus = listAddCheckboxes.GetItemChecked(ONHIATUS);
                    changeShow.ShowCancelled = listAddCheckboxes.GetItemChecked(CANCELLED);
                    changeShow.ShowDeleted = listAddCheckboxes.GetItemChecked(DELETED);
                    changeShow.ShowMissedLastWeek = listAddCheckboxes.GetItemChecked(MISSEDLASTWEEK);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }

        public void FillDialog(Shows tempShow)
        {
            double[] time = new double[] { 7, 7.5, 8, 8.5, 9, 9.5, 10 };
            int timeindex = 0;

            changeShow = tempShow;
            txtAddShowName.Text = tempShow.ShowName;
            cmbAddDay.SelectedIndex = tempShow.DayIndex - 1;
            for (int x = 0; x < time.Length; x++) if (tempShow.TimeIndex == time[x]) timeindex = x;
            cmbAddTime.SelectedIndex = timeindex;
            dateAddStart.Value = tempShow.StartDate;
            dateAddSeasonEnd.Value = tempShow.SeasonEnd;
			chkSingleShowing.Checked = tempShow.SingleShowing;

            listAddCheckboxes.SetItemChecked(ONHIATUS, tempShow.OnHiatus);
            listAddCheckboxes.SetItemChecked(CANCELLED, tempShow.ShowCancelled);
            listAddCheckboxes.SetItemChecked(DELETED, tempShow.ShowDeleted);
            listAddCheckboxes.SetItemChecked(MISSEDLASTWEEK, tempShow.ShowMissedLastWeek);
            if(tempShow.MultipleShowTimes == true)
            {
                for(int x = 0; x < tempShow.MultiDays.Count(); x++)
                {
                    listMultipleShows.Items.Add(new ListViewItem(new string[] { tempShow.MultiDays[x], tempShow.MultiTimes[x] }));
                }
                chkMultipleDays.Checked = true;
                cmbAddDay.Enabled = false;
                cmbAddTime.Enabled = false;
            }
        }

        public void AddMultipleShows()
        {
            ListViewItem item;
            for (int x = 0; x < AddRowsToAddToList.Value; x++)
            {
                item = listMultipleShows.Items[x];
                changeShow.MultiDays[x] = item.Text;
                changeShow.MultiTimes[x] = item.SubItems[1].Text;
            }
            changeShow.MultiShowCount = Convert.ToInt32(AddRowsToAddToList.Value);
        }

        private void cmbHiddenBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 27)
            {
                cmbHiddenBox.Hide();
            }
        }

        private void cmbHiddenBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbHiddenBox.SelectedIndex;
            if (i >= 0)
            {
                string str = cmbHiddenBox.Items[i].ToString();
                if (selectedSubItem == 1) item.SubItems[selectedSubItem].Text = str;
                else item.Text = str;
            }
        }

        private void cmbHiddenBox_Leave(object sender, EventArgs e)
        {
            cmbHiddenBox.Hide();
        }

        private void listMultipleShows_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            string[] strDays = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] strTimes = new string[] { "7:00", "7:30", "8:00", "8:30", "9:00", "9:30", "10:00" };

            item = e.Item;
            selectedSubItem = e.SubItem;
//            Console.WriteLine("Item {0}  SubItem {1}", e.Item, e.SubItem);
            cmbHiddenBox.Items.Clear();
            if (e.SubItem == 0) cmbHiddenBox.Items.AddRange(strDays);
            else cmbHiddenBox.Items.AddRange(strTimes);

            listMultipleShows.StartEditing(cmbHiddenBox, e.Item, e.SubItem);
        }

        private void chkMultipleDays_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMultipleDays.Checked == true)
            {
                cmbAddDay.Enabled = false;
                cmbAddTime.Enabled = false;
                listMultipleShows.Enabled = true;
                listMultipleShows.Items.Add(new ListViewItem(new string[] { "Monday", "7:00" }));
                listMultipleShows.Items.Add(new ListViewItem(new string[] { "Tuesday", "7:00" }));
            }
            else
            {
                cmbAddDay.Enabled = true;
                cmbAddTime.Enabled = true;
                listMultipleShows.Items.Clear();
                listMultipleShows.Enabled = false;
            }
        }

        private void AddRowsToAddToList_ValueChanged(object sender, EventArgs e)
        {
            if(listMultipleShows.Items.Count < AddRowsToAddToList.Value)
            {
                listMultipleShows.Items.Add(new ListViewItem(new string[] { "Monday", "7:00" }));
            }
            else
            {
                listMultipleShows.Items.RemoveAt(listMultipleShows.Items.Count - 1);
            }
        }
    }
}
