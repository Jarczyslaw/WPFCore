using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPFCore.Converters;

namespace WPFCoreSample.Converters
{
    public class IntegerToColorConverter : BaseSingleConverter<IntegerToColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var x = (int)value;
            if (x % 2 == 0)
                return new SolidColorBrush(Colors.Green);
            else
                return new SolidColorBrush(Colors.Red);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
