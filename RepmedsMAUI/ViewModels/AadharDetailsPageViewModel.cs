using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RepmedApp.ViewModels
{
    public partial class AadharDetailsPageViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        [ObservableProperty]
        private ImageSource frontImage;

        [ObservableProperty]
        private ImageSource backImage;

        [ObservableProperty]
        private bool isFrontUploaded;

        [ObservableProperty]
        private bool isBackUploaded;

        public AadharDetailsPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Title = "Aadhar Card Details";
            
            // Initialize properties
            frontImage = ImageSource.FromFile("aadhar_front_placeholder.png");
            backImage = ImageSource.FromFile("aadhar_back_placeholder.png");
            isFrontUploaded = false;
            isBackUploaded = false;
        }

        [RelayCommand]
        private async Task UploadFrontAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    FrontImage = ImageSource.FromStream(() => stream);
                    IsFrontUploaded = true;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to upload photo: " + ex.Message, "OK");
            }
        }

        [RelayCommand]
        private async Task UploadBackAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    BackImage = ImageSource.FromStream(() => stream);
                    IsBackUploaded = true;
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

            if (!IsFrontUploaded)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please upload front side of Aadhar card", "OK");
                return;
            }

            if (!IsBackUploaded)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please upload back side of Aadhar card", "OK");
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
