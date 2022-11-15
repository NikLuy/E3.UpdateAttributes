using System;
using System.Diagnostics;
using System.Linq;
using E3.UpdateAttributes.Interfaces.E3Connector;

namespace E3.UpdateAttributes.E3Connector
{
    public class E3Connector : IE3Connector
    {
        public bool Connect(ref object e3App)
        {
            var e3Objects = RunningObjectTable.GetRunningInstances();
            var myProcess = Process.GetCurrentProcess();

            if (e3Objects.ContainsKey(myProcess.Id))
            {
                // intern gestartet
                e3App = e3Objects[myProcess.Id];
            }
            else switch (e3Objects.Count)
            {
                case 1:
                    // extern gestartet, 1 Instanz e3
                    e3App = e3Objects.First();
                    break;
                case 0:
                    // neues e3 starten
                    var e3ApplicationType = Type.GetTypeFromProgID("CT.Application");
                    e3App = Activator.CreateInstance(e3ApplicationType);
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}
