using Super.SuperMarket.DAl.SQLServer.Model;
using Super.SuperMarket.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.SuperMarket.Domain.Mangers
{
    public class PaymentMethodManger : Repository<PaymentMethod>
    {
        public IEnumerable<string> PaymentMethods()
        {
            return GettAll().Where(c => c.IsArchived == false).Select(c => c.Name).Distinct().OrderBy(c => c);
        }

    }
}
