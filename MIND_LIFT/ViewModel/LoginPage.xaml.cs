using MIND_LIFT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIND_LIFT.ViewModel
{
    public partial class LoginPage : ContentPage
    {
        private FirebaseAuthService _authService;
        private FirestoreService _firestoreService;

        public LoginPage()
        {
            InitializeComponent();
            _authService = new FirebaseAuthService();
            _firestoreService = new FirestoreService();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            try
            {
                string token = await _authService.RegisterAsync(email, password);
                await DisplayAlert("Success", "Registered successfully!", "OK");

                // 🔥 Optional: Add mood entry after registration
                await _firestoreService.AddMoodEntryAsync(token, "user123", "Calm", "Feeling peaceful after meditation");

                await DisplayAlert("Mood Logged", "Mood saved to Firestore", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            try
            {
                string token = await _authService.LoginAsync(email, password);
                await DisplayAlert("Success", "Logged in successfully!", "OK");

                // 🔥 Optional: Add mood entry after login
                await _firestoreService.AddMoodEntryAsync(token, "user123", "Happy", "Had a great therapy session!");

                await DisplayAlert("Mood Logged", "Mood saved to Firestore", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Login Failed", ex.Message, "OK");
            }
        }
    }
}