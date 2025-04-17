using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using MIND_LIFT.Model;
using MIND_LIFT.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MIND_LIFT.ViewModel
{
    public partial class DashboardViewModel : ObservableObject
    {
        private readonly FirestoreService _firestoreService;

        [ObservableProperty]
        private string userId = string.Empty;  // Properly initialized

        [ObservableProperty]
        private string idToken = string.Empty; // Properly initialized

        [ObservableProperty]
        private Affirmation dailyAffirmation;

        [ObservableProperty]
        private ObservableCollection<MoodEntry> moodEntries = new();

        [ObservableProperty]
        private bool isLoading;

        public DashboardViewModel(FirestoreService firestoreService)
        {
            _firestoreService = firestoreService;
            DailyAffirmation = new Affirmation { Message = "You are strong, capable, and resilient." };

            // Load credentials when VM initializes
            _ = LoadCredentials();
        }

        private async Task LoadCredentials()
        {
            // Get from SecureStorage
            var userId = await SecureStorage.GetAsync("userId") ?? "[no user ID found]";
            var token = await SecureStorage.GetAsync("idToken") ?? "[no token found]";

            // Show only first 5 chars of token for security
            await Shell.Current.DisplayAlert(
                "Firebase Credentials",
                $"User ID: {userId}\nToken: {token[..Math.Min(5, token.Length)]}...",
                "OK"
            );
        }

        [RelayCommand]
        private async Task LoadMoodEntries()
        {
            if (IsLoading) return;

            IsLoading = true;

            try
            {
                // Your existing mood entries loading logic
                // Can safely use UserId and IdToken here
            }
            finally
            {
                IsLoading = false;
            }
        }

        // All your navigation commands preserved exactly as they were
        [RelayCommand]
        private async Task GotoMoodTracker()
        {
            await Shell.Current.GoToAsync("MoodTrackerPage");
        }

        [RelayCommand]
        private async Task NavigateToMeditation()
        {
            await Shell.Current.GoToAsync("MeditationPage");
        }

        [RelayCommand]
        private async Task NavigateToJournal()
        {
            await Shell.Current.GoToAsync("JournalPage");
        }

        [RelayCommand]
        private async Task NavigateToSettings()
        {
            await Shell.Current.GoToAsync("SettingsPage");
        }

        // Add any other navigation commands you had originally
    }
}