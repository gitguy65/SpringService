using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input; 
using SpringService.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SpringService.ViewModels
{
    [QueryProperty("Booking", "Booking")]
    public partial class BookingDetailViewModel : BaseViewModel
    {
        private readonly IConnectivity connectivity;
        private readonly IGeolocation geolocation;
        [ObservableProperty]
        Booking booking;

        ObservableCollection<User> Technicians { get; } = [];

        public BookingDetailViewModel(IConnectivity connectivity, IGeolocation geolocation)
        {
            this.connectivity = connectivity;
            this.geolocation = geolocation;
        }

        [RelayCommand]
        static async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task GetClosestTechnician()
        {
            if (IsBusy || Technicians.Count == 0)
                return;

            try
            {
                var IsAllowed = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                var location = await geolocation.GetLastKnownLocationAsync();
                
                location ??= await geolocation.GetLocationAsync(
                        new GeolocationRequest
                        {
                            DesiredAccuracy = GeolocationAccuracy.Medium,
                            Timeout = TimeSpan.FromSeconds(30),
                        });

                if (location is null)
                    return;

                /*var first = Technicians
                    .OrderBy( m => location.CalculateDistance(m.Latitude, m.Longitude, DistanceUnits.Miles)
                    .FirstOrDefault());

                if (first is null)
                    return;

                await Shell.Current.DisplayAlert("Closest Technician ", $"{first.Name} in {first.Location}", "Ok");*/
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get closest technicians by location: {ex}", "Ok");
            }
        }
    }
}
