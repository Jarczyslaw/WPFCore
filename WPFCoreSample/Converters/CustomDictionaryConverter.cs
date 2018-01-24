using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPFCore.Converters;
using WPFCoreSample.Models;

namespace WPFCoreSample.Converters
{
    public class CustomDictionaryConverter : DictionaryConverter<ConverterTypes, Brush>
    {
        public CustomDictionaryConverter()
        {
            Values.Add(ConverterTypes.One, new SolidColorBrush(Colors.YellowGreen));
            Values.Add(ConverterTypes.Two, new SolidColorBrush(Colors.OrangeRed));
            Values.Add(ConverterTypes.Three, new LinearGradientBrush(Colors.Yellow, Colors.Turquoise, 0d));
        }
    }
}
