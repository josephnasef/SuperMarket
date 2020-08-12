using Super.SuperMarket.DAl.SQLServer.Model;
using Super.SuperMarket.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.SuperMarket.Domain.Mangers
{
    public class AppUserManger : Repository<AppUser>
    {
        public List<AppUser> Search(object Key)
        {
            List<AppUser> Mylist =  GettAll().Where(a => a.Name.Contains((string)Key)
            || a.Phone.Contains((string)Key)
            || a.Address.Contains((string)Key)
            || a.CreatedBy.Contains((string)Key)).ToList();
            return Mylist;
        }

    }
}
