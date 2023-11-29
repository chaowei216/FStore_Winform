using BusinessObject.Models;
using DataAccess.Repository;
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
    public partial class frmMemberDetail : Form
    {
        public frmMemberDetail()
        {
            InitializeComponent();
        }

        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Member? MemberInfo { get; set; }

        private void txtPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCity.Items.Clear();
            cbCity.Text = "";
            if (cbCountry.SelectedIndex == 0)
            {
                cbCity.Items.Add("Ho Chi Minh");
                cbCity.Items.Add("Ha Noi");
                cbCity.Items.Add("Da Lat");
                cbCity.Items.Add("Vung Tau");
            } else if(cbCountry.SelectedIndex == 1)
            {
                cbCity.Items.Add("Busan");
                cbCity.Items.Add("Seoul");
                cbCity.Items.Add("Daegu");
                cbCity.Items.Add("Gwangju");
            } else if(cbCountry.SelectedIndex == 2)
            {
                cbCity.Items.Add("Tokyo");
                cbCity.Items.Add("Sapporo");
                cbCity.Items.Add("Sendai");
                cbCity.Items.Add("Kyoto");
            } else if( cbCountry.SelectedIndex == 3)
            {
                cbCity.Items.Add("Beijing");
                cbCity.Items.Add("Chongqing");
                cbCity.Items.Add("Guangzhou");
                cbCity.Items.Add("Chengdu");
            } else if(cbCountry.SelectedIndex == 4)
            {
                cbCity.Items.Add("New York");
                cbCity.Items.Add("Chicago");
                cbCity.Items.Add("San Diego");
                cbCity.Items.Add("Houston");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtCompanyName.Text == ""
                || cbCity.Text == "" || cbCountry.Text == "" ||
                txtPassword.Text == "")
            {
                MessageBox.Show("Please enter full field before saving!", "Create member");
                return;
            }

            if (MemberRepository.GetMemberByEmail(txtEmail.Text) != null)
                MessageBox.Show("Email is Existed!!!", "Create Member");
            else
            {
                try
                {
                    Member mem = new Member()
                    {
                        Email = txtEmail.Text,
                        CompanyName = txtCompanyName.Text,
                        Country = cbCountry.Text,
                        City = cbCity.Text,
                        Password = txtPassword.Text
                    };
                    MemberRepository.AddMember(mem);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,  "Create Member");
                }

            }
        }

        private void frmMemberDetail_Load(object sender, EventArgs e)
        {
            txtPassword.Enabled = !InsertOrUpdate;
            txtEmail.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtEmail.Text = MemberInfo.Email;
                txtCompanyName.Text = MemberInfo.CompanyName;
                cbCountry.Text = MemberInfo.Country;
                cbCity.Text = MemberInfo.City;
                txtPassword.Text = MemberInfo.Password;
            }
        }
    }
}
