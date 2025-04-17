using MIND_LIFT.ViewModel;
using MIND_LIFT.Services;


namespace MIND_LIFT.View;

public partial class DashboardPage : ContentPage
{
    public DashboardPage(DashboardViewModel viewModel) 
    {

        if (viewModel == null)
            throw new ArgumentNullException(nameof(viewModel));

        InitializeComponent();
        BindingContext = new DashboardViewModel(new FirestoreService());
    }
}