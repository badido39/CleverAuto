using Microsoft.AspNetCore.Components.Web.Extensions;
using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;
namespace CleverAuto
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

        }
        
    }
}
