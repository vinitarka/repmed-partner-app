using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RepmedApp.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        [ObservableProperty]
        private string mobileNumber;

        [ObservableProperty]
        private bool termsAccepted;

        public LoginPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Title = "Login";
            mobileNumber = string.Empty;
            termsAccepted = false;
        }

        [RelayCommand]
        private async Task SendOtpAsync()
        {
            if (IsBusy)
                return;

            if (string.IsNullOrWhiteSpace(MobileNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter mobile number", "OK");
                return;
            }

            if (!TermsAccepted)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please accept terms and conditions", "OK");
                return;
            }

            IsBusy = true;

            try
            {
                // Simulate OTP sending
                await Task.Delay(1000);
                
                // Navigate to OTP verification page
                await _navigation.PushAsync(new Views.OtpVerificationPage(MobileNumber));
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

        [RelayCommand]
        private async Task OpenTermsAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Terms of Use", "Terms and conditions content goes here.", "OK");
        }

        [RelayCommand]
        private async Task OpenPrivacyPolicyAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Privacy Policy", "Privacy policy content goes here.", "OK");
        }
    }
}
