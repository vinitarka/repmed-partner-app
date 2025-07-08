using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using RepmedApp.Views;
using RepmedApp.ViewModels;

namespace RepmedApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register services
            RegisterServices(builder.Services);

            // Register pages and viewmodels
            RegisterViewsAndViewModels(builder.Services);

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Add any additional services here
            services.AddSingleton<INavigation>(provider =>
            {
                var app = Application.Current;
                return app?.MainPage?.Navigation;
            });

            services.AddSingleton<IServiceProvider>(provider => provider);
        }

        private static void RegisterViewsAndViewModels(IServiceCollection services)
        {
            // Register ViewModels
            services.AddTransient<SplashPageViewModel>();
            services.AddTransient<LoginPageViewModel>();
            services.AddTransient<OtpVerificationPageViewModel>();
            services.AddTransient<PersonalInformationPageViewModel>();
            services.AddTransient<DocumentsPageViewModel>();
            services.AddTransient<AadharDetailsPageViewModel>();
            services.AddTransient<PanCardPageViewModel>();
            services.AddTransient<DrivingLicensePageViewModel>();
            services.AddTransient<VehicleDetailsPageViewModel>();
            services.AddTransient<BankDetailsPageViewModel>();
            services.AddTransient<RegistrationStatusPageViewModel>();
            services.AddTransient<SupportPageViewModel>();

            // Register Pages with their ViewModels
            services.AddTransient(s => new SplashPage(s.GetRequiredService<SplashPageViewModel>()));
            services.AddTransient(s => new LoginPage(s.GetRequiredService<LoginPageViewModel>()));
            services.AddTransient(s => new OtpVerificationPage(s.GetRequiredService<OtpVerificationPageViewModel>()));
            services.AddTransient(s => new PersonalInformationPage(s.GetRequiredService<PersonalInformationPageViewModel>()));
            services.AddTransient(s => new DocumentsPage(s.GetRequiredService<DocumentsPageViewModel>()));
            services.AddTransient(s => new AadharDetailsPage(s.GetRequiredService<AadharDetailsPageViewModel>()));
            services.AddTransient(s => new PanCardPage(s.GetRequiredService<PanCardPageViewModel>()));
            services.AddTransient(s => new DrivingLicensePage(s.GetRequiredService<DrivingLicensePageViewModel>()));
            services.AddTransient(s => new VehicleDetailsPage(s.GetRequiredService<VehicleDetailsPageViewModel>()));
            services.AddTransient(s => new BankDetailsPage(s.GetRequiredService<BankDetailsPageViewModel>()));
            services.AddTransient(s => new RegistrationStatusPage(s.GetRequiredService<RegistrationStatusPageViewModel>()));
            services.AddTransient(s => new SupportPage(s.GetRequiredService<SupportPageViewModel>()));
        }
    }
}
