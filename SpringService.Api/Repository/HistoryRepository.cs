using SpringService.Api.Models;
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        public bool CreateHistory(History history)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHistory(int id)
        {
            throw new NotImplementedException();
        }

        public List<History> GetAllHistories()
        {
            throw new NotImplementedException();
        }

        public List<History> GetHistories(User user)
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
