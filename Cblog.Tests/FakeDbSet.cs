// ----------------------------------------------------------------------
// <copyright file="FakeDbSet.cs" company="">
//  FakeDbSet
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    class FakeDbSet<T> : IDbSet<T>
        where T : class
    {
        public FakeDbSet()
        {
            data_ = new HashSet<T>();
            query_ = data_.AsQueryable();
        }

        public T Add(T entity)
        {
            data_.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            return this.Add(entity);
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            return default(T);
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public System.Collections.ObjectModel.ObservableCollection<T> Local
        {
            get { throw new NotImplementedException(); }
        }

        public T Remove(T entity)
        {
            data_.Remove(entity);
            return entity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data_.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data_.GetEnumerator();
        }

        public Type ElementType
        {
            get { return typeof(T); }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return query_.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return query_.Provider; }
        }

        private HashSet<T> data_;
        private IQueryable<T> query_;
    }
}
