using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeAssignment.ExpressionResolver
{
    internal class TreeManager
    {
        private int _count = 10;
        /// <summary>
        /// Buid tree
        /// </summary>
        /// <param name="postFixedExpression"></param>
        /// <returns></returns>
        internal TreeNode BuildTree(string postFixedExpression)
        {
            var tokenizeExpression = postFixedExpression.Split(' ');
           
            var stack = new Stack<TreeNode>();
            foreach (var token in tokenizeExpression)
                if (IsMathOperator(token))
                {
                    var rightOperand = stack.Pop();
                    var leftOperand = stack.Pop();
                    stack.Push(new TreeNode(token, leftOperand, rightOperand));
                }
                else
                    stack.Push(new TreeNode(token));

            return stack.Pop();
        }

        /// <summary>
        /// Calculate the answar
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public  int EvalTree(TreeNode root)
        {

          
            if (root == null)
                return 0;

           
            if (root.Left == null && root.Right == null)
                return Convert.ToInt32(root.Data);

          
            int leftEval = EvalTree(root.Left);

      
            int rightEval = EvalTree(root.Right);

           
            if (root.Data.Equals("+"))
                return leftEval + rightEval;

            if (root.Data.Equals("-"))
                return leftEval - rightEval;

            if (root.Data.Equals("*"))
                return leftEval * rightEval;

            return leftEval / rightEval;
        }

        /// <summary>
        /// Check for  math  operators
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool IsMathOperator(string token)
        {
            return "+".Equals(token) ||
              "-".Equals(token) || "*".Equals(token) || "÷".Equals(token);
        }
        
        /// <summary>
        /// print sub tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="space"></param>
        public void PrintSubTree(TreeNode root, int space)
        {
            if (root == null)
                return;

            space += _count;

            PrintSubTree(root.Right, space);
            Console.Write("\n");

            for (int i = _count; i < space; i++)
                Console.Write(" ");

            Console.Write(root.Data + "\n");
            PrintSubTree(root.Left, space);
        }
        /// <summary>
        /// print the tree
        /// </summary>
        /// <param name="root"></param>
        public void PrintTree(TreeNode root)
        {
            PrintSubTree(root, 0);
        }
    }

}


