using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chord
{
    public sealed class RingInstance
    {
        private static RingInstance _instance = null;
        public List<Node> Network;
        private RingInstance()
        {
            Network = new List<Node>();
        }//ctor

        public static RingInstance Instance
        {
            get
            {
                if (_instance == null) _instance = new RingInstance();
                return _instance;
            }//get
        }//singleton property

        public bool Join(Node joining)
        {
            var successor = Network.FirstOrDefault(n => n.ID >= joining.ID);
            joining.Successor = (successor ?? Network[0]);
            joining.Predecessor = successor.Predecessor;
            joining.Predecessor.Successor = joining;

            Network.Add(joining);
            return Network.Contains(joining);
        }//Join

        public bool Leave(Node leaving)
        {
            leaving.Predecessor.Successor = leaving.Successor;
            leaving.Successor.Predecessor = leaving.Predecessor;

            Network.Remove(leaving);
            return Network.Contains(leaving);
        }//Leave
    }//RingInstance
}//chord
