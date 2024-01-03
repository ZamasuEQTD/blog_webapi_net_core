using Shared.Common.Domain;

namespace Data
{
    static public class DataExtensions
    {
        static public IQueryable<T> PorPagina<T>(this IQueryable<T> query, int pagina, int? take = 15)
        {
            return query.Skip(0).Take(take?? 15);
        }

        static public IQueryable<T> OrdenarPorPrimeroCreado<T>(this IQueryable<T> query) where T : BaseModel
        {
            return query.OrderByDescending(h => h.CreatedAt);
        }
    }
}