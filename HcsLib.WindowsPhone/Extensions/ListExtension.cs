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
using System.Collections.Generic;
using System.Linq;

namespace HcsLib.WindowsPhone.Extensions
{
    public static class ListExtension
    {
        public static bool IsExists<T>(this List<T> list, Func<T, bool> predicate)
        {
            return list.Where(predicate).Count() > 0;
        }
    }
}
