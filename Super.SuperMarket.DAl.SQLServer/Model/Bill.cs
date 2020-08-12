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
    public class Bill: EntityBase
    {
        #region constructiors
        public Bill()
        {
            this.Operations = new HashSet<Operation>();
            //this.Products = new HashSet<Product>();
        }
        #endregion

        #region Main Attrubite
        public int Id { get; set; }

        [Display(Name = "Full Price")]
        [Required(ErrorMessage = "Please enter a Full Price")]
        [DataType(DataType.Currency)]
        public decimal FullPrice { get; set; }

        [Required(ErrorMessage = "Please enter a Date Of Expire")]
        [Display(Name = "Date Of Expire")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfExpire { get; set; }

        [Required(ErrorMessage = "Please enter a Operation Type")]
        [Display(Name = "Operation Type Id")]
        public int OperationTypeId { get; set; }

        [Required(ErrorMessage = "Please enter a Payment Method")]
        [Display(Name = "payment Method Id")]
        public int paymentMethodId { get; set; }

        //[Required(ErrorMessage = "Please enter a AppUser")]
        //[Display(Name = "AppUser Id")]
        //public int? AppUserId { get; set; }
        #endregion

        #region Relations
        //public virtual AppUser AppUser { get; set; }
        public virtual OperationType OperationType { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }       
        public virtual ICollection<Operation> Operations { get; set; }      
        //public virtual ICollection<Product> Products { get; set; }
        #endregion
    }
}
