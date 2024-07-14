using SpringService.Api.Models;

namespace SpringService.Api.Repository.IRepository
{
    public interface IHistoryRepository
    {
        IEnumerable<History> GetAllHistories();
        IEnumerable<History> GetHistories(User user);
        bool CreateHistory(History history);
        bool UpdateHistory(History history);
        bool DeleteHistory(int id);
        bool HistoryExists(History history);
    }
}
