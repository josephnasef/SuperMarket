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
    public class Supplier : EntityBase
    {
        #region constructiors
        
        public Supplier()
        {
            this.BankAccount = new HashSet<BankAccount>();
            this.Products = new HashSet<Product>();
            this.Suppliers1 = new HashSet<Supplier>();
            this.PaymentMethods = new HashSet<PaymentMethod>();
            this.Categories = new HashSet<Category>();
        }
        #endregion
        #region Main Attrubite

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Supplier Name ")]
        [Display(Name = "Supplier Name")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Phone ")]
        [Phone]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a your  Email ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a Supplier Address")]
        public string Address { get; set; }

        public int Rate { get; set; }
       
        [Required(ErrorMessage = "Please enter a your  Email")]
        [Display(Name = "User Name")]
        public int AppUserId { get; set; }

       

       


        #endregion

        #region Relations

        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Supplier> Suppliers1 { get; set; }
        public virtual ICollection<Supplier> Supplier1 { get; set; }
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<BankAccount> BankAccount { get; set; }

        #endregion
    }
}
