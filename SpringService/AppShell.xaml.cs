using SpringService.Views;

namespace SpringService
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CategoryDetail), typeof(CategoryDetail));
            Routing.RegisterRoute(nameof(BookingDetail), typeof(BookingDetail));
            Routing.RegisterRoute(nameof(BookingCreate), typeof(BookingCreate));
        }
    }
}
