using CommunityToolkit.Mvvm.Input; 
using SpringService.Models;
using SpringService.Services;
using SpringService.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SpringService.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly ReviewService reviewService;
        private readonly CategoryService categoryService;
        private readonly IConnectivity connectivity;

        public ObservableCollection<Review> Reviews { get; } = [];
        public ObservableCollection<Category> Categories { get; } = [];

        public HomeViewModel(IConnectivity connectivity,
                             CategoryService categoryService,
                             ReviewService reviewSevice)
        {
            this.reviewService = reviewSevice;
            this.categoryService = categoryService;
            this.connectivity = connectivity;

            GetPopularCategories();
        }

        public async Task GetReviews()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var reviews = reviewService.GetPopularReviews();

                if (Reviews.Count != 0)
                    Reviews.Clear();

                foreach (var review in reviews)
                    Reviews.Add(review);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get reviews: { ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void GetPopularCategories()
        {
            if (IsBusy)
                return;

            try
            { 
                IsBusy = true;
                List<Category> categories = categoryService.GetPopularServices();

                if (Categories.Count != 0)
                    Categories.Clear();

                foreach (var category in categories)
                {
                    Categories.Add(category); 
                }
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error!", $"Unable to get categories: {ex.Message}", "OK");
            }
            finally
            { 
                IsBusy = false;
            }
        }


        [RelayCommand] 
        public async Task CategoryDetail(Category category)
        {
            if (category is null)
            {
                await Shell.Current.DisplayAlert("Error!", "No Categories found", "OK");
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(CategoryDetail)}", true, new Dictionary<string, object>
            {
                { "Category", category }
            });
        }


        [RelayCommand]
        public async Task CreateBooking()
        {
            await Shell.Current.GoToAsync(nameof(BookingCreate));
        }
    }
}
