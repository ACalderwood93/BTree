using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTreeTest.Models;

namespace BTreeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree SearchTree = new Tree();

            SearchTree.InsertNode(14);
            SearchTree.InsertNode(12);
            SearchTree.InsertNode(16);


            SearchTree.Search(12);
        }
    }
}
