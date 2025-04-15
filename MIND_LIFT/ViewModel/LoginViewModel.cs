using System.Windows.Input;
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

        public ICommand LoginCommand { get; }
        public ICommand GoToSignUpCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new AsyncRelayCommand(LoginAsync);
            GoToSignUpCommand = new AsyncRelayCommand(NavigateToSignup);
        }

        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Email and password cannot be empty", "OK");
                return;
            }

            try
            {
                string token = await _authService.LoginAsync(Email, Password);
                await Shell.Current.DisplayAlert("Success", "Logged in successfully!", "OK");

                await _firestoreService.AddMoodEntryAsync(token, "user123", "Happy", "Had a great therapy session!");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Login Failed", ex.Message, "OK");
            }
        }

        private async Task NavigateToSignup()
        {
            await Shell.Current.GoToAsync("//SignupPage"); // Adjust route if needed
        }
    }
}
