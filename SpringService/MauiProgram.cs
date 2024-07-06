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
            builder.Services.AddSingleton<ReviewService>();
            builder.Services.AddSingleton<CategoryService>();
            builder.Services.AddSingleton<BookingService>();
            builder.Services.AddSingleton<HistoryService>();
            builder.Services.AddSingleton<ProfileService>();
            builder.Services.AddSingleton<RegistrationService>();
            builder.Services.AddSingleton<LoginService>();

            builder.Services.AddSingleton<IBookingService, BookingServiceAsync>();
            builder.Services.AddSingleton<ICategoryService, CategoryServiceAsync>();
            builder.Services.AddSingleton<IReviewService, ReviewService>();

            // Pages
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<Home>();

            builder.Services.AddTransient<CategoryDetailViewModel>();
            builder.Services.AddTransient<CategoryDetail>();

            builder.Services.AddTransient<CategoriesViewModel>();
            builder.Services.AddTransient<Categories>();

            builder.Services.AddSingleton<BookingsViewModel>();
            builder.Services.AddSingleton<Bookings>();

            builder.Services.AddTransient<BookingDetailViewModel>();
            builder.Services.AddTransient<BookingDetail>();

            builder.Services.AddSingleton<BookingCreateViewModel>();
            builder.Services.AddSingleton<BookingCreate>();
                               
            builder.Services.AddSingleton<HistoryViewModel>();
            builder.Services.AddSingleton<History>();

            builder.Services.AddTransient<HistoryDetailViewModel>();
            builder.Services.AddTransient<HistoryDetail>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
