namespace MarketRecorder
{
    partial class SettingForm
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
            this.StartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartTimeLbl = new System.Windows.Forms.Label();
            this.EndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndTimeLbl = new System.Windows.Forms.Label();
            this.AllDayCheck = new System.Windows.Forms.CheckBox();
            this.SeprateFileCheck = new System.Windows.Forms.CheckBox();
            this.RecordingTimeGroup = new System.Windows.Forms.GroupBox();
            this.NameLbl = new System.Windows.Forms.Label();
            this.SettingsScroll = new System.Windows.Forms.VScrollBar();
            this.MainContainer = new System.Windows.Forms.Panel();
            this.DriveOptionsGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DriveUploadTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DriveAutoUploadCheck = new System.Windows.Forms.CheckBox();
            this.DriveAutoConnectCheck = new System.Windows.Forms.CheckBox();
            this.DriveUploadButton = new System.Windows.Forms.Button();
            this.DriveConnectButton = new System.Windows.Forms.Button();
            this.FileCountLbl = new System.Windows.Forms.Label();
            this.DriveAutoUploadGroup = new System.Windows.Forms.GroupBox();
            this.DriveUploadAllNoneBttn = new System.Windows.Forms.Button();
            this.DriveWindowFilesCheck = new System.Windows.Forms.CheckBox();
            this.DriveMainFileCheck = new System.Windows.Forms.CheckBox();
            this.DriveConnectionLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ScrollContainer = new System.Windows.Forms.Panel();
            this.CloseBttn = new System.Windows.Forms.Button();
            this.LastUploadLBL = new System.Windows.Forms.Label();
            this.RecordingTimeGroup.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.DriveOptionsGroup.SuspendLayout();
            this.DriveAutoUploadGroup.SuspendLayout();
            this.ScrollContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartTimePicker
            // 
            this.StartTimePicker.CustomFormat = "HH:mm:ss";
            this.StartTimePicker.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartTimePicker.Location = new System.Drawing.Point(73, 23);
            this.StartTimePicker.Name = "StartTimePicker";
            this.StartTimePicker.ShowUpDown = true;
            this.StartTimePicker.Size = new System.Drawing.Size(111, 20);
            this.StartTimePicker.TabIndex = 0;
            this.StartTimePicker.Value = new System.DateTime(2019, 1, 18, 12, 59, 0, 0);
            this.StartTimePicker.ValueChanged += new System.EventHandler(this.StartTimePicker_ValueChanged);
            // 
            // StartTimeLbl
            // 
            this.StartTimeLbl.AutoSize = true;
            this.StartTimeLbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTimeLbl.Location = new System.Drawing.Point(8, 25);
            this.StartTimeLbl.Name = "StartTimeLbl";
            this.StartTimeLbl.Size = new System.Drawing.Size(61, 14);
            this.StartTimeLbl.TabIndex = 1;
            this.StartTimeLbl.Text = "Start time : ";
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.CustomFormat = "HH:mm:ss";
            this.EndTimePicker.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndTimePicker.Location = new System.Drawing.Point(73, 49);
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.ShowUpDown = true;
            this.EndTimePicker.Size = new System.Drawing.Size(110, 20);
            this.EndTimePicker.TabIndex = 0;
            this.EndTimePicker.Value = new System.DateTime(2019, 1, 18, 13, 0, 0, 0);
            this.EndTimePicker.ValueChanged += new System.EventHandler(this.EndTimePicker_ValueChanged);
            // 
            // EndTimeLbl
            // 
            this.EndTimeLbl.AutoSize = true;
            this.EndTimeLbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndTimeLbl.Location = new System.Drawing.Point(8, 51);
            this.EndTimeLbl.Name = "EndTimeLbl";
            this.EndTimeLbl.Size = new System.Drawing.Size(56, 14);
            this.EndTimeLbl.TabIndex = 1;
            this.EndTimeLbl.Text = "End time : ";
            // 
            // AllDayCheck
            // 
            this.AllDayCheck.AutoSize = true;
            this.AllDayCheck.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllDayCheck.Location = new System.Drawing.Point(9, 99);
            this.AllDayCheck.Name = "AllDayCheck";
            this.AllDayCheck.Size = new System.Drawing.Size(95, 18);
            this.AllDayCheck.TabIndex = 2;
            this.AllDayCheck.Text = "Record all day";
            this.AllDayCheck.UseVisualStyleBackColor = true;
            this.AllDayCheck.CheckedChanged += new System.EventHandler(this.AllDayCheck_CheckedChanged);
            // 
            // SeprateFileCheck
            // 
            this.SeprateFileCheck.AutoSize = true;
            this.SeprateFileCheck.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeprateFileCheck.Location = new System.Drawing.Point(9, 75);
            this.SeprateFileCheck.Name = "SeprateFileCheck";
            this.SeprateFileCheck.Size = new System.Drawing.Size(147, 18);
            this.SeprateFileCheck.TabIndex = 3;
            this.SeprateFileCheck.Text = "Seperate file for window";
            this.SeprateFileCheck.UseVisualStyleBackColor = true;
            this.SeprateFileCheck.CheckedChanged += new System.EventHandler(this.SeprateFileCheck_CheckedChanged);
            // 
            // RecordingTimeGroup
            // 
            this.RecordingTimeGroup.Controls.Add(this.StartTimeLbl);
            this.RecordingTimeGroup.Controls.Add(this.SeprateFileCheck);
            this.RecordingTimeGroup.Controls.Add(this.StartTimePicker);
            this.RecordingTimeGroup.Controls.Add(this.AllDayCheck);
            this.RecordingTimeGroup.Controls.Add(this.EndTimePicker);
            this.RecordingTimeGroup.Controls.Add(this.EndTimeLbl);
            this.RecordingTimeGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecordingTimeGroup.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordingTimeGroup.Location = new System.Drawing.Point(5, 3);
            this.RecordingTimeGroup.Name = "RecordingTimeGroup";
            this.RecordingTimeGroup.Size = new System.Drawing.Size(200, 124);
            this.RecordingTimeGroup.TabIndex = 4;
            this.RecordingTimeGroup.TabStop = false;
            this.RecordingTimeGroup.Text = "Recording Time Options";
            // 
            // NameLbl
            // 
            this.NameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameLbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLbl.Location = new System.Drawing.Point(10, 5);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(225, 20);
            this.NameLbl.TabIndex = 6;
            this.NameLbl.Text = "Name";
            this.NameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SettingsScroll
            // 
            this.SettingsScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SettingsScroll.LargeChange = 50;
            this.SettingsScroll.Location = new System.Drawing.Point(216, 3);
            this.SettingsScroll.Maximum = 300;
            this.SettingsScroll.Name = "SettingsScroll";
            this.SettingsScroll.Size = new System.Drawing.Size(20, 596);
            this.SettingsScroll.SmallChange = 25;
            this.SettingsScroll.TabIndex = 8;
            this.SettingsScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SettingsScroll_Scroll);
            // 
            // MainContainer
            // 
            this.MainContainer.Controls.Add(this.DriveOptionsGroup);
            this.MainContainer.Controls.Add(this.RecordingTimeGroup);
            this.MainContainer.Location = new System.Drawing.Point(1, 1);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Size = new System.Drawing.Size(211, 413);
            this.MainContainer.TabIndex = 9;
            // 
            // DriveOptionsGroup
            // 
            this.DriveOptionsGroup.Controls.Add(this.LastUploadLBL);
            this.DriveOptionsGroup.Controls.Add(this.label2);
            this.DriveOptionsGroup.Controls.Add(this.DriveUploadTimePicker);
            this.DriveOptionsGroup.Controls.Add(this.DriveAutoUploadCheck);
            this.DriveOptionsGroup.Controls.Add(this.DriveAutoConnectCheck);
            this.DriveOptionsGroup.Controls.Add(this.DriveUploadButton);
            this.DriveOptionsGroup.Controls.Add(this.DriveConnectButton);
            this.DriveOptionsGroup.Controls.Add(this.FileCountLbl);
            this.DriveOptionsGroup.Controls.Add(this.DriveAutoUploadGroup);
            this.DriveOptionsGroup.Controls.Add(this.DriveConnectionLbl);
            this.DriveOptionsGroup.Controls.Add(this.label1);
            this.DriveOptionsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DriveOptionsGroup.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveOptionsGroup.Location = new System.Drawing.Point(5, 133);
            this.DriveOptionsGroup.Name = "DriveOptionsGroup";
            this.DriveOptionsGroup.Size = new System.Drawing.Size(200, 258);
            this.DriveOptionsGroup.TabIndex = 5;
            this.DriveOptionsGroup.TabStop = false;
            this.DriveOptionsGroup.Text = "Google Drive Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Upload Time : ";
            // 
            // DriveUploadTimePicker
            // 
            this.DriveUploadTimePicker.CustomFormat = "HH:mm:ss";
            this.DriveUploadTimePicker.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveUploadTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DriveUploadTimePicker.Location = new System.Drawing.Point(89, 202);
            this.DriveUploadTimePicker.Name = "DriveUploadTimePicker";
            this.DriveUploadTimePicker.ShowUpDown = true;
            this.DriveUploadTimePicker.Size = new System.Drawing.Size(95, 20);
            this.DriveUploadTimePicker.TabIndex = 6;
            this.DriveUploadTimePicker.Value = new System.DateTime(2019, 1, 18, 13, 20, 30, 0);
            this.DriveUploadTimePicker.ValueChanged += new System.EventHandler(this.DriveUploadTimePicker_ValueChanged);
            // 
            // DriveAutoUploadCheck
            // 
            this.DriveAutoUploadCheck.AutoSize = true;
            this.DriveAutoUploadCheck.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveAutoUploadCheck.Location = new System.Drawing.Point(12, 175);
            this.DriveAutoUploadCheck.Name = "DriveAutoUploadCheck";
            this.DriveAutoUploadCheck.Size = new System.Drawing.Size(85, 18);
            this.DriveAutoUploadCheck.TabIndex = 2;
            this.DriveAutoUploadCheck.Text = "Auto Upload";
            this.DriveAutoUploadCheck.UseVisualStyleBackColor = true;
            this.DriveAutoUploadCheck.CheckedChanged += new System.EventHandler(this.DriveAutoUploadCheck_CheckedChanged);
            // 
            // DriveAutoConnectCheck
            // 
            this.DriveAutoConnectCheck.AutoSize = true;
            this.DriveAutoConnectCheck.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveAutoConnectCheck.Location = new System.Drawing.Point(12, 51);
            this.DriveAutoConnectCheck.Name = "DriveAutoConnectCheck";
            this.DriveAutoConnectCheck.Size = new System.Drawing.Size(92, 18);
            this.DriveAutoConnectCheck.TabIndex = 2;
            this.DriveAutoConnectCheck.Text = "Auto Connect";
            this.DriveAutoConnectCheck.UseVisualStyleBackColor = true;
            this.DriveAutoConnectCheck.CheckedChanged += new System.EventHandler(this.DriveAutoConnectCheck_CheckedChanged);
            // 
            // DriveUploadButton
            // 
            this.DriveUploadButton.Enabled = false;
            this.DriveUploadButton.Location = new System.Drawing.Point(109, 173);
            this.DriveUploadButton.Name = "DriveUploadButton";
            this.DriveUploadButton.Size = new System.Drawing.Size(75, 23);
            this.DriveUploadButton.TabIndex = 5;
            this.DriveUploadButton.Text = "Upload";
            this.DriveUploadButton.UseVisualStyleBackColor = true;
            this.DriveUploadButton.Click += new System.EventHandler(this.DriveUploadButton_Click);
            // 
            // DriveConnectButton
            // 
            this.DriveConnectButton.Location = new System.Drawing.Point(108, 48);
            this.DriveConnectButton.Name = "DriveConnectButton";
            this.DriveConnectButton.Size = new System.Drawing.Size(75, 23);
            this.DriveConnectButton.TabIndex = 5;
            this.DriveConnectButton.Text = "Connect";
            this.DriveConnectButton.UseVisualStyleBackColor = true;
            this.DriveConnectButton.Click += new System.EventHandler(this.DriveConnectButton_Click);
            // 
            // FileCountLbl
            // 
            this.FileCountLbl.AutoSize = true;
            this.FileCountLbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileCountLbl.Location = new System.Drawing.Point(80, 76);
            this.FileCountLbl.Name = "FileCountLbl";
            this.FileCountLbl.Size = new System.Drawing.Size(13, 14);
            this.FileCountLbl.TabIndex = 4;
            this.FileCountLbl.Text = "0";
            // 
            // DriveAutoUploadGroup
            // 
            this.DriveAutoUploadGroup.Controls.Add(this.DriveUploadAllNoneBttn);
            this.DriveAutoUploadGroup.Controls.Add(this.DriveWindowFilesCheck);
            this.DriveAutoUploadGroup.Controls.Add(this.DriveMainFileCheck);
            this.DriveAutoUploadGroup.Location = new System.Drawing.Point(9, 98);
            this.DriveAutoUploadGroup.Name = "DriveAutoUploadGroup";
            this.DriveAutoUploadGroup.Size = new System.Drawing.Size(175, 69);
            this.DriveAutoUploadGroup.TabIndex = 3;
            this.DriveAutoUploadGroup.TabStop = false;
            this.DriveAutoUploadGroup.Text = "Auto Upload Options";
            // 
            // DriveUploadAllNoneBttn
            // 
            this.DriveUploadAllNoneBttn.Location = new System.Drawing.Point(119, 14);
            this.DriveUploadAllNoneBttn.Name = "DriveUploadAllNoneBttn";
            this.DriveUploadAllNoneBttn.Size = new System.Drawing.Size(50, 23);
            this.DriveUploadAllNoneBttn.TabIndex = 8;
            this.DriveUploadAllNoneBttn.Text = "Clear";
            this.DriveUploadAllNoneBttn.UseVisualStyleBackColor = true;
            this.DriveUploadAllNoneBttn.Click += new System.EventHandler(this.DriveUploadAllNoneBttn_Click);
            // 
            // DriveWindowFilesCheck
            // 
            this.DriveWindowFilesCheck.AutoSize = true;
            this.DriveWindowFilesCheck.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveWindowFilesCheck.Location = new System.Drawing.Point(10, 43);
            this.DriveWindowFilesCheck.Name = "DriveWindowFilesCheck";
            this.DriveWindowFilesCheck.Size = new System.Drawing.Size(91, 18);
            this.DriveWindowFilesCheck.TabIndex = 2;
            this.DriveWindowFilesCheck.Text = "Window Files";
            this.DriveWindowFilesCheck.UseVisualStyleBackColor = true;
            this.DriveWindowFilesCheck.CheckedChanged += new System.EventHandler(this.DriveWindowFilesCheck_CheckedChanged);
            // 
            // DriveMainFileCheck
            // 
            this.DriveMainFileCheck.AutoSize = true;
            this.DriveMainFileCheck.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveMainFileCheck.Location = new System.Drawing.Point(10, 19);
            this.DriveMainFileCheck.Name = "DriveMainFileCheck";
            this.DriveMainFileCheck.Size = new System.Drawing.Size(67, 18);
            this.DriveMainFileCheck.TabIndex = 2;
            this.DriveMainFileCheck.Text = "Main File";
            this.DriveMainFileCheck.UseVisualStyleBackColor = true;
            this.DriveMainFileCheck.CheckedChanged += new System.EventHandler(this.DriveMainFileCheck_CheckedChanged);
            // 
            // DriveConnectionLbl
            // 
            this.DriveConnectionLbl.AutoSize = true;
            this.DriveConnectionLbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveConnectionLbl.ForeColor = System.Drawing.Color.Maroon;
            this.DriveConnectionLbl.Location = new System.Drawing.Point(9, 27);
            this.DriveConnectionLbl.Name = "DriveConnectionLbl";
            this.DriveConnectionLbl.Size = new System.Drawing.Size(175, 14);
            this.DriveConnectionLbl.TabIndex = 1;
            this.DriveConnectionLbl.Text = "Connection Status : Not Connected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Count : ";
            // 
            // ScrollContainer
            // 
            this.ScrollContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollContainer.Controls.Add(this.SettingsScroll);
            this.ScrollContainer.Controls.Add(this.CloseBttn);
            this.ScrollContainer.Controls.Add(this.MainContainer);
            this.ScrollContainer.Location = new System.Drawing.Point(0, 30);
            this.ScrollContainer.Name = "ScrollContainer";
            this.ScrollContainer.Size = new System.Drawing.Size(240, 628);
            this.ScrollContainer.TabIndex = 10;
            // 
            // CloseBttn
            // 
            this.CloseBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.Close;
            this.CloseBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseBttn.FlatAppearance.BorderSize = 0;
            this.CloseBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseBttn.Location = new System.Drawing.Point(215, 602);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(22, 22);
            this.CloseBttn.TabIndex = 5;
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // LastUploadLBL
            // 
            this.LastUploadLBL.AutoSize = true;
            this.LastUploadLBL.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastUploadLBL.Location = new System.Drawing.Point(9, 232);
            this.LastUploadLBL.Name = "LastUploadLBL";
            this.LastUploadLBL.Size = new System.Drawing.Size(115, 14);
            this.LastUploadLBL.TabIndex = 8;
            this.LastUploadLBL.Text = "Last Upload : 00:00:00";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(240, 656);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.ScrollContainer);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SettingForm";
            this.RecordingTimeGroup.ResumeLayout(false);
            this.RecordingTimeGroup.PerformLayout();
            this.MainContainer.ResumeLayout(false);
            this.DriveOptionsGroup.ResumeLayout(false);
            this.DriveOptionsGroup.PerformLayout();
            this.DriveAutoUploadGroup.ResumeLayout(false);
            this.DriveAutoUploadGroup.PerformLayout();
            this.ScrollContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartTimePicker;
        private System.Windows.Forms.Label StartTimeLbl;
        private System.Windows.Forms.DateTimePicker EndTimePicker;
        private System.Windows.Forms.Label EndTimeLbl;
        private System.Windows.Forms.CheckBox AllDayCheck;
        private System.Windows.Forms.CheckBox SeprateFileCheck;
        private System.Windows.Forms.GroupBox RecordingTimeGroup;
        private System.Windows.Forms.Button CloseBttn;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.VScrollBar SettingsScroll;
        private System.Windows.Forms.Panel MainContainer;
        private System.Windows.Forms.Panel ScrollContainer;
        private System.Windows.Forms.GroupBox DriveOptionsGroup;
        private System.Windows.Forms.CheckBox DriveAutoUploadCheck;
        private System.Windows.Forms.CheckBox DriveAutoConnectCheck;
        private System.Windows.Forms.Button DriveUploadButton;
        private System.Windows.Forms.Button DriveConnectButton;
        private System.Windows.Forms.Label FileCountLbl;
        private System.Windows.Forms.GroupBox DriveAutoUploadGroup;
        private System.Windows.Forms.CheckBox DriveWindowFilesCheck;
        private System.Windows.Forms.CheckBox DriveMainFileCheck;
        private System.Windows.Forms.Label DriveConnectionLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DriveUploadTimePicker;
        private System.Windows.Forms.Button DriveUploadAllNoneBttn;
        private System.Windows.Forms.Label LastUploadLBL;
    }
}