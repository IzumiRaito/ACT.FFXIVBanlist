using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advanced_Combat_Tracker;
using System.Windows.Forms;
using System.Reflection;

[assembly: AssemblyTitle("FFXIV Banlist")]
[assembly: AssemblyDescription("A plugin that allows to store information about met players, positive or negative ")]
[assembly: AssemblyCompany("IzumiRaito@Odin")]
[assembly: AssemblyVersion("1.0.0.1")]

namespace FFXIVBanlist
{
    public class tmp : IActPluginV1
    {
        private BanlistWindow window;

        private Label statusLabel;

        public void DeInitPlugin()
        {
            statusLabel.Text = "Plugin Exited";
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            window = new BanlistWindow();
            statusLabel = pluginStatusText;
            pluginScreenSpace.Controls.Add(window);
            //throw new NotImplementedException();

            statusLabel.Text = "Plugin Started";

            //ActGlobals.oFormActMain.
        }
    }
}
