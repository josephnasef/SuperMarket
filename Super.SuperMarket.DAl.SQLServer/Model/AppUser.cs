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
    public class AppUser: EntityBase
    {
        #region constructiors

        public AppUser()
        {
            //this.Bills = new HashSet<Bill>();
            //this.Operations = new HashSet<Operation>();
            this.Suppliers = new HashSet<Supplier>();
        }
        #endregion
        #region Main Attrubite

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Name Of User")]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a user address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a Phone number Of User")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter a Role Of User")]
        public int RoleId { get; set; }

        [Display(Name = "Birth Day")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "Photo Url")]
        public string PhotoUrl { get; set; }

        #endregion

        #region Relations

        public virtual Role Role { get; set; }
       
        //public virtual ICollection<Bill> Bills { get; set; }
       
        //public virtual ICollection<Operation> Operations { get; set; }
       
        public virtual ICollection<Supplier> Suppliers { get; set; }


        #endregion
    }
}
