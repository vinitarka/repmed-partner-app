using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RepmedApp.ViewModels
{
    public partial class VehicleDetailsPageViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        [ObservableProperty]
        private string vehicleNumber;

        [ObservableProperty]
        private string registrationNumber;

        [ObservableProperty]
        private string chassisNumber;

        [ObservableProperty]
        private string engineNumber;

        [ObservableProperty]
        private string ownerName;

        [ObservableProperty]
        private string address;

        public VehicleDetailsPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Title = "Vehicle Details";
            
            // Initialize properties
            vehicleNumber = string.Empty;
            registrationNumber = string.Empty;
            chassisNumber = string.Empty;
            engineNumber = string.Empty;
            ownerName = string.Empty;
            address = string.Empty;
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            if (IsBusy)
                return;

            if (string.IsNullOrWhiteSpace(VehicleNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter vehicle number", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(RegistrationNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter registration number", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(ChassisNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter chassis number", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(EngineNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter engine/motor number", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(OwnerName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter owner name", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Address))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter address", "OK");
                return;
            }

            IsBusy = true;

            try
            {
                // Simulate API call
                await Task.Delay(1000);
                
                // Navigate to bank details page
                await _navigation.PushAsync(new Views.BankDetailsPage());
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
