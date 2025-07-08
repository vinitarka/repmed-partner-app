# Repmed Partner App

A .NET MAUI mobile application for Repmed partners to register and manage their deliveries.

## Features

- Partner Registration Flow
  - Mobile Number Verification with OTP
  - Personal Information Collection
  - Document Upload (Aadhar, PAN, Driving License)
  - Vehicle Details
  - Bank Account Details
- Registration Status Tracking
- Support System

## Requirements

- .NET 8.0 SDK
- Visual Studio 2022 or Visual Studio Code with .NET MAUI workload
- Android SDK (for Android development)
- Xcode 14+ (for iOS development, macOS only)

## Getting Started

1. Clone the repository
2. Open the solution in Visual Studio or Visual Studio Code
3. Restore NuGet packages
4. Build and run the application

### Building for Android

```bash
dotnet build -t:Run -f net8.0-android
```

### Building for iOS (requires macOS)

```bash
dotnet build -t:Run -f net8.0-ios
```

## Project Structure

- `/ViewModels` - MVVM ViewModels
- `/Views` - XAML Pages
- `/Converters` - Value Converters
- `/Platforms` - Platform-specific code
- `/Resources` - Images, fonts, and other resources

## Dependencies

- Microsoft.Maui.Controls (8.0.3)
- CommunityToolkit.Maui (7.0.0)
- CommunityToolkit.Mvvm (8.2.2)

## Architecture

The app follows the MVVM (Model-View-ViewModel) pattern using CommunityToolkit.Mvvm for better separation of concerns and maintainability.

## Navigation Flow

1. Splash Screen (2-3 seconds)
2. Mobile Number Entry & OTP Verification
3. Personal Information Form
4. Document Upload Screens
5. Vehicle Details Form
6. Bank Account Details Form
7. Registration Status Screen

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request
