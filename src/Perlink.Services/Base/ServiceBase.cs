﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Perlink.Data;

namespace Perlink.Services.Base
{
    public interface IServiceBase 
    {
        //Para implementações futuras se surgir alguma ideia
    }

    public abstract class ServiceBase: IServiceBase
    {
        protected PerlinkDbContext _context;

        public ServiceBase(PerlinkDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all records from a entity
        /// </summary> 
        /// <returns>IQuerable</returns>
        protected IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            return dbSet.AsQueryable();
        }

        /// <summary>
        ///     Gets all records from a entity filtering by a condition. (you can also use GetAll().Where(x => x.Id != 0) but, you will trigger 2 actions, GetAll() and Where filter)
        /// Using GetAllWhere you will trigger just one action, its much more faster.
        /// </summary>
        /// <example>
        ///     Ex: var records = GetAllWhere(x => x.Id == 1)  returns all records where Id is equal to 1
        /// </example> 
        /// <param name="predicate"></param>
        /// <returns></returns>
        protected IQueryable<TEntity> GetAllWhere<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            return dbSet.Where(predicate);
        }

        /// <summary>
        /// Adds an entity to be saved but, its not exists on database yet.
        /// </summary>
        /// <param name="entity"></param>
        protected void Insert<TEntity>(TEntity entity, bool CommitAllChangesOnSuccess = true) where TEntity : class
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            dbSet.Add(entity);
            _context.SaveChanges(CommitAllChangesOnSuccess);
        }

        /// <summary>
        /// Remove an entity from database and commits its changes.
        /// </summary>
        /// <param name="entity"></param>
        protected void Delete<TEntity>(TEntity entity, bool CommitAllChangesOnSuccess = true) where TEntity : class
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            dbSet.Remove(entity);
            _context.SaveChanges(CommitAllChangesOnSuccess);
        }

        /// <summary>
        /// Gets an entity by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        protected TEntity GetEntityById<TEntity>(int id) where TEntity : class
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            return dbSet.Find(id);
        }

        /// <summary>
        /// Commits all changes added on database
        /// </summary>
        /// <param name="CommitAllChangesOnSuccess"></param>
        /// <returns></returns>
        protected bool Update<TEntity>(TEntity entity, bool CommitAllChangesOnSuccess = true) where TEntity : class
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();

            if (_context.Entry<TEntity>(entity).State == EntityState.Modified)
            {
                try
                {
                    dbSet.Attach(entity);
                    _context.SaveChanges(CommitAllChangesOnSuccess);

                    return true;
                }
                catch (DbUpdateException ex)
                {
                    return false;
                }
            }

            return false;
        }


    }
}
