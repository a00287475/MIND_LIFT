using MIND_LIFT.Model;
using MIND_LIFT.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace MIND_LIFT.ViewModel;

[QueryProperty(nameof(UserId), "userId")]
[QueryProperty(nameof(IdToken), "idToken")]
public partial class DashboardViewModel : ObservableObject
{


    private readonly FirestoreService _firestoreService;

    [ObservableProperty]
    private string userId;

    [ObservableProperty]
    private string idToken;

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
        _ = LoadMoodEntries();
    }

    [RelayCommand]
    private async Task LoadMoodEntries()
    {
        IsLoading = true;
        await Shell.Current.DisplayAlert("Credentials", $"UserId: {UserId}\nToken: {IdToken}", "OK");

        if (string.IsNullOrWhiteSpace(UserId) || string.IsNullOrWhiteSpace(IdToken))
        {
            await Shell.Current.DisplayAlert("Missing Credentials",
                $"UserId: {UserId ?? "null"}\nToken: {IdToken ?? "null"}", "OK");
            return;
        }
    }

   

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


}


