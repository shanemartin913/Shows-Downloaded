using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Shows_Downloaded
{
    public partial class AddShowForm : Form
    {
        public Shows changeShow = new Shows();
        public int MultiRowsShown = 0;

        public AddShowForm()
        {
            InitializeComponent();
            grpMultiDay.Enabled = false;
            lblFirst.Visible = false;
            lblSecond.Visible = false;
            lblThird.Visible = false;
            lblFourth.Visible = false;
            Day1.Visible = false;
            Day2.Visible = false;
            Day3.Visible = false;
            Day4.Visible = false;
            Time1.Visible = false;
            Time2.Visible = false;
            Time3.Visible = false;
            Time4.Visible = false;
            Add1.Visible = false;
            Add2.Visible = false;
            Add3.Visible = false;
            Remove2.Visible = false;
            Remove3.Visible = false;
            Remove4.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtAddShowName != null && cmbAddDay.SelectedIndex > -1 && cmbAddTime.SelectedIndex > -1)
            {
                if (cmbAddDay.Text.Equals("Multiple"))
                {
                    AddMultipleShows();
                    changeShow.MultipleShowTimes = true;
                    changeShow.ShowName = txtAddShowName.Text;
                    changeShow.StartDate = dateAddStart.Value;
                    changeShow.SeasonEnd = dateAddSeasonEnd.Value;
                    changeShow.OnHiatus = chkAddOnHiatus.Checked;
                }
                else
                {
                    changeShow.ShowName = txtAddShowName.Text;
                    changeShow.ShowDay = cmbAddDay.Text;
                    changeShow.ShowTime = cmbAddTime.Text;
                    changeShow.StartDate = dateAddStart.Value;
                    changeShow.SeasonEnd = dateAddSeasonEnd.Value;
                    changeShow.OnHiatus = chkAddOnHiatus.Checked;
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
            chkAddOnHiatus.Checked = tempShow.OnHiatus;
        }

        private void Add1_Click(object sender, EventArgs e)
        {
            lblSecond.Visible = true;
            Day2.Visible = true;
            Time2.Visible = true;
            Add2.Visible = true;
            Remove2.Visible = true;
            MultiRowsShown = 2;
        }

        private void Add2_Click(object sender, EventArgs e)
        {
            lblThird.Visible = true;
            Day3.Visible = true;
            Time3.Visible = true;
            Add3.Visible = true;
            Remove3.Visible = true;
            MultiRowsShown = 3;
        }

        private void Add3_Click(object sender, EventArgs e)
        {
            lblFourth.Visible = true;
            Day4.Visible = true;
            Time4.Visible = true;
            Remove4.Visible = true;
            MultiRowsShown = 4;
        }

        private void Remove2_Click(object sender, EventArgs e)
        {
            if (MultiRowsShown == 2)
            {
                lblSecond.Visible = false;
                Day2.Visible = false;
                Time2.Visible = false;
                Add2.Visible = false;
                Remove2.Visible = false;
                MultiRowsShown = 1;
            }
        }

        private void Remove3_Click(object sender, EventArgs e)
        {
            if (MultiRowsShown == 3)
            {
                lblThird.Visible = false;
                Day3.Visible = false;
                Time3.Visible = false;
                Add3.Visible = false;
                Remove3.Visible = false;
                MultiRowsShown = 2;
            }
        }

        private void Remove4_Click(object sender, EventArgs e)
        {
            if (MultiRowsShown == 4)
            {
                lblFourth.Visible = false;
                Day4.Visible = false;
                Time4.Visible = false;
                Remove4.Visible = false;
                MultiRowsShown = 3;
            }
        }

        private void cmbAddDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAddDay.Text.Equals("Multiple"))
            {
                grpMultiDay.Enabled = true;
                lblFirst.Visible = true;
                Day1.Visible = true;
                Time1.Visible = true;
                Add1.Visible = true;
                MultiRowsShown = 1;
            }
            else
            {
                grpMultiDay.Enabled = false;
                lblFirst.Visible = false;
                lblSecond.Visible = false;
                lblThird.Visible = false;
                lblFourth.Visible = false;
                Day1.Visible = false;
                Day2.Visible = false;
                Day3.Visible = false;
                Day4.Visible = false;
                Time1.Visible = false;
                Time2.Visible = false;
                Time3.Visible = false;
                Time4.Visible = false;
                Add1.Visible = false;
                Add2.Visible = false;
                Add3.Visible = false;
                Remove2.Visible = false;
                Remove3.Visible = false;
                Remove4.Visible = false;
                MultiRowsShown = 0;
            }
        }

        public void AddMultipleShows()
        {
            for(int x = 0; x < MultiRowsShown; x++)
            {
                if(x == 0)
                {
                    changeShow.MultiDays[x] = Day1.Text;
                    changeShow.MultiTimes[x] = Time1.Text;
                }
                if(x == 1)
                {
                    changeShow.MultiDays[x] = Day2.Text;
                    changeShow.MultiTimes[x] = Time2.Text;
                }
                if (x == 2)
                {
                    changeShow.MultiDays[x] = Day3.Text;
                    changeShow.MultiTimes[x] = Time3.Text;
                }
                if (x == 3)
                {
                    changeShow.MultiDays[x] = Day4.Text;
                    changeShow.MultiTimes[x] = Time4.Text;
                }
            }
        }
    }
}
