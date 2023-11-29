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
    public partial class frmAddToCart : Form
    {
        Cart cart;
        public bool InsertOrUpdate { get; set; }
        IProductRepository productRepository = new ProductRepository();
        public frmAddToCart()
        {
            InitializeComponent();
        }

        public frmAddToCart(Cart c) : this()
        {
            cart = c;
        }

        public OrderDetail OrderDetail { get; set; }
        public int MemberID { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddToCart_Load(object sender, EventArgs e)
        {
            txtMemberID.Text = MemberID.ToString();
            txtProductId.Text = OrderDetail.ProductId.ToString();
            txtUnitPrice.Text = OrderDetail.UnitPrice.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (nudQuantity.Value == 0 || nudQuantity.Value > productRepository.GetProductById(int.Parse(txtProductId.Text)).UnitsInStock)
            {
                MessageBox.Show("Not enough quantity", "Add or update item");
            } else
            {
                ItemObject item = new ItemObject()
                {
                    ProductId = OrderDetail.ProductId,
                    UnitPrice = OrderDetail.UnitPrice,
                    Quantity = (int)nudQuantity.Value,
                    Discount = OrderDetail.Discount,
                    MemberId = MemberID
                };
                if (!InsertOrUpdate)
                {
                    cart.AddToCart(item);
                }
                else
                {
                    cart.UpdateItem(item);
                }
            }




        }
    }
}
