using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections;
using System.Windows.Controls.Primitives;

namespace HcsLib.WindowsPhone.Msic
{
    public class VisualHelper
    {
        public static UIElement FindElementRecursive(FrameworkElement parent, Type targetType)
        {
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            UIElement returnElement = null;
            if (childCount > 0)
            {
                for (int i = 0; i < childCount; i++)
                {
                    Object element = VisualTreeHelper.GetChild(parent, i);
                    if (element.GetType() == targetType)
                    {
                        return element as UIElement;
                    }
                    else
                    {
                        returnElement = FindElementRecursive(VisualTreeHelper.GetChild(parent, i) as FrameworkElement, targetType);
                    }
                }
            }
            return returnElement;
        }
        public static VisualStateGroup FindVisualState(FrameworkElement element, string name)
        {
            if (element == null)
                return null;

            IList groups = VisualStateManager.GetVisualStateGroups(element);
            foreach (VisualStateGroup group in groups)
                if (group.Name == name)
                    return group;

            return null;
        }

        public static void HookedScrollEvents(FrameworkElement hookedControl,
             Action<object, VisualStateChangedEventArgs> group_CurrentStateChanging,
             Action<object, VisualStateChangedEventArgs> vgroup_CurrentStateChanging,
             Action<object, VisualStateChangedEventArgs> hgroup_CurrentStateChanging)
        {
            ScrollBar sb = null;
            ScrollViewer sv = null;
            sb = (ScrollBar)VisualHelper.FindElementRecursive(hookedControl, typeof(ScrollBar));
            sv = (ScrollViewer)VisualHelper.FindElementRecursive(hookedControl, typeof(ScrollViewer));

            if (sv != null)
            {
                FrameworkElement element = VisualTreeHelper.GetChild(sv, 0) as FrameworkElement;
                if (element != null)
                {
                    VisualStateGroup group = VisualHelper.FindVisualState(element, "ScrollStates");
                    if (group != null && group_CurrentStateChanging != null)
                    {
                        group.CurrentStateChanging += new EventHandler<VisualStateChangedEventArgs>(group_CurrentStateChanging);
                    }
                    VisualStateGroup vgroup = VisualHelper.FindVisualState(element, "VerticalCompression");
                    VisualStateGroup hgroup = VisualHelper.FindVisualState(element, "HorizontalCompression");
                    if (vgroup != null && vgroup_CurrentStateChanging != null)
                    {
                        vgroup.CurrentStateChanging += new EventHandler<VisualStateChangedEventArgs>(vgroup_CurrentStateChanging);
                    }
                    if (hgroup != null && hgroup_CurrentStateChanging != null)
                    {
                        hgroup.CurrentStateChanging += new EventHandler<VisualStateChangedEventArgs>(hgroup_CurrentStateChanging);
                    }
                }
            }
        }
    }
}
