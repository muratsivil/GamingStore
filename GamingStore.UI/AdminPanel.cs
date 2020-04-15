using GamingStore.Repository.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingStore.UI
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }
        EfCategoryRepository efCategoryRepository = new EfCategoryRepository();
        EfProductRepository efProductRepository = new EfProductRepository();
        private void AdminPanel_Load(object sender, EventArgs e)
        {
            dataGridViewCategory.DataSource = efCategoryRepository.GetActiveCategory();
            dataGridViewProduct.DataSource = efProductRepository.GetActiveProduct();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            efCategoryRepository.CreateCategory(txtAddCategoryName.Text, txtAddCategoryDesc.Text);
            dataGridViewCategory.DataSource = efCategoryRepository.GetActiveCategory();
            efCategoryRepository.TextBoxEraser(grpAddCatagory);
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            efCategoryRepository.UpdateCategory(idCategory, txtUpdateCategoryName.Text, txtUpdateCategoryDesc.Text);
            dataGridViewCategory.DataSource = efCategoryRepository.GetActiveCategory();
            efCategoryRepository.TextBoxEraser(grpUpdateCategory);
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            efCategoryRepository.DeleteCategory(idCategory);
            dataGridViewCategory.DataSource = efCategoryRepository.GetActiveCategory();
            efCategoryRepository.TextBoxEraser(grpDeleteCategory);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            efProductRepository.CreateProduct(idProduct, txtAddProductName.Text, txtAddProductDesc.Text, int.Parse(txtAddProductPrice.Text));
            dataGridViewProduct.DataSource = efProductRepository.GetActiveProduct();
            efProductRepository.TextBoxEraser(grpAddProduct);
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            efProductRepository.UpdateProduct(idProduct, txtUpdateProductName.Text, txtUpdateProductDesc.Text, int.Parse(txtUpdateProductPrice.Text));
            dataGridViewProduct.DataSource = efProductRepository.GetActiveProduct();
            efProductRepository.TextBoxEraser(grpUpdateProduct);
        }
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            efProductRepository.DeleteProduct(idProduct);
            dataGridViewProduct.DataSource = efProductRepository.GetActiveProduct();
            efProductRepository.TextBoxEraser(grpDeleteProduct);
        }
        Guid idCategory;
        private void dataGridViewCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idCategory = Guid.Parse(dataGridViewCategory.CurrentRow.Cells["CategoryID"].Value.ToString());
            txtUpdateCategoryID.Text = idCategory.ToString();
            txtUpdateCategoryName.Text = dataGridViewCategory.CurrentRow.Cells["CategoryName"].Value.ToString();
            txtUpdateCategoryDesc.Text = dataGridViewCategory.CurrentRow.Cells["CategoryDescription"].Value.ToString();
            txtDeleteCategoryID.Text = idCategory.ToString();

        }

        Guid idProduct;
        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idProduct = Guid.Parse(dataGridViewProduct.CurrentRow.Cells["ProductID"].Value.ToString());
            txtUpdateProductID.Text = idProduct.ToString();
            txtUpdateProductName.Text = dataGridViewProduct.CurrentRow.Cells["ProductName"].Value.ToString();
            txtUpdateProductDesc.Text = dataGridViewProduct.CurrentRow.Cells["ProductDescription"].Value.ToString();
            txtUpdateProductPrice.Text = dataGridViewProduct.CurrentRow.Cells["ProductPrice"].Value.ToString();
            txtDeleteProductID.Text = idProduct.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            dataGridViewProduct.DataSource = efProductRepository.GetAllProduct();
            dataGridViewCategory.DataSource = efCategoryRepository.GetAllCategory();
        }
    }
}
