using MIND_LIFT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MIND_LIFT.Services;


namespace MIND_LIFT.ViewModel;

public partial class DashboardViewModel : ObservableObject
{
    private readonly FirestoreService _firestoreService;

    [ObservableProperty]
    private Affirmation dailyAffirmation;


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
    private async Task DisplayAllMoodEntries()
    {
        
        try
        {
            // Replace these with actual values from your auth system
            string userId = "YOUR_USER_ID";
            string idToken = "YOUR_AUTH_TOKEN";

            var entries = await _firestoreService.GetMoodEntriesAsync(userId, idToken);

            Console.WriteLine("\n==== ALL MOOD ENTRIES ====");
            foreach (var entry in entries)
            {
                Console.WriteLine($"\nDate: {entry.Date}");
                Console.WriteLine($"Mood Score: {entry.MoodScore}/10");
                Console.WriteLine($"Emotions: {string.Join(", ", entry.Emotions)}");
                Console.WriteLine($"Notes: {entry.Notes ?? "None"}");
            }
            Console.WriteLine($"\nTotal entries: {entries.Count}");
            Console.WriteLine("=========================\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error displaying entries: {ex.Message}");
        }
    }
}
