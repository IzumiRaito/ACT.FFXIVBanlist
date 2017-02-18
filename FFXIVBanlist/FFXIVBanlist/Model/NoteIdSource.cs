using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFXIVBanlist.Model
{
    public class NoteIdSource
    {
        private static NoteIdSource instance;
        public static NoteIdSource Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NoteIdSource();
                }
                return instance;
            }
        }

        private int maxIndex;

        private NoteIdSource()
        {
            maxIndex = 0;
        }

        public int GetNextId()
        {
            maxIndex++;
            return maxIndex;
        }

        public void OnNoteLoaded(Note note)
        {
            if (maxIndex < note.Id)
            {
                maxIndex = note.Id;
            }

        }
    }
}
