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
   public class Product: EntityBase
    {
        #region constructiors

        public Product()
        {
            this.Operations = new HashSet<Operation>();
            //this.Bills = new HashSet<Bill>();
        }
        #endregion
        #region Main Attrubite

        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Barcode Number ")]
        [Display(Name = "Barcode Number")]
        public int BarcodeNumber { get; set; }

        [Required(ErrorMessage = "Enter Name of Product")]
        [Display(Name = "Proudact Name")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Purchase Price of Product")]
        [Display(Name = "Purchase Price")]
        [DataType(DataType.Currency)]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Enter Selling Price of Product")]
        [DataType(DataType.Currency)]
        [Display(Name = "Selling Price")]

        public decimal SellingPrice { get; set; }

        [Display(Name = "Made In Country")]
        public string MadeInCountry { get; set; }

        [Required(ErrorMessage = "Enter Selling Price of Product")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Production Date")]
        public System.DateTime ProductionDate { get; set; }

        [Required(ErrorMessage = "Enter Expiry Date of Product")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }
        
        [Display(Name = "Quentity")]
        public int Quentity { get; set; }

        [Display(Name = "Has Guarantee")]
        public bool HasGuarantee { get; set; }

        [Required(ErrorMessage = "Enter Category Id of Product")]
        [Display(Name = "Category type")]
        public int CategoryId { get; set; }

        [Display(Name = "Supplier Name")]
        public Nullable<int> SupplierId { get; set; }
        #endregion

        #region Relations

        public virtual Category Category { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual Supplier Supplier { get; set; }
        //public virtual ICollection<Bill> Bills { get; set; }

        #endregion
    }
}
