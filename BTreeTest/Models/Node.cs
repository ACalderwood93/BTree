using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BTreeTest.Models
{
    
    class Node
    {
        public int Key { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public object Parent { get; private set; }
        public int StartPos { get; private set; }

        public Node()
        {

        }

        public Node(int key) : this()
        {
            this.Key = key;

        }

        public enum NodePosition
        {
            left,
            right,
            center
        }

        public void Add(int key)
        {
            if (this.Key != key)
            {
                if (key > this.Key)
                {
                    if (this.RightNode != null)
                    {
                        this.RightNode.Add(key);
                    }
                    else
                    {
                        this.RightNode = new Node(key);
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
                        this.LeftNode = new Node(key);
                    }
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
        private void PrintValue(string value, NodePosition nodePostion)
        {
            switch (nodePostion)
            {
                case NodePosition.left:
                    PrintLeftValue(value);
                    break;
                case NodePosition.right:
                    PrintRightValue(value);
                    break;
                case NodePosition.center:
                    Console.WriteLine(value);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void PrintLeftValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("L:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void PrintRightValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintPretty(string indent, NodePosition nodePosition, bool last, bool empty)
        {

            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "| ";
            }

            var stringValue = empty ? "-" : Key.ToString();
            PrintValue(stringValue, nodePosition);

            if (!empty && (this.LeftNode != null || this.RightNode != null))
            {
                if (this.LeftNode != null)
                    this.LeftNode.PrintPretty(indent, NodePosition.left, false, false);
                else
                    PrintPretty(indent, NodePosition.left, false, true);

                if (this.RightNode != null)
                    this.RightNode.PrintPretty(indent, NodePosition.right, true, false);
                else
                    PrintPretty(indent, NodePosition.right, true, true);
            }
        }


    }
}

