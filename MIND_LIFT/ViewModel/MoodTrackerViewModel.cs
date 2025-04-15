using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MIND_LIFT.Model;
using MIND_LIFT.Services;

namespace MIND_LIFT.ViewModel
{
    public partial class MoodTrackerViewModel : ObservableObject
    {
        private readonly FirestoreService _firestoreService;
        private readonly FirebaseAuthService _authService;

        [ObservableProperty]
        private string userId;

        [ObservableProperty]
        private string idToken;

        [ObservableProperty]
        private int moodScore;

        [ObservableProperty]
        private ObservableCollection<string> selectedEmotions;

        [ObservableProperty]
        private string notes;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string statusMessage;

        public MoodTrackerViewModel()
        {
            _firestoreService = new FirestoreService();
            _authService = new FirebaseAuthService();
            SelectedEmotions = new ObservableCollection<string>();
            MoodScore = 5; // Default mood score
        }

        // Used to set credentials after login
        public void SetUserCredentials(string userId, string idToken)
        {
            UserId = userId;
            IdToken = idToken;
        }

        [RelayCommand]
        private async Task SubmitMoodAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                StatusMessage = "Submitting mood...";

                if (string.IsNullOrWhiteSpace(UserId) || string.IsNullOrWhiteSpace(IdToken))
                {
                    StatusMessage = "User not authenticated.";
                    return;
                }

                // Create a mood summary from selected emotions
                string mood = SelectedEmotions.Count > 0
                    ? string.Join(", ", SelectedEmotions)
                    : "Neutral";

                // ? Create moodEntry object
                var moodEntry = new MoodEntry
                {
                    EntryId = Guid.NewGuid().ToString(),
                    UserId = UserId,
                    Date = DateTime.UtcNow,
                    MoodScore = MoodScore,
                    Emotions = new List<string>(SelectedEmotions),
                    Notes = Notes
                };

                // ? Pass the moodEntry object to the method
                await _firestoreService.AddMoodEntryAsync(IdToken, moodEntry);


                StatusMessage = "Mood entry saved successfully!";
                Notes = string.Empty;
                SelectedEmotions.Clear();
                MoodScore = 5;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to submit mood: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
