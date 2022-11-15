using E3.UpdateAttributes.Gui;
using E3.UpdateAttributes.Interfaces.E3Connector;
using E3.UpdateAttributes.Interfaces.Repository;
using E3.UpdateAttributes.Logic;
using E3.UpdateAttributes.Repository;
using E3PlugIn;
using Ninject;
using System;
using System.Windows.Forms;

namespace E3.UpdateAttributes
{
    public class E3Plugin : IE3PlugIn
    {
        //private const int ExpectedMinimumBuild = 1920;

        private IPluginLogic _pluginLogic;
        private IKernel _kernel;

        public void Init(IE3InitializationContext context)
        {
            try
            {
                if (!CheckE3Feutures(context)) return; 

                _kernel = new StandardKernel();
                _kernel.Bind<IE3Repository>().To<E3Repository>().InSingletonScope();
                _kernel.Bind<IE3Connector>().To<E3Connector.E3Connector>().InSingletonScope();
                _kernel.Bind<IPluginLogic>().To<PluginLogic>().InSingletonScope();

                _kernel.Bind<E3Plugin>().ToSelf().InSingletonScope();


                _pluginLogic = _kernel.Get<IPluginLogic>();

                context.RegisterMainWindowInitEventHandler(EventHandlerRegisterMainWindow);
                context.RegisterAfterOpenProjectEventHandler(_pluginLogic.AfterOpenProjectEvent);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EventHandlerRegisterMainWindow(object sender, MainWindowInitEventArgs mainWindowInitEventArgs)
        {
            try
            {
                var version = $"{GetType().Assembly.GetName().Version.ToString(3)}";

                if (_pluginLogic.CheckPreConditions())
                {
                    mainWindowInitEventArgs.AddDockingWindow("E3.UpdateAttributes", _kernel.Get<PlugIn>());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckE3Feutures(IE3InitializationContext context)
        {
            if (context == null) return false;

            if (
                context.CheckFeature(E3Features.FEATURE_CABLE) ||
                context.CheckFeature(E3Features.FEATURE_SCHEMA) ||
                context.CheckFeature(E3Features.FEATURE_STUDENT)   
                ) return true;

            return false;
        }
    }
}
