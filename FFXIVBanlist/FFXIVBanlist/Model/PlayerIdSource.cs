using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFXIVBanlist.Model
{
    public class PlayerIdSource
    {
        private static PlayerIdSource instance;
        public static PlayerIdSource Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerIdSource();
                }
                return instance;
            }
        }

        private int maxIndex;

        private PlayerIdSource()
        {
            maxIndex = 0;
        }

        public int GetNextId()
        {
            maxIndex++;
            return maxIndex;
        }

        public void OnPlayerLoaded(Player player)
        {
            if (maxIndex < player.Id)
            {
                maxIndex = player.Id;
            }

        }
    }
}
