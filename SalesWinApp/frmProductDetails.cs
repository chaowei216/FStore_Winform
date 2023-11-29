using BusinessObject;
using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreWinApp
{
    public partial class frmProductDetails : Form
    {
        public frmProductDetails()
        {
            InitializeComponent();
        }

        public IProductRepository ProductRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Product? ProductInfo { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product()
                {
                    CategoryId = int.Parse(txtCategoryID.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text),
                };
                if(!InsertOrUpdate)
                {
                    if (ProductRepository.GetProductByName(txtProductName.Text) != null)
                    {
                        DialogResult confirmation = MessageBox.Show("Product Name is existed", "Add product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    ProductRepository.AddProduct(product);
                } else
                {
                    product.ProductId = int.Parse(txtProductId.Text);
                    ProductRepository.UpdateProduct(product);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add a new product");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProductDetails_Load(object sender, EventArgs e)
        {
            txtProductId.Enabled = false;
            if (InsertOrUpdate)
            {
                txtProductId.Text = ProductInfo.ProductId.ToString();
                txtCategoryID.Text = ProductInfo.CategoryId.ToString();
                txtProductName.Text = ProductInfo.ProductName;
                txtWeight.Text = ProductInfo.Weight;
                txtUnitPrice.Text = ProductInfo.UnitPrice.ToString();
                txtUnitsInStock.Text = ProductInfo.UnitsInStock.ToString();
            } 
        }
    }
}
