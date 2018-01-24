using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFCoreSample.DependencyProperties;

namespace WPFCoreSample.Controls
{
    public class CustomTextBox : TextBox
    {
        public CustomTextBoxStringProperty CustomTextProperty = new CustomTextBoxStringProperty(nameof(CustomText), string.Empty);

        public string CustomText
        {
            get { return CustomTextProperty.Get(this); }
            set { CustomTextProperty.Set(this, value); }
        }
    }
}
