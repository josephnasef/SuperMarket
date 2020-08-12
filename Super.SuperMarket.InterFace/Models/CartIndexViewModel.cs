using Super.SuperMarket.Domain.Mangers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Super.SuperMarket.InterFace.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}