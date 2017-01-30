using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advanced_Combat_Tracker;
using System.Windows.Forms;
using System.Reflection;
using FFXIVBanlist.Processing;

namespace FFXIVBanlist
{
    public class tmp : IActPluginV1
    {
        private BanlistWindow window;
        private Label statusLabel;
        private DateExtractor dateExtractor = new DateExtractor();
        private CommandParser commandParser = new CommandParser();

        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= parseLogLine;
            statusLabel.Text = "Plugin Exited";
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            window = new BanlistWindow();
            statusLabel = pluginStatusText;
            pluginScreenSpace.Controls.Add(window);
            //throw new NotImplementedException();

            statusLabel.Text = "Plugin Started";

            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(parseLogLine);
            //ActGlobals.oFormActMain.
        }

        public void parseLogLine(bool isImport, LogLineEventArgs logInfo)
        {
            if (!isImport)
            {
                string line = logInfo.logLine;
                string date = dateExtractor.GetCurrentDate(line);
                string value = dateExtractor.RemoveDate(line);

                if(commandParser.IsCommnad(value))
                    window.AppendLine(date + ":" + commandParser.ProcessCommand(value));

            }
        }
    }
}
