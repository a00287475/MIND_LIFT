using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MIND_LIFT.Model;
using MIND_LIFT.Services;
using System.Linq;
using Microsoft.Maui.Controls;

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
            MoodScore = 5; // Default mood score (1-10 scale)

            SelectedEmotions.CollectionChanged += (s, e) =>
            {
                if (SelectedEmotions.Count > 5)
                {
                    // Remove last added item if over limit
                    SelectedEmotions.RemoveAt(SelectedEmotions.Count - 1);
                    StatusMessage = "You can select up to 5 emotions only.";
                }
            };
        }

        public void SetUserCredentials(string userId, string idToken)
        {
            UserId = userId;
            IdToken = idToken;
        }

        [RelayCommand]
        private async Task SubmitMoodAsync()
        {
            Console.WriteLine("Submit button clicked.");

            if (IsBusy) return;

            try
            {
                IsBusy = true;
                StatusMessage = "Submitting mood...";

                if (string.IsNullOrWhiteSpace(UserId) || string.IsNullOrWhiteSpace(IdToken))
                {
                    StatusMessage = "User not authenticated.";
                    await Shell.Current.DisplayAlert("Error", "You must be logged in to submit your mood.", "OK");
                    return;
                }

                if (SelectedEmotions.Count == 0)
                {
                    StatusMessage = "Please select at least one emotion.";
                    await Shell.Current.DisplayAlert("Validation", "Please select at least one emotion.", "OK");
                    return;
                }

                var moodEntry = new MoodEntry
                {
                    EntryId = Guid.NewGuid().ToString(),
                    UserId = UserId,
                    Date = DateTime.UtcNow,
                    MoodScore = MoodScore,
                    Emotions = new List<string>(SelectedEmotions),
                    Notes = Notes
                };

                await _firestoreService.AddMoodEntryAsync(IdToken, moodEntry);

                StatusMessage = "Mood entry saved successfully!";
                await Shell.Current.DisplayAlert("Success", "Your mood has been saved.", "OK");

                // Reset form
                Notes = string.Empty;
                SelectedEmotions.Clear();
                MoodScore = 5;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to submit mood: {ex.Message}";
                await Shell.Current.DisplayAlert("Error", $"Failed to save mood: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
