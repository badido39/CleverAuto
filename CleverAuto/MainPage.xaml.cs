

using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;

namespace CleverAuto
{
    public partial class MainPage : ContentPage
    {
        private readonly ToastService _toastService;

        public MainPage(ToastService toastService)
        {
            _toastService = toastService;
        }

        public MainPage()
        {
            InitializeComponent();
            var hubConnection = new HubConnectionBuilder()
             .WithUrl("http://localhost:5156/hub")
             .Build();

            // Handle the "ReceiveNotification" event
            hubConnection.On<string>("ReceiveMessage", (message) =>
            {
                // Handle the received notification in your .NET MAUI app
                _toastService.Notify(new(ToastType.Danger, $"Error: {message}."));

                Debug.WriteLine($"Received notification: {message}");
            });

            // Start the SignalR connection
            Task.Run(() =>
            {
                Dispatcher.Dispatch(async () =>
                await hubConnection.StartAsync()
                );
            });
        }
        
       
    }
}
