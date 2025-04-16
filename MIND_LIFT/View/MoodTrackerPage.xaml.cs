using MIND_LIFT.ViewModel;

namespace MIND_LIFT.View;

public partial class MoodTrackerPage : ContentPage
{
    public MoodTrackerPage()
    {
        InitializeComponent();
        BindingContext = new MoodTrackerViewModel();
    }
}