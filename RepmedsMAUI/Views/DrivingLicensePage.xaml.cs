using RepmedApp.ViewModels;

namespace RepmedApp.Views
{
    public partial class DrivingLicensePage : ContentPage
    {
        private readonly DrivingLicensePageViewModel _viewModel;

        public DrivingLicensePage(DrivingLicensePageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
    }
}
