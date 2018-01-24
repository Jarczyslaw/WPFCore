using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFCoreSample.AttachedProperties
{
    public class AdditionalText
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(string), typeof(AdditionalText), new PropertyMetadata(string.Empty, null, BaseCoerceValueCallback));

        public static string GetValue(DependencyObject d)
        {
            return (string)d.GetValue(ValueProperty);
        }

        public static void SetValue(DependencyObject d, string value)
        {
            d.SetValue(ValueProperty, value);
        }

        private static object BaseCoerceValueCallback(DependencyObject d, object baseValue)
        {
            Debug.WriteLine(baseValue);
            return baseValue;
        }
    }
}
