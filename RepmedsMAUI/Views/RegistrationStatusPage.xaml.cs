using RepmedApp.ViewModels;

namespace RepmedApp.Views
{
    public partial class RegistrationStatusPage : ContentPage
    {
        private readonly RegistrationStatusPageViewModel _viewModel;

        public RegistrationStatusPage()
        {
            InitializeComponent();
            _viewModel = new RegistrationStatusPageViewModel(Navigation);
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            // Remove previous pages from navigation stack to prevent going back
            var existingPages = Navigation.NavigationStack.ToList();
            for (int i = 0; i < existingPages.Count - 1; i++)
            {
                Navigation.RemovePage(existingPages[i]);
            }
        }
    }
}
