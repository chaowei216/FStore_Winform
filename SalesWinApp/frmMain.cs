using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmMain : Form
    {
        private readonly string _role;
        private readonly string _email;
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string role, string email) : this()
        {
            _role = role;
            roleToolStripMenuItem.Text = _role;
            _email = email;
        }

        private void mnuVerticalSort_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuHorizontalSort_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuCascadeSort_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuIconSort_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuFstore_Click_1(object sender, EventArgs e)
        {
            if (roleToolStripMenuItem.Text == "Admin")
            {
                frmProducts frmProducts = new frmProducts("Admin", _email);
                frmProducts.MdiParent = this;
                frmProducts.Show();
            }
            else
            {
                frmProducts frmProducts = new frmProducts("User", _email);
                frmProducts.MdiParent = this;
                frmProducts.Show();
            }
        }

        private void mnuOrder_Click_1(object sender, EventArgs e)
        {
            if (roleToolStripMenuItem.Text == "Admin")
            {
                frmOrders frmOrders = new frmOrders("Admin", _email);
                frmOrders.MdiParent = this;
                frmOrders.Show();
            }
            else
            {
                frmOrders frmOrders = new frmOrders("User", _email);
                frmOrders.MdiParent = this;
                frmOrders.Show();
            }
        }

        private void mnuMember_Click_1(object sender, EventArgs e)
        {
            if (roleToolStripMenuItem.Text == "Admin")
            {
                frmMembers frmMembers = new frmMembers("Admin", _email);
                frmMembers.MdiParent = this;
                frmMembers.Show();
            }
            else
            {
                frmMembers frmMembers = new frmMembers("User", _email);
                frmMembers.MdiParent = this;
                frmMembers.Show();
            }
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            frmLogin f = new frmLogin();
            f.Show();
        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }
    }
}
