using MIND_LIFT.View;

namespace MIND_LIFT;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();


        Routing.RegisterRoute("DashboardPage", typeof(DashboardPage));
        Routing.RegisterRoute("//LoginPage", typeof(LoginPage));
        Routing.RegisterRoute("SignupPage", typeof(SignupPage));
    }
}
