using System.Runtime.InteropServices;
using e3;
using E3.UpdateAttributes.Interfaces.E3Connector;
using E3.UpdateAttributes.Interfaces.Repository;

namespace E3.UpdateAttributes.Repository
{
    public class E3RepositoryBase : IE3RepositoryBase
    {
        private int _e3ConnectionCounter;
        protected IApplicationInterface E3App;
        protected IJobInterface E3Job;
        protected IE3Connector E3Connector;

        public E3RepositoryBase(IE3Connector e3Connector)
        {
            E3Connector = e3Connector;
            _e3ConnectionCounter = 0;
        }
        public bool Connect()
        {
            if (_e3ConnectionCounter == 0)
            {
                object tmpE3App = null;

                if (E3Connector.Connect(ref tmpE3App) == false) return false;

                E3App = (IApplicationInterface)tmpE3App;
                E3Job = (IJobInterface)E3App.CreateJobObject();
            }
            _e3ConnectionCounter++;
            return true;
        }
        public void Dispose()
        {
            if (IsConnected) FinalDisconnect();
        }
        public bool IsConnected => _e3ConnectionCounter > 0;

        public void Disconnect()
        {
            if (_e3ConnectionCounter > 0) _e3ConnectionCounter--;
            if (_e3ConnectionCounter > 0) return;
            if (_e3ConnectionCounter == 0) FinalDisconnect();
        }
        private void FinalDisconnect()
        {
            if (E3Job != null) ReleaseComObject(E3Job);
            if (E3App != null) ReleaseComObject(E3App);
            _e3ConnectionCounter = 0;
        }

        private static void ReleaseComObject(object comObject)
        {
            if (comObject == null) return;
            Marshal.ReleaseComObject(comObject);
            // ReSharper disable once RedundantAssignment
            comObject = null;
        }


        public void PutInfo(bool showMessageBox, string message, int itemId = 0)
        {
            E3App.PutInfo(showMessageBox ? 1 : 0, message, itemId);
        }

        public void PutWarning(bool showMessageBox, string message, int itemId = 0)
        {
            E3App.PutWarning(showMessageBox ? 1 : 0, message, itemId);
        }

        public void PutError(bool showMessageBox, string message, int itemId = 0)
        {
            E3App.PutError(showMessageBox ? 1 : 0, message, itemId);
        }

        public int GetItemType(int itemId)
        {
            return E3Job.GetItemType(itemId);
        }
    }
}