using Super.SuperMarket.DAl.SQLServer.BasesAndAbstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.SuperMarket.DAl.SQLServer.Model
{
    public class BankAccount: EntityBase
    {
        #region Main Attrubite

        public int Id { get; set; }

        [Display(Name = "Banck Name")]
        [Required(ErrorMessage = "Enter Banck Name")]
        public string BanckName { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage ="Enter Username")]
        public string UserName { get; set; }

        [Display(Name = "Banck Account Number")]
        [Required(ErrorMessage = "Enter Banck Account Number")]
        public int BanckAccountNumber { get; set; }

        [Required(ErrorMessage = "Enter Banck Account Password")]
        public int Password { get; set; }

        public int SupplierId { get; set; }
        #endregion

        #region Relations

        public Supplier Supplier { get; set; }

        #endregion

    }
}
