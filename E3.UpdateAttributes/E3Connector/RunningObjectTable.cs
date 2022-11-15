using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace E3.UpdateAttributes.E3Connector
{
    public static class RunningObjectTable
    {
        public static Dictionary<int,object> GetRunningInstances()
        {
            IBindCtx bindCtx;
            Win32.CreateBindCtx(0, out bindCtx);
            if (bindCtx == null) return null;

            // get Running Object Table ...
            IRunningObjectTable rot;
            Win32.GetRunningObjectTable(0, out rot);
            if (rot == null) return null;

            // get enumerator for ROT entries
            IEnumMoniker monikerEnumerator;
            rot.EnumRunning(out monikerEnumerator);
            if (monikerEnumerator == null) return null;

            monikerEnumerator.Reset();

            var instances = new Dictionary<int, object>();

            var pNumFetched = new IntPtr();
            var monikers = new IMoniker[1];

            while (monikerEnumerator.Next(1, monikers, pNumFetched) == 0)
            {
                string displayName;
                monikers[0].GetDisplayName(bindCtx, null, out displayName);

                var splitedDisplayName = displayName.Split(':');
                if (splitedDisplayName.Length != 2) continue;

                int n;
                if (splitedDisplayName[0].ToUpper() != @"!E3APPLICATION" || !int.TryParse(splitedDisplayName[1], out n)) continue;

                object obj;
                rot.GetObject(monikers[0], out obj);
                instances.Add(n, obj);
            }
            return instances;
        }
    }
}