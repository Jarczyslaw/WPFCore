using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPFCore.Converters
{
    public abstract class BaseSingleConverter<T> : MarkupExtension, IValueConverter
        where T: class, new()
    {
        private static T Instance = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Instance == null)
                Instance = new T();
            return Instance;
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
