using System.Globalization;

namespace RepmedApp.Converters
{
    public class BoolToUploadTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isUploaded)
            {
                return isUploaded ? "Re-Upload" : "Upload";
            }
            return "Upload";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
