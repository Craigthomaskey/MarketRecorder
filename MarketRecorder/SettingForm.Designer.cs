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
            this.CloseBttn = new System.Windows.Forms.Button();
            this.NameLbl = new System.Windows.Forms.Label();
            this.SettingsScroll = new System.Windows.Forms.VScrollBar();
            this.MainContainer = new System.Windows.Forms.Panel();
            this.ScrollContainer = new System.Windows.Forms.Panel();
            this.RecordingTimeGroup.SuspendLayout();
            this.MainContainer.SuspendLayout();
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
            this.StartTimePicker.Size = new System.Drawing.Size(110, 20);
            this.StartTimePicker.TabIndex = 0;
            this.StartTimePicker.Value = new System.DateTime(2019, 1, 18, 12, 59, 0, 0);
            this.StartTimePicker.ValueChanged += new System.EventHandler(this.StartTimePicker_ValueChanged);
            // 
            // StartTimeLbl
            // 
            this.StartTimeLbl.AutoSize = true;
            this.StartTimeLbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTimeLbl.Location = new System.Drawing.Point(6, 25);
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
            this.EndTimeLbl.Location = new System.Drawing.Point(6, 51);
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
            // CloseBttn
            // 
            this.CloseBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.Close;
            this.CloseBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseBttn.FlatAppearance.BorderSize = 0;
            this.CloseBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseBttn.Location = new System.Drawing.Point(215, 332);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(22, 22);
            this.CloseBttn.TabIndex = 5;
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
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
            this.SettingsScroll.Size = new System.Drawing.Size(20, 326);
            this.SettingsScroll.SmallChange = 25;
            this.SettingsScroll.TabIndex = 8;
            this.SettingsScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SettingsScroll_Scroll);
            // 
            // MainContainer
            // 
            this.MainContainer.Controls.Add(this.RecordingTimeGroup);
            this.MainContainer.Location = new System.Drawing.Point(1, 1);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Size = new System.Drawing.Size(211, 136);
            this.MainContainer.TabIndex = 9;
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
            this.ScrollContainer.Size = new System.Drawing.Size(240, 358);
            this.ScrollContainer.TabIndex = 10;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(240, 386);
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
    }
}