using GamingStore.Entities.Entity.Concrete;
using GamingStore.Entities.Entity.Enums;
using GamingStore.Repository.Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingStore.Repository.Infrastructure.Concrete
{
    public class EfProductRepository : EfBaseRepository, IProductRepository
    {
        Product product = new Product();

        public void CreateProduct(Guid categoryID, string productName, string productDescription, int productPrice)
        {
            product.Id = categoryID;
            product.ProductName = productName;
            product.ProductDescription = productDescription;
            product.ProductPrice = productPrice;
            if (productName == "" || productDescription == "" || productPrice.ToString() == "" )
            {
                MessageBox.Show("Error. Fill in the blanks..!");
            }
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            try
            {
                product = db.Products.FirstOrDefault(x => x.Id == id);
                product.DeleteDate = DateTime.Now;
                product.Status = Status.Passive;
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Error. DeleteProduct();");
            }
            
        }

        public List<Product> FinfByNameProduct(string productName)
        {
            return db.Products.Where(x => x.ProductName.ToLower() == productName.ToLower()).ToList();
        }

        public List<Product> GetActiveProduct()
        {
            return db.Products.Where(x => x.Status != Status.Passive).ToList();
        }

        public List<Product> GetAllProduct()
        {
            return db.Products.ToList();
        }

        public void TextBoxEraser(GroupBox groupBox)
        {
            foreach (Control item in groupBox.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }  

        public void UpdateProduct(Guid id, string productName, string productDescription, int productPrice)
        {
            try
            {
                product = db.Products.FirstOrDefault(x => x.Id == id);
                product.ProductName = productName;
                product.ProductPrice = productPrice;
                product.ProductDescription = productDescription;
                product.Status = Status.Modified;
                product.UpdateDate = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Error. UpdateProduct();");
            }
            
        }
    }
}
