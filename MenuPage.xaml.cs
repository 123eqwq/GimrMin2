namespace GimrMin2;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
	}

	private void GoBackToFirstPage(object sender, EventArgs e)
	{
		AppShell.Current.GoToAsync("//" + nameof(LoginPage), true);
	}
}