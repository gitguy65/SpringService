using Microsoft.Maui.Networking;
using SpringService.Models;
using SpringService.Services; 
using System.Collections.ObjectModel;
using System.Diagnostics; 

namespace SpringService.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {
        private readonly HistoryService historyService;
        private readonly IConnectivity connectivity;

        public ObservableCollection<History> History { get; } = new();
        public HistoryViewModel(HistoryService historyService, IConnectivity connectivity)
        {
            this.historyService = historyService;
            this.connectivity = connectivity;
        }

        async Task GetReviewsAsync()
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Connection Error!", "Check your internet and try again", "OK");
                return;
            }

            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var histories = await historyService.GetHistory();

                if (History.Count != 0)
                    History.Clear();

                foreach (var history in histories)
                    History.Add(history);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get histories: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
