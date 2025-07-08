using RepmedApp.ViewModels;

namespace RepmedApp.Views
{
    public partial class AadharDetailsPage : ContentPage
    {
        private readonly AadharDetailsPageViewModel _viewModel;

        public AadharDetailsPage()
        {
            InitializeComponent();
            _viewModel = new AadharDetailsPageViewModel(Navigation);
            BindingContext = _viewModel;
        }
    }
}
