using GamingStore.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingStore.Repository.Infrastructure.Abstraction
{
    interface IProductRepository
    {
        void CreateProduct(Guid categoryId, string productName, string productDescription, int productPrice);
        void UpdateProduct(Guid id, string productName, string productDescription, int productPrice);
        void DeleteProduct(Guid id);
        List<Product> GetActiveProduct();
        List<Product> FinfByNameProduct(string productName);
        List<Product> GetAllProduct();
        void TextBoxEraser(GroupBox groupBox);
    }
}
