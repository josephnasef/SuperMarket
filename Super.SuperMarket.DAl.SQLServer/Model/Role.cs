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
    public class Role : EntityBase
    {
        #region constructiors

        public Role()
        {
            this.AppUsers = new HashSet<AppUser>();
        }
        #endregion
        #region Main Attrubite

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a role Name ")]
        [Display(Name = "Role Name")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        

     
        #endregion

        #region Relations

        public virtual ICollection<AppUser> AppUsers { get; set; }
        #endregion
    }
}
