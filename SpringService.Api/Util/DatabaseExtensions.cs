using SpringService.Api.Models;

namespace SpringService.Api.Util
{
    static class DatabaseExtensions
    {
        public static IQueryable<Booking> GetFilteredBookings(this IQueryable<Booking> query, string? titleFilter, bool? doneFilter, int? skip, int? take)
        {
            if (!string.IsNullOrEmpty(titleFilter))
                query = query.Where(t => t.Description.Contains(titleFilter));

            if (doneFilter is not null)
                query = query.Where(t => t.IsJobCompleted == doneFilter);

                if (skip is not null)
                    query = query.Skip(skip.Value);

            if (take is not null)
                query = query.Take(take.Value);

            return query;
        }
    }
}




