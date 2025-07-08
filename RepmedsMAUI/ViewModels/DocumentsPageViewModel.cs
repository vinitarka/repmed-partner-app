using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RepmedApp.ViewModels
{
    public partial class DocumentsPageViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        [ObservableProperty]
        private bool isAadharFrontUploaded;

        [ObservableProperty]
        private bool isAadharBackUploaded;

        [ObservableProperty]
        private bool isPanCardUploaded;

        [ObservableProperty]
        private bool isDrivingLicenseUploaded;

        public DocumentsPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Title = "Personal Documents";
            
            // Initialize properties
            isAadharFrontUploaded = false;
            isAadharBackUploaded = false;
            isPanCardUploaded = false;
            isDrivingLicenseUploaded = false;
        }

        [RelayCommand]
        private async Task NavigateToAadharDetailsAsync()
        {
            await _navigation.PushAsync(new Views.AadharDetailsPage());
        }

        [RelayCommand]
        private async Task NavigateToPanCardAsync()
        {
            await _navigation.PushAsync(new Views.PanCardPage());
        }

        [RelayCommand]
        private async Task NavigateToDrivingLicenseAsync()
        {
            await _navigation.PushAsync(new Views.DrivingLicensePage());
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            if (IsBusy)
                return;

            if (!IsAadharFrontUploaded || !IsAadharBackUploaded)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please upload Aadhar card (both sides)", "OK");
                return;
            }

            if (!IsPanCardUploaded)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please upload PAN card", "OK");
                return;
            }

            if (!IsDrivingLicenseUploaded)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please upload Driving License", "OK");
                return;
            }

            IsBusy = true;

            try
            {
                // Simulate API call
                await Task.Delay(1000);
                
                // Navigate to vehicle details page
                await _navigation.PushAsync(new Views.VehicleDetailsPage());
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
