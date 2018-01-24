using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCore;

namespace WPFCoreSample.AttachedProperties
{
    public class StringAttachedProperty : BaseAttachedProperty<StringAttachedProperty, string>
    {
        public override void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("Property changed: " + e.NewValue);
        }

        public override object CoerceValue(DependencyObject d, string baseValue)
        {
            Debug.WriteLine("Coerce value: " + baseValue);
            return base.CoerceValue(d, baseValue);
        }
    }
}
