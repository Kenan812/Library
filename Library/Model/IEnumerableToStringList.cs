using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Model
{
    public static class IEnumerableToStringList
    {
        public static List<string> ToStringList(IEnumerable<dynamic> items)
        {
            var data = items.ToArray();
            if (data.Count() == 0) return null;

            var ls = new List<string>();
            foreach (var d in (IDictionary<string, object>)data[0])
            {
                ls.Add(d.Value.ToString());
            }

            return ls;
        }
    }
}
