using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MIND_LIFT.ViewModel;

public partial class MoodTrackerViewModel : ObservableObject
{
    [ObservableProperty]
    private int selectedMoodRating;

    [ObservableProperty]
    private List<string> selectedEmotions = new();

    [RelayCommand]
    private void Submit()
    {
        // Handle submission logic here
    }
}