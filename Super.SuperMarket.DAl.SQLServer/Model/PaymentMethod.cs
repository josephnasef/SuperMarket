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
    public class PaymentMethod: EntityBase
    {
        #region constructiors

        public PaymentMethod()
        {
            this.Bills = new HashSet<Bill>();
            this.Suppliers = new HashSet<Supplier>();
        }
        #endregion

        #region Main Attrubite

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is't here ")]
        [Display(Name = "Payment Method Name")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Descreption is't here ")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        #endregion

        #region Relations

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        #endregion
    }
}
