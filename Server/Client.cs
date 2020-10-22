using System.Net;

namespace Chord
{
    public class Client
    {
        private IPHostEntry _hostInfo;
        private IPAddress _ipAddress;
        private IPEndPoint _localEndPoint;

        public Client(int portNum)
        {
            _hostInfo = Dns.GetHostEntry(Dns.GetHostName());
            _ipAddress = _hostInfo.AddressList[0];
            _localEndPoint = new IPEndPoint(_ipAddress, portNum);
        }//ctor

    }//client
}//chord
