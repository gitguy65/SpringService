using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input; 
using SpringService.Models;
using SpringService.Services;
using SpringService.Services.IService;
using SpringService.Views;
using System.Collections.ObjectModel; 

namespace SpringService.ViewModels
{
    public partial class BookingsViewModel : BaseViewModel
    {
        private readonly BookingService bookingService; 
        private readonly IConnectivity connectivity;
        private readonly IBookingService bookingServiceAsync;

        public ObservableCollection<Booking> Bookings { get; } = [];

        [ObservableProperty]
        bool isRefreshing;

        public BookingsViewModel(BookingService bookingService, 
                                 IConnectivity connectivity,
                                 IBookingService bookingServiceAsync)
        {
            this.bookingService = bookingService; 
            this.connectivity = connectivity;
            this.bookingServiceAsync = bookingServiceAsync;

            GetBookings();
        }

        /*private async void InitializeAsync()
        {
            await GetBookingsAsync();
        }*/    
        /* 
        public async Task GetBookingsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Connection Error!", "Check your internet and try again", "OK");
                    return;
                }
                IsBusy = true;
                List<Booking> bookings = await bookingServiceAsync.GetBookings();
                
                if (Bookings.Count != 0)
                    Bookings.Clear();

                foreach (var booking in bookings)
                {
                    Bookings.Add(booking); 
                }     
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", $"Unable to get bookings: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }*/

        [RelayCommand]
        public void GetBookings()
        {
            if (IsBusy)
                return;

            try
            { 
                IsBusy = true;
                List<Booking> bookings = bookingService.GetBookings();

                if (Bookings.Count != 0)
                    Bookings.Clear();

                foreach (var booking in bookings)
                {
                    Bookings.Add(booking);
                }
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error!", $"Unable to get bookings: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        
        [RelayCommand]
        public async Task BookingDetail(Booking booking)
        {
            if (booking is null)
                await Shell.Current.DisplayAlert("Error!", "No bookings found", "OK");
                //return;

            await Shell.Current.GoToAsync($"{nameof(BookingDetail)}", true, new Dictionary<string, object>
            {
                { "Booking", booking}
            });
        }
        

        [RelayCommand]
        public async Task CreateBooking()
        { 
            await Shell.Current.GoToAsync(nameof(BookingCreate)); 
        }
    }
}
