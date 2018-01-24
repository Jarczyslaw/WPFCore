using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFCore.ServiceLocator;
using WPFCoreSample.Services;

namespace WPFCoreSample.Pages
{
    public class BasePage : Page
    {
        public BasePage()
        {
            var logger = ServiceLocator.Instance.Get<ILogger>();
            logger.Log(GetType().Name + " created");
        }
    }
}
