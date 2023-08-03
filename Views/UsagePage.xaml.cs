using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.ViewModels;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace ExploreCity.Views;

public partial class UsagePage : ContentPage
{
	public UsagePage(UsageViewModel usageViewModel)
	{
		InitializeComponent();
		BindingContext = usageViewModel;
    }
}