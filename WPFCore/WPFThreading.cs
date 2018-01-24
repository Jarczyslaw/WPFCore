using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WPFCore
{
    public static class WPFThreading
    {
        public static void SafeInvoke(Action action, DispatcherPriority priority = DispatcherPriority.Send)
        {
            if (Application.Current.Dispatcher.CheckAccess())
                action.Invoke();
            else
            {
                Application.Current.Dispatcher.Invoke(priority, new Action(delegate ()
                {
                    action.Invoke();
                }));
            }
        }

        public static void SafeBeginInvoke(Action action)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                action.Invoke();
            }));
        }
    }
}
