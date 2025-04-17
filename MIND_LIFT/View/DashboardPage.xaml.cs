using MIND_LIFT.ViewModel;
using MIND_LIFT.Services;

namespace MIND_LIFT.View
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage(DashboardViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel; // Use the injected ViewModel
        }
    }
}