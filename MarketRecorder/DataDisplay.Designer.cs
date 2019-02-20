namespace MarketRecorder
{
    partial class DataDisplay
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
            this.DataWindow = new System.Windows.Forms.TextBox();
            this.SizeBttn = new System.Windows.Forms.Button();
            this.MoveBttn = new System.Windows.Forms.Button();
            this.CloseBttn = new System.Windows.Forms.Button();
            this.NameLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DataWindow
            // 
            this.DataWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataWindow.Location = new System.Drawing.Point(12, 13);
            this.DataWindow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DataWindow.Multiline = true;
            this.DataWindow.Name = "DataWindow";
            this.DataWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataWindow.Size = new System.Drawing.Size(657, 317);
            this.DataWindow.TabIndex = 0;
            // 
            // SizeBttn
            // 
            this.SizeBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SizeBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.Size;
            this.SizeBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SizeBttn.FlatAppearance.BorderSize = 0;
            this.SizeBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SizeBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.SizeBttn.Location = new System.Drawing.Point(633, 335);
            this.SizeBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SizeBttn.Name = "SizeBttn";
            this.SizeBttn.Size = new System.Drawing.Size(36, 24);
            this.SizeBttn.TabIndex = 1;
            this.SizeBttn.Text = " ";
            this.SizeBttn.UseVisualStyleBackColor = true;
            this.SizeBttn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SizeMouseDown);
            this.SizeBttn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SizeMouseMove);
            this.SizeBttn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SizeMouseUp);
            // 
            // MoveBttn
            // 
            this.MoveBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.Move;
            this.MoveBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MoveBttn.FlatAppearance.BorderSize = 0;
            this.MoveBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.MoveBttn.Location = new System.Drawing.Point(601, 336);
            this.MoveBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MoveBttn.Name = "MoveBttn";
            this.MoveBttn.Size = new System.Drawing.Size(25, 24);
            this.MoveBttn.TabIndex = 2;
            this.MoveBttn.Text = " ";
            this.MoveBttn.UseVisualStyleBackColor = true;
            this.MoveBttn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LocationMouseDown);
            this.MoveBttn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LocationMouseMove);
            this.MoveBttn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LocationMouseUp);
            // 
            // CloseBttn
            // 
            this.CloseBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBttn.BackgroundImage = global::MarketRecorder.Properties.Resources.Close;
            this.CloseBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseBttn.FlatAppearance.BorderSize = 0;
            this.CloseBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseBttn.Location = new System.Drawing.Point(568, 336);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(22, 23);
            this.CloseBttn.TabIndex = 6;
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // NameLbl
            // 
            this.NameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameLbl.Location = new System.Drawing.Point(12, 337);
            this.NameLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(533, 19);
            this.NameLbl.TabIndex = 7;
            this.NameLbl.Text = "Type";
            // 
            // DataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 365);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.CloseBttn);
            this.Controls.Add(this.SizeBttn);
            this.Controls.Add(this.MoveBttn);
            this.Controls.Add(this.DataWindow);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "DataDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Current Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DataWindow;
        private System.Windows.Forms.Button SizeBttn;
        private System.Windows.Forms.Button MoveBttn;
        private System.Windows.Forms.Button CloseBttn;
        private System.Windows.Forms.Label NameLbl;
    }
}