using System.Globalization;

namespace RepmedApp.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool status)
            {
                if (parameter?.ToString() == "text")
                {
                    return status ? "Approved" : (parameter?.ToString() == "rejected" ? "Rejected" : "Pending");
                }
                else
                {
                    // Return color based on status
                    return status ? Colors.FromArgb("#4CAF50") :  // Green for approved
                           (parameter?.ToString() == "rejected" ? 
                            Colors.FromArgb("#F44336") :          // Red for rejected
                            Colors.FromArgb("#FFA000"));          // Orange for pending
                }
            }
            return Colors.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
