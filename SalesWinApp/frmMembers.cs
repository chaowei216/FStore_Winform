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
    public partial class frmMembers : Form
    {
        BindingSource source = new BindingSource();
        IMemberRepository memberRepository = new MemberRepository();
        private readonly string _role;
        private readonly string _email;
        public frmMembers()
        {
            InitializeComponent();
        }
        public frmMembers(string role, string email) : this()
        {
            _role = role;
            lbRole.Text = _role;
            _email = email;
        }
        private void ClearText()
        {
            txtMemberId.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            cbCity.Text = string.Empty;
            cbCountry.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private Member? GetMember()
        {
            Member? member = null;
            try
            {
                member = new Member()
                {
                    MemberId = int.Parse(txtMemberId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    Country = cbCountry.Text,
                    City = cbCity.Text,
                    Password = txtPassword.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Member");
            }
            return member;
        }

        public void LoadMemberList()
        {
            if (lbRole.Text == "Admin")
            {
                var members = memberRepository.GetMembers();
                try
                {
                    source.DataSource = members;
                    txtMemberId.DataBindings.Clear();
                    txtEmail.DataBindings.Clear();
                    txtCompanyName.DataBindings.Clear();
                    cbCity.DataBindings.Clear();
                    cbCountry.DataBindings.Clear();
                    txtPassword.DataBindings.Clear();

                    txtMemberId.DataBindings.Add("Text", source, "MemberId");
                    txtEmail.DataBindings.Add("Text", source, "Email");
                    txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                    cbCountry.DataBindings.Add("Text", source, "Country");
                    cbCity.DataBindings.Add("Text", source, "City");
                    txtPassword.DataBindings.Add("Text", source, "Password");

                    dgvMemberList.DataSource = source;
                    if (source == null)
                    {
                        ClearText();
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                        btnNew.Enabled = true;
                        btnUpdate.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load member list");
                }
            }
            else
            {
                var user = memberRepository.GetMemberByEmail(_email);
                try
                {
                    source.DataSource = user;
                    txtMemberId.DataBindings.Clear();
                    txtEmail.DataBindings.Clear();
                    txtCompanyName.DataBindings.Clear();
                    cbCity.DataBindings.Clear();
                    cbCountry.DataBindings.Clear();
                    txtPassword.DataBindings.Clear();

                    txtMemberId.DataBindings.Add("Text", source, "MemberId");
                    txtEmail.DataBindings.Add("Text", source, "Email");
                    txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                    cbCountry.DataBindings.Add("Text", source, "Country");
                    cbCity.DataBindings.Add("Text", source, "City");
                    txtPassword.DataBindings.Add("Text", source, "Password");

                    dgvMemberList.DataSource = source;
                    if (source == null)
                    {
                        ClearText();
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = false;
                        btnNew.Enabled = false;
                        btnUpdate.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load member list");
                }
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmMemberDetail frmMemberDetail = new frmMemberDetail()
            {
                Text = "Add Member",
                MemberRepository = memberRepository
            };
            if (frmMemberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!memberRepository.DeleteMember(int.Parse(txtMemberId.Text)))
                MessageBox.Show("Delete error!!", "Delete Member");
            else LoadMemberList();
            source.Position = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lbRole.Text == "Admin")
            {
                frmMemberDetail frmMemberDetail = new frmMemberDetail
                {
                    Text = "Update Member",
                    InsertOrUpdate = true,
                    MemberInfo = GetMember(),
                    MemberRepository = memberRepository
                };
                if (frmMemberDetail.ShowDialog() == DialogResult.OK)
                {
                    LoadMemberList();
                }
            }
            else
            {
                if (btnUpdate.Text == "Update")
                {
                    cbCountry.Enabled = true;
                    cbCity.Enabled = true;
                    txtCompanyName.Enabled = true;
                    txtPassword.Enabled = true;
                    btnUpdate.Text = "Commit";
                    btnDelete.Enabled = false;
                    btnCancel.Visible = true;
                }
                else if (btnUpdate.Text == "Commit")
                {
                    DialogResult confirmation = MessageBox.Show("Are you sure to update it?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirmation == DialogResult.OK)
                    {
                        txtCompanyName.Enabled = false;
                        cbCountry.Enabled = false;
                        cbCity.Enabled = false;
                        txtPassword.Enabled = false;
                        btnUpdate.Text = "Update";
                        btnDelete.Enabled = true;
                        btnCancel.Visible = false;
                        Member mem = new Member()
                        {
                            MemberId = int.Parse(txtMemberId.Text),
                            Email = txtEmail.Text,
                            CompanyName = txtCompanyName.Text,
                            Country = cbCountry.Text,
                            City = cbCity.Text,
                            Password = txtPassword.Text
                        };
                        if (!memberRepository.UpdateMember(mem))
                        {
                            MessageBox.Show("Fail to update member", "Update Member");
                        }
                        else
                        {
                            LoadMemberList();
                            source.Position = 0;
                        }

                    }
                }
            }
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
            }
            else if (cbCountry.SelectedIndex == 1)
            {
                cbCity.Items.Add("Busan");
                cbCity.Items.Add("Seoul");
                cbCity.Items.Add("Daegu");
                cbCity.Items.Add("Gwangju");
            }
            else if (cbCountry.SelectedIndex == 2)
            {
                cbCity.Items.Add("Tokyo");
                cbCity.Items.Add("Sapporo");
                cbCity.Items.Add("Sendai");
                cbCity.Items.Add("Kyoto");
            }
            else if (cbCountry.SelectedIndex == 3)
            {
                cbCity.Items.Add("Beijing");
                cbCity.Items.Add("Chongqing");
                cbCity.Items.Add("Guangzhou");
                cbCity.Items.Add("Chengdu");
            }
            else if (cbCountry.SelectedIndex == 4)
            {
                cbCity.Items.Add("New York");
                cbCity.Items.Add("Chicago");
                cbCity.Items.Add("San Diego");
                cbCity.Items.Add("Houston");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCompanyName.Enabled = false;
            cbCountry.Enabled = false;
            cbCity.Enabled = false;
            txtPassword.Enabled = false;
            btnUpdate.Text = "Update";
            btnDelete.Enabled = true;
            btnCancel.Visible = false;
            LoadMemberList();
        }


    }
}
