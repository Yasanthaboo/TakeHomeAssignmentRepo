using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeAssignment.ExpressionResolver
{
    internal class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public string Data { get; set; }    
        public TreeNode(string data)
        {
            this.Data = data;
            Left = Right= null;
        }

        public TreeNode(string data,TreeNode left , TreeNode right) 
        {
            this.Data = data;
            Left = left;
            Right = right;
        }

    }
}
