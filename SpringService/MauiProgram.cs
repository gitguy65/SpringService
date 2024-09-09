using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpringService.Services;
using SpringService.Services.IService;
using SpringService.ViewModels;
using SpringService.Views;

namespace SpringService
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("boxicons.ttf", "BoxIcons");
                });

            builder.Services.AddSingleton<LocalDatabase>();

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddSingleton<IMap>(Map.Default);

            // API Dependency Services
            builder.Services.AddTransient<ReviewService>();
            builder.Services.AddTransient<CategoryService>();
            builder.Services.AddTransient<BookingService>();
            builder.Services.AddTransient<HistoryService>();
            builder.Services.AddTransient<ProfileService>();
            builder.Services.AddTransient<RegistrationService>();
            builder.Services.AddTransient<LoginService>();

            builder.Services.AddTransient<IBookingService, BookingServiceAsync>();
            builder.Services.AddTransient<ICategoryService, CategoryServiceAsync>();
            builder.Services.AddTransient<IReviewService, ReviewService>();

            // Pages
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<Home>();

            builder.Services.AddTransient<CategoryDetailViewModel>();
            builder.Services.AddTransient<CategoryDetail>();

            builder.Services.AddTransient<CategoriesViewModel>();
            builder.Services.AddTransient<Categories>();

            builder.Services.AddTransient<BookingsViewModel>();
            builder.Services.AddTransient<Bookings>();

            builder.Services.AddTransient<BookingDetailViewModel>();
            builder.Services.AddTransient<BookingDetail>();

            builder.Services.AddTransient<BookingCreateViewModel>();
            builder.Services.AddTransient<BookingCreate>();
                               
            builder.Services.AddTransient<HistoryViewModel>();
            builder.Services.AddTransient<History>();

            builder.Services.AddTransient<HistoryDetailViewModel>();
            builder.Services.AddTransient<HistoryDetail>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
