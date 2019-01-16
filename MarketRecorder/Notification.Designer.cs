namespace MarketRecorder
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
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.CloseBttn = new System.Windows.Forms.Button();
            this.DurrationTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Location = new System.Drawing.Point(45, 4);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(347, 31);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "This is a notification in case you need to know something!";
            this.MainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IconBox
            // 
            this.IconBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.IconBox.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.IconBox.Location = new System.Drawing.Point(6, 4);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(33, 31);
            this.IconBox.TabIndex = 1;
            this.IconBox.TabStop = false;
            // 
            // CloseBttn
            // 
            this.CloseBttn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBttn.Location = new System.Drawing.Point(397, 4);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(50, 31);
            this.CloseBttn.TabIndex = 2;
            this.CloseBttn.Text = "Close";
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // DurrationTimer
            // 
            this.DurrationTimer.Enabled = true;
            this.DurrationTimer.Interval = 5000;
            this.DurrationTimer.Tick += new System.EventHandler(this.DurrationTimer_Tick);
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 40);
            this.Controls.Add(this.CloseBttn);
            this.Controls.Add(this.IconBox);
            this.Controls.Add(this.MainLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notification";
            this.Text = "Notification";
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.PictureBox IconBox;
        private System.Windows.Forms.Button CloseBttn;
        private System.Windows.Forms.Timer DurrationTimer;
    }
}