using Super.SuperMarket.Domain.Mangers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Super.SuperMarket.DAl.SQLServer.Model;


namespace Super.SuperMarket.InterFace.Models
{
    public class InvoiceViewModel
    {
        public Cart Cart { get; set; }
        public OperationType operationType { get; set; }
        public string ReturnUrl { get; set; }

    }
}