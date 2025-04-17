using MIND_LIFT.Model;
using MIND_LIFT.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MIND_LIFT.ViewModel;

public partial class DashboardViewModel : ObservableObject
{
    private readonly FirestoreService _firestoreService;

    [ObservableProperty]
    private Affirmation dailyAffirmation;

    [ObservableProperty]
    private ObservableCollection<MoodEntry> moodEntries = new();

    [ObservableProperty]
    private bool isLoading;

    public DashboardViewModel(FirestoreService firestoreService)
    {
        _firestoreService = firestoreService;
        DailyAffirmation = new Affirmation
        {
            Message = "You are strong, capable, and resilient."
        };
    }

    [RelayCommand]
    private async Task GotoMoodTracker()
    {
        await Shell.Current.GoToAsync("MoodTrackerPage");
    }

    [RelayCommand]
    private async Task LoadMoodEntries()
    {
        IsLoading = true;
        try
        {
            string userId = "YOUR_USER_ID"; // Get from your auth system
            string idToken = "YOUR_AUTH_TOKEN"; // Get from your auth system

            var entries = await _firestoreService.GetAllMoodEntriesAsync(userId, idToken);

            MoodEntries.Clear();
            foreach (var entry in entries)
            {
                MoodEntries.Add(entry);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsLoading = false;
        }
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
}