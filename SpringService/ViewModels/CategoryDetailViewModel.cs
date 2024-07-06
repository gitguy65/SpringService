using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpringService.Models;
using SpringService.Views;

namespace SpringService.ViewModels
{
    [QueryProperty(nameof(Category), "Category")]
    public partial class CategoryDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        Category category;

        public CategoryDetailViewModel()
        {

        }

        [RelayCommand]
        static async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task CreateBooking()
        {
            await Shell.Current.GoToAsync(nameof(BookingCreate));
        }
    } 
}
