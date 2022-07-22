using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            /*
             * using  ile yapılan işlem bittiği anda oluşturulan nesne bellekten silinir
             * Performans açısından context gibi performans gerektiren objelerde using kullanılması optimizasyon açısından önemlidir.
            */
            //IDisposable Pattern Implementation Of C#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //verilen entity ile veri tabanındaki entityi eşle (Bu durumda bulamayacak)
                addedEntity.State = EntityState.Added; //Bu nesneyi veri tabanına ekle
                context.SaveChanges(); // Değişiklikleri Kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //verilen entity ile veri tabanındaki entityi eşle 
                deletedEntity.State = EntityState.Deleted; //Bu nesneyi veri tabanından sil
                context.SaveChanges(); // Değişiklikleri Kaydet
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //verilen entity ile veri tabanındaki entityi eşle 
                updatedEntity.State = EntityState.Modified; //Bu nesneyi veri tabanında güncelle
                context.SaveChanges(); // Değişiklikleri Kaydet
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }



    }
}
