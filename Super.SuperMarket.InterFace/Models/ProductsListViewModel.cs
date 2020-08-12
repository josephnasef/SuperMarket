using Super.SuperMarket.DAl.SQLServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Super.SuperMarket.InterFace.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

    }
}