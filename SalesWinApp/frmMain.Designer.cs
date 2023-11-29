namespace SalesWinApp
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.roleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFstore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMember = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIconSort = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascadeSort = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHorizontalSort = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerticalSort = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roleToolStripMenuItem,
            this.mnuFstore,
            this.mnuOrder,
            this.mnuMember,
            this.toolsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // roleToolStripMenuItem
            // 
            this.roleToolStripMenuItem.BackColor = System.Drawing.Color.Cyan;
            this.roleToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roleToolStripMenuItem.Name = "roleToolStripMenuItem";
            this.roleToolStripMenuItem.Size = new System.Drawing.Size(14, 24);
            // 
            // mnuFstore
            // 
            this.mnuFstore.Name = "mnuFstore";
            this.mnuFstore.Size = new System.Drawing.Size(63, 24);
            this.mnuFstore.Text = "&Fstore";
            this.mnuFstore.Click += new System.EventHandler(this.mnuFstore_Click_1);
            // 
            // mnuOrder
            // 
            this.mnuOrder.Name = "mnuOrder";
            this.mnuOrder.Size = new System.Drawing.Size(61, 24);
            this.mnuOrder.Text = "&Order";
            this.mnuOrder.Click += new System.EventHandler(this.mnuOrder_Click_1);
            // 
            // mnuMember
            // 
            this.mnuMember.Name = "mnuMember";
            this.mnuMember.Size = new System.Drawing.Size(79, 24);
            this.mnuMember.Text = "&Member";
            this.mnuMember.Click += new System.EventHandler(this.mnuMember_Click_1);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.toolsToolStripMenuItem.Text = "&View";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIconSort,
            this.mnuCascadeSort,
            this.mnuHorizontalSort,
            this.mnuVerticalSort});
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.customizeToolStripMenuItem.Text = "&Sort";
            // 
            // mnuIconSort
            // 
            this.mnuIconSort.Image = global::SalesWinApp.Properties.Resources.Dominicanjoker_Comic_Publisher_Folder_Icon_512;
            this.mnuIconSort.Name = "mnuIconSort";
            this.mnuIconSort.Size = new System.Drawing.Size(162, 26);
            this.mnuIconSort.Text = "&Icon";
            // 
            // mnuCascadeSort
            // 
            this.mnuCascadeSort.Image = global::SalesWinApp.Properties.Resources.Saki_NuoveXT_Actions_view_symbol_128;
            this.mnuCascadeSort.Name = "mnuCascadeSort";
            this.mnuCascadeSort.Size = new System.Drawing.Size(162, 26);
            this.mnuCascadeSort.Text = "&Cascade";
            // 
            // mnuHorizontalSort
            // 
            this.mnuHorizontalSort.Image = global::SalesWinApp.Properties.Resources.Tpdkdesign_net_Refresh_Cl_Windows_View_Icon_256;
            this.mnuHorizontalSort.Name = "mnuHorizontalSort";
            this.mnuHorizontalSort.Size = new System.Drawing.Size(162, 26);
            this.mnuHorizontalSort.Text = "&Horizontal";
            // 
            // mnuVerticalSort
            // 
            this.mnuVerticalSort.Image = global::SalesWinApp.Properties.Resources.Tpdkdesign_net_Refresh_Cl_Windows_View_Detail_256;
            this.mnuVerticalSort.Name = "mnuVerticalSort";
            this.mnuVerticalSort.Size = new System.Drawing.Size(162, 26);
            this.mnuVerticalSort.Text = "&Vertical";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click_1);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem mnuIconSort;
        private ToolStripMenuItem mnuCascadeSort;
        private ToolStripMenuItem mnuHorizontalSort;
        private ToolStripMenuItem mnuVerticalSort;
        private ToolStripMenuItem mnuFstore;
        private ToolStripMenuItem mnuOrder;
        private ToolStripMenuItem mnuMember;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem roleToolStripMenuItem;
    }
}