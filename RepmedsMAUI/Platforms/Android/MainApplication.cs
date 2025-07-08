using Android.App;
using Android.Runtime;

namespace RepmedApp
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp()
        {
            // Initialize any Android-specific services here if needed
            return MauiProgram.CreateMauiApp();
        }

        public override void OnCreate()
        {
            base.OnCreate();

            // Initialize any Android-specific configurations here
            Microsoft.Maui.ApplicationModel.Platform.Init(this);
        }
    }
}
