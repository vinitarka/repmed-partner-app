using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RepmedApp.ViewModels
{
    public partial class OtpVerificationPageViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private readonly IServiceProvider _serviceProvider;
        private System.Timers.Timer _timer;
        private int _remainingSeconds = 30;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(OtpMessage))]
        private string mobileNumber = string.Empty;

        [ObservableProperty]
        private string otp1 = string.Empty;

        [ObservableProperty]
        private string otp2 = string.Empty;

        [ObservableProperty]
        private string otp3 = string.Empty;

        [ObservableProperty]
        private string otp4 = string.Empty;

        private string _otpMessage = string.Empty;
        public string OtpMessage
        {
            get => _otpMessage;
            set => SetProperty(ref _otpMessage, value);
        }

        private string _timerText = string.Empty;
        public string TimerText
        {
            get => _timerText;
            set => SetProperty(ref _timerText, value);
        }

        private bool _canResend;
        public bool CanResend
        {
            get => _canResend;
            set
            {
                if (SetProperty(ref _canResend, value))
                {
                    OnPropertyChanged(nameof(ResendText));
                }
            }
        }

        public string ResendText => CanResend ? "Resend OTP" : "Wait";

        public ICommand ResendOtpCommand { get; }
        public ICommand VerifyOtpCommand { get; }

        public OtpVerificationPageViewModel(INavigation navigation, IServiceProvider serviceProvider)
        {
            _navigation = navigation;
            _serviceProvider = serviceProvider;
            Title = "OTP Verification";

            // Initialize commands
            ResendOtpCommand = new AsyncRelayCommand(ResendOtpAsync, () => CanResend);
            VerifyOtpCommand = new AsyncRelayCommand(VerifyOtpAsync);

            // Set initial mobile number (this should come from previous page)
            MobileNumber = "+91 98765 43210"; // Example number
            
            InitializeTimer();
            UpdateOtpMessage();
        }

        private void InitializeTimer()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
            CanResend = false;
            UpdateTimerText();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _remainingSeconds--;
            
            if (_remainingSeconds <= 0)
            {
                _timer.Stop();
                CanResend = true;
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    TimerText = string.Empty;
                });
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    UpdateTimerText();
                });
            }
        }

        private void UpdateTimerText()
        {
            TimerText = $"Resend OTP in {_remainingSeconds} seconds";
        }

        private void UpdateOtpMessage()
        {
            OtpMessage = $"Please enter the verification code sent to {MobileNumber}";
        }

        private async Task ResendOtpAsync()
        {
            if (!CanResend)
                return;

            await ExecuteAsync(async () =>
            {
                // Simulate API call
                await Task.Delay(1000);

                // Reset OTP fields
                Otp1 = Otp2 = Otp3 = Otp4 = string.Empty;

                // Reset timer
                _remainingSeconds = 30;
                InitializeTimer();

                await Application.Current.MainPage.DisplayAlert("Success", "OTP has been resent", "OK");
            });
        }

        private async Task VerifyOtpAsync()
        {
            if (IsBusy)
                return;

            string otp = $"{Otp1}{Otp2}{Otp3}{Otp4}";

            if (string.IsNullOrWhiteSpace(otp) || otp.Length != 4)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid OTP", "OK");
                return;
            }

            await ExecuteAsync(async () =>
            {
                // Simulate API call
                await Task.Delay(1000);

                // Navigate to personal information page
                var personalInfoPage = _serviceProvider.GetRequiredService<Views.PersonalInformationPage>();
                await _navigation.PushAsync(personalInfoPage);

                // Remove OTP page from navigation stack
                var existingPages = _navigation.NavigationStack.ToList();
                foreach (var page in existingPages.Where(p => p is Views.OtpVerificationPage))
                {
                    _navigation.RemovePage(page);
                }
            });
        }

        public void OnDisappearing()
        {
            _timer?.Stop();
            _timer?.Dispose();
        }
    }
}
