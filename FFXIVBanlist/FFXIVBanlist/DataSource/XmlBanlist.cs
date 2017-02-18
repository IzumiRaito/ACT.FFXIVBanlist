using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFXIVBanlist.Model;
using System.Xml.Serialization;
using System.IO;

namespace FFXIVBanlist.DataSource
{
    [Serializable]
    public class XmlBanlist : IDataStore
    {
        [NonSerialized]
        private string FilePath;
        public List<Player> allPlayers = new List<Player>();
        public List<Note> allNotes = new List<Note>();
        [NonSerialized]
        private Dictionary<string, Note> cache = new Dictionary<string, Note>();

        public static XmlBanlist FromFile(string filename)
        {
            try
            {
                XmlSerializer thisSerializer = new XmlSerializer(typeof(XmlBanlist));

                TextReader reader = new StreamReader(filename);
                XmlBanlist bl = (XmlBanlist)thisSerializer.Deserialize(reader);
                bl.FilePath = filename;
                reader.Close();
                return bl;
            }
            catch (FileNotFoundException e)
            {
                XmlBanlist bl = new XmlBanlist();
                bl.FilePath = filename;
                bl.Save();
                return bl;
            }
        }


        public  Player AddPlayer(Player player)
        {
            allPlayers.Add(player);
            return player;
        }

        public  Player AddPlayer(string firstName, string lastName, string server)
        {
            Player player = new Player(firstName, lastName, server);
            return AddPlayer(player);
        }

        public  Note AddNote(Note note)
        {
            allNotes.Add(note);
            return note;
        }

        private Player tryGetPlayer(string firstName, string lastName,
            string server)
        {
            foreach (Player p in allPlayers)
            {
                if (p.Equals(firstName, lastName, server))
                {
                    return p;
                }
            }
            return null;
        }

        public  Note AddNote(string firstName, string lastName,
            string server, Note.Type type, string text)
        {
            Player player = tryGetPlayer(firstName, lastName, server);
            if (player == null)
            {
                player = AddPlayer(firstName, lastName, server);
            }

            Note note = new Note(player.Id, type, text);
            AddNote(note);
            Save();
            return note;
        }

        public void DeleteNote(int noteId)
        {
            allNotes.RemoveAll(note => note.Id == noteId);
        }

        private List<Note> GetNotesForPlayer(int id)
        {
            List<Note> result = new List<Note>();
            foreach (Note note in allNotes)
            {
                if (note.PlayerId == id)
                {
                    result.Add(note);
                }
            }
            return result;

        }

        public  List<Note> QueryForNotes(string firstName, string lastName, string server)
        {
            Player p = tryGetPlayer(firstName, lastName, server);
            return GetNotesForPlayer(p.Id);
        }

        public  List<Player> QueryForPlayers(string firstName, string lastName)
        {
            List<Player> result = new List<Player>();

            foreach (Player p in allPlayers)
            {
                if (p.Equals(firstName, lastName))
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public  void Save()
        {
            XmlSerializer thisSerializer = new XmlSerializer(typeof(XmlBanlist));

            TextWriter writer = new StreamWriter(FilePath);
            thisSerializer.Serialize(writer, this);
            writer.Close();
        }
    }
}
