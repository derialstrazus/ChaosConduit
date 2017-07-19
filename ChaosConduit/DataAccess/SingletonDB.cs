using ChaosConduit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChaosConduit.DataAccess
{
    public class SingletonDB
    {
        #region "Singleton Framework"
        private static readonly SingletonDB instance = new SingletonDB();

        static SingletonDB() { }

        private SingletonDB() { }

        public static SingletonDB Instance
        {
            get { return instance; }
        }
        #endregion



        public List<User> Users { get; set; }
        public List<Room> Rooms { get; set; }



        public void Initialize()
        {
            Users = new List<User>();
            Rooms = new List<Room>();
        }
    }
}