using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MIND_LIFT.View;

namespace MIND_LIFT.ViewModel;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string? email;

    [ObservableProperty]
    private string? password;

    [RelayCommand]
    public async Task Login()
    {
        //await Application.Current.MainPage.DisplayAlert("Debug", $"Email: {Email ?? "null"}, Password: {Password ?? "null"}", "OK");    //   T Catch exceptions

        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Email or Password is empty!", "OK");
            return;
        }
        if (Email == "user" && Password == "pass")
        {
            //try
            //{                                                                                                                          //   To Catch exceptions
            await Shell.Current.GoToAsync("//DashboardPage");
                
            //}

            //catch (Exception ex)
            //{
            //    // This will catch any runtime errors like misconfigured routes
            //    await Application.Current.MainPage.DisplayAlert("Navigation Crash", ex.ToString(), "OK");                              //   To Catch exceptions
            //}

        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Login Failed", "Invalid email or password", "OK");
        }
    }

    [RelayCommand]
    private async Task GoToSignUp()
    {
        await Shell.Current.GoToAsync("//SignupPage");
    }
}

