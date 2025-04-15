namespace MIND_LIFT.View;

public partial class MoodTrackerPage : ContentPage
{
    public MoodTrackerPage()
    {
        InitializeComponent();
        BindingContext = new MIND_LIFT.ViewModel.MoodTrackerViewModel();
    }
}