using ServerSide.Modul;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServerSide.Entiteis
{
    public class MainManager
    {
        private MainManager() { }

        private static readonly MainManager _Instance = new MainManager();
        public static MainManager Instance
        {
            get { return _Instance; }
        }

        // Instance of Products
        // Because of it I can access to its function
        public EProducts products = new EProducts();

        // Instance of Usermessage
        // Because of it I can access to its function
        public EUserMessage message = new EUserMessage();


    }
}
