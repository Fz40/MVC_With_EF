using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ICategory : Category
    {
        private int id;
        private string name;


        [DisplayName("Category ID")]
        public int ICategoryID
        {
            get { return CategoryID; }
            set { id = CategoryID; }
        }

        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Required Category Name")]
        public string ICategoryName {
            get { return CategoryName; }
            set { name = CategoryName; }
        }

        [DisplayName("Category Description")]
        public string IDescription {
            get { return Description; }
            set { value = Description; }
        }


    }
}