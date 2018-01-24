using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPFCore.Converters;

namespace WPFCoreSample.Converters
{
    public class BoolToBrushConverter : BoolToValueConverter<SolidColorBrush>
    {
        public BoolToBrushConverter() : base(new SolidColorBrush(Colors.YellowGreen), new SolidColorBrush(Colors.OrangeRed)) { }
    }
}
