using DiplomaBlazor.ViewModels;

namespace DiplomaBlazor;

public partial class MainPage : ContentPage
{
	public MainPage(AppViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
