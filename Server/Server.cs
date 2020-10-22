using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Chord
{
    public class Server
    {
        private ICollection<Connection> _connectionList;
        private ConnectionHandler _connectionHandler;
        private IPHostEntry _hostInfo;
        private IPAddress _ipAddress;
        private IPEndPoint _localEndPoint;
        private Socket _listener;
        public int Backlog { get; set; } = 10;

        public Server(int portNum)
        {
            _connectionList = new List<Connection>();

            SetupLocalEndPoint(portNum);
            BeginListening();
        }//ctor


        public void SetupLocalEndPoint(int portNum)
        {
            _hostInfo = Dns.GetHostEntry(Dns.GetHostName());
            _ipAddress = _hostInfo.AddressList[0];
            _localEndPoint = new IPEndPoint(_ipAddress, portNum);
        }

        public void BeginListening()
        {
            _listener = new Socket(_ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _listener.Bind(_localEndPoint);
            _listener.Listen(Backlog);
        }//BeginListening()


        public void Listen()
        {
            do
            {
                Socket Handler = _listener.Accept();
                Task.Factory.StartNew(() => HandleRequest());
            } while (!TimeToExit);
        }//Listen()

    }//Server
}//Server 
