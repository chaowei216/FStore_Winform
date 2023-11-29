using BusinessObject;
using BusinessObject.Models;
using DataAccess.Repository;
using MyStoreWinApp;
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
    public partial class frmProducts : Form
    {
        BindingSource source = new BindingSource();
        IProductRepository productRepository = new ProductRepository();
        IMemberRepository memberRepository = new MemberRepository();
        private readonly string _role;
        private readonly string _email;
        Cart cart;
        public frmProducts()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public frmProducts(string role, string email) : this()
        {
            _email = email;
            _role = role;
            lbRole.Text = _role;
            cart = new Cart();
        }
        private void ClearText()
        {
            txtProductId.Text = string.Empty;
            txtCategoryId.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            nudUnitsInStock.Text = "0";
        }

        private Product? GetProduct()
        {
            Product? product = null;
            try
            {
                product = new Product()
                {
                    ProductId = int.Parse(txtProductId.Text),
                    CategoryId = int.Parse(txtCategoryId.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = (int)nudUnitsInStock.Value
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get product");
            }
            return product;
        }

        public void LoadProductList()
        {
            var products = productRepository.GetProducts();

            try
            {
                source.DataSource = products;
                txtProductId.DataBindings.Clear();
                txtCategoryId.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                nudUnitsInStock.DataBindings.Clear();

                txtProductId.DataBindings.Add("Text", source, "ProductId");
                txtCategoryId.DataBindings.Add("Text", source, "CategoryId");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                nudUnitsInStock.DataBindings.Add("Value", source, "UnitsInStock");

                dgvProductList.DataSource = source;
                if (source == null)
                {
                    ClearText();
                    btnNew.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnAddToCart.Enabled = false;
                    btnViewCart.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnNew.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnViewCart.Enabled = true;
                    btnAddToCart.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCategoryId.Enabled = false;
            txtProductName.Enabled = false;
            txtWeight.Enabled = false;
            txtUnitPrice.Enabled = false;
            nudUnitsInStock.Enabled = false;
            btnUpdate.Text = "Update";
            btnDelete.Enabled = true;
            LoadProductList();
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            frmProductDetails frmProductDetails = new frmProductDetails()
            {
                Text = "Add Product",
                InsertOrUpdate = false,
                ProductRepository = productRepository
            };
            if (frmProductDetails.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            frmProductDetails frmProductDetails = new frmProductDetails
            {
                Text = "Update Member",
                InsertOrUpdate = true,
                ProductInfo = GetProduct(),
                ProductRepository = productRepository
            };
            if (frmProductDetails.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (!productRepository.DeleteProduct(int.Parse(txtProductId.Text)))
                MessageBox.Show("Delete error!!", "Delete Product");
            else LoadProductList();
            source.Position = 0;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            if(!_role.Equals("Admin"))
            {
                btnNew.Visible = false;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
            } else
            {
                btnAddToCart.Visible = false;
                btnViewCart.Visible = false;
            }
        }

        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {
            frmAddToCart frmAddToCart = new frmAddToCart(cart)
            {
                Text = "Add To Cart",
                InsertOrUpdate = false,
                MemberID = memberRepository.GetMemberByEmail(_email).MemberId,
                OrderDetail = new OrderDetail()
                {
                    ProductId = int.Parse(txtProductId.Text),
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                },

            };
            if (frmAddToCart.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = 0;
            }
        }

        private void btnViewCart_Click(object sender, EventArgs e)
        {
            frmCart frmCart = new frmCart(cart)
            {
                Text = "Add To Cart",
                MemberID = memberRepository.GetMemberByEmail(_email)?.MemberId,
            };
            if(frmCart.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = 0;
            }
        }
    }
}