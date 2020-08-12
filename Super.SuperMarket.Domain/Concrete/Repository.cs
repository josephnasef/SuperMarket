using Super.SuperMarket.DAl.SQLServer.Context;
using Super.SuperMarket.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.SuperMarket.Domain.Concrete
{
    public class Repository<TEtity> : IRepository<TEtity> where TEtity : class
    {
        private readonly Context _Context;
        private readonly DbSet<TEtity> _Set;
        public Repository()
        {
            _Context = new Context();
            _Set = _Context.Set<TEtity>();

        }
        public TEtity Add(TEtity entity)
        {
            _Set.Add(entity);
            return _Context.SaveChanges() > 0 ? entity : null;
        }

        public List<TEtity> GetAllBind()
        {
            return GettAll().ToList();
        }

        public TEtity GetBy(params object[] Id)
        {
            var Myobject = _Set.Find(Id);
            return Myobject;
        }

        public IQueryable<TEtity> GettAll()
        {
            return _Set;
        }

        public bool Remove(TEtity entity)
        {
            _Set.Remove(entity);
            
            return _Context.SaveChanges() > 0;
        }

        public bool Update(TEtity entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
            return _Context.SaveChanges() > 0;
        }
        public void Save()
        {
            _Context.SaveChanges();
        }

       
    }
}
