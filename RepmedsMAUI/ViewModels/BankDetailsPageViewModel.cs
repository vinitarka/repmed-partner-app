using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RepmedApp.ViewModels
{
    public partial class BankDetailsPageViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        [ObservableProperty]
        private string bankName;

        [ObservableProperty]
        private string accountHolderName;

        [ObservableProperty]
        private string accountType;

        [ObservableProperty]
        private string routingNumber;

        [ObservableProperty]
        private string accountNumber;

        [ObservableProperty]
        private bool saveForFutureTransactions;

        public BankDetailsPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Title = "Bank Details";
            
            // Initialize properties
            bankName = string.Empty;
            accountHolderName = string.Empty;
            accountType = string.Empty;
            routingNumber = string.Empty;
            accountNumber = string.Empty;
            saveForFutureTransactions = false;
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            if (IsBusy)
                return;

            if (string.IsNullOrWhiteSpace(BankName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter bank name", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(AccountHolderName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter account holder name", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(AccountType))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please select account type", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(RoutingNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter routing number", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(AccountNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter account number", "OK");
                return;
            }

            IsBusy = true;

            try
            {
                // Simulate API call
                await Task.Delay(1000);
                
                // Navigate to registration status page
                await _navigation.PushAsync(new Views.RegistrationStatusPage());
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
