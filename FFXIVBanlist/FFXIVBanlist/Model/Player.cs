using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFXIVBanlist.Model
{
    [Serializable]
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ServerName { get; set; }

        public Player()
        {

        }

        public Player(int id, string firstName, string lastName, string serverName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ServerName = serverName;
            PlayerIdSource.Instance.OnPlayerLoaded(this);
        }

        public Player(string firstName, string lastName, string serverName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ServerName = serverName;
            Id = PlayerIdSource.Instance.GetNextId();
        }

        public override bool Equals(object other)
        {
            if (other.GetType() != typeof(Player))
            {
                return false;
            }
            Player otherPlayer = other as Player;
            if (otherPlayer.GetHashCode() != GetHashCode())
            {
                return false;
            }
            if (!otherPlayer.LastName.Equals(LastName))
            {
                return false;
            }
            if (!otherPlayer.FirstName.Equals(FirstName))
            {
                return false;
            }
            if (!otherPlayer.ServerName.Equals(ServerName))
            {
                return false;
            }
            return true;
        }

        public bool Equals(string firstName, string lastName)
        {
            if (!lastName.Equals(LastName))
            {
                return false;
            }
            if (!firstName.Equals(FirstName))
            {
                return false;
            }
            return true;

        }

        public bool Equals(string firstName, string lastName, string serverName)
        {
            if (!lastName.Equals(LastName))
            {
                return false;
            }
            if (!firstName.Equals(FirstName))
            {
                return false;
            }
            if (!serverName.Equals(ServerName))
            {
                return false;
            }
            return true;

        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode() ^ ServerName.GetHashCode();
        }
    }
}
