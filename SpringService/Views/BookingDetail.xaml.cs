using SpringService.Models;
using SpringService.ViewModels;

namespace SpringService.Views;

public partial class BookingDetail : ContentPage
{
	public Booking Booking { get; set; }
	public BookingDetail(BookingDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}