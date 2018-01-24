using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCore;
using WPFCoreSample.Controls;

namespace WPFCoreSample.DependencyProperties
{
    public class CustomTextBoxStringProperty : BaseDependencyProperty<CustomTextBox, string>
    {
        public CustomTextBoxStringProperty(string name, string defaultValue) : base(name, defaultValue) { }

        public override string OnCoerceValue(CustomTextBox owner, string baseValue)
        {
            Debug.WriteLine("OnCoerce: " + baseValue);
            return base.OnCoerceValue(owner, baseValue);
        }
    }
}
