using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Navigation;
using System.Collections.Generic;

namespace HcsLib.WindowsPhone.View
{
    public class AppPageBase : PhoneApplicationPage
    {
        ProgressIndicator m_ProgressIndicator;

        protected List<EventHandler<EventArgs>> InitialDataHandlers { get; set; }

        public AppPageBase()
        {
            Loaded += OnPageLoaded;
            InitialDataHandlers = new List<EventHandler<EventArgs>>();
            //初始化进度条
            m_ProgressIndicator = new ProgressIndicator();
            Microsoft.Phone.Shell.SystemTray.SetProgressIndicator(this, m_ProgressIndicator);
            m_ProgressIndicator.Text = "加载中";
            m_ProgressIndicator.IsIndeterminate = true;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back && InitialDataHandlers.Count == 0)
            {

            }

            base.OnNavigatedTo(e);
        }

        protected virtual void OnPageLoaded(object sender, RoutedEventArgs e)
        {
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            Loaded -= OnPageLoaded;

            if (e.NavigationMode != NavigationMode.Back)
            {
            }

            base.OnNavigatedFrom(e);
        }

        public void SetProgressIndicatorVisible(bool isVisible)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (null != m_ProgressIndicator)
                {
                    m_ProgressIndicator.IsVisible = isVisible;
                }

                SystemTray.SetIsVisible(this, isVisible);
            });
        }
    }
}
