using MIND_LIFT.ViewModel;

namespace MIND_LIFT.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}