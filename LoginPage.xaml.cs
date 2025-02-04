namespace GimrMin2;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    public void OnSvgImageTapped(object sender, EventArgs e)
    {
        if (PasswordEntry.IsPassword == true)
        {
            SvgImage.Source = "visible.svg";
            PasswordEntry.IsPassword = false;
        }
        else
        {
            SvgImage.Source = "not_visible.svg";
            PasswordEntry.IsPassword = true;
        }

    }


    private void GoToMenuPage(object sender, EventArgs e)
    {
        string PeopleName = UsernameEntry.Text.Trim();
        string PeoplePassword = PasswordEntry.Text.Trim();

        bool isPeopleNameEmpty = string.IsNullOrWhiteSpace(PeopleName);
        if (isPeopleNameEmpty)
        {
            AppShell.Current.DisplayAlert("Ошибка", "Поле с именем не может быть пустым!", "ОК");
            return;
        }

        bool isPeoplePasswordEmpty = string.IsNullOrWhiteSpace(PeoplePassword);
        if (isPeoplePasswordEmpty)
        {
            AppShell.Current.DisplayAlert("Ошибка", "Поле с паролем не может быть пустым!", "ОК");
            return;
        }

        bool isLoginSucceded = ApplicationData.Peoples.Any(x => x.Username == PeopleName && x.Password == PeoplePassword);
        if (!isLoginSucceded)
        {
            AppShell.Current.DisplayAlert("Ошибка", "Имя или пароль не совпадают", "ОК");
            return;
        }

        AppShell.Current.GoToAsync("//" + nameof(MenuPage), true);
    }

    private void GoToRegistrationPage(object sender, EventArgs e)
    {
        AppShell.Current.GoToAsync(nameof(RegistrationPage), true);
    }
}
