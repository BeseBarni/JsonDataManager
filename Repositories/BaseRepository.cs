using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Repositories
{
    public class BaseRepository<TContext> : IDisposable where TContext : DbContext, new()
    {
        /// <summary>
        /// Command timeout
        /// </summary>
        protected int CommandTimeout = 30;



        /// <summary>
        /// Lekérdezésnek van eredménye
        /// </summary>
        public bool HasResult { get; set; }



        /// <summary>
        /// Lekérdezés sikeresség flag
        /// </summary>
        public bool Success { get; set; }



        /// <summary>
        /// Gyerek elem Context típusa
        /// </summary>
        protected TContext Ctx { get; set; }


        /// <summary>
        /// Konstruktor
        /// </summary>



        protected virtual TContext CreateNewContext()
        {
            throw new NotSupportedException("Must override");
        }



        /// <summary>
        /// lekérdezés using használatával az osztály context-jét használva
        /// </summary>
        /// <typeparam name="T">Visszatérési érték típusa</typeparam>
        /// <param name="linqMethod">Linq kifejezés a lekérdezéshez</param>
        /// <returns>T típussal tér vissza</returns>
        protected T SelectInUsing<T>(Func<T> linqMethod, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            HasResult = true;
            using var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = isolationLevel, Timeout = new TimeSpan(0, 0, CommandTimeout) });
            using (Ctx = CreateNewContext())
            {



                T result = linqMethod();
                if (EqualityComparer<T>.Default.Equals(result, default))
                {
                    HasResult = false;
                }



                scope.Complete();



                return result;
            }
        }




        /// <summary>
        /// Egy int PK-val rendelkező Entity mentése, ha létezik az id, akkor update, ha nem létezik, akkor insert
        /// </summary>
        /// <typeparam name="T">Entity típus</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="hasId">Az Id-re mutató feltétel</param>
        protected TProp InsertOrUpdateInUsing<T, TProp>(T entity, Predicate<T> hasId, Func<T, TProp> mapProp) where T : class
        {
            Success = true;
            try
            {
                using (Ctx = new TContext())
                {
                    if (hasId(entity))
                    {
                        Ctx.Entry(entity).State = EntityState.Modified;
                    }
                    else
                    {
                        Ctx.Set<T>().Add(entity);
                    }
                    Ctx.SaveChanges();



                    return mapProp(entity);
                }
            }
            catch (Exception)
            {
                // Exception elkapása, logolása és tovább dobása
                //logger.Log(ex);
                throw;
            }
        }




        /// <summary>
        /// Egy PK-val rendelkező elem
        /// </summary>
        /// <typeparam name="T">Entity típusa</typeparam>
        /// <typeparam name="TProp">Visszamappolandó property (vagy akár entity) típusa</typeparam>
        /// <param name="entity">A beszúrandó entity</param>
        /// <param name="mapProp">Mappoló eljárás a visszatérési értékhez</param>
        /// <param name="getExistEntity">Létező (logikai törlésre szánt) entity-k listáját visszaadó eljárás</param>
        /// <param name="logicalDelete">Logikai törlés egy T típusú entity-re</param>
        /// <returns>TProp típusú visszatérési érték, amit a mapProp visszaad</returns>
        protected TProp InsertWithLogicalDelete<T, TProp>(T entity, Func<T, TProp> mapProp, Func<DbSet<T>, IQueryable<T>> getExistEntity, Func<T, T> logicalDelete) where T : class
        {
            Success = true;
            try
            {
                using (Ctx = new TContext())
                {
                    List<T> existList = getExistEntity(Ctx.Set<T>()).ToList();
                    if (existList != null && existList.Count > 0)
                    {
                        foreach (T exist in existList)
                        {
                            logicalDelete(exist);
                            Ctx.Entry(exist).State = EntityState.Modified;
                        }
                    }



                    Ctx.Set<T>().Add(entity);
                    Ctx.SaveChanges();



                    return mapProp(entity);
                }
            }
            catch (Exception)
            {
                // Exception elkapása, logolása és tovább dobása
                //logger.Log(ex);
                throw;
            }
        }



        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (Ctx != null)
                Ctx.Dispose();

            GC.SuppressFinalize(this);
        }



    }
}
