using System.Xml.Serialization;
using MIND_LIFT.View;

namespace MIND_LIFT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }


    }
}