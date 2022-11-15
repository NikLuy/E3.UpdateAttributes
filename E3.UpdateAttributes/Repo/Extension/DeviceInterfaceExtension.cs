using e3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace E3PluginExample.Plugin.Repo.Extension
{
    public static class DeviceInterfaceExtension
    {
        public static IEnumerable<IDeviceInterface> GetDeviceInterfaces(IJobInterface e3Job, int[] ids)
        {
            IDeviceInterface e3Device = null;
            try
            {
                e3Device = (IDeviceInterface)e3Job.CreateDeviceObject();
                foreach (var e3Id in ids)
                {
                    e3Device.SetId(e3Id);
                    yield return e3Device;
                }
            }
            finally
            {
                if (e3Device != null) Marshal.FinalReleaseComObject(e3Device);
            }
        }
    }
}
