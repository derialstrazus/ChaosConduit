using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChaosConduit.Models
{
    public class Room
    {
        public Guid ID { get; set; }

        public List<User> Users { get; set; }

        private string _RoomName;

        public string RoomName
        {
            get { return (_RoomName != null) ? _RoomName : string.Join(", ", Users.Select(x => x.Name).ToList()); }
            set { _RoomName = value; }
        }
    }
}