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
    public class Operation: EntityBase
    {
        #region Main Attrubite

        public int Id { get; set; }



        [Required(ErrorMessage = "Value  is't here ")]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Item Number  is't here ")]
        public int ItemNumber { get; set; }

        //[Required(ErrorMessage = "AppUser Id  is't here ")]
        //[Display(Name = "AppUser Id")]
        //public int AppUserId { get; set; }

        [Required(ErrorMessage = "Product Id  is't here ")]
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Operation Type Id Id  is't here ")]
        [Display(Name = "Operation Type Id")]
        public int OperationTypeId { get; set; }
       
        #endregion

        #region Relations

        //public virtual AppUser AppUser { get; set; }
        [ForeignKey("Bill")]
        public int? Bill_Id { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual OperationType OperationType { get; set; }
        public virtual Product Product { get; set; }
        #endregion
    }
}
