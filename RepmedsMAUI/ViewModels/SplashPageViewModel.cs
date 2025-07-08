using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace RepmedApp.ViewModels
{
    public partial class SplashPageViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private readonly IServiceProvider _serviceProvider;

        [ObservableProperty]
        private bool isLoading;

        public SplashPageViewModel(INavigation navigation, IServiceProvider serviceProvider)
        {
            _navigation = navigation;
            _serviceProvider = serviceProvider;
            Title = "Welcome";
            IsLoading = true;
        }

        public override async Task InitializeAsync()
        {
            try
            {
                // Simulate initialization delay
                await Task.Delay(2500);

                // Get the login page from DI container
                var loginPage = _serviceProvider.GetRequiredService<Views.LoginPage>();

                // Navigate to login page
                await _navigation.PushAsync(loginPage);

                // Remove splash page from navigation stack
                var existingPages = _navigation.NavigationStack.ToList();
                foreach (var page in existingPages.Where(p => p is Views.SplashPage))
                {
                    _navigation.RemovePage(page);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
