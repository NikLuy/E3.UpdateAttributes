using E3.UpdateAttributes.Interfaces.Logic;
using E3.UpdateAttributes.Interfaces.Repository;
using E3PlugIn;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace E3.UpdateAttributes.Logic
{
    public class PluginLogic : IDisposable, IPluginLogic
    {
        private readonly CultureInfo _currentCultureInfo;
        private readonly IE3Repository _e3Repository;
        private bool _pluginIsEnabled;

        public event PluginEnabledHandler PluginEnabled;
        public delegate void PluginEnabledHandler(object sender, bool e);


        public PluginLogic(IE3Repository e3Repository)
        {
            _e3Repository = e3Repository;

            _currentCultureInfo = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
        }

        public bool PluginIsEnabled
        {
            get { return _pluginIsEnabled; }
            set { _pluginIsEnabled = value; }
        }

        public List<string> GetAttributes()
        {
            try
            {

                if (ConnectToE3Failed()) return null;
                var message = $"GetAttributes";
                return _e3Repository.GetAttributesFromDevice();
            }
            catch (Exception ex)
            {
                _e3Repository.PutInfo(false, ex.Message);
                return null;
            }
            finally
            {
                _e3Repository.Disconnect();
            }

        }

        public void UpdateAttributes(List<string> Attributes)
        {
            try
            {
                if (ConnectToE3Failed()) return;
                
                _e3Repository.UpdateDeviceAttributes(Attributes);
            }
            finally
            {
                _e3Repository.Disconnect();
            }

        }

        public void PutMessage(string message)
        {
            try
            {
                if (ConnectToE3Failed()) return;
                _e3Repository.PutInfo(false, message);
            }
            finally
            {
                _e3Repository.Disconnect();
            }

        }

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = _currentCultureInfo;
        }

        public bool CheckPreConditions()
        {
            return true;
        }

        public void AfterOpenProjectEvent(object sender, AfterOpenProjectEventArgs e)
        {
            _pluginIsEnabled = true;
            PluginEnabled?.Invoke(this, _pluginIsEnabled);
            try
            {
                if (ConnectToE3Failed()) return;
            }
            finally
            {
                _e3Repository.Disconnect();
            }
        }

        private bool ConnectToE3Failed()
        {
            if (_e3Repository.Connect()) return false;
            return true;
        }

    }
}