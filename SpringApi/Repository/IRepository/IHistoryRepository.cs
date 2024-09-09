using SpringApi.Model;

namespace SpringApi.Repository.IRepository
{
    public interface IHistoryRepository
    {
        IEnumerable<History> GetAllHistories();
        IEnumerable<History> GetHistories(UserProfile user);
        bool CreateHistory(History history);
        bool UpdateHistory(History history);
        bool DeleteHistory(int id);
        bool HistoryExists(History history);
    }
}
