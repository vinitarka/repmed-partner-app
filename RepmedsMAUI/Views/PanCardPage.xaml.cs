using RepmedApp.ViewModels;

namespace RepmedApp.Views
{
    public partial class PanCardPage : ContentPage
    {
        private readonly PanCardPageViewModel _viewModel;

        public PanCardPage(PanCardPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
    }
}
