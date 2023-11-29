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
    public partial class frmCart : Form
    {
        Cart cart;
        BindingSource source = new BindingSource();
        IProductRepository productRepository = new ProductRepository();   
        IMemberRepository memberRepository = new MemberRepository();
        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        IOrderRepository orderRepository = new OrderRepository();
        public frmCart()
        {
            InitializeComponent();
        }

        public int? MemberID { get; set; }

        public frmCart(Cart c) : this()
        {
            cart = c;
        }

        private void ClearText()
        {
            txtMemberId.Text = string.Empty;
            txtProductId.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            nudQuantity.Value = 0;
            txtDiscount.Text = string.Empty;
            txtTotal.Text = "0";
        }

        public void LoadCartList()
        {
            List<ItemObject> itemCart = cart.GetCartItems().ToList();

            try
            {
                source.DataSource = itemCart;
                txtMemberId.DataBindings.Clear();
                txtProductId.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                nudQuantity.DataBindings.Clear();
                txtDiscount.DataBindings.Clear();

                txtMemberId.DataBindings.Add("Text", source, "MemberId");
                txtProductId.DataBindings.Add("Text", source, "ProductId");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                nudQuantity.DataBindings.Add("Value", source, "Quantity");
                txtDiscount.DataBindings.Add("Text", source, "Discount");

                dgvCartList.DataSource = source;
                if (itemCart.Count == 0)
                {
                    ClearText();
                    nudQuantity.Enabled = false;
                    btnRemove.Enabled = false;
                    btnCheckOut.Enabled = false;
                }
                else
                {
                    double total = 0;
                    foreach (var cartItem in itemCart)
                    {
                        total = (double)(cartItem.Quantity * cartItem.UnitPrice);
                    }
                    txtTotal.Text = total.ToString();
                    nudQuantity.Enabled = true;
                    btnRemove.Enabled = true;
                    btnCheckOut.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load cart list");
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCart_Load(object sender, EventArgs e)
        {
            LoadCartList();
        }

        private void dgvCartList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAddToCart frmAddToCart = new frmAddToCart(cart)
            {
                Text = "Update item",
                InsertOrUpdate = true,
                MemberID = int.Parse(txtMemberId.Text),
                OrderDetail = new OrderDetail()
                {
                    ProductId = int.Parse(txtProductId.Text),
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                },
            };
            if (frmAddToCart.ShowDialog() == DialogResult.OK)
            {
                LoadCartList();
                source.Position = 0;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ItemObject item = new ItemObject()
            {
                MemberId = int.Parse(txtMemberId.Text),
                ProductId = int.Parse(txtProductId.Text),
                Quantity = (int)nudQuantity.Value,
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                Discount = Double.Parse(txtDiscount.Text),
            };
            cart.RemoveFormCart(item);
            LoadCartList();
        }

        private void dgvCartList_DataMemberChanged(object sender, EventArgs e)
        {
            if(cart != null && cart.GetCartItems().Count > 0)
            {
                double total = 0;
                foreach (var cartItem in cart.GetCartItems().ToList())
                {
                    total = (double)(cartItem.Quantity * cartItem.UnitPrice);
                }
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Order order = new Order()
            {
                MemberId = int.Parse(txtMemberId.Text),
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(3),
                ShippedDate = DateTime.Now.AddDays(3),
                Freight = 30000,
            };
            orderRepository.AddOrder(order);
            foreach (var cartItem in cart.GetCartItems().ToList())
            {
                MessageBox.Show(order.OrderId.ToString());
                OrderDetail detail = new OrderDetail()
                {
                    ProductId = cartItem.ProductId,
                    OrderId = order.OrderId,
                    Discount = cartItem.Discount,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.UnitPrice,
                };
                if (!orderDetailRepository.AddNew(detail))
                    MessageBox.Show("Fail to add new detail", "Add order detail");
                Product product = productRepository.GetProductById(cartItem.ProductId);
                product.UnitsInStock = product.UnitsInStock - cartItem.Quantity;
                productRepository.UpdateProduct(product);
                cart.RemoveFormCart(cartItem);
            }
            MessageBox.Show("Check Out Successfully", "Check Out");
            LoadCartList();
        }
    }
}
