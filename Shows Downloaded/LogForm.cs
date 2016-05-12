using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shows_Downloaded
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            LoadColumnHeaderSizes();
            DatabaseLogs.LoadLogs();

            FillList();
        }

		private void LogForm_FormClosing (object sender, FormClosingEventArgs e)
		{
			SaveColumnHeaderSizes();
		}

		private void FillList()
        {
            int x = DatabaseLogs.LogCollection.Count;

            for(int i = 0; i < x; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = DatabaseLogs.LogCollection[i].LogDate.ToString("dd MMM yyyy HH:mm:ss");
                lvi.SubItems.Add(DatabaseLogs.LogCollection[i].Status);

                logList.Items.Add(lvi);
            }
        }

		public void LoadColumnHeaderSizes ()
		{
			char[] delimiterChars = { ' ', ';' };
			string sizes = DatabaseSettings.settings.LogColumnSizes;

			string[] words = sizes.Split(delimiterChars);

			for(int i = 0; i < words.Length; i++)
			{
				logList.Columns[i].Width = Convert.ToInt32(words[i]);
			}
		}

		public void SaveColumnHeaderSizes ()
		{
			string temp = "";

			for(int i = 0; i < logList.Columns.Count; i++)
			{
				if(i != 0)
					temp += ";" + logList.Columns[i].Width.ToString();
				else
					temp += logList.Columns[i].Width.ToString();
			}
			DatabaseSettings.settings.LogColumnSizes = temp;
		}
	}
}
