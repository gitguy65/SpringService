using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using SpringService.Models;
using SpringService.Services;

namespace SpringService.ViewModels
{
    public partial class CategoriesViewModel : BaseViewModel
    {
        private readonly CategoryService categoryService;
        public ObservableCollection<Category> Categories { get; } = [];
        public CategoriesViewModel(CategoryService categoryService) {
            this.categoryService = categoryService;
            GetAllServices();
        }


        public void GetAllServices()
        {
            if (IsBusy) { } 

            try
            {
                IsBusy = true;
                List<Category> categories = categoryService.GetAllServices();

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


    }
}
