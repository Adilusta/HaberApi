using System.Linq;

namespace SportStore.Models
{
    public class EFHaberRepository : IHaberRepository
    {
        private HaberDbContext context;
        public EFHaberRepository(HaberDbContext ctx)
        {
            this.context = ctx;
        }
        public IQueryable<Haber> Haberler => context.Haberler;

        public void CreateHaber(Haber p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void DeleteHaber(Haber p)
        {
            context.Remove(p);
            context.SaveChanges();
        }

        public void SaveHaber(Haber p)
        {
            context.SaveChanges();
        }
    }
}
