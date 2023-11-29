using DataAccess.Repository;

namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        IMemberRepository member = new MemberRepository();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmMemberDetail f = new frmMemberDetail()
            {
                Text = "Register account",
                MemberRepository = member,
            };
            f.ShowDialog();
        }

        private void txtPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            var tmp = member.CheckLogin(txtEmail.Text, txtPassword.Text);
            if (tmp != null && tmp.MemberId == 0)
            {
                frmMain f = new frmMain("Admin", txtEmail.Text);
                f.ShowDialog();
                this.Hide();
            }
            else if (tmp != null && tmp.MemberId != 0)
            {
                frmMain f = new frmMain("User", txtEmail.Text);
                f.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Fail to login", "Login");
            }
        }
    }
}