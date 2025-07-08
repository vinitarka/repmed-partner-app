using RepmedApp.ViewModels;

namespace RepmedApp.Views
{
    public partial class SupportPage : ContentPage
    {
        private readonly SupportPageViewModel _viewModel;

        public SupportPage()
        {
            InitializeComponent();
            _viewModel = new SupportPageViewModel(Navigation);
            BindingContext = _viewModel;
        }
    }
}
