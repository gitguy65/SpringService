using SpringService.ViewModels;

namespace SpringService.Views;

public partial class Categories : ContentPage
{
	public Categories(CategoriesViewModel categoriesViewModel)
	{
		InitializeComponent();
		BindingContext = categoriesViewModel;
	}
}