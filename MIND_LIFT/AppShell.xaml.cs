using MIND_LIFT.View;

namespace MIND_LIFT;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();


        Routing.RegisterRoute("DashboardPage", typeof(View.DashboardPage));
        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
    }
}
