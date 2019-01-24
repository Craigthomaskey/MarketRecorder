namespace MarketRecorder
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MainContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SettingMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveContractsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeOnCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataUpdateSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.secondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SizeBttn = new System.Windows.Forms.Button();
            this.MoveBttn = new System.Windows.Forms.Button();
            this.SettingsBttn = new System.Windows.Forms.Button();
            this.CloseBttn = new System.Windows.Forms.Button();
            this.SettingMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            this.MainContainer.AllowDrop = true;
            this.MainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MainContainer.AutoScroll = true;
            this.MainContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainContainer.Location = new System.Drawing.Point(3, 5);
            this.MainContainer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MainContainer.Size = new System.Drawing.Size(473, 190);
            this.MainContainer.TabIndex = 1;
            this.MainContainer.WrapContents = false;
            this.MainContainer.DragDrop += new System.Windows.Forms.DragEventHandler(this.ContDragDrop);
            this.MainContainer.DragOver += new System.Windows.Forms.DragEventHandler(this.ContDragOver);
            // 
            // SettingMenu
            // 
            this.SettingMenu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveContractsToolStripMenuItem,
            this.writeDataToolStripMenuItem,
            this.writeOnCloseToolStripMenuItem,
            this.dataUpdateSpeedToolStripMenuItem,
            this.pauseRecordingToolStripMenuItem,
            this.notificationsToolStripMenuItem,
            this.sIMToolStripMenuItem});
            this.SettingMenu.Name = "SettingMenu";
            this.SettingMenu.ShowImageMargin = false;
            this.SettingMenu.Size = new System.Drawing.Size(158, 186);
            this.SettingMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.SettingMenu_Closing);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // saveContractsToolStripMenuItem
            // 
            this.saveContractsToolStripMenuItem.Name = "saveContractsToolStripMenuItem";
            this.saveContractsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveContractsToolStripMenuItem.Text = "Save Contracts";
            this.saveContractsToolStripMenuItem.Click += new System.EventHandler(this.saveContractsToolStripMenuItem_Click);
            // 
            // writeDataToolStripMenuItem
            // 
            this.writeDataToolStripMenuItem.Name = "writeDataToolStripMenuItem";
            this.writeDataToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.writeDataToolStripMenuItem.Text = "Write Data";
            this.writeDataToolStripMenuItem.Click += new System.EventHandler(this.writeDataToolStripMenuItem_Click);
            // 
            // writeOnCloseToolStripMenuItem
            // 
            this.writeOnCloseToolStripMenuItem.Name = "writeOnCloseToolStripMenuItem";
            this.writeOnCloseToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.writeOnCloseToolStripMenuItem.Text = "Write On Close";
            this.writeOnCloseToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_CheckedChanged);
            this.writeOnCloseToolStripMenuItem.Click += new System.EventHandler(this.writeOnCloseToolStripMenuItem_Click);
            // 
            // dataUpdateSpeedToolStripMenuItem
            // 
            this.dataUpdateSpeedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secondsToolStripMenuItem1,
            this.secondsToolStripMenuItem,
            this.minuteToolStripMenuItem,
            this.minutesToolStripMenuItem,
            this.minutesToolStripMenuItem1,
            this.hourToolStripMenuItem});
            this.dataUpdateSpeedToolStripMenuItem.Name = "dataUpdateSpeedToolStripMenuItem";
            this.dataUpdateSpeedToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.dataUpdateSpeedToolStripMenuItem.Text = "Data Update Speed";
            // 
            // secondsToolStripMenuItem1
            // 
            this.secondsToolStripMenuItem1.Name = "secondsToolStripMenuItem1";
            this.secondsToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.secondsToolStripMenuItem1.Text = "15 Seconds";
            this.secondsToolStripMenuItem1.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_CheckedChanged);
            this.secondsToolStripMenuItem1.Click += new System.EventHandler(this.secondsToolStripMenuItem1_Click);
            // 
            // secondsToolStripMenuItem
            // 
            this.secondsToolStripMenuItem.Name = "secondsToolStripMenuItem";
            this.secondsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.secondsToolStripMenuItem.Text = "30 Seconds";
            this.secondsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_CheckedChanged);
            this.secondsToolStripMenuItem.Click += new System.EventHandler(this.secondsToolStripMenuItem_Click);
            // 
            // minuteToolStripMenuItem
            // 
            this.minuteToolStripMenuItem.Name = "minuteToolStripMenuItem";
            this.minuteToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.minuteToolStripMenuItem.Text = "1 Minute";
            this.minuteToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_CheckedChanged);
            this.minuteToolStripMenuItem.Click += new System.EventHandler(this.minuteToolStripMenuItem_Click);
            // 
            // minutesToolStripMenuItem
            // 
            this.minutesToolStripMenuItem.Name = "minutesToolStripMenuItem";
            this.minutesToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.minutesToolStripMenuItem.Text = "2 Minutes";
            this.minutesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_CheckedChanged);
            this.minutesToolStripMenuItem.Click += new System.EventHandler(this.minutesToolStripMenuItem_Click);
            // 
            // minutesToolStripMenuItem1
            // 
            this.minutesToolStripMenuItem1.Name = "minutesToolStripMenuItem1";
            this.minutesToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.minutesToolStripMenuItem1.Text = "5 Minutes";
            this.minutesToolStripMenuItem1.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_CheckedChanged);
            this.minutesToolStripMenuItem1.Click += new System.EventHandler(this.minutesToolStripMenuItem1_Click);
            // 
            // hourToolStripMenuItem
            // 
            this.hourToolStripMenuItem.Name = "hourToolStripMenuItem";
            this.hourToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.hourToolStripMenuItem.Text = "1 Hour";
            this.hourToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_CheckedChanged);
            this.hourToolStripMenuItem.Click += new System.EventHandler(this.hourToolStripMenuItem_Click);
            // 
            // pauseRecordingToolStripMenuItem
            // 
            this.pauseRecordingToolStripMenuItem.Name = "pauseRecordingToolStripMenuItem";
            this.pauseRecordingToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.pauseRecordingToolStripMenuItem.Text = "Pause Recording";
            this.pauseRecordingToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_CheckedChanged);
            this.pauseRecordingToolStripMenuItem.Click += new System.EventHandler(this.pauseRecordingToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.notificationsToolStripMenuItem.Text = "Notifications";
            this.notificationsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_CheckedChanged);
            this.notificationsToolStripMenuItem.Click += new System.EventHandler(this.notificationsToolStripMenuItem_Click);
            // 
            // sIMToolStripMenuItem
            // 
            this.sIMToolStripMenuItem.Name = "sIMToolStripMenuItem";
            this.sIMToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.sIMToolStripMenuItem.Text = "SIM";
            this.sIMToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_CheckedChanged);
            this.sIMToolStripMenuItem.Click += new System.EventHandler(this.sIMToolStripMenuItem_Click);
            // 
            // SizeBttn
            // 
            this.SizeBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SizeBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.Size;
            this.SizeBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SizeBttn.FlatAppearance.BorderSize = 0;
            this.SizeBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SizeBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.SizeBttn.Location = new System.Drawing.Point(480, 164);
            this.SizeBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SizeBttn.Name = "SizeBttn";
            this.SizeBttn.Size = new System.Drawing.Size(36, 25);
            this.SizeBttn.TabIndex = 0;
            this.SizeBttn.Text = " ";
            this.SizeBttn.UseVisualStyleBackColor = true;
            this.SizeBttn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SizeMouseDown);
            this.SizeBttn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SizeMouseMove);
            this.SizeBttn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SizeMouseUp);
            // 
            // MoveBttn
            // 
            this.MoveBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.Move;
            this.MoveBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MoveBttn.FlatAppearance.BorderSize = 0;
            this.MoveBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.MoveBttn.Location = new System.Drawing.Point(480, 105);
            this.MoveBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MoveBttn.Name = "MoveBttn";
            this.MoveBttn.Size = new System.Drawing.Size(36, 25);
            this.MoveBttn.TabIndex = 0;
            this.MoveBttn.Text = " ";
            this.MoveBttn.UseVisualStyleBackColor = true;
            this.MoveBttn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LocationMouseDown);
            this.MoveBttn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LocationMouseMove);
            this.MoveBttn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LocationMouseUp);
            // 
            // SettingsBttn
            // 
            this.SettingsBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.Settings;
            this.SettingsBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SettingsBttn.FlatAppearance.BorderSize = 0;
            this.SettingsBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.SettingsBttn.Location = new System.Drawing.Point(480, 60);
            this.SettingsBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SettingsBttn.Name = "SettingsBttn";
            this.SettingsBttn.Size = new System.Drawing.Size(36, 25);
            this.SettingsBttn.TabIndex = 0;
            this.SettingsBttn.Text = " ";
            this.SettingsBttn.UseVisualStyleBackColor = true;
            this.SettingsBttn.Click += new System.EventHandler(this.SettingsBttn_Click);
            // 
            // CloseBttn
            // 
            this.CloseBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.Power;
            this.CloseBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseBttn.FlatAppearance.BorderSize = 0;
            this.CloseBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseBttn.Location = new System.Drawing.Point(480, 14);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(36, 25);
            this.CloseBttn.TabIndex = 0;
            this.CloseBttn.Text = " ";
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 200);
            this.Controls.Add(this.SizeBttn);
            this.Controls.Add(this.MoveBttn);
            this.Controls.Add(this.SettingsBttn);
            this.Controls.Add(this.CloseBttn);
            this.Controls.Add(this.MainContainer);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximumSize = new System.Drawing.Size(526, 2000);
            this.MinimumSize = new System.Drawing.Size(526, 200);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Market Recorder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ContDragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.ContDragOver);
            this.SettingMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseBttn;
        private System.Windows.Forms.Button SettingsBttn;
        private System.Windows.Forms.Button MoveBttn;
        private System.Windows.Forms.Button SizeBttn;
        private System.Windows.Forms.FlowLayoutPanel MainContainer;
        private System.Windows.Forms.ContextMenuStrip SettingMenu;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveContractsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataUpdateSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem secondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseRecordingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sIMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeOnCloseToolStripMenuItem;
    }
}

