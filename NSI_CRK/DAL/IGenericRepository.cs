using System;
using System.Collections.Generic;

namespace NSI_CRK.DAL
{
    public interface IGenericRepository<Type> : IDisposable
    {
        IEnumerable<Type> GetAll();
        Type GetById(int? id);
        void Insert(Type obj);
        void Update(Type obj);
        void Delete(int? id);
        void Save();
    }
}
