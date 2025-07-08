using RepmedApp.ViewModels;

namespace RepmedApp.Views
{
    public partial class OtpVerificationPage : ContentPage
    {
        private readonly OtpVerificationPageViewModel _viewModel;

        public OtpVerificationPage(OtpVerificationPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;

            // Add handlers for entry completion
            SetupEntryHandlers();
        }

        private void SetupEntryHandlers()
        {
            var entries = this.GetVisualTreeDescendants()
                             .OfType<Entry>()
                             .OrderBy(e => Grid.GetColumn(e))
                             .ToList();

            for (int i = 0; i < entries.Count; i++)
            {
                var currentEntry = entries[i];
                var nextEntry = i < entries.Count - 1 ? entries[i + 1] : null;
                var previousEntry = i > 0 ? entries[i - 1] : null;

                // Move to next entry when a digit is entered
                currentEntry.TextChanged += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.NewTextValue) && nextEntry != null)
                    {
                        nextEntry.Focus();
                    }
                };

                // Handle backspace to move to previous entry
                currentEntry.Unfocused += (s, e) =>
                {
                    if (string.IsNullOrEmpty(currentEntry.Text) && previousEntry != null)
                    {
                        previousEntry.Focus();
                    }
                };
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel?.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            // Show confirmation dialog before going back
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                var result = await DisplayAlert(
                    "Confirm",
                    "Are you sure you want to cancel the registration?",
                    "Yes",
                    "No"
                );

                if (result)
                {
                    await Navigation.PopAsync();
                }
            });

            return true;
        }
    }
}
