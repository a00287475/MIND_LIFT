using MIND_LIFT.ViewModel;


namespace MIND_LIFT.View;

public partial class DashboardPage : ContentPage
{
    public DashboardPage(DashboardViewModel viewModel) 
    {
        InitializeComponent();
        BindingContext = viewModel; 
    }
}