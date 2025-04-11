using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MIND_LIFT.ViewModel;

public partial class SignupViewModel : ObservableObject
{
    // ViewModel properties would go here
    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    [RelayCommand]
    private async Task GoToLogin()
    {
        await Shell.Current.GoToAsync("//LoginPage");
    }
}