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

        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync<T>();
        }

        public Task<T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entities.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return context.SaveChangesAsync();
        }        
        
        public async Task Delete(int id)
        {
            T entity = await entities.SingleOrDefaultAsync(x => x.Id == id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
