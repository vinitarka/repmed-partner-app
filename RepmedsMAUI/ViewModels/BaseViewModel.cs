using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RepmedApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        public bool IsNotBusy => !IsBusy;

        public BaseViewModel()
        {
            title = string.Empty;
            isBusy = false;
            isLoading = false;
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        protected async Task ExecuteAsync(Func<Task> operation)
        {
            try
            {
                IsBusy = true;
                ErrorMessage = string.Empty;
                await operation?.Invoke();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                await Application.Current.MainPage.DisplayAlert("Error", ErrorMessage, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
