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
using WPFCoreSample.Pages;

namespace WPFCoreSample.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Type> pages;
        private Dictionary<Type, BasePage> openedPages = new Dictionary<Type, BasePage>();
        private Page currentPage;

        public MainWindow()
        {
            InitializeComponent();
            InitializePages();
            InitializeButtons();

            OpenPage(pages.First());
        }

        private void InitializePages()
        {
            pages = new List<Type>();
            pages.Add(typeof(HomePage));
            pages.Add(typeof(CounterPage));
            pages.Add(typeof(ConvertersPage));
            pages.Add(typeof(DependencyPropertiesPage));
            pages.Add(typeof(AttachedPropertiesPage));
            pages.Add(typeof(DragAndDropPage));
        }

        private void InitializeButtons()
        {
            foreach (var pageType in pages)
            {
                var button = new Button()
                {
                    Content = GetPageName(pageType),
                    Tag = pageType,
                };
                button.Click += Button_Click;
                PagesButtons.Items.Add(button);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            OpenPage(button.Tag as Type);
        }

        private void OpenPage(Type pageType)
        {
            if (openedPages.TryGetValue(pageType, out BasePage pageToOpen))
                pageToOpen = openedPages[pageType];
            else
            {
                pageToOpen = (BasePage)Activator.CreateInstance(pageType);
                openedPages.Add(pageType, pageToOpen);
            }
            currentPage = pageToOpen;
            PageFrame.Content = currentPage;
            UpdatePageControls(pageType);
        }

        private void UpdatePageControls(Type pageType)
        {
            PageTitle.Text = GetPageName(pageType);
            var buttons = PagesButtons.Items.Cast<Button>();
            foreach (var button in buttons)
                button.IsEnabled = !((Type)button.Tag == pageType);
        }

        private string GetPageName(Type pageType)
        {
            return pageType.Name.Replace("Page", string.Empty);
        }
    }
}
