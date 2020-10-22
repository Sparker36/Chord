using System.Net;
using System.Net.Sockets;

namespace Chord
{
    public class ConnectionHandler
    {
        private Socket _listener;
        private IPHostEntry _ipHost;
        private IPAddress _ipAddr;
        private IPEndPoint _localEndPoint;
        private readonly int _portNumber;

        /// <summary>
        /// Sets up a local endpoint along for the new ConnectionHandler
        /// </summary>
        /// <param name="port">Desired port number for the endpoint. Default is 12345.</param>
        /// <param name="backlog">Number of max connections. Default is 10.</param>
        public ConnectionHandler(int port = 12345)
        {
            _portNumber = port;
            SetUpLocalEndPoint();
        }//ConnectionHandler

        /// <summary>
        /// Sets up IP Host Info, IP Address, and Local EndPoint for each ConnectionHandler object.
        /// </summary>
        private void SetUpLocalEndPoint()
        {
            _ipHost = Dns.GetHostEntry(Dns.GetHostName());
            _ipAddr = _ipHost.AddressList[0];
            _localEndPoint = new IPEndPoint(_ipAddr, _portNumber);
        }//SetUpLocalEndPoint()

        /// <summary>
        /// Creates and binds a socket to the local endpoint, then starts listening for connections.
        /// </summary>
        /// <param name="Backlog">Number of max connections allowed</param>
        private void Listen(int Backlog)
        {
            _listener = new Socket(_ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _listener.Bind(_localEndPoint);
            _listener.Listen(Backlog);
        }//Listen()
    }//ConnectionHandler
}//Server namespace
