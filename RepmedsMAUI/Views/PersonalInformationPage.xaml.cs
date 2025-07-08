using RepmedApp.ViewModels;

namespace RepmedApp.Views
{
    public partial class PersonalInformationPage : ContentPage
    {
        private readonly PersonalInformationPageViewModel _viewModel;

        public PersonalInformationPage()
        {
            InitializeComponent();
            _viewModel = new PersonalInformationPageViewModel(Navigation);
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
