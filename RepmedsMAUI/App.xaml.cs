using Microsoft.Extensions.DependencyInjection;

namespace RepmedApp
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            MainPage = new NavigationPage(_serviceProvider.GetRequiredService<Views.SplashPage>())
            {
                BarBackgroundColor = Color.FromArgb("#004D40"),
                BarTextColor = Colors.White
            };
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            // Set window properties
            window.Title = "Repmed Partner";

            // Set default width and height for desktop platforms
            if (DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst ||
                DeviceInfo.Current.Platform == DevicePlatform.WinUI)
            {
                window.Width = 400;
                window.Height = 800;
            }

            // Handle window events
            window.Created += (s, e) =>
            {
                // Window created
            };

            window.Activated += (s, e) =>
            {
                // Window activated
            };

            window.Deactivated += (s, e) =>
            {
                // Window deactivated
            };

            window.Destroying += (s, e) =>
            {
                // Window being destroyed
            };

            return window;
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
