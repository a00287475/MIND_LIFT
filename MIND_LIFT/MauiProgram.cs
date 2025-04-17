using Microsoft.Extensions.Logging;
using MIND_LIFT.Services;
using MIND_LIFT.View;
using MIND_LIFT.ViewModel;

namespace MIND_LIFT
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<FirestoreService>();
            builder.Services.AddSingleton<DashboardViewModel>();

#endif

            return builder.Build();
        }
    }
}
