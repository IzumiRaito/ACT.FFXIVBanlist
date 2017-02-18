using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFXIVBanlist.Model
{
    public interface IDataStore
    {

         Player AddPlayer(Player player);
         Player AddPlayer(string firstName, string lastName, string server);
         Note AddNote(Note note);
         Note AddNote(string firstName, string lastName, 
            string server, Note.Type type, string note);

         void DeleteNote(int noteId);

         List<Note> QueryForNotes(string firstName, string lastName, string server);
         List<Player> QueryForPlayers(string firstName, string lastName);

         void Save();
    }
}
