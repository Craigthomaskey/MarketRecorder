namespace MarketRecorder
{
    partial class ContractControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CloseBttn = new System.Windows.Forms.Button();
            this.SettingsBttn = new System.Windows.Forms.Button();
            this.MainLabel = new System.Windows.Forms.Label();
            this.LastTradeLbl = new System.Windows.Forms.Label();
            this.TradeTypeLabl = new System.Windows.Forms.Label();
            this.AskVolumeLbl = new System.Windows.Forms.Label();
            this.BidVolumeLbl = new System.Windows.Forms.Label();
            this.LastPriceLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseBttn
            // 
            this.CloseBttn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.DeleteCont;
            this.CloseBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseBttn.FlatAppearance.BorderSize = 0;
            this.CloseBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseBttn.Location = new System.Drawing.Point(416, 4);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(22, 33);
            this.CloseBttn.TabIndex = 3;
            this.CloseBttn.Text = " ";
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // SettingsBttn
            // 
            this.SettingsBttn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.SettingsCont;
            this.SettingsBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SettingsBttn.FlatAppearance.BorderSize = 0;
            this.SettingsBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.SettingsBttn.Location = new System.Drawing.Point(387, 4);
            this.SettingsBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SettingsBttn.Name = "SettingsBttn";
            this.SettingsBttn.Size = new System.Drawing.Size(15, 33);
            this.SettingsBttn.TabIndex = 3;
            this.SettingsBttn.Text = " ";
            this.SettingsBttn.UseVisualStyleBackColor = true;
            this.SettingsBttn.Click += new System.EventHandler(this.SettingsBttn_Click);
            // 
            // MainLabel
            // 
            this.MainLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Location = new System.Drawing.Point(3, 3);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(109, 33);
            this.MainLabel.TabIndex = 4;
            this.MainLabel.Text = "HE Feb19 x Apr19";
            this.MainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LastTradeLbl
            // 
            this.LastTradeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LastTradeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastTradeLbl.Location = new System.Drawing.Point(118, 3);
            this.LastTradeLbl.Name = "LastTradeLbl";
            this.LastTradeLbl.Size = new System.Drawing.Size(46, 33);
            this.LastTradeLbl.TabIndex = 5;
            this.LastTradeLbl.Text = "N/A";
            this.LastTradeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TradeTypeLabl
            // 
            this.TradeTypeLabl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TradeTypeLabl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TradeTypeLabl.Location = new System.Drawing.Point(222, 3);
            this.TradeTypeLabl.Name = "TradeTypeLabl";
            this.TradeTypeLabl.Size = new System.Drawing.Size(46, 33);
            this.TradeTypeLabl.TabIndex = 5;
            this.TradeTypeLabl.Text = "N/A";
            this.TradeTypeLabl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AskVolumeLbl
            // 
            this.AskVolumeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AskVolumeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AskVolumeLbl.Location = new System.Drawing.Point(274, 3);
            this.AskVolumeLbl.Name = "AskVolumeLbl";
            this.AskVolumeLbl.Size = new System.Drawing.Size(46, 33);
            this.AskVolumeLbl.TabIndex = 5;
            this.AskVolumeLbl.Text = "N/A";
            this.AskVolumeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BidVolumeLbl
            // 
            this.BidVolumeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BidVolumeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BidVolumeLbl.Location = new System.Drawing.Point(326, 3);
            this.BidVolumeLbl.Name = "BidVolumeLbl";
            this.BidVolumeLbl.Size = new System.Drawing.Size(46, 33);
            this.BidVolumeLbl.TabIndex = 5;
            this.BidVolumeLbl.Text = "N/A";
            this.BidVolumeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LastPriceLbl
            // 
            this.LastPriceLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LastPriceLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastPriceLbl.Location = new System.Drawing.Point(170, 3);
            this.LastPriceLbl.Name = "LastPriceLbl";
            this.LastPriceLbl.Size = new System.Drawing.Size(46, 33);
            this.LastPriceLbl.TabIndex = 6;
            this.LastPriceLbl.Text = "N/A";
            this.LastPriceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContractControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.LastPriceLbl);
            this.Controls.Add(this.BidVolumeLbl);
            this.Controls.Add(this.AskVolumeLbl);
            this.Controls.Add(this.TradeTypeLabl);
            this.Controls.Add(this.LastTradeLbl);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SettingsBttn);
            this.Controls.Add(this.CloseBttn);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ContractControl";
            this.Size = new System.Drawing.Size(450, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseBttn;
        private System.Windows.Forms.Button SettingsBttn;
        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.Label LastTradeLbl;
        private System.Windows.Forms.Label TradeTypeLabl;
        private System.Windows.Forms.Label AskVolumeLbl;
        private System.Windows.Forms.Label BidVolumeLbl;
        private System.Windows.Forms.Label LastPriceLbl;
    }
}
