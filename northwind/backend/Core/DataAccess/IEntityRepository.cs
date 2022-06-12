using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {// IEntityRepository T tipinde çalışacak. Generic yapı kullanılacak, T'nin referans tip olduğu, IEntity'den implement edilmiş ve newlenebilir olan her şey kullanılabilecek.
        
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T,bool>> filter=null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
