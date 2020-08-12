using Super.SuperMarket.DAl.SQLServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Super.SuperMarket.Domain.Concrete;
//using Super.SuperMarket.Domain.Mangers;

namespace Super.SuperMarket.Test

{
    class Program
    {
        static void Main(string[] args)
        {
            AppUserManger _repository = new AppUserManger();
            //RoleManger _repository = new RoleManger();

            //Role MyRole = new Role() { Id = 1, Name = "JOJO" };
            //AppUser appUser = new AppUser() { Name = "jojo", RoleId = 1, Address = "Egypt" };
            AppUser appUser = _repository.GetBy(2);

            _repository.Remove(appUser);

            Console.ReadKey();
        }
    }
}
