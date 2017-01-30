using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFXIVBanlist.Processing
{
    public class CommandParser
    {
        public class Command
        {
            public const string ADD = "add";
            public const string REMOVE = "remove";
            public const string FIND = "find";
        }
        const string ECHO_IDENTIFIER = "00:0038:";
        const string PREFIX_1 = "blist";
        const string PREFIX_2 = "banlist";

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
            if (string.Equals(command, Command.ADD))
            {
                return ProcessAdd(parts);
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
                return String.Format("Invalid command {0}. Requires {1}, {2} or {3}",
                    command, Command.ADD, Command.REMOVE, Command.FIND); 
            }
        }


        private string ProcessAdd(string[] parts)
        {
            if (parts.Length < 5)
            {
                return "Invalid parameters for command. Requires first_name last_name server.";
            }
            string firstName = parts[2];
            string lastName = parts[3];
            string server = parts[4];

            return "Process add";
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
