using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WPFCore;
using WPFCoreSample.Controls;

namespace WPFCoreSample.DependencyProperties
{
    public class ColorPickerProperty : BaseDependencyProperty<ColorPicker, Color>
    {
        public ColorPickerProperty(string name) : base(name, Colors.Black) { }

        public override void OnPropertyChanged(ColorPicker owner, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("Color updated to: " + e.NewValue);
        }

        public override Color OnCoerceValue(ColorPicker owner, Color baseValue)
        {
            Debug.WriteLine("Color changed to: " + baseValue);
            owner.UpdateColor(baseValue);
            return baseValue;
        }
    }
}
