using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MIND_LIFT.ViewModel;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    [RelayCommand]
    public async Task Login()
    {
        if (Email == "user" && Password == "pass")
        {
            await Shell.Current.GoToAsync("//DashboardPage");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Login Failed", "Invalid email or password", "OK");
        }
    }
}

