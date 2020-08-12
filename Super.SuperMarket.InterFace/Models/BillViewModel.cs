using Super.SuperMarket.DAl.SQLServer.Model;
using Super.SuperMarket.Domain.Mangers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Super.SuperMarket.InterFace.Models
{
    public class BillViewModel
    {
        public Cart cart{ get; set; }
        public int OperationTypeId {
            get { return OperationTypeId; }   // get method
            set { OperationTypeId = value; }
        }
        public Bill bill{ get; set; }
    }
}