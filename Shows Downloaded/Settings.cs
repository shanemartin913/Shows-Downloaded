using System;
using System.IO;
using System.Windows.Forms;

namespace Shows_Downloaded
{
	public partial class Settings : Form
	{
		/// <summary>
		/// Database path for main form
		/// </summary>
		public string strDatabasePath;
		public string strLogfilePath;
		public bool bKeepLog;

		public Settings ()
		{
			InitializeComponent();
		}

		private void Settings_Load (object sender, EventArgs e)
		{
			txtDatabasePath.Text = DatabaseSettings.settings.DatabaseLocation;// Properties.Settings.Default.DatabaseLocation;
			txtLogFilePath.Text = DatabaseSettings.settings.LogFileLocation;// Properties.Settings.Default.LogLocation;
			grpLogFile.Checked = DatabaseSettings.settings.KeepLog;// Properties.Settings.Default.KeepLog;
			chkLogToDatabase.Checked = DatabaseSettings.settings.LogToDatabase;
		}

		private void btnOK_Click (object sender, EventArgs e)
		{
            DatabaseSettings.settings.DatabaseLocation = txtDatabasePath.Text;
            DatabaseSettings.settings.LogFileLocation = txtLogFilePath.Text;
            DatabaseSettings.settings.KeepLog = grpLogFile.Checked;
            DatabaseSettings.settings.LogToDatabase = chkLogToDatabase.Checked;
			//Properties.Settings.Default.DatabaseLocation = txtDatabasePath.Text;
			//Properties.Settings.Default.LogLocation = txtLogFilePath.Text;
			//Properties.Settings.Default.KeepLog = grpLogFile.Checked;
			strDatabasePath = txtDatabasePath.Text;
			strLogfilePath = txtLogFilePath.Text;
			bKeepLog = grpLogFile.Checked;
			//Properties.Settings.Default.Save();

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnDatabasePath_Click (object sender, EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Title = "Select Access Database";
			theDialog.Filter = "Access database|*.accdb";
			theDialog.InitialDirectory = Path.GetDirectoryName(txtDatabasePath.Text);
			if(theDialog.ShowDialog() == DialogResult.OK)
				txtDatabasePath.Text = theDialog.FileName.ToString();
		}

		private void btnLogFilePath_Click (object sender, EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Title = "Select Log File";
			theDialog.Filter = "Log File|*.log";
			theDialog.CheckFileExists = false;
			theDialog.CheckPathExists = false;
			theDialog.InitialDirectory = Path.GetDirectoryName(txtLogFilePath.Text);
			if(theDialog.ShowDialog() == DialogResult.OK)
				txtLogFilePath.Text = theDialog.FileName.ToString();
		}
	}
}
