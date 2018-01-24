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
using WPFCore;
using WPFCoreSample.DependencyProperties;

namespace WPFCoreSample.Controls
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public readonly ColorPickerProperty ColorProperty = new ColorPickerProperty(nameof(Color));

        public Color Color
        {
            get { return ColorProperty.Get(this); }
            set { ColorProperty.Set(this, value); }
        }

        public ColorPicker()
        {
            InitializeComponent();
            UpdateColor(ColorProperty.Get(this));
        }

        private void TbAlpha_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!CheckValidValue(tbAlpha.Text))
                return;

            Color = Color.FromArgb(byte.Parse(tbAlpha.Text), Color.R, Color.G, Color.B);
        }

        private void TbBlue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!CheckValidValue(tbBlue.Text))
                return;

            Color = Color.FromArgb(Color.A, Color.R, Color.G, byte.Parse(tbBlue.Text));
        }

        private void TbGreen_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!CheckValidValue(tbGreen.Text))
                return;

            Color = Color.FromArgb(Color.A, Color.R, byte.Parse(tbGreen.Text), Color.B);
        }

        private void TbRed_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!CheckValidValue(tbRed.Text))
                return;

            Color = Color.FromArgb(Color.A, byte.Parse(tbRed.Text), Color.G, Color.B);
        }

        private bool CheckValidValue(string text)
        {
            return byte.TryParse(text, out byte result);
        }

        public void UpdateColor(Color newColor)
        {
            UnregisterTextVoxEvents();

            tbRed.Text = newColor.R.ToString();
            tbGreen.Text = newColor.G.ToString();
            tbBlue.Text = newColor.B.ToString();
            tbAlpha.Text = newColor.A.ToString();

            gdPreview.Background = new SolidColorBrush(newColor);
            RegisterTextBoxEvents();
        }

        private void RegisterTextBoxEvents()
        {
            tbRed.TextChanged += TbRed_TextChanged;
            tbGreen.TextChanged += TbGreen_TextChanged;
            tbBlue.TextChanged += TbBlue_TextChanged;
            tbAlpha.TextChanged += TbAlpha_TextChanged;
        }

        private void UnregisterTextVoxEvents()
        {
            tbRed.TextChanged -= TbRed_TextChanged;
            tbGreen.TextChanged -= TbGreen_TextChanged;
            tbBlue.TextChanged -= TbBlue_TextChanged;
            tbAlpha.TextChanged -= TbAlpha_TextChanged;
        }
    }
}
