using Android.App;
using Android.Content.PM;
using Android.OS;

namespace RepmedApp
{
    [Activity(Theme = "@style/Maui.SplashTheme",
              MainLauncher = true,
              ConfigurationChanges = ConfigChanges.ScreenSize | 
                                   ConfigChanges.Orientation | 
                                   ConfigChanges.UiMode | 
                                   ConfigChanges.ScreenLayout | 
                                   ConfigChanges.SmallestScreenSize | 
                                   ConfigChanges.Density,
              ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);

            // Handle permissions
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                RequestPermissions(new string[]
                {
                    Android.Manifest.Permission.Camera,
                    Android.Manifest.Permission.ReadExternalStorage,
                    Android.Manifest.Permission.WriteExternalStorage,
                    Android.Manifest.Permission.Internet,
                    Android.Manifest.Permission.AccessNetworkState
                }, 0);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
