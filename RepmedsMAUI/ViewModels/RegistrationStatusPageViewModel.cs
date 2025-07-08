using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RepmedApp.ViewModels
{
    public partial class RegistrationStatusPageViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        [ObservableProperty]
        private bool isPersonalInfoApproved;

        [ObservableProperty]
        private bool isDocumentsRejected;

        [ObservableProperty]
        private bool isVehicleDetailsPending;

        [ObservableProperty]
        private bool isBankDetailsApproved;

        [ObservableProperty]
        private bool isEmergencyDetailsApproved;

        public RegistrationStatusPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Title = "Registration Status";
            
            // Initialize properties with mock status
            isPersonalInfoApproved = true;
            isDocumentsRejected = true;
            isVehicleDetailsPending = true;
            isBankDetailsApproved = true;
            isEmergencyDetailsApproved = true;
        }

        [RelayCommand]
        private async Task ViewPersonalInfoAsync()
        {
            await _navigation.PushAsync(new Views.PersonalInformationPage());
        }

        [RelayCommand]
        private async Task ViewDocumentsAsync()
        {
            await _navigation.PushAsync(new Views.DocumentsPage());
        }

        [RelayCommand]
        private async Task ViewVehicleDetailsAsync()
        {
            await _navigation.PushAsync(new Views.VehicleDetailsPage());
        }

        [RelayCommand]
        private async Task ViewBankDetailsAsync()
        {
            await _navigation.PushAsync(new Views.BankDetailsPage());
        }

        [RelayCommand]
        private async Task ContactSupportAsync()
        {
            await _navigation.PushAsync(new Views.SupportPage());
        }
    }
}
