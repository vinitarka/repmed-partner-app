using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RepmedApp.ViewModels
{
    public partial class SupportPageViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private string emailId;

        [ObservableProperty]
        private string subject;

        [ObservableProperty]
        private string message;

        public SupportPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Title = "Support";
            
            // Initialize properties
            fullName = string.Empty;
            emailId = string.Empty;
            subject = string.Empty;
            message = string.Empty;
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            if (IsBusy)
                return;

            if (string.IsNullOrWhiteSpace(FullName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter full name", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(EmailId))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter email ID", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Subject))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter subject", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Message))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter message", "OK");
                return;
            }

            IsBusy = true;

            try
            {
                // Simulate API call
                await Task.Delay(1000);
                
                await Application.Current.MainPage.DisplayAlert("Success", "Your message has been sent. Our support team will contact you soon.", "OK");
                await _navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
