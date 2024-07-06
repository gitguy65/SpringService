using SpringService.ViewModels;

namespace SpringService.Views;

public partial class BookingCreate : ContentPage
{
	public BookingCreate(BookingCreateViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}