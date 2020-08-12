using Super.SuperMarket.DAl.SQLServer.BasesAndAbstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.SuperMarket.DAl.SQLServer.Model
{
    public class Category: EntityBase
    {
        #region constructiors

        public Category()
        {
            this.Products = new HashSet<Product>();
            this.Suppliers = new HashSet<Supplier>();
        }
        #endregion
        #region Main Attrubite

        [Required(ErrorMessage = "Please enter a Name of Category")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Name of Category")]
        [Display(Name = "Category type")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Description of Category")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool HiddInMenu { get; set; }



        #endregion

        #region Relations

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        #endregion
    }
}
