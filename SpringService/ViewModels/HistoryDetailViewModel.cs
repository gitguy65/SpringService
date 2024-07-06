using CommunityToolkit.Mvvm.ComponentModel;
using SpringService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringService.ViewModels
{
    [QueryProperty("History", "History")]
    public partial class HistoryDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        History history;

        public HistoryDetailViewModel()
        {
            
        }
    }
}
