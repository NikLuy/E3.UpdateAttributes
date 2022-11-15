using e3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3PluginExample.Plugin.Repo.Extension
{
    public static class JobInterfaceExtension
    {
        public static int[] GetSelectedDeviceIds(this IJobInterface e3Job)
        {
            object e3Ids = null;
            e3Job.GetSelectedDeviceIds(ref e3Ids);
            return ApplicationInterfaceExtension.E3ArrayToArray<int>(e3Ids);
        }
        public static int[] GetAllDeviceIds(this IJobInterface e3Job)
        {
            object e3Ids = null;
            e3Job.GetAllDeviceIds(ref e3Ids);
            return ApplicationInterfaceExtension.E3ArrayToArray<int>(e3Ids);
        }

        public static IEnumerable<IDeviceInterface> GetSelectedDevices(this IJobInterface e3Job)
        {
            return DeviceInterfaceExtension.GetDeviceInterfaces(e3Job, e3Job.GetSelectedDeviceIds());
        }
        public static IEnumerable<IDeviceInterface> GetAllDevices(this IJobInterface e3Job)
        {
            return DeviceInterfaceExtension.GetDeviceInterfaces(e3Job, e3Job.GetAllDeviceIds());
        }

        public static int GetSelectedDevicesCount(this IJobInterface e3Job)
        {
            return e3Job.GetSelectedDeviceIds().Count();
        }
    }
}
