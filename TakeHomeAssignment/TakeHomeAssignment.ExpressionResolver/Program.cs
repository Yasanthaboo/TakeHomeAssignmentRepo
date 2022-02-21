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
            try
            {
                bool IsExit  = false;
                while (!IsExit)
                {
                    string expression = DisplayInstructions();
                    var request = Console.ReadLine();

                    var expressionManager = new ExpressionManager();
                    var treeManager = new TreeManager();
                    var postfix = expressionManager.Tranceform(expression);
                    var tree = treeManager.BuildTree(postfix);

                    switch (request)
                    {
                        case "Exit":
                            IsExit = true;
                            break;
                        case "1":
                            treeManager.PrintTree(tree);
                            break;
                        case "2":
                            var reseult = treeManager.EvalTree(tree);
                            Console.WriteLine(string.Format("Ansawer is : {0}", Convert.ToString(reseult)));
                            break;
                        case "3":
                            HandleNewExpression(expressionManager, treeManager);
                            break;
                        default:
                            Console.WriteLine("Select valid option to continue.");
                            break;
                    }

                }
            }
            catch (Exception er)
            {
                Console.WriteLine(string.Format("Unable to execute the request.{0}.",er.Message));
                //creeate the  logg        
            }
        }

        private static void HandleNewExpression(ExpressionManager expressionManager, TreeManager treeManager)
        {
            Console.WriteLine("please enter new expression.leave  one space between each token.");
            var newexpression = Console.ReadLine();
            var selectedpostfix = expressionManager.Tranceform(newexpression);
            var selectedtree = treeManager.BuildTree(selectedpostfix);
            treeManager.PrintTree(selectedtree);
            var solution = treeManager.EvalTree(selectedtree);
            Console.WriteLine(string.Format("Ansawer is : {0}", Convert.ToString(solution)));
        }

        private static string DisplayInstructions()
        {
            Console.WriteLine("-----------------------------------------------------------------------");
            var expression = "( 15 ÷ ( 7 - ( 1 + 1 ) ) * -3 ) - ( 2 + ( 1 + 1 ) )";
            Console.WriteLine("Current exression in {0}.", expression);
            Console.WriteLine("Please  select an option to continue.");
            Console.WriteLine("Enter 1 to display the tree.");
            Console.WriteLine("Enter 2 to display the answar.");
            Console.WriteLine("Enter 3 to solve diffent expression.");
            Console.WriteLine("Enter 'Exit' for close the application.");
            Console.WriteLine("-----------------------------------------------------------------------");
            return expression;
        }
    }
}
