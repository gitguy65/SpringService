using SpringService.Api.Data;
using SpringService.Api.Models;
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Repository
{
    public class HistoryRepository(ApplicationDbContext context) : BaseRepository(context), IHistoryRepository
    {
        private new readonly ApplicationDbContext context = context;
        public bool CreateHistory(History history)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHistory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<History> GetAllHistories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<History> GetHistories(AppUser user)
        {
            throw new NotImplementedException();
        }

        public bool HistoryExists(History history)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHistory(History history)
        {
            throw new NotImplementedException();
        }
    }
}
