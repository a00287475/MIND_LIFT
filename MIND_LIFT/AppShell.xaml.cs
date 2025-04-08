namespace MIND_LIFT;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("DashboardPage", typeof(View.DashboardPage));
    }
}
