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
    public partial class frmOrderDetail : Form
    {
        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        IOrderRepository orderRepository = new OrderRepository();
        BindingSource source = new BindingSource();

        public frmOrderDetail()
        {
            InitializeComponent();
        }

        public int OrderID { get; set; }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public frmOrderDetail(int orderId) : this()
        {
            OrderID = orderId;
        }

        private void ClearText()
        {
            txtOrderId.Text = string.Empty;
            txtProductId.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }

        public void LoadOrderDetail()
        {
            var ordDetails = orderDetailRepository.GetOrderDetailByOrId(OrderID);
            try
            {
                source.DataSource = ordDetails;
                txtOrderId.DataBindings.Clear();
                txtProductId.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtQuantity.DataBindings.Clear();
                txtDiscount.DataBindings.Clear();

                txtOrderId.DataBindings.Add("Text", source, "OrderId");
                txtProductId.DataBindings.Add("Text", source, "ProductId");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtQuantity.DataBindings.Add("Text", source, "Quantity");
                txtDiscount.DataBindings.Add("Text", source, "Discount");

                dgvOrderDetailList.DataSource = source;
                if (ordDetails.Count == 0)
                {
                    ClearText();
                }
                else
                {
                    double total = 0;
                    foreach(var ord in ordDetails)
                    {
                        total = (double)(ord.Quantity * ord.UnitPrice);
                    }
                    total = total + (double)orderRepository.GetOrder(OrderID).Freight;
                    txtTotal.Text = total.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOrderDetail();
        }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            LoadOrderDetail();
        }
    }
}
