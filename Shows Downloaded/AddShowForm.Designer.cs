namespace Shows_Downloaded
{
    partial class AddShowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtAddShowName = new System.Windows.Forms.TextBox();
			this.cmbAddDay = new System.Windows.Forms.ComboBox();
			this.cmbAddTime = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.dateAddStart = new System.Windows.Forms.DateTimePicker();
			this.dateAddSeasonEnd = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbHiddenBox = new System.Windows.Forms.ComboBox();
			this.listMultipleShows = new ListViewEx.ListViewEx();
			this.columnMultipleDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnMultipleTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkMultipleDays = new System.Windows.Forms.CheckBox();
			this.listAddCheckboxes = new System.Windows.Forms.CheckedListBox();
			this.AddRowsToAddToList = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.chkSingleShowing = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.AddRowsToAddToList)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(29, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Show Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Day:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(29, 185);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Time:";
			// 
			// txtAddShowName
			// 
			this.txtAddShowName.Location = new System.Drawing.Point(103, 46);
			this.txtAddShowName.Name = "txtAddShowName";
			this.txtAddShowName.Size = new System.Drawing.Size(164, 20);
			this.txtAddShowName.TabIndex = 1;
			// 
			// cmbAddDay
			// 
			this.cmbAddDay.FormattingEnabled = true;
			this.cmbAddDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
			this.cmbAddDay.Location = new System.Drawing.Point(91, 19);
			this.cmbAddDay.Name = "cmbAddDay";
			this.cmbAddDay.Size = new System.Drawing.Size(164, 21);
			this.cmbAddDay.TabIndex = 1;
			// 
			// cmbAddTime
			// 
			this.cmbAddTime.FormattingEnabled = true;
			this.cmbAddTime.Items.AddRange(new object[] {
            "7:00",
            "7:30",
            "8:00",
            "8:30",
            "9:00",
            "9:30",
            "10:00"});
			this.cmbAddTime.Location = new System.Drawing.Point(103, 176);
			this.cmbAddTime.Name = "cmbAddTime";
			this.cmbAddTime.Size = new System.Drawing.Size(164, 21);
			this.cmbAddTime.TabIndex = 9;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(361, 425);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 14;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(465, 425);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// dateAddStart
			// 
			this.dateAddStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateAddStart.Location = new System.Drawing.Point(423, 46);
			this.dateAddStart.Name = "dateAddStart";
			this.dateAddStart.Size = new System.Drawing.Size(117, 20);
			this.dateAddStart.TabIndex = 4;
			this.dateAddStart.Value = new System.DateTime(2016, 5, 11, 0, 0, 0, 0);
			// 
			// dateAddSeasonEnd
			// 
			this.dateAddSeasonEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateAddSeasonEnd.Location = new System.Drawing.Point(423, 82);
			this.dateAddSeasonEnd.Name = "dateAddSeasonEnd";
			this.dateAddSeasonEnd.Size = new System.Drawing.Size(117, 20);
			this.dateAddSeasonEnd.TabIndex = 6;
			this.dateAddSeasonEnd.Value = new System.DateTime(2016, 5, 11, 0, 0, 0, 0);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(343, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Season Start";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(343, 89);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Season End";
			// 
			// cmbHiddenBox
			// 
			this.cmbHiddenBox.FormattingEnabled = true;
			this.cmbHiddenBox.Location = new System.Drawing.Point(12, 427);
			this.cmbHiddenBox.Name = "cmbHiddenBox";
			this.cmbHiddenBox.Size = new System.Drawing.Size(121, 21);
			this.cmbHiddenBox.TabIndex = 13;
			this.cmbHiddenBox.Visible = false;
			this.cmbHiddenBox.SelectedIndexChanged += new System.EventHandler(this.cmbHiddenBox_SelectedIndexChanged);
			this.cmbHiddenBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbHiddenBox_KeyPress);
			this.cmbHiddenBox.Leave += new System.EventHandler(this.cmbHiddenBox_Leave);
			// 
			// listMultipleShows
			// 
			this.listMultipleShows.AllowColumnReorder = true;
			this.listMultipleShows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnMultipleDay,
            this.columnMultipleTime});
			this.listMultipleShows.DoubleClickActivation = false;
			this.listMultipleShows.FullRowSelect = true;
			this.listMultipleShows.GridLines = true;
			this.listMultipleShows.Location = new System.Drawing.Point(12, 248);
			this.listMultipleShows.Name = "listMultipleShows";
			this.listMultipleShows.Size = new System.Drawing.Size(527, 160);
			this.listMultipleShows.TabIndex = 12;
			this.listMultipleShows.UseCompatibleStateImageBehavior = false;
			this.listMultipleShows.View = System.Windows.Forms.View.Details;
			this.listMultipleShows.SubItemClicked += new ListViewEx.SubItemEventHandler(this.listMultipleShows_SubItemClicked);
			// 
			// columnMultipleDay
			// 
			this.columnMultipleDay.Text = "Day";
			this.columnMultipleDay.Width = 125;
			// 
			// columnMultipleTime
			// 
			this.columnMultipleTime.Text = "Time";
			this.columnMultipleTime.Width = 100;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkSingleShowing);
			this.groupBox1.Controls.Add(this.chkMultipleDays);
			this.groupBox1.Controls.Add(this.cmbAddDay);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(12, 89);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(274, 81);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Days";
			// 
			// chkMultipleDays
			// 
			this.chkMultipleDays.AutoSize = true;
			this.chkMultipleDays.Location = new System.Drawing.Point(166, 58);
			this.chkMultipleDays.Name = "chkMultipleDays";
			this.chkMultipleDays.Size = new System.Drawing.Size(89, 17);
			this.chkMultipleDays.TabIndex = 3;
			this.chkMultipleDays.Text = "Multiple Days";
			this.chkMultipleDays.UseVisualStyleBackColor = true;
			this.chkMultipleDays.CheckedChanged += new System.EventHandler(this.chkMultipleDays_CheckedChanged);
			// 
			// listAddCheckboxes
			// 
			this.listAddCheckboxes.FormattingEnabled = true;
			this.listAddCheckboxes.Items.AddRange(new object[] {
            "On Hiatus",
            "Cancelled",
            "Deleted",
            "Missed Last Week"});
			this.listAddCheckboxes.Location = new System.Drawing.Point(346, 117);
			this.listAddCheckboxes.Name = "listAddCheckboxes";
			this.listAddCheckboxes.Size = new System.Drawing.Size(193, 64);
			this.listAddCheckboxes.TabIndex = 7;
			// 
			// AddRowsToAddToList
			// 
			this.AddRowsToAddToList.Location = new System.Drawing.Point(75, 222);
			this.AddRowsToAddToList.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.AddRowsToAddToList.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.AddRowsToAddToList.Name = "AddRowsToAddToList";
			this.AddRowsToAddToList.Size = new System.Drawing.Size(76, 20);
			this.AddRowsToAddToList.TabIndex = 11;
			this.AddRowsToAddToList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.AddRowsToAddToList.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.AddRowsToAddToList.ValueChanged += new System.EventHandler(this.AddRowsToAddToList_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 229);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Day count";
			// 
			// chkSingleShowing
			// 
			this.chkSingleShowing.AutoSize = true;
			this.chkSingleShowing.Location = new System.Drawing.Point(20, 58);
			this.chkSingleShowing.Name = "chkSingleShowing";
			this.chkSingleShowing.Size = new System.Drawing.Size(99, 17);
			this.chkSingleShowing.TabIndex = 2;
			this.chkSingleShowing.Text = "Single Showing";
			this.chkSingleShowing.UseVisualStyleBackColor = true;
			// 
			// AddShowForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(563, 460);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.AddRowsToAddToList);
			this.Controls.Add(this.listAddCheckboxes);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.listMultipleShows);
			this.Controls.Add(this.cmbHiddenBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dateAddSeasonEnd);
			this.Controls.Add(this.dateAddStart);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbAddTime);
			this.Controls.Add(this.txtAddShowName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Name = "AddShowForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Show";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.AddRowsToAddToList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddShowName;
        private System.Windows.Forms.ComboBox cmbAddDay;
        private System.Windows.Forms.ComboBox cmbAddTime;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dateAddStart;
        private System.Windows.Forms.DateTimePicker dateAddSeasonEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbHiddenBox;
        private ListViewEx.ListViewEx listMultipleShows;
        private System.Windows.Forms.ColumnHeader columnMultipleDay;
        private System.Windows.Forms.ColumnHeader columnMultipleTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkMultipleDays;
        private System.Windows.Forms.CheckedListBox listAddCheckboxes;
        private System.Windows.Forms.NumericUpDown AddRowsToAddToList;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkSingleShowing;
	}
}