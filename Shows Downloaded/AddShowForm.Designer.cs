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
            this.chkAddOnHiatus = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.Day1 = new System.Windows.Forms.ComboBox();
            this.Time1 = new System.Windows.Forms.ComboBox();
            this.Add1 = new System.Windows.Forms.Button();
            this.grpMultiDay = new System.Windows.Forms.GroupBox();
            this.Day2 = new System.Windows.Forms.ComboBox();
            this.Remove2 = new System.Windows.Forms.Button();
            this.lblSecond = new System.Windows.Forms.Label();
            this.Add2 = new System.Windows.Forms.Button();
            this.Time2 = new System.Windows.Forms.ComboBox();
            this.Day3 = new System.Windows.Forms.ComboBox();
            this.Remove3 = new System.Windows.Forms.Button();
            this.lblThird = new System.Windows.Forms.Label();
            this.Add3 = new System.Windows.Forms.Button();
            this.Time3 = new System.Windows.Forms.ComboBox();
            this.Day4 = new System.Windows.Forms.ComboBox();
            this.Remove4 = new System.Windows.Forms.Button();
            this.lblFourth = new System.Windows.Forms.Label();
            this.Time4 = new System.Windows.Forms.ComboBox();
            this.grpMultiDay.SuspendLayout();
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
            this.label2.Location = new System.Drawing.Point(29, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Day:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time:";
            // 
            // txtAddShowName
            // 
            this.txtAddShowName.Location = new System.Drawing.Point(103, 46);
            this.txtAddShowName.Name = "txtAddShowName";
            this.txtAddShowName.Size = new System.Drawing.Size(164, 20);
            this.txtAddShowName.TabIndex = 3;
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
            "Sunday",
            "Multiple"});
            this.cmbAddDay.Location = new System.Drawing.Point(103, 80);
            this.cmbAddDay.Name = "cmbAddDay";
            this.cmbAddDay.Size = new System.Drawing.Size(164, 21);
            this.cmbAddDay.TabIndex = 4;
            this.cmbAddDay.SelectedIndexChanged += new System.EventHandler(this.cmbAddDay_SelectedIndexChanged);
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
            this.cmbAddTime.Location = new System.Drawing.Point(103, 123);
            this.cmbAddTime.Name = "cmbAddTime";
            this.cmbAddTime.Size = new System.Drawing.Size(164, 21);
            this.cmbAddTime.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(361, 351);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(465, 351);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
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
            this.dateAddStart.TabIndex = 8;
            this.dateAddStart.Value = new System.DateTime(2016, 4, 10, 15, 58, 30, 0);
            // 
            // dateAddSeasonEnd
            // 
            this.dateAddSeasonEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateAddSeasonEnd.Location = new System.Drawing.Point(423, 82);
            this.dateAddSeasonEnd.Name = "dateAddSeasonEnd";
            this.dateAddSeasonEnd.Size = new System.Drawing.Size(117, 20);
            this.dateAddSeasonEnd.TabIndex = 9;
            this.dateAddSeasonEnd.Value = new System.DateTime(2016, 4, 10, 15, 58, 30, 0);
            // 
            // chkAddOnHiatus
            // 
            this.chkAddOnHiatus.AutoSize = true;
            this.chkAddOnHiatus.Location = new System.Drawing.Point(423, 123);
            this.chkAddOnHiatus.Name = "chkAddOnHiatus";
            this.chkAddOnHiatus.Size = new System.Drawing.Size(73, 17);
            this.chkAddOnHiatus.TabIndex = 10;
            this.chkAddOnHiatus.Text = "On Hiatus";
            this.chkAddOnHiatus.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Season Start";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Season End";
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(24, 38);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(26, 13);
            this.lblFirst.TabIndex = 13;
            this.lblFirst.Text = "First";
            // 
            // Day1
            // 
            this.Day1.FormattingEnabled = true;
            this.Day1.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.Day1.Location = new System.Drawing.Point(71, 30);
            this.Day1.Name = "Day1";
            this.Day1.Size = new System.Drawing.Size(164, 21);
            this.Day1.TabIndex = 14;
            // 
            // Time1
            // 
            this.Time1.FormattingEnabled = true;
            this.Time1.Items.AddRange(new object[] {
            "7:00",
            "7:30",
            "8:00",
            "8:30",
            "9:00",
            "9:30",
            "10:00"});
            this.Time1.Location = new System.Drawing.Point(241, 30);
            this.Time1.Name = "Time1";
            this.Time1.Size = new System.Drawing.Size(116, 21);
            this.Time1.TabIndex = 15;
            // 
            // Add1
            // 
            this.Add1.Image = global::Shows_Downloaded.Properties.Resources.AddButton2;
            this.Add1.Location = new System.Drawing.Point(371, 30);
            this.Add1.Name = "Add1";
            this.Add1.Size = new System.Drawing.Size(32, 23);
            this.Add1.TabIndex = 16;
            this.Add1.UseVisualStyleBackColor = true;
            this.Add1.Click += new System.EventHandler(this.Add1_Click);
            // 
            // grpMultiDay
            // 
            this.grpMultiDay.Controls.Add(this.Day4);
            this.grpMultiDay.Controls.Add(this.Remove4);
            this.grpMultiDay.Controls.Add(this.lblFourth);
            this.grpMultiDay.Controls.Add(this.Time4);
            this.grpMultiDay.Controls.Add(this.Day3);
            this.grpMultiDay.Controls.Add(this.Remove3);
            this.grpMultiDay.Controls.Add(this.lblThird);
            this.grpMultiDay.Controls.Add(this.Add3);
            this.grpMultiDay.Controls.Add(this.Time3);
            this.grpMultiDay.Controls.Add(this.Day2);
            this.grpMultiDay.Controls.Add(this.Remove2);
            this.grpMultiDay.Controls.Add(this.lblSecond);
            this.grpMultiDay.Controls.Add(this.Add2);
            this.grpMultiDay.Controls.Add(this.Time2);
            this.grpMultiDay.Controls.Add(this.Day1);
            this.grpMultiDay.Controls.Add(this.lblFirst);
            this.grpMultiDay.Controls.Add(this.Add1);
            this.grpMultiDay.Controls.Add(this.Time1);
            this.grpMultiDay.Enabled = false;
            this.grpMultiDay.Location = new System.Drawing.Point(13, 170);
            this.grpMultiDay.Name = "grpMultiDay";
            this.grpMultiDay.Size = new System.Drawing.Size(483, 175);
            this.grpMultiDay.TabIndex = 18;
            this.grpMultiDay.TabStop = false;
            this.grpMultiDay.Text = "Multiple Days";
            // 
            // Day2
            // 
            this.Day2.FormattingEnabled = true;
            this.Day2.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.Day2.Location = new System.Drawing.Point(71, 67);
            this.Day2.Name = "Day2";
            this.Day2.Size = new System.Drawing.Size(164, 21);
            this.Day2.TabIndex = 19;
            // 
            // Remove2
            // 
            this.Remove2.Image = global::Shows_Downloaded.Properties.Resources.RemoveButton;
            this.Remove2.Location = new System.Drawing.Point(409, 67);
            this.Remove2.Name = "Remove2";
            this.Remove2.Size = new System.Drawing.Size(32, 23);
            this.Remove2.TabIndex = 22;
            this.Remove2.UseVisualStyleBackColor = true;
            this.Remove2.Click += new System.EventHandler(this.Remove2_Click);
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(24, 75);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(44, 13);
            this.lblSecond.TabIndex = 18;
            this.lblSecond.Text = "Second";
            // 
            // Add2
            // 
            this.Add2.Image = global::Shows_Downloaded.Properties.Resources.AddButton2;
            this.Add2.Location = new System.Drawing.Point(371, 67);
            this.Add2.Name = "Add2";
            this.Add2.Size = new System.Drawing.Size(32, 23);
            this.Add2.TabIndex = 21;
            this.Add2.UseVisualStyleBackColor = true;
            this.Add2.Click += new System.EventHandler(this.Add2_Click);
            // 
            // Time2
            // 
            this.Time2.FormattingEnabled = true;
            this.Time2.Items.AddRange(new object[] {
            "7:00",
            "7:30",
            "8:00",
            "8:30",
            "9:00",
            "9:30",
            "10:00"});
            this.Time2.Location = new System.Drawing.Point(241, 67);
            this.Time2.Name = "Time2";
            this.Time2.Size = new System.Drawing.Size(116, 21);
            this.Time2.TabIndex = 20;
            // 
            // Day3
            // 
            this.Day3.FormattingEnabled = true;
            this.Day3.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.Day3.Location = new System.Drawing.Point(71, 103);
            this.Day3.Name = "Day3";
            this.Day3.Size = new System.Drawing.Size(164, 21);
            this.Day3.TabIndex = 24;
            // 
            // Remove3
            // 
            this.Remove3.Image = global::Shows_Downloaded.Properties.Resources.RemoveButton;
            this.Remove3.Location = new System.Drawing.Point(409, 103);
            this.Remove3.Name = "Remove3";
            this.Remove3.Size = new System.Drawing.Size(32, 23);
            this.Remove3.TabIndex = 27;
            this.Remove3.UseVisualStyleBackColor = true;
            this.Remove3.Click += new System.EventHandler(this.Remove3_Click);
            // 
            // lblThird
            // 
            this.lblThird.AutoSize = true;
            this.lblThird.Location = new System.Drawing.Point(24, 111);
            this.lblThird.Name = "lblThird";
            this.lblThird.Size = new System.Drawing.Size(31, 13);
            this.lblThird.TabIndex = 23;
            this.lblThird.Text = "Third";
            // 
            // Add3
            // 
            this.Add3.Image = global::Shows_Downloaded.Properties.Resources.AddButton2;
            this.Add3.Location = new System.Drawing.Point(371, 103);
            this.Add3.Name = "Add3";
            this.Add3.Size = new System.Drawing.Size(32, 23);
            this.Add3.TabIndex = 26;
            this.Add3.UseVisualStyleBackColor = true;
            this.Add3.Click += new System.EventHandler(this.Add3_Click);
            // 
            // Time3
            // 
            this.Time3.FormattingEnabled = true;
            this.Time3.Items.AddRange(new object[] {
            "7:00",
            "7:30",
            "8:00",
            "8:30",
            "9:00",
            "9:30",
            "10:00"});
            this.Time3.Location = new System.Drawing.Point(241, 103);
            this.Time3.Name = "Time3";
            this.Time3.Size = new System.Drawing.Size(116, 21);
            this.Time3.TabIndex = 25;
            // 
            // Day4
            // 
            this.Day4.FormattingEnabled = true;
            this.Day4.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.Day4.Location = new System.Drawing.Point(71, 139);
            this.Day4.Name = "Day4";
            this.Day4.Size = new System.Drawing.Size(164, 21);
            this.Day4.TabIndex = 29;
            // 
            // Remove4
            // 
            this.Remove4.Image = global::Shows_Downloaded.Properties.Resources.RemoveButton;
            this.Remove4.Location = new System.Drawing.Point(409, 139);
            this.Remove4.Name = "Remove4";
            this.Remove4.Size = new System.Drawing.Size(32, 23);
            this.Remove4.TabIndex = 32;
            this.Remove4.UseVisualStyleBackColor = true;
            this.Remove4.Click += new System.EventHandler(this.Remove4_Click);
            // 
            // lblFourth
            // 
            this.lblFourth.AutoSize = true;
            this.lblFourth.Location = new System.Drawing.Point(24, 147);
            this.lblFourth.Name = "lblFourth";
            this.lblFourth.Size = new System.Drawing.Size(37, 13);
            this.lblFourth.TabIndex = 28;
            this.lblFourth.Text = "Fourth";
            // 
            // Time4
            // 
            this.Time4.FormattingEnabled = true;
            this.Time4.Items.AddRange(new object[] {
            "7:00",
            "7:30",
            "8:00",
            "8:30",
            "9:00",
            "9:30",
            "10:00"});
            this.Time4.Location = new System.Drawing.Point(241, 139);
            this.Time4.Name = "Time4";
            this.Time4.Size = new System.Drawing.Size(116, 21);
            this.Time4.TabIndex = 30;
            // 
            // AddShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 386);
            this.Controls.Add(this.grpMultiDay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkAddOnHiatus);
            this.Controls.Add(this.dateAddSeasonEnd);
            this.Controls.Add(this.dateAddStart);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbAddTime);
            this.Controls.Add(this.cmbAddDay);
            this.Controls.Add(this.txtAddShowName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddShowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Show";
            this.grpMultiDay.ResumeLayout(false);
            this.grpMultiDay.PerformLayout();
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
        private System.Windows.Forms.CheckBox chkAddOnHiatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.ComboBox Day1;
        private System.Windows.Forms.ComboBox Time1;
        private System.Windows.Forms.Button Add1;
        private System.Windows.Forms.GroupBox grpMultiDay;
        private System.Windows.Forms.ComboBox Day4;
        private System.Windows.Forms.Button Remove4;
        private System.Windows.Forms.Label lblFourth;
        private System.Windows.Forms.ComboBox Time4;
        private System.Windows.Forms.ComboBox Day3;
        private System.Windows.Forms.Button Remove3;
        private System.Windows.Forms.Label lblThird;
        private System.Windows.Forms.Button Add3;
        private System.Windows.Forms.ComboBox Time3;
        private System.Windows.Forms.ComboBox Day2;
        private System.Windows.Forms.Button Remove2;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Button Add2;
        private System.Windows.Forms.ComboBox Time2;
    }
}