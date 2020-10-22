using System.Collections.Generic;

namespace Chord
{
    public class Server
    {
        private ICollection<Connection> _connectionList;
        private ConnectionHandler _connectionHandler;
        private FingerTable _finger;

        public Server()
        {
            _connectionList = new List<Connection>();
        }//ctor

    }//Server
}//Server 
