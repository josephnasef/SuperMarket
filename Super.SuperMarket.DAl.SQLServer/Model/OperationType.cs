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
    public class OperationType: EntityBase
    {
        #region constructiors

        public OperationType()
        {
            this.Bills = new HashSet<Bill>();
            this.Operations = new HashSet<Operation>();
        }
        #endregion

        #region Main Attrubite

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is't here ")]
        [Display(Name = "Operation Name")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Description is't here ")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        #endregion

        #region Relations

        public virtual ICollection<Bill> Bills { get; set; }       
        public virtual ICollection<Operation> Operations { get; set; }

        #endregion
    }
}
