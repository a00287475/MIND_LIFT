using MIND_LIFT.Components;
using MIND_LIFT.Model;
using MIND_LIFT.View;
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