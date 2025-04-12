using MIND_LIFT.ViewModel;
using System;
using MIND_LIFT.Model; // <-- Ensure this points to the correct namespace where FirebaseAuthService is defined


namespace MIND_LIFT.View;
public partial class LoginPage : ContentPage
{
    private FirebaseAuthService authService;

    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();

        // Check if AuthenticationService is initialized
        if (authService == null)
        {
            authService = new FirebaseAuthService();
        }
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // Check if the UI elements are properly initialized
        if (EmailEntry != null && PasswordEntry != null)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    await authService.SignInWithEmailPassword(email, password);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Login failed: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Email or password is empty.");
            }
        }
        else
        {
            Console.WriteLine("EmailEntry or PasswordEntry is not initialized.");
        }
    }
}