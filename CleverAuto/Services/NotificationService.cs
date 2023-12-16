using CleverAuto.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;
using System.Text.Json;

namespace CleverAuto.Services
{
    public class SignalRService
    {
        private readonly HubConnection _connection;

        public event Action<Notification> OnMessageReceived;
        public event Action OnConnected;
        public event Action OnDisconnected;
        public event Action OnReconnected; // New event for reconnection


        public SignalRService()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5156/hub")

                .Build();
            _connection.On<string>("MessageReceived", (json) =>
            {
                try
                {
                    Console.WriteLine(json);
                    var notification = JsonSerializer.Deserialize<Notification>(json);
                    Console.WriteLine($"Send at :{notification.Created} with title :{notification.Title} with message : {notification.Message} Seen : {notification.Seen}");

                    OnMessageReceived?.Invoke(notification);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                }
            });

            _connection.Closed +=  (exception) =>
            {


                Console.WriteLine($"Connection closed. Error: {exception?.Message}");
                OnDisconnected?.Invoke();
                try
                {
                StartConnectionAsync();

                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Connection closed. Error: {ex?.Message}");
                }

                return Task.CompletedTask;
            };
          

            _ = StartConnectionAsync();

            
        }

        public async Task StartConnectionAsync()
        {
            try
            {
                await _connection.StartAsync();
                Console.WriteLine("Connection started");
                OnConnected?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting connection: {ex.Message}");
            }
        }

        public async Task StopConnectionAsync()
        {
            await _connection.StopAsync();
        }
    }
}
