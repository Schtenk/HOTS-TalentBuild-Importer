using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HOTS_TalentBuild_Importer.Extensions
{
    public static class DbSetExtension
    {
        public static EntityEntry<T> AddIfMissing<T>(this DbSet<T> dbSet, T entity) where T : class, new()
        {
            var exists = dbSet.Any(d => d == entity);
            return !exists ? dbSet.Add(entity) : null;
        }
        public static EntityEntry<T> AddOrUpdate<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate) where T : class, new()
        {
            var update = dbSet.Any(predicate);
            return update ? dbSet.Update(entity) : dbSet.Add(entity);
        }
        /// <summary>
        /// Updates if entry is found in DbSet and ifFunc returns true. Adds if entry is not found in DbSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="entity"></param>
        /// <param name="predicate"></param>
        /// <param name="ifFunc"></param>
        /// <returns></returns>
        public static EntityEntry<T> UpdateIfOrAdd<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate) where T : class, new()
        {
            var exists = dbSet.Any(predicate);

            var needsUpdate = false;
            if (exists) needsUpdate = dbSet.Any(predicate);

            return needsUpdate ? dbSet.Update(entity) : (!exists ? dbSet.Add(entity) : null);

        }
    }
}
