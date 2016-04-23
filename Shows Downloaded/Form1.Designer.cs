namespace Shows_Downloaded
{
    partial class ShowsForm
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
            this.components = new System.ComponentModel.Container();
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn7 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn8 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn9 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn10 = new GlacialComponents.Controls.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listShow = new GlacialComponents.Controls.GlacialList();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDayofWeek = new System.Windows.Forms.ComboBox();
            this.listmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listmenuAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.listmenuModify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.listmenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.listmenuClearMissedWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbonUpDown1 = new System.Windows.Forms.RibbonUpDown();
            this.showRibbon = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonSave = new System.Windows.Forms.RibbonButton();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonExit = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonShowCancelled = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonShowOnHiatus = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonShowSkipWeek = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonAddShow = new System.Windows.Forms.RibbonButton();
            this.ribbonModifyShow = new System.Windows.Forms.RibbonButton();
            this.ribbonDelete = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbonClearChecks = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.colorMissedWeek = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDownloaded = new System.Windows.Forms.Label();
            this.colorSkipped = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorNotDownloaded = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.downloadedColorPicker = new System.Windows.Forms.ColorDialog();
            this.skippedColorPicker = new System.Windows.Forms.ColorDialog();
            this.notdownloadColorPicker = new System.Windows.Forms.ColorDialog();
            this.listselectiontimer = new System.Windows.Forms.Timer(this.components);
            this.missedweekColorPicker = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.listmenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listShow);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbDayofWeek);
            this.groupBox1.Location = new System.Drawing.Point(13, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(974, 397);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shows";
            // 
            // listShow
            // 
            this.listShow.AllowColumnResize = true;
            this.listShow.AllowMultiselect = false;
            this.listShow.AlternateBackground = System.Drawing.Color.GreenYellow;
            this.listShow.AlternatingColors = false;
            this.listShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listShow.AutoHeight = true;
            this.listShow.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listShow.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "ColumnID";
            glColumn1.NumericSort = false;
            glColumn1.Text = "ID";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 30;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "ColumnName";
            glColumn2.NumericSort = false;
            glColumn2.Text = "Show Name";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 200;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "ColumnDay";
            glColumn3.NumericSort = false;
            glColumn3.Text = "Day";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 80;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = true;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "ColumnDownloaded";
            glColumn4.NumericSort = false;
            glColumn4.Text = "Downloaded";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 75;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "ColumnTime";
            glColumn5.NumericSort = false;
            glColumn5.Text = "Time";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 100;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = true;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "ColumnSkipWeek";
            glColumn6.NumericSort = false;
            glColumn6.Text = "SkipWeek";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn6.Width = 100;
            glColumn7.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn7.CheckBoxes = false;
            glColumn7.ImageIndex = -1;
            glColumn7.Name = "ColumnStartDate";
            glColumn7.NumericSort = false;
            glColumn7.Text = "Start Date";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn7.Width = 100;
            glColumn8.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn8.CheckBoxes = false;
            glColumn8.ImageIndex = -1;
            glColumn8.Name = "ColumnSeasonEnd";
            glColumn8.NumericSort = false;
            glColumn8.Text = "Season End";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 100;
            glColumn9.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn9.CheckBoxes = true;
            glColumn9.ImageIndex = -1;
            glColumn9.Name = "ColumnOnHiatus";
            glColumn9.NumericSort = false;
            glColumn9.Text = "OnHiatus";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn9.Width = 100;
            glColumn10.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn10.CheckBoxes = true;
            glColumn10.ImageIndex = -1;
            glColumn10.Name = "ColumnCancelled";
            glColumn10.NumericSort = false;
            glColumn10.Text = "Cancelled";
            glColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn10.Width = 100;
            this.listShow.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5,
            glColumn6,
            glColumn7,
            glColumn8,
            glColumn9,
            glColumn10});
            this.listShow.ControlStyle = GlacialComponents.Controls.GLControlStyles.Normal;
            this.listShow.FullRowSelect = true;
            this.listShow.GridColor = System.Drawing.Color.LightGray;
            this.listShow.GridLines = GlacialComponents.Controls.GLGridLines.gridHorizontal;
            this.listShow.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.listShow.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.listShow.HeaderHeight = 22;
            this.listShow.HeaderVisible = true;
            this.listShow.HeaderWordWrap = false;
            this.listShow.HotColumnTracking = false;
            this.listShow.HotItemTracking = false;
            this.listShow.HotTrackingColor = System.Drawing.Color.LightGray;
            this.listShow.HoverEvents = false;
            this.listShow.HoverTime = 1;
            this.listShow.ImageList = null;
            this.listShow.ItemHeight = 17;
            this.listShow.ItemWordWrap = false;
            this.listShow.Location = new System.Drawing.Point(10, 66);
            this.listShow.Name = "listShow";
            this.listShow.Selectable = false;
            this.listShow.SelectedTextColor = System.Drawing.Color.White;
            this.listShow.SelectionColor = System.Drawing.Color.DeepSkyBlue;
            this.listShow.ShowBorder = true;
            this.listShow.ShowFocusRect = false;
            this.listShow.Size = new System.Drawing.Size(946, 310);
            this.listShow.SortType = GlacialComponents.Controls.SortTypes.None;
            this.listShow.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.listShow.TabIndex = 2;
            this.listShow.Text = "glacialList1";
            this.listShow.ColumnClickedEvent += new GlacialComponents.Controls.GlacialList.ClickedEventHandler(this.listShow_ColumnClickedEvent);
            this.listShow.ItemChangedEvent += new GlacialComponents.Controls.ChangedEventHandler(this.listShow_ItemChangedEvent);
            this.listShow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listShow_MouseClick);
            this.listShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listShow_MouseDown);
            this.listShow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listShow_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Day of Week";
            // 
            // cmbDayofWeek
            // 
            this.cmbDayofWeek.FormattingEnabled = true;
            this.cmbDayofWeek.Items.AddRange(new object[] {
            "All",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cmbDayofWeek.Location = new System.Drawing.Point(83, 24);
            this.cmbDayofWeek.Name = "cmbDayofWeek";
            this.cmbDayofWeek.Size = new System.Drawing.Size(121, 21);
            this.cmbDayofWeek.TabIndex = 0;
            this.cmbDayofWeek.SelectedIndexChanged += new System.EventHandler(this.cmbDayofWeek_SelectedIndexChanged);
            // 
            // listmenu
            // 
            this.listmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listmenuAddNew,
            this.toolStripSeparator1,
            this.listmenuModify,
            this.toolStripSeparator2,
            this.listmenuDelete,
            this.toolStripSeparator3,
            this.listmenuClearMissedWeek});
            this.listmenu.Name = "listmenu";
            this.listmenu.Size = new System.Drawing.Size(174, 110);
            // 
            // listmenuAddNew
            // 
            this.listmenuAddNew.Name = "listmenuAddNew";
            this.listmenuAddNew.Size = new System.Drawing.Size(173, 22);
            this.listmenuAddNew.Text = "Add New Show...";
            this.listmenuAddNew.Click += new System.EventHandler(this.listmenuAddNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // listmenuModify
            // 
            this.listmenuModify.Name = "listmenuModify";
            this.listmenuModify.Size = new System.Drawing.Size(173, 22);
            this.listmenuModify.Text = "Modify Show...";
            this.listmenuModify.Click += new System.EventHandler(this.listmenuModify_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // listmenuDelete
            // 
            this.listmenuDelete.Name = "listmenuDelete";
            this.listmenuDelete.Size = new System.Drawing.Size(173, 22);
            this.listmenuDelete.Text = "Delete Show";
            this.listmenuDelete.Click += new System.EventHandler(this.listmenuDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // listmenuClearMissedWeek
            // 
            this.listmenuClearMissedWeek.Enabled = false;
            this.listmenuClearMissedWeek.Name = "listmenuClearMissedWeek";
            this.listmenuClearMissedWeek.Size = new System.Drawing.Size(173, 22);
            this.listmenuClearMissedWeek.Text = "Clear Missed Week";
            this.listmenuClearMissedWeek.Click += new System.EventHandler(this.listmenuClearMissedWeek_Click);
            // 
            // ribbonUpDown1
            // 
            this.ribbonUpDown1.TextBoxText = "";
            this.ribbonUpDown1.TextBoxWidth = 50;
            // 
            // showRibbon
            // 
            this.showRibbon.CaptionBarVisible = false;
            this.showRibbon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.showRibbon.Location = new System.Drawing.Point(0, 0);
            this.showRibbon.Minimized = false;
            this.showRibbon.Name = "showRibbon";
            // 
            // 
            // 
            this.showRibbon.OrbDropDown.BorderRoundness = 8;
            this.showRibbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.showRibbon.OrbDropDown.Name = "";
            this.showRibbon.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.showRibbon.OrbDropDown.TabIndex = 0;
            this.showRibbon.OrbImage = null;
            this.showRibbon.OrbVisible = false;
            // 
            // 
            // 
            this.showRibbon.QuickAcessToolbar.Enabled = false;
            this.showRibbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.showRibbon.Size = new System.Drawing.Size(999, 106);
            this.showRibbon.TabIndex = 3;
            this.showRibbon.Tabs.Add(this.ribbonTab1);
            this.showRibbon.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.showRibbon.Text = "ribbon1";
            this.showRibbon.ThemeColor = System.Windows.Forms.RibbonTheme.Black;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Panels.Add(this.ribbonPanel4);
            this.ribbonTab1.Text = "";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.ribbonSave);
            this.ribbonPanel1.Items.Add(this.ribbonExit);
            this.ribbonPanel1.Text = "File";
            // 
            // ribbonSave
            // 
            this.ribbonSave.DropDownItems.Add(this.ribbonButton1);
            this.ribbonSave.DropDownItems.Add(this.ribbonButton2);
            this.ribbonSave.Image = ((System.Drawing.Image)(resources.GetObject("ribbonSave.Image")));
            this.ribbonSave.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonSave.SmallImage")));
            this.ribbonSave.Text = "Save";
            this.ribbonSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "ribbonButton2";
            // 
            // ribbonExit
            // 
            this.ribbonExit.Image = ((System.Drawing.Image)(resources.GetObject("ribbonExit.Image")));
            this.ribbonExit.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonExit.SmallImage")));
            this.ribbonExit.Text = "Exit";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.ribbonShowCancelled);
            this.ribbonPanel2.Items.Add(this.ribbonShowOnHiatus);
            this.ribbonPanel2.Items.Add(this.ribbonShowSkipWeek);
            this.ribbonPanel2.Text = "View";
            // 
            // ribbonShowCancelled
            // 
            this.ribbonShowCancelled.Text = "Show Cancelled";
            this.ribbonShowCancelled.CheckBoxCheckChanged += new System.EventHandler(this.ribbonShowCancelled_CheckBoxCheckChanged);
            // 
            // ribbonShowOnHiatus
            // 
            this.ribbonShowOnHiatus.Text = "Show On Hiatus";
            this.ribbonShowOnHiatus.CheckBoxCheckChanged += new System.EventHandler(this.ribbonShowOnHiatus_CheckBoxCheckChanged);
            // 
            // ribbonShowSkipWeek
            // 
            this.ribbonShowSkipWeek.Text = "Show Skipped Shows";
            this.ribbonShowSkipWeek.CheckBoxCheckChanged += new System.EventHandler(this.ribbonShowSkipWeek_CheckBoxCheckChanged);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.ribbonAddShow);
            this.ribbonPanel3.Items.Add(this.ribbonModifyShow);
            this.ribbonPanel3.Items.Add(this.ribbonDelete);
            this.ribbonPanel3.Text = "Change Show";
            // 
            // ribbonAddShow
            // 
            this.ribbonAddShow.Image = ((System.Drawing.Image)(resources.GetObject("ribbonAddShow.Image")));
            this.ribbonAddShow.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonAddShow.SmallImage")));
            this.ribbonAddShow.Text = "Add Show";
            this.ribbonAddShow.ToolTip = "Add new show";
            this.ribbonAddShow.Click += new System.EventHandler(this.listmenuAddNew_Click);
            // 
            // ribbonModifyShow
            // 
            this.ribbonModifyShow.Image = ((System.Drawing.Image)(resources.GetObject("ribbonModifyShow.Image")));
            this.ribbonModifyShow.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonModifyShow.SmallImage")));
            this.ribbonModifyShow.Text = "Modify Show";
            this.ribbonModifyShow.ToolTip = "Modify the selected show";
            this.ribbonModifyShow.Click += new System.EventHandler(this.listmenuModify_Click);
            // 
            // ribbonDelete
            // 
            this.ribbonDelete.Image = ((System.Drawing.Image)(resources.GetObject("ribbonDelete.Image")));
            this.ribbonDelete.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonDelete.SmallImage")));
            this.ribbonDelete.Text = "Delete Show";
            this.ribbonDelete.ToolTip = "Delete the selected show";
            this.ribbonDelete.Click += new System.EventHandler(this.listmenuDelete_Click);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.ribbonClearChecks);
            this.ribbonPanel4.Text = "Checks";
            // 
            // ribbonClearChecks
            // 
            this.ribbonClearChecks.Image = ((System.Drawing.Image)(resources.GetObject("ribbonClearChecks.Image")));
            this.ribbonClearChecks.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonClearChecks.SmallImage")));
            this.ribbonClearChecks.Text = "Clear Checks";
            this.ribbonClearChecks.Click += new System.EventHandler(this.ribbonClearChecks_Click);
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.Image")));
            this.ribbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.SmallImage")));
            this.ribbonOrbMenuItem1.Text = "ribbonOrbMenuItem1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.colorMissedWeek);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.colorDownloaded);
            this.groupBox2.Controls.Add(this.colorSkipped);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.colorNotDownloaded);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(776, 537);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 157);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Legend";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Missed Week";
            // 
            // colorMissedWeek
            // 
            this.colorMissedWeek.BackColor = System.Drawing.Color.HotPink;
            this.colorMissedWeek.Location = new System.Drawing.Point(107, 125);
            this.colorMissedWeek.Name = "colorMissedWeek";
            this.colorMissedWeek.Size = new System.Drawing.Size(68, 18);
            this.colorMissedWeek.TabIndex = 6;
            this.colorMissedWeek.Click += new System.EventHandler(this.colorMissedWeek_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Not Downloaded";
            // 
            // colorDownloaded
            // 
            this.colorDownloaded.BackColor = System.Drawing.Color.SpringGreen;
            this.colorDownloaded.Location = new System.Drawing.Point(107, 26);
            this.colorDownloaded.Name = "colorDownloaded";
            this.colorDownloaded.Size = new System.Drawing.Size(68, 18);
            this.colorDownloaded.TabIndex = 0;
            this.colorDownloaded.Click += new System.EventHandler(this.colorDownloaded_Click);
            // 
            // colorSkipped
            // 
            this.colorSkipped.BackColor = System.Drawing.Color.LightYellow;
            this.colorSkipped.Location = new System.Drawing.Point(107, 58);
            this.colorSkipped.Name = "colorSkipped";
            this.colorSkipped.Size = new System.Drawing.Size(68, 18);
            this.colorSkipped.TabIndex = 1;
            this.colorSkipped.Click += new System.EventHandler(this.colorSkipped_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Skipped";
            // 
            // colorNotDownloaded
            // 
            this.colorNotDownloaded.BackColor = System.Drawing.Color.Tomato;
            this.colorNotDownloaded.Location = new System.Drawing.Point(107, 94);
            this.colorNotDownloaded.Name = "colorNotDownloaded";
            this.colorNotDownloaded.Size = new System.Drawing.Size(68, 18);
            this.colorNotDownloaded.TabIndex = 2;
            this.colorNotDownloaded.Click += new System.EventHandler(this.colorNotDownloaded_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Downloaded";
            // 
            // downloadedColorPicker
            // 
            this.downloadedColorPicker.Color = System.Drawing.Color.SpringGreen;
            this.downloadedColorPicker.SolidColorOnly = true;
            // 
            // skippedColorPicker
            // 
            this.skippedColorPicker.Color = System.Drawing.Color.LightYellow;
            this.skippedColorPicker.SolidColorOnly = true;
            // 
            // notdownloadColorPicker
            // 
            this.notdownloadColorPicker.Color = System.Drawing.Color.Tomato;
            this.notdownloadColorPicker.SolidColorOnly = true;
            // 
            // listselectiontimer
            // 
            this.listselectiontimer.Enabled = true;
            this.listselectiontimer.Interval = 250;
            this.listselectiontimer.Tick += new System.EventHandler(this.listselectiontimer_Tick);
            // 
            // missedweekColorPicker
            // 
            this.missedweekColorPicker.Color = System.Drawing.Color.HotPink;
            this.missedweekColorPicker.FullOpen = true;
            this.missedweekColorPicker.SolidColorOnly = true;
            // 
            // ShowsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 706);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.showRibbon);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowsForm";
            this.ShowIcon = false;
            this.Text = "Shows Downloaded";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowsForm_FormClosing);
            this.Load += new System.EventHandler(this.ShowsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.listmenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDayofWeek;
        private GlacialComponents.Controls.GlacialList listShow;
        private System.Windows.Forms.RibbonUpDown ribbonUpDown1;
        private System.Windows.Forms.Ribbon showRibbon;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton ribbonSave;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.ContextMenuStrip listmenu;
        private System.Windows.Forms.ToolStripMenuItem listmenuAddNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem listmenuModify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem listmenuDelete;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonButton ribbonExit;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonCheckBox ribbonShowCancelled;
        private System.Windows.Forms.RibbonCheckBox ribbonShowOnHiatus;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton ribbonAddShow;
        private System.Windows.Forms.RibbonButton ribbonModifyShow;
        private System.Windows.Forms.RibbonButton ribbonDelete;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton ribbonClearChecks;
        private System.Windows.Forms.RibbonCheckBox ribbonShowSkipWeek;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label colorDownloaded;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label colorSkipped;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label colorNotDownloaded;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog downloadedColorPicker;
        private System.Windows.Forms.ColorDialog skippedColorPicker;
        private System.Windows.Forms.ColorDialog notdownloadColorPicker;
        private System.Windows.Forms.Timer listselectiontimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label colorMissedWeek;
        private System.Windows.Forms.ColorDialog missedweekColorPicker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem listmenuClearMissedWeek;
    }
}

