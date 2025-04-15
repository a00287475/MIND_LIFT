using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MIND_LIFT.Services;
using System.Diagnostics;

namespace MIND_LIFT.ViewModel;

public partial class SignupViewModel : ObservableObject
{
    private readonly FirebaseAuthService _authService;

    public SignupViewModel()
    {
        _authService = new FirebaseAuthService();
    }

    // 🔤 Input Properties (Bound from XAML)
    [ObservableProperty]
    private string firstName;

    [ObservableProperty]
    private string lastName;

    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private string confirmPassword;

    // 🟢 Sign Up Command (linked in XAML to Button)
    [RelayCommand]
    private async Task SignupAsync()
    {
        if (string.IsNullOrWhiteSpace(Email) ||
            string.IsNullOrWhiteSpace(Password) ||
            string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            await ShowAlert("Error", "Please fill in all required fields.");
            return;
        }

        if (Password != ConfirmPassword)
        {
            await ShowAlert("Error", "Passwords do not match.");
            return;
        }

        try
        {
            // Register the user with Firebase
            string token = await _authService.RegisterAsync(Email, Password);

            // After successful signup, navigate to LoginPage
            await ShowAlert("Success", "Account created! You can now log in.");
            await Shell.Current.GoToAsync("LoginPage"); // Use the correct route name
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[Signup Error] {ex.Message}");
            await ShowAlert("Signup Failed", ex.Message);
        }
    }

    // 🔁 Go To Login Page Command
    [RelayCommand]
    private async Task GoToLoginAsync()
    {
        // Ensure we navigate to the correct page route
        await Shell.Current.GoToAsync("LoginPage");
    }

    // 🛎️ Helper to show alerts
    private Task ShowAlert(string title, string message) =>
        Application.Current.MainPage.DisplayAlert(title, message, "OK");
}
