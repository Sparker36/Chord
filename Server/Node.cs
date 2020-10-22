using System.Collections;

namespace Chord
{
    public class Node
    {
        public int ID { get; private set; }
        public Node Predecessor, Successor;
        private IDictionary _fingerTable;

        public Node()
        {
            _fingerTable = new Hashtable(100); //100 is max nodes, given by assignment spec
        }//ctor

        public bool RequestJoin(RingInstance instance)
        {
            return instance.Join(this);
        }//RequestJoin

        public bool RequestLeave(RingInstance instance)
        {
            return instance.Leave(this);
        }//RequestLeave
    }//Node
}//namespace Chord
