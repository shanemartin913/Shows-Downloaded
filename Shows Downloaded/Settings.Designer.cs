namespace Shows_Downloaded
{
	partial class Settings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.settingsFrm = new System.Windows.Forms.TabControl();
			this.settingsFile = new System.Windows.Forms.TabPage();
			this.btnDatabasePath = new System.Windows.Forms.Button();
			this.grpLogFile = new UIToolbox.CheckGroupBox();
			this.btnLogFilePath = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLogFilePath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDatabasePath = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.chkLogToDatabase = new System.Windows.Forms.CheckBox();
			this.settingsFrm.SuspendLayout();
			this.settingsFile.SuspendLayout();
			this.grpLogFile.SuspendLayout();
			this.SuspendLayout();
			// 
			// settingsFrm
			// 
			this.settingsFrm.Controls.Add(this.settingsFile);
			this.settingsFrm.Controls.Add(this.tabPage2);
			this.settingsFrm.Location = new System.Drawing.Point(13, 13);
			this.settingsFrm.Name = "settingsFrm";
			this.settingsFrm.SelectedIndex = 0;
			this.settingsFrm.Size = new System.Drawing.Size(518, 261);
			this.settingsFrm.TabIndex = 0;
			// 
			// settingsFile
			// 
			this.settingsFile.Controls.Add(this.btnDatabasePath);
			this.settingsFile.Controls.Add(this.grpLogFile);
			this.settingsFile.Controls.Add(this.label1);
			this.settingsFile.Controls.Add(this.txtDatabasePath);
			this.settingsFile.Location = new System.Drawing.Point(4, 22);
			this.settingsFile.Name = "settingsFile";
			this.settingsFile.Padding = new System.Windows.Forms.Padding(3);
			this.settingsFile.Size = new System.Drawing.Size(510, 235);
			this.settingsFile.TabIndex = 0;
			this.settingsFile.Text = "Files";
			this.settingsFile.UseVisualStyleBackColor = true;
			// 
			// btnDatabasePath
			// 
			this.btnDatabasePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDatabasePath.Location = new System.Drawing.Point(353, 34);
			this.btnDatabasePath.Name = "btnDatabasePath";
			this.btnDatabasePath.Size = new System.Drawing.Size(61, 23);
			this.btnDatabasePath.TabIndex = 5;
			this.btnDatabasePath.Text = "Browse...";
			this.btnDatabasePath.UseVisualStyleBackColor = true;
			this.btnDatabasePath.Click += new System.EventHandler(this.btnDatabasePath_Click);
			// 
			// grpLogFile
			// 
			this.grpLogFile.Checked = false;
			this.grpLogFile.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.grpLogFile.Controls.Add(this.chkLogToDatabase);
			this.grpLogFile.Controls.Add(this.btnLogFilePath);
			this.grpLogFile.Controls.Add(this.label2);
			this.grpLogFile.Controls.Add(this.txtLogFilePath);
			this.grpLogFile.Location = new System.Drawing.Point(7, 73);
			this.grpLogFile.Name = "grpLogFile";
			this.grpLogFile.Size = new System.Drawing.Size(450, 130);
			this.grpLogFile.TabIndex = 4;
			this.grpLogFile.TabStop = false;
			this.grpLogFile.Text = "Log File";
			// 
			// btnLogFilePath
			// 
			this.btnLogFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLogFilePath.Location = new System.Drawing.Point(343, 57);
			this.btnLogFilePath.Name = "btnLogFilePath";
			this.btnLogFilePath.Size = new System.Drawing.Size(61, 23);
			this.btnLogFilePath.TabIndex = 6;
			this.btnLogFilePath.Text = "Browse...";
			this.btnLogFilePath.UseVisualStyleBackColor = true;
			this.btnLogFilePath.Click += new System.EventHandler(this.btnLogFilePath_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Log File Path";
			// 
			// txtLogFilePath
			// 
			this.txtLogFilePath.Location = new System.Drawing.Point(8, 59);
			this.txtLogFilePath.Name = "txtLogFilePath";
			this.txtLogFilePath.Size = new System.Drawing.Size(329, 20);
			this.txtLogFilePath.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Database Path";
			// 
			// txtDatabasePath
			// 
			this.txtDatabasePath.Location = new System.Drawing.Point(18, 36);
			this.txtDatabasePath.Name = "txtDatabasePath";
			this.txtDatabasePath.Size = new System.Drawing.Size(329, 20);
			this.txtDatabasePath.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(510, 235);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(357, 296);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(452, 296);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// chkLogToDatabase
			// 
			this.chkLogToDatabase.AutoSize = true;
			this.chkLogToDatabase.Location = new System.Drawing.Point(8, 99);
			this.chkLogToDatabase.Name = "chkLogToDatabase";
			this.chkLogToDatabase.Size = new System.Drawing.Size(105, 17);
			this.chkLogToDatabase.TabIndex = 7;
			this.chkLogToDatabase.Text = "Log to Database";
			this.chkLogToDatabase.UseVisualStyleBackColor = true;
			// 
			// Settings
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(543, 331);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.settingsFrm);
			this.Name = "Settings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.Settings_Load);
			this.settingsFrm.ResumeLayout(false);
			this.settingsFile.ResumeLayout(false);
			this.settingsFile.PerformLayout();
			this.grpLogFile.ResumeLayout(false);
			this.grpLogFile.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl settingsFrm;
		private System.Windows.Forms.TabPage settingsFile;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtLogFilePath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDatabasePath;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private UIToolbox.CheckGroupBox grpLogFile;
		private System.Windows.Forms.Button btnDatabasePath;
		private System.Windows.Forms.Button btnLogFilePath;
		private System.Windows.Forms.CheckBox chkLogToDatabase;
	}
}