using BusinessObject;
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
    public partial class frmOrders : Form
    {
        IOrderRepository orderRepository = new OrderRepository();
        IMemberRepository memberRepository = new MemberRepository();
        BindingSource source = new BindingSource();
        private readonly string _role;
        private readonly string _email;
        public frmOrders()
        {
            InitializeComponent();
        }

        public frmOrders(string role, string email) : this()
        {
            _role = role;
            lbRole.Text = _role;
            _email = email;
        }

        private void ClearText()
        {
            txtOrderId.Text = string.Empty;
            txtMemberId.Text = string.Empty;
            txtOrderDate.Text = string.Empty;
            txtRequiredDate.Text = string.Empty;
            txtShippedDate.Text = string.Empty;
            txtFreight.Text = string.Empty;
        }

        private void LoadOrderList()
        {
            if (lbRole.Text == "Admin")
            {
                List<Order> orderList = orderRepository.GetOrders().ToList();
                try
                {
                    source.DataSource = orderList;
                    txtOrderId.DataBindings.Clear();
                    txtMemberId.DataBindings.Clear();
                    txtOrderDate.DataBindings.Clear();
                    txtRequiredDate.DataBindings.Clear();
                    txtShippedDate.DataBindings.Clear();
                    txtFreight.DataBindings.Clear();

                    txtOrderId.DataBindings.Add("Text", source, "OrderID");
                    txtMemberId.DataBindings.Add("Text", source, "MemberID");
                    txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                    txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                    txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                    txtFreight.DataBindings.Add("Text", source, "Freight");

                    dgvOrderList.DataSource = null;
                    dgvOrderList.DataSource = source;
                    if (orderList.Count == 0)
                    {
                        ClearText();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load Order list");
                }
            }
            else
            {
                List<Order> orderList = orderRepository.GetOrderByMemberId(memberRepository.GetMemberByEmail(_email).MemberId).ToList();
                try
                {
                    source.DataSource = orderList;
                    txtOrderId.DataBindings.Clear();
                    txtMemberId.DataBindings.Clear();
                    txtOrderDate.DataBindings.Clear();
                    txtRequiredDate.DataBindings.Clear();
                    txtShippedDate.DataBindings.Clear();
                    txtFreight.DataBindings.Clear();

                    txtOrderId.DataBindings.Add("Text", source, "OrderID");
                    txtMemberId.DataBindings.Add("Text", source, "MemberID");
                    txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                    txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                    txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                    txtFreight.DataBindings.Add("Text", source, "Freight");

                    dgvOrderList.DataSource = null;
                    dgvOrderList.DataSource = source;
                    if (orderList.Count == 0)
                    {
                        ClearText();
                        btnNew.Enabled = false;
                    }
                    else
                    {
                        btnNew.Enabled = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load Order list");
                }
            }
        }

        private void dgvOrderList_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            frmOrderDetail frmOrderDetail = new frmOrderDetail(int.Parse(txtOrderId.Text));
            if (frmOrderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
                source.Position = 0;
            }
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            LoadOrderList();
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            frmOrderInformation frmOrderInfo = new frmOrderInformation()
            {
                Text = "Add member",
                InsertOrUpdate = false,
                OrderRepository = orderRepository
            };
            if (frmOrderInfo.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtOrderId.Text);
                bool result = orderRepository.DeleteOrder(id);
                if (!result)
                    MessageBox.Show("Fail to delete", "Detele order");
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Not a number");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete order");
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
