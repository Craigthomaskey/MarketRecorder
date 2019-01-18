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
            this.CloseBttn = new System.Windows.Forms.Button();
            this.SettingsBttn = new System.Windows.Forms.Button();
            this.MoveBttn = new System.Windows.Forms.Button();
            this.SizeBttn = new System.Windows.Forms.Button();
            this.MainContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SettingMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveContractsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseBttn
            // 
            this.CloseBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBttn.Location = new System.Drawing.Point(481, 5);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(74, 25);
            this.CloseBttn.TabIndex = 0;
            this.CloseBttn.Text = "Close";
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // SettingsBttn
            // 
            this.SettingsBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsBttn.Location = new System.Drawing.Point(481, 36);
            this.SettingsBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SettingsBttn.Name = "SettingsBttn";
            this.SettingsBttn.Size = new System.Drawing.Size(74, 25);
            this.SettingsBttn.TabIndex = 0;
            this.SettingsBttn.Text = "Settings";
            this.SettingsBttn.UseVisualStyleBackColor = true;
            this.SettingsBttn.Click += new System.EventHandler(this.SettingsBttn_Click);
            // 
            // MoveBttn
            // 
            this.MoveBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveBttn.Location = new System.Drawing.Point(481, 67);
            this.MoveBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MoveBttn.Name = "MoveBttn";
            this.MoveBttn.Size = new System.Drawing.Size(74, 25);
            this.MoveBttn.TabIndex = 0;
            this.MoveBttn.Text = "Move";
            this.MoveBttn.UseVisualStyleBackColor = true;
            this.MoveBttn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LocationMouseDown);
            this.MoveBttn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LocationMouseMove);
            this.MoveBttn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LocationMouseUp);
            // 
            // SizeBttn
            // 
            this.SizeBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SizeBttn.Location = new System.Drawing.Point(481, 450);
            this.SizeBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SizeBttn.Name = "SizeBttn";
            this.SizeBttn.Size = new System.Drawing.Size(74, 25);
            this.SizeBttn.TabIndex = 0;
            this.SizeBttn.Text = "Size";
            this.SizeBttn.UseVisualStyleBackColor = true;
            this.SizeBttn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SizeMouseDown);
            this.SizeBttn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SizeMouseMove);
            this.SizeBttn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SizeMouseUp);
            // 
            // MainContainer
            // 
            this.MainContainer.AllowDrop = true;
            this.MainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainContainer.AutoScroll = true;
            this.MainContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainContainer.Location = new System.Drawing.Point(3, 5);
            this.MainContainer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MainContainer.Size = new System.Drawing.Size(473, 470);
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
            this.saveContractsToolStripMenuItem});
            this.SettingMenu.Name = "SettingMenu";
            this.SettingMenu.ShowImageMargin = false;
            this.SettingMenu.Size = new System.Drawing.Size(156, 76);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.versionToolStripMenuItem.Text = "Version";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // saveContractsToolStripMenuItem
            // 
            this.saveContractsToolStripMenuItem.Name = "saveContractsToolStripMenuItem";
            this.saveContractsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveContractsToolStripMenuItem.Text = "Save Contracts";
            this.saveContractsToolStripMenuItem.Click += new System.EventHandler(this.saveContractsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 480);
            this.Controls.Add(this.SizeBttn);
            this.Controls.Add(this.MoveBttn);
            this.Controls.Add(this.SettingsBttn);
            this.Controls.Add(this.CloseBttn);
            this.Controls.Add(this.MainContainer);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximumSize = new System.Drawing.Size(560, 2000);
            this.MinimumSize = new System.Drawing.Size(560, 480);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
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
    }
}

