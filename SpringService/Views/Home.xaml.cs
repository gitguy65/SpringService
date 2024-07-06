using SpringService.ViewModels;

namespace SpringService.Views;

public partial class Home : ContentPage
{
	public Home(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		BindingContext = homeViewModel;
	}
}