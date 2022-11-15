using E3.UpdateAttributes.Interfaces.Repository;
using E3.UpdateAttributes.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace E3.UpdateAttributes.Gui
{
    public partial class PlugIn : UserControl
    {
        private readonly IPluginLogic _pluginLogic;

        public PlugIn(IPluginLogic pluginLogic)
        {
            _pluginLogic = pluginLogic;
             InitializeComponent();
        }

        private void btnGetAttributes_Click(object sender, EventArgs e)
        {
           var Attributes =  _pluginLogic.GetAttributes();
            lbAttributes.Items.Clear();
            lbAttributes.Items.AddRange(Attributes.ToArray());
        }

        private void btnUpdateAttributes_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (var item in lbAttributes.SelectedItems)
            {
                list.Add(item.ToString());
            }
            if(list.Count > 0)
            {
                _pluginLogic.UpdateAttributes(list);
            }else
            {
                _pluginLogic.PutMessage("Kein Attribut gewählt");
            }
          
        }
    }
}
