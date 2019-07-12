using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCCommon
{
    public static class ListExtension
    {
        public static string JoinToString<T>(this IEnumerable<T> list, string separator, bool wrap = false, bool includeEmpty = false)
        {
            if (list == null || list.Count() == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            if (wrap)
            {
                foreach (T t in list)
                {
                    string s = string.Empty;
                    if (t != null)
                        s = t.ToString();
                    if (includeEmpty || !string.IsNullOrEmpty(s))
                        sb.Append(s + separator);
                }
                if (sb.Length > 0)
                    sb.Insert(0, separator);
            }
            else
            {
                foreach (T t in list)
                {
                    string s = string.Empty;
                    if (t != null)
                        s = t.ToString();

                    if (includeEmpty || !string.IsNullOrEmpty(s))
                        sb.Append(separator + s);
                }
                if (sb.Length > 0)
                    sb.Remove(0, separator.Length);
            }
            return sb.ToString();
        }
    }
}
