using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3PluginExample.Plugin.Repo.Extension
{
    public static class ApplicationInterfaceExtension
    {
        public static T[] E3ArrayToArray<T>(object e3Ids)
        {
            var e3Arr = ((object[])e3Ids);
            if (e3Arr == null || e3Arr.Length == 0)
                return new T[] { };

            var arr = new T[e3Arr.Length - 1];
            for (var i = 1; i < e3Arr.Length; i++)
            {
                arr[i - 1] = (T)e3Arr[i];
            }
            return arr;
        }
    }
}
