namespace GimrMin2;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}
    private void GoBackToLoginPage(object sender, EventArgs e)
    {
        AppShell.Current.GoToAsync("..", true);
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



    private void RegisterUser(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;
        string passwordRepeat = PasswordRepeatEntry.Text;


        bool isUsernameEmpty = string.IsNullOrWhiteSpace(username.Trim());
        if (isUsernameEmpty)
        {
            AppShell.Current.DisplayAlert("Ошибка", "Поле с именем не может быть пустым!", "ОК");
            return;
        }
 
        bool isPasswordEmpty = string.IsNullOrWhiteSpace(password.Trim());
        if (isPasswordEmpty)
        {
            AppShell.Current.DisplayAlert("Ошибка", "Поле с паролем не может быть пустым!", "ОК");
            return;
        }

        bool isPasswordRepeatEmpty = string.IsNullOrWhiteSpace(passwordRepeat.Trim());
        if (isPasswordRepeatEmpty)
        {
            AppShell.Current.DisplayAlert("Ошибка", "Поле с паролем не может быть пустым!", "ОК");
            return;
        }

        bool isUsernameExist = ApplicationData.Peoples.Any(x => x.Username == username);
        if (isUsernameExist)
        {
            AppShell.Current.DisplayAlert("Ошибка", "Даное имя уже существует", "ОК");
            return;
        }

        if (password != passwordRepeat)
        {
            AppShell.Current.DisplayAlert("Плохо", "Пороль не одинаковый", "ОКИ");
            return;
        }

        ApplicationData.Peoples.Add(new User(username, password));

        AppShell.Current.DisplayAlert("Успех", "Позьзователь добавлен", "ОК");
        AppShell.Current.GoToAsync("..", true);
    }
}