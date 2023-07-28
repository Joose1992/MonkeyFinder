using MonkeyFinder.Views;

namespace MonkeyFinder;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Views.MainPage), typeof(Views.MainPage));
		Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
	}
}

