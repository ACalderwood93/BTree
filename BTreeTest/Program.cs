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
            var rand = new Random();
            for (int i = 0; i < 1000; i++)
            {

                int randomNumber = rand.Next(0, 1000);
                SearchTree.InsertNode(randomNumber);
            }

           

            SearchTree.MapTree();
        }
    }
}
