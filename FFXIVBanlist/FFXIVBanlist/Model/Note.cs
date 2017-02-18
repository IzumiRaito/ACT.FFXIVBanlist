using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFXIVBanlist.Model
{
    [Serializable]
    public class Note
    {
        public enum Type {
            BAD,
            NEUTRAL,
            GOOD
        }

        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Type NoteType { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public Note()
        {

        }

        public Note(int id, int playerId, Type noteType, string text, DateTime date)
        {
            Id = id;
            PlayerId = playerId;
            NoteType = noteType;
            Text = text;
            Date = date;
            NoteIdSource.Instance.OnNoteLoaded(this);
        }

        public Note(int playerId, Type noteType, string text, DateTime date)
        {
            Id = NoteIdSource.Instance.GetNextId();
            PlayerId = playerId;
            NoteType = noteType;
            Text = text;
            Date = date;
        }

        public Note(int playerId, Type noteType, string text)
        {
            Id = NoteIdSource.Instance.GetNextId();
            PlayerId = playerId;
            NoteType = noteType;
            Text = text;
            Date = DateTime.Now;
        }

    }
}
