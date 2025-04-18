﻿using MIND_LIFT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace MIND_LIFT.ViewModel;

public partial class DashboardViewModel : ObservableObject
{
    [ObservableProperty]
    private Affirmation dailyAffirmation;

    public DashboardViewModel()
    {
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
}
