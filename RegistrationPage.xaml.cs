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
            AppShell.Current.DisplayAlert("������", "���� � ������ �� ����� ���� ������!", "��");
            return;
        }
 
        bool isPasswordEmpty = string.IsNullOrWhiteSpace(password.Trim());
        if (isPasswordEmpty)
        {
            AppShell.Current.DisplayAlert("������", "���� � ������� �� ����� ���� ������!", "��");
            return;
        }

        bool isPasswordRepeatEmpty = string.IsNullOrWhiteSpace(passwordRepeat.Trim());
        if (isPasswordRepeatEmpty)
        {
            AppShell.Current.DisplayAlert("������", "���� � ������� �� ����� ���� ������!", "��");
            return;
        }

        bool isUsernameExist = ApplicationData.Peoples.Any(x => x.Username == username);
        if (isUsernameExist)
        {
            AppShell.Current.DisplayAlert("������", "����� ��� ��� ����������", "��");
            return;
        }

        if (password != passwordRepeat)
        {
            AppShell.Current.DisplayAlert("�����", "������ �� ����������", "���");
            return;
        }

        ApplicationData.Peoples.Add(new User(username, password));

        AppShell.Current.DisplayAlert("�����", "������������ ��������", "��");
        AppShell.Current.GoToAsync("..", true);
    }
}