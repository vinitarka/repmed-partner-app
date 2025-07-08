using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RepmedApp.ViewModels
{
    public partial class PersonalInformationPageViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private DateTime? dateOfBirth;

        [ObservableProperty]
        private string emailId;

        [ObservableProperty]
        private string alternativeMobileNumber;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private ImageSource profilePicture;

        public PersonalInformationPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Title = "Personal Information";
            
            // Initialize properties
            fullName = string.Empty;
            emailId = string.Empty;
            alternativeMobileNumber = string.Empty;
            address = string.Empty;
            profilePicture = ImageSource.FromFile("default_profile.png");
        }

        [RelayCommand]
        private async Task UploadPhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    ProfilePicture = ImageSource.FromStream(() => stream);
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

            if (string.IsNullOrWhiteSpace(FullName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter full name", "OK");
                return;
            }

            if (!DateOfBirth.HasValue)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please select date of birth", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(EmailId))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter email ID", "OK");
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
                
                // Navigate to documents page
                await _navigation.PushAsync(new Views.DocumentsPage());
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
