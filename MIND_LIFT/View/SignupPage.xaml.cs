namespace MIND_LIFT.View;

public partial class SignupPage : ContentPage
{
	public SignupPage()
	{
		InitializeComponent();
        BindingContext = new MIND_LIFT.ViewModel.SignupViewModel();
    }
}