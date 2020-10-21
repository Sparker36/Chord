using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Chord
{
    public class Connection
    {
        private IPEndPoint  _serverEndPoint,
                            _clientEndPoint;
        private IPHostEntry _serverHost,
                            _clientHost;
        private IPAddress   _serverAddress,
                            _clientAddress;
        private int _portNumber;
        private Socket _connectionSocket;


        public Connection(IPAddress clientAddress, IPHostEntry clientHost, IPAddress serverAddress, IPHostEntry serverHost, int portNumber)
        {
            _serverHost = serverHost;
            _serverAddress = serverAddress;
            _serverEndPoint = new IPEndPoint(serverAddress, portNumber);

            _clientHost = clientHost;
            _clientAddress = clientAddress;
            _clientEndPoint = new IPEndPoint(clientAddress, portNumber);

            _connectionSocket = new Socket(serverAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }//Connection()
    }//Connection
}//Chord namespace
