using E3.UpdateAttributes.Logic;
using E3PlugIn;
using System.Collections.Generic;

namespace E3.UpdateAttributes.Interfaces.Repository
{
    public interface IPluginLogic
    {
        bool PluginIsEnabled { get; set; }

        event PluginLogic.PluginEnabledHandler PluginEnabled;

        void AfterOpenProjectEvent(object sender, AfterOpenProjectEventArgs e);
        bool CheckPreConditions();
        void Dispose();
        List<string> GetAttributes();
        void UpdateAttributes(List<string> Attributes);

        void PutMessage(string message);
    }
}