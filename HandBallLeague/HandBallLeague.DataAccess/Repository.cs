using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly HandBallLeagueContext context;
        private DbSet<T> entities;

        public Repository(HandBallLeagueContext handBallLeagueContext)
        {
            this.context = handBallLeagueContext;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable<T>();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            context.SaveChanges();
        }        
        
        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(x => x.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
