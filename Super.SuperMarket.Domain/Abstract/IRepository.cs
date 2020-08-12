using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.SuperMarket.Domain.Abstract
{
  
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GettAll();
        List<TEntity> GetAllBind();
        TEntity Add(TEntity entity);
        TEntity GetBy(params object[] Id);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);


    }
}
