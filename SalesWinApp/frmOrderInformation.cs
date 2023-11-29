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
    public partial class frmOrderInformation : Form
    {
        public frmOrderInformation()
        {
            InitializeComponent();
        }

        public bool InsertOrUpdate { get; set; }
        public IOrderRepository OrderRepository { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMemberId.Text == "" || txtOrderDate.Text == ""
                    || txtRequiredDate.Text == "" || txtShippedDate.Text == "" ||
                    txtFreight.Text == "")
            {
                MessageBox.Show("Please enter full field before saving", "Order Info");
            }
            try
            {
                DateTime orderDate = DateTime.ParseExact(txtOrderDate.Text, "dd/MM/yyyy", null);
                DateTime requiredDate = DateTime.ParseExact(txtRequiredDate.Text, "dd/MM/yyyy", null);
                DateTime shippedDate = DateTime.ParseExact(txtShippedDate.Text, "dd/MM/yyyy", null);

                Order ord = new Order()
                {
                    MemberId = int.Parse(txtMemberId.Text),
                    OrderDate = orderDate,
                    RequiredDate = requiredDate,
                    ShippedDate = shippedDate,
                    Freight = decimal.Parse(txtFreight.Text),
                };
                if (InsertOrUpdate == false)
                {
                    OrderRepository.AddOrder(ord);
                }
                else
                {
                    OrderRepository.UpdateOrder(ord);
                }
            } catch(FormatException ex)
            {
                MessageBox.Show(ex.Message, "Order Info");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Order Info");
            }
        }
    }
}
