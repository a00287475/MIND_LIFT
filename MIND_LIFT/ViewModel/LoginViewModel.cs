using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MIND_LIFT.Services;

namespace MIND_LIFT.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly FirebaseAuthService _authService = new();
        private readonly FirestoreService _firestoreService = new();

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Email and password cannot be empty", "OK");
                return;
            }

            try
            {
                var authLink =  await _authService.SignInWithEmailAndPasswordAsync(Email, Password);

                var idToken = authLink.FirebaseToken;
                var userId = authLink.User.LocalId;

                // ✅ Save token and user ID securely
                await SecureStorage.SetAsync("idToken", idToken);
                await SecureStorage.SetAsync("userId", userId);
                await Shell.Current.DisplayAlert("Success", "Logged in successfully!", "OK");
                await Shell.Current.GoToAsync("//DashboardPage");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Login Failed", ex.Message, "OK");
            }
        }

        [RelayCommand]
        private async Task GoToSignup()
        {
            await Shell.Current.GoToAsync("//SignupPage"); // Fixed typo
        }
    }
}