using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using CleverAuto.Helpers;
using CleverAuto.Services;
using Microsoft.Extensions.Logging;

namespace CleverAuto
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
#endif
            builder.Services
     .AddBlazorise(options =>
     {
         options.Immediate = true;
     })
     .AddBootstrapProviders()
     .AddFontAwesomeIcons();
            builder.Services.AddSingleton<CustomerService>();
            builder.Services.AddSingleton<HttpClientInstance>();

            return builder.Build();
        }
    }
}
