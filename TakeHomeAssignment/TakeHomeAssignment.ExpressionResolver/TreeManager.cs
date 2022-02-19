using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeAssignment.ExpressionResolver
{
    internal class TreeManager
    {
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

        private bool IsMathOperator(string token)
        {
            return "+".Equals(token) ||
              "-".Equals(token) || "*".Equals(token) || "/".Equals(token);
        }

        internal void PrintTree()
        {

        }


    }

}


