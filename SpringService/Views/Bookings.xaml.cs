using SpringService.ViewModels;

namespace SpringService.Views;

public partial class Bookings : ContentPage
{
    public Bookings(BookingsViewModel bookingsViewModel)
    {
        InitializeComponent();
        BindingContext = bookingsViewModel;
    }
}