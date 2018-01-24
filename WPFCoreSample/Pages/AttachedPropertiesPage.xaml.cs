using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCoreSample.AttachedProperties;

namespace WPFCoreSample.Pages
{
    /// <summary>
    /// Interaction logic for AttachedPropertiesPage.xaml
    /// </summary>
    public partial class AttachedPropertiesPage : BasePage
    {
        public AttachedPropertiesPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<int> props = new List<int>();

            var container = spAttachedContainer;
            foreach (UIElement element in container.Children)
                props.Add(IntegerAttachedProperty.GetValue(element));
            MessageBox.Show(string.Join(", ", props));
        }
    }
}
