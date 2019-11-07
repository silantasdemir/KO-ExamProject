using KO.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KO.BLL
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(int entityID);
        ICollection<TEntity> GetAll();

    }
}
