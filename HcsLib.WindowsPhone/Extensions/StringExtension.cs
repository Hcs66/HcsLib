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
using System.Text;

namespace HcsLib.WindowsPhone.Extensions
{
    public static class StringExtension
    {

        /// <summary>
        /// 追加字符串，用分隔符分隔，默认分隔符为“,”
        /// </summary>
        /// <param name="sb">StringBuilder对象</param>
        /// <param name="append">要追加的字符串</param>
        public static void AppendString(this StringBuilder sb, string append)
        {
            AppendString(sb, append, ",");
        }

        /// <summary>
        /// 追加字符串，用分隔符分隔
        /// </summary>
        /// <param name="sb">StringBulider对象</param>
        /// <param name="append">要追加的字符串</param>
        /// <param name="split">分隔符</param>
        public static void AppendString(this StringBuilder sb, string append, string split)
        {
            if (sb.Length == 0)
            {
                sb.Append(append);
                return;
            }

            sb.Append(split);
            sb.Append(append);
        }

    }
}
