namespace MIND_LIFT.View;

public partial class TestPage : ContentPage
{
	public TestPage()
	{
		InitializeComponent();
        Application.Current.MainPage.DisplayAlert("TestPage", "Constructor reached!", "OK");
    }
}