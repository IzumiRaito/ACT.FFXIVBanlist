using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advanced_Combat_Tracker;
using System.Windows.Forms;
using System.Reflection;
using FFXIVBanlist.Processing;
using FFXIVBanlist.Model;
using FFXIVBanlist.DataSource;
using System.IO;
using FFXIVBanlist.Logging;

namespace FFXIVBanlist
{
    public class FFXIVBanlist : IActPluginV1
    {
        public static ILogger logger;
        const string FILENAME = "odin.txt";

        private BanlistWindow window;
        private Label statusLabel;
        private DateExtractor dateExtractor = new DateExtractor();
        private IDataStore dataStore;
        private CommandParser commandParser;

        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= parseLogLine;
            statusLabel.Text = "Plugin Exited";
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            window = new BanlistWindow();
            logger = window;
            statusLabel = pluginStatusText;
            pluginScreenSpace.Controls.Add(window);
            string path = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, FILENAME);
            dataStore = XmlBanlist.FromFile(path);
            commandParser = new CommandParser(dataStore);
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

                window.AppendLine(logInfo.logLine);
                if(commandParser.IsCommnad(value))
                    window.AppendLine(date + ":" + commandParser.ProcessCommand(value));

            }
        }
    }
}
