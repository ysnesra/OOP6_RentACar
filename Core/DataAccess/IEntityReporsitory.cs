using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityReporsitory<T> where T : class,IEntity,new()  //sadece veritabanı nesneleri ile çalışan IEntityRepository oldu
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //filtreleyerek listelemek için Expression yazarız

        T Get(Expression<Func<T, bool>> filter); 

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
