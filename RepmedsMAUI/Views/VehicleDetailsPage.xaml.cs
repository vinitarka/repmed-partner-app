using RepmedApp.ViewModels;

namespace RepmedApp.Views
{
    public partial class VehicleDetailsPage : ContentPage
    {
        private readonly VehicleDetailsPageViewModel _viewModel;

        public VehicleDetailsPage()
        {
            InitializeComponent();
            _viewModel = new VehicleDetailsPageViewModel(Navigation);
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
