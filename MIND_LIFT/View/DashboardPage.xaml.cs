using MIND_LIFT.ViewModels;

namespace MIND_LIFT.View;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
        BindingContext = new DashboardViewModel();
    }
}