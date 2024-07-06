using SpringService.Models;
using SpringService.ViewModels;

namespace SpringService.Views;

public partial class CategoryDetail : ContentPage
{
    public Category Category { get; set; }
    public CategoryDetail(CategoryDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}