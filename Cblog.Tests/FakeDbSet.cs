// ----------------------------------------------------------------------
// <copyright file="FakeDbSet.cs" company="cvlad">
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

    /// <summary>
    /// The fake db set.
    /// </summary>
    /// <typeparam name="T">
    /// Model type.
    /// </typeparam>
    internal class FakeDbSet<T> : IDbSet<T>
        where T : class
    {
        /// <summary>
        /// The data_.
        /// </summary>
        private readonly HashSet<T> data_;

        /// <summary>
        /// The query_.
        /// </summary>
        private readonly IQueryable<T> query_;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDbSet{T}"/> class.
        /// </summary>
        public FakeDbSet()
        {
            this.data_ = new HashSet<T>();
            this.query_ = this.data_.AsQueryable();
        }

        /// <summary>
        /// Gets the observable collection.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// Currently not implemented.
        /// </exception>
        public System.Collections.ObjectModel.ObservableCollection<T> Local
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the element type.
        /// </summary>
        public Type ElementType
        {
            get { return typeof(T); }
        }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        public System.Linq.Expressions.Expression Expression
        {
            get { return this.query_.Expression; }
        }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        public IQueryProvider Provider
        {
            get { return this.query_.Provider; }
        }

        /// <summary>
        /// Adds a new instance to the set.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The newly inserted instance.
        /// </returns>
        public T Add(T entity)
        {
            this.data_.Add(entity);
            return entity;
        }

        /// <summary>
        /// The attaches a an instance to the current set.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The newly inserted instance.
        /// </returns>
        public T Attach(T entity)
        {
            return this.Add(entity);
        }

        /// <summary>
        /// Creates a new instance of a derived type of T.
        /// </summary>
        /// <typeparam name="TDerivedEntity">
        /// The derived entity.
        /// </typeparam>
        /// <returns>
        /// The TDerivedEntity.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// This method is not implemented.
        /// </exception>
        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a default constructed T.
        /// </summary>
        /// <returns>
        /// The T.
        /// </returns>
        public T Create()
        {
            return default(T);
        }

        /// <summary>
        /// Finds an object using a key from the set.
        /// </summary>
        /// <param name="keyValues">
        /// The key values.
        /// </param>
        /// <returns>
        /// The T.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Currently not implemented.
        /// </exception>
        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes an entity from the set.
        /// </summary>
        /// <param name="entity">
        /// The entity to remove.
        /// </param>
        /// <returns>
        /// The entity that was removed
        /// </returns>
        public T Remove(T entity)
        {
            this.data_.Remove(entity);
            return entity;
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// An IEnumerator of T.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.data_.GetEnumerator();
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The System.Collections.IEnumerator.
        /// </returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.data_.GetEnumerator();
        }
    }
}
