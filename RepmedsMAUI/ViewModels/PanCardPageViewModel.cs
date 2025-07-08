using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RepmedApp.ViewModels
{
    public partial class PanCardPageViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        [ObservableProperty]
        private ImageSource panImage;

        [ObservableProperty]
        private bool isPanUploaded;

        public PanCardPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Title = "PAN Card Details";
            
            // Initialize properties
            panImage = ImageSource.FromFile("pan_placeholder.png");
            isPanUploaded = false;
        }

        [RelayCommand]
        private async Task UploadPanAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    PanImage = ImageSource.FromStream(() => stream);
                    IsPanUploaded = true;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to upload photo: " + ex.Message, "OK");
            }
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            if (IsBusy)
                return;

            if (!IsPanUploaded)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please upload PAN card", "OK");
                return;
            }

            IsBusy = true;

            try
            {
                // Simulate API call
                await Task.Delay(1000);
                
                // Go back to documents page
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
