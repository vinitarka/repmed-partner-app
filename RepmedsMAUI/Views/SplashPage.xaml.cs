using RepmedApp.ViewModels;

namespace RepmedApp.Views
{
    public partial class SplashPage : ContentPage
    {
        private readonly SplashPageViewModel _viewModel;

        public SplashPage(SplashPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            // Initialize the view model
            await _viewModel.InitializeAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            // Disable back button on splash screen
            return true;
        }
    }
}
