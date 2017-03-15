using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeTest.Models
{
    class Node
    {
        public int Key { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public Node Parent { get; set; }

        public Node()
        {

        }

        public Node(int key, Node Parent) : this()
        {
            this.Key = key;
            this.Parent = Parent;
        }


        public void Add(int key)
        {
            if (this.Key == key)
                throw new Exception("Object of that key already exists");

            if (key > this.Key)
            {
                if (this.RightNode != null)
                {
                    this.RightNode.Add(key);
                }
                else
                {
                    this.RightNode = new Node(key, this);
                }
            }
            else
            {
                if (this.LeftNode != null)
                {
                    this.LeftNode.Add(key);
                }
                else
                {
                    this.LeftNode = new Node(key, this);
                }
            }
        }
        public Node Search(int key)
        {
            var result = new Node();

            if (this.Key == key)
                return this;

            if (key < this.Key)
            {
                result = this.LeftNode?.Search(key);
            }
            else
            {
                result = this.RightNode?.Search(key);
            }

            return result;
        }
    }
}

