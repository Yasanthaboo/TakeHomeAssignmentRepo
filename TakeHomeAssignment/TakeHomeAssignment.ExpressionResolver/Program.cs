using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeAssignment.ExpressionResolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var treeManager = new TreeManager();
           var tree =  treeManager.BuildTree("15 7 1 1 + - / -3 * 2 1 1 + + -");
           var reseult=treeManager.EvalTree(tree);
           Console.WriteLine(Convert.ToString(reseult));

            Console.ReadLine();
        }
    }
}
