using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        public static class Generic
        {
            /// <summary>
            /// Generic functionality for any Entity Framework types.
            /// Be careful when using it on view entities as slow performance 
            /// has been noted in other applications
            /// </summary>
            /// <typeparam name="TEntity"></typeparam>
            /// <returns></returns>
            public static List<TEntity> GetAll<TEntity>() where TEntity : EntityObject
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities())
                {
                    List<TEntity> query = ctx.CreateObjectSet<TEntity>().ToList();
                    return query;
                }
            }

            public static List<TEntity> Find<TEntity>(Func<TEntity, bool> predicate) where TEntity : EntityObject
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities())
                {
                    List<TEntity> query = ctx.CreateObjectSet<TEntity>().Where(predicate).ToList();
                    return query;
                }
            }

            public static TEntity GetFirstOrDefault<TEntity>(Func<TEntity, bool> predicate) where TEntity : EntityObject
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities())
                {
                    TEntity query = ctx.CreateObjectSet<TEntity>().Where(predicate).FirstOrDefault();
                    return query;
                }
            }

            public static int GetCount<TEntity>(Func<TEntity, bool> predicate) where TEntity : EntityObject
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities())
                {
                    int query = ctx.CreateObjectSet<TEntity>().Where(predicate).Count();
                    return query;
                }
            }

            public static int GetCount<TEntity>() where TEntity : EntityObject
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities())
                {
                    int query = ctx.CreateObjectSet<TEntity>().Count();
                    return query;
                }
            }


        }
    }
}
