using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFXIVBanlist.Model;

namespace FFXIVBanlist.Processing
{
    public class CommandParser
    {
        public class Command
        {
            public const string BAN = "ban";
            public const string INFO = "info";
            public const string COMMEND = "comm";
            public const string REMOVE = "remove";
            public const string FIND = "find";
        }
        const string ECHO_IDENTIFIER = "00:0038:";
        const string PREFIX_1 = "blist";
        const string PREFIX_2 = "banlist";

        private IDataStore dataStore;

        public CommandParser(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public bool IsCommnad(string line)
        {
            return line.StartsWith(ECHO_IDENTIFIER);
        }

        private string RemoveEchoIdentifier(string command)
        {
            return command.Remove(0, ECHO_IDENTIFIER.Length);
        }

        public string ProcessCommand(string commandLine)
        {
            commandLine = RemoveEchoIdentifier(commandLine);

            string[] parts = commandLine.Split(' ');

            string prefix = parts[0];
            if (!string.Equals(prefix, PREFIX_1) && !string.Equals(prefix, PREFIX_2))
            {
                return String.Format("Incorrect command prefix. Requires {0} or {1}", PREFIX_1, PREFIX_2); 
            }
            string command = parts[1];
            if (string.Equals(command, Command.BAN))
            {
                return ProcessAdd(parts, Note.Type.BAD);
            }
            if (string.Equals(command, Command.INFO))
            {
                return ProcessAdd(parts, Note.Type.NEUTRAL);
            }
            if (string.Equals(command, Command.COMMEND))
            {
                return ProcessAdd(parts, Note.Type.GOOD);
            }
            else if (string.Equals(command, Command.REMOVE))
            {
                return ProcessRemove(parts);
            }
            else if (string.Equals(command, Command.FIND))
            {
                return ProcessFind(parts);
            }
            else
            {
                return String.Format("Invalid command {0}. Requires {1}, {2} , {3} , {4} or {5}",
                    command, Command.BAN, Command.COMMEND, Command.INFO, Command.REMOVE, Command.FIND); 
            }
        }


        private string ProcessAdd(string[] parts, Note.Type type)
        {
            if (parts.Length < 6)
            {
                return "Invalid parameters for command. Requires first_name last_name server.";
            }
            string firstName = parts[2];
            string lastName = parts[3];
            string server = parts[4];
            StringBuilder message = new StringBuilder();
            for (int i = 5; i < parts.Length; i++)
            {
                message.Append(parts[i]).Append(" ");
            }
            dataStore.AddNote(firstName, lastName, server, type, message.ToString());

            return string.Format("{0} added for player {1} {2} on {3}", 
                type.ToString(), firstName, lastName, server);
        }

        private string ProcessRemove(string[] parts)
        {
            if (parts.Length < 5)
            {
                return "Invalid parameters for command. Requires first_name last_name server.";
            }
            string firstName = parts[2];
            string lastName = parts[3];
            string server = parts[4];
            return "Process remove";
        }

        private string ProcessFind(string[] parts)
        {
            if (parts.Length < 4)
            {
                return "Invalid parameters for command. Requires first_name last_name [server].";
            }
            string firstName = parts[2];
            string lastName = parts[3];

            return "Process find";
        }
    }
}
