using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeTest.Models
{
    class Tree
    {
        public Node RootNode { get; set; }

        public Tree()
        {
            RootNode = new Node(0, null);
        }
        public Node InsertNode(int key)
        {
            this.RootNode.Add(key);
            return new Node();
        }
        public Node Search(int key)
        {
           return this.RootNode.Search(key);
        }
    }
}
