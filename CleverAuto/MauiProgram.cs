﻿using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using CleverAuto.Data;
using CleverAuto.Helpers;
using CleverAuto.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;

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
#if WINDOWS
            builder.ConfigureLifecycleEvents(events =>
            {
                events.AddWindows(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.OnWindowCreated(window =>
                    {
                        IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                        AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);
                        if (winuiAppWindow.Presenter is OverlappedPresenter p)
                            p.Maximize();
                        else
                        {
                            const int width = 1200;
                            const int height = 800;
                            winuiAppWindow.MoveAndResize(new RectInt32(1920 / 2 - width / 2, 1080 / 2 - height / 2, width, height));
                        }

                    });
                });
            });
#endif
            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Filename=AppDatabase.db3"));;

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
            builder.Services.AddSingleton<HttpClientInstance>();
            builder.Services.AddSingleton<ICustomerService, CustomerServiceRemote>();

            return builder.Build();
        }
    }
}
