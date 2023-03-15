using System.Linq;

namespace SportStore.Models
{
    public interface IHaberRepository
    {
        IQueryable<Haber> Haberler { get; }

        void SaveHaber(Haber p);
        void CreateHaber(Haber p);
        void DeleteHaber(Haber p);
    }
}
