﻿namespace MarketRecorder
{
    partial class Notification
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
            this.MainLabel = new System.Windows.Forms.Label();
            this.CloseBttn = new System.Windows.Forms.Button();
            this.DurrationTimer = new System.Windows.Forms.Timer(this.components);
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.OptionsBttn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainLabel.Location = new System.Drawing.Point(50, 5);
            this.MainLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(373, 40);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "This is a notification in case you need to know something!";
            this.MainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainLabel.Click += new System.EventHandler(this.MainLabel_Click);
            // 
            // CloseBttn
            // 
            this.CloseBttn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.Close;
            this.CloseBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseBttn.FlatAppearance.BorderSize = 0;
            this.CloseBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseBttn.Location = new System.Drawing.Point(427, 5);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(18, 18);
            this.CloseBttn.TabIndex = 2;
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // DurrationTimer
            // 
            this.DurrationTimer.Enabled = true;
            this.DurrationTimer.Interval = 10000;
            this.DurrationTimer.Tick += new System.EventHandler(this.DurrationTimer_Tick);
            // 
            // IconBox
            // 
            this.IconBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.IconBox.BackColor = System.Drawing.SystemColors.Control;
            this.IconBox.Location = new System.Drawing.Point(6, 5);
            this.IconBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(40, 40);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconBox.TabIndex = 1;
            this.IconBox.TabStop = false;
            this.IconBox.Click += new System.EventHandler(this.IconBox_Click);
            // 
            // OptionsBttn
            // 
            this.OptionsBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.SettingsForNotificationsV2;
            this.OptionsBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OptionsBttn.Enabled = false;
            this.OptionsBttn.FlatAppearance.BorderSize = 0;
            this.OptionsBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionsBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.OptionsBttn.Location = new System.Drawing.Point(427, 27);
            this.OptionsBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.OptionsBttn.Name = "OptionsBttn";
            this.OptionsBttn.Size = new System.Drawing.Size(18, 18);
            this.OptionsBttn.TabIndex = 7;
            this.OptionsBttn.UseVisualStyleBackColor = true;
            this.OptionsBttn.Click += new System.EventHandler(this.OptionsBttn_Click);
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 50);
            this.Controls.Add(this.OptionsBttn);
            this.Controls.Add(this.CloseBttn);
            this.Controls.Add(this.IconBox);
            this.Controls.Add(this.MainLabel);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Notification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notification";
            this.Shown += new System.EventHandler(this.Notification_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.PictureBox IconBox;
        private System.Windows.Forms.Button CloseBttn;
        private System.Windows.Forms.Timer DurrationTimer;
        private System.Windows.Forms.Button OptionsBttn;
    }
}