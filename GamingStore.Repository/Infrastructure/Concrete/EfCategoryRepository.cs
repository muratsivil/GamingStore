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
    public class EfCategoryRepository : EfBaseRepository, ICategoryRepository
    {
        Category category = new Category();

        public void CreateCategory(string categoryName, string categoryDescription)
        {
            category.CategoryName = categoryName;
            category.CategoryDescription = categoryDescription;
            if (categoryName == "" || categoryDescription == "")
            {
                MessageBox.Show("Fill in the blanks");
            }
            else
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void DeleteCategory(Guid id)
        {
            try
            {
                category = db.Categories.FirstOrDefault(x => x.Id == id);
                category.DeleteDate = DateTime.Now;
                category.Status = Status.Passive;
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Error..!");
            }
        }

        public List<Category> FinfByNameCategory(string categoryName)
        {
            return db.Categories.Where(x => x.CategoryName.ToLower() == categoryName.ToLower()).ToList();
        }

        public List<Category> GetActiveCategory()
        {
            return db.Categories.Where(x => x.Status != Status.Passive).ToList();
        }

        public List<Category> GetAllCategory()
        {
            return db.Categories.ToList();
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

        public void UpdateCategory(Guid id, string categoryName, string categoryDescription)
        {
            try
            {
                category = db.Categories.FirstOrDefault(x => x.Id == id);
                category.CategoryName = categoryName;
                category.CategoryDescription = categoryDescription;
                category.Status = Status.Modified;
                category.UpdateDate = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Update Error..!");
            }
            
        }
    }
}
