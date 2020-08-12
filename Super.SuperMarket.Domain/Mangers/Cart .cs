using Super.SuperMarket.DAl.SQLServer.Model;
//using Super.SuperMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.SuperMarket.Domain.Mangers
{
   public class Cart
    {
        HashSet<CartLine> lineCollection = new HashSet<CartLine>();
        public void AddItem(Product productpram , int quantity)
        {
            CartLine MyProduct = new CartLine() { Product = productpram, Quantity = quantity };
            var line = lineCollection
                .Where(L => L.Product.Id == productpram.Id)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(MyProduct);
            }
            else { line.Quantity += quantity; }            
        }
        public void Remove(Product productPram)
        {
            List<CartLine> line = lineCollection
               .Where(L => L.Product.Id == productPram.Id)
               .ToList();
            var myline = lineCollection
               .Where(L => L.Product.Id == productPram.Id).FirstOrDefault();


            if (line.Count() > 1)
            {
                lineCollection
                 .Where(L => L.Product.Id == productPram.Id).FirstOrDefault().Quantity--;
            }
            else if (line.Count() == 1)
            {
                lineCollection.RemoveWhere(l => l.Product.Id == productPram.Id);
            }
        }
        public decimal ComputeTotalValue()
        {

            return lineCollection.Sum(l => l.Product.SellingPrice * l.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> lines
        {
            get { return lineCollection; }
        }

    }
}
