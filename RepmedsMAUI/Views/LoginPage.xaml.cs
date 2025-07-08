using RepmedApp.ViewModels;

namespace RepmedApp.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly LoginPageViewModel _viewModel;

        public LoginPage(LoginPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            // Clear navigation stack to prevent going back to splash screen
            if (Navigation.NavigationStack.Count > 1)
            {
                var existingPages = Navigation.NavigationStack.ToList();
                for (int i = 0; i < existingPages.Count - 1; i++)
                {
                    Navigation.RemovePage(existingPages[i]);
                }
            }
        }
    }
}
