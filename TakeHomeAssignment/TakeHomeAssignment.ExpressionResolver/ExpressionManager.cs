using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TakeHomeAssignment.ExpressionResolver
{
    /// <summary>
    /// Expression related operations
    /// </summary>
    internal class ExpressionManager
    {

        private string _postfix = "";
        private Stack<string> _lastTokens;
        private string[] tokens; 
        public ExpressionManager()
        {
            _lastTokens = new Stack<string>();
        }

        /// <summary>
        /// Add one character to result
        /// </summary>
        /// <param name="value"></param>
        private  void AddToken (string  value)
        {
            if (_postfix.Length > 0 && value.Length > 0 )
                _postfix += " ";

            _postfix+=value;
        }

        /// <summary>
        /// Generate string with added space
        /// </summary>
        /// <param name="givenExpression"></param>
        /// <returns></returns>
        public string GetSpacedStrinng(string givenExpression)
        {
            char[] chars = givenExpression.ToCharArray();
            string result = "";
            int expressionLength = givenExpression.Length-1;
            for(int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '-')
                {
                    if (i > 0)
                    {
                        var previous = chars[i - 1];

                        if (IsOperator(previous.ToString()) || previous.Equals(')') || previous.Equals('('))
                        {
                            result += chars[i].ToString();
                        }

                    }
                    else if (i == 0)
                    {
                        var next = chars[i + 1];

                        if (!IsOperator(next.ToString()) || !next.Equals(')') || !next.Equals('('))
                        {
                            result += chars[i].ToString();
                        }
                    }
                    else
                    {
                        result += chars[i] + " ";
                    }
                }
                else if (i == expressionLength)
                {
                    result += chars[i].ToString();
                }
                else
                {
                    result += chars[i] + " ";
                }
                }

            return result;
         }

        /// <summary>
        /// Transeform string to postfix expression 
        /// </summary>
        /// <param name="givenEpression"></param>
        /// <returns></returns>
        public string Tranceform(string givenEpression)
        {
            tokens = (givenEpression ?? "").Split(' ');

            foreach (var token in tokens)
            {
                if (IsValue(token))
                    AddToken(token);
                else if (HasOpenParathasis(token))
                    HandleOpenParanthasis();
                else if (HasCloseParanthasis(token))
                    HandleCloseParathasis();
                else
                    HandleOperators(token);
            }

            AddAllLastTokens();
            return _postfix;
        }

       
        /// <summary>
        /// Evaluate postfixed expression
        /// </summary>
        /// <param name="postfixExpression"></param>
        /// <returns></returns>
        internal  int EvaluatePostFix(string  postfixExpression)
        {
            if (string.IsNullOrEmpty(postfixExpression))
                return -1;
            Stack<string> evaluatoinResults = new Stack<string>();
            string[] tokens = postfixExpression.Split(' ');

            foreach (var token in tokens)
            {
                if(IsOperator(token))
                {
                    EvaluteResult(token, evaluatoinResults);
                }
                else
                {
                    evaluatoinResults.Push(token);
                }
            }

            return Convert.ToInt32(evaluatoinResults.Pop());
        }

        /// <summary>
        /// helping  method  for  calculation base of operator
        /// </summary>
        /// <param name="token"></param>
        /// <param name="reseults"></param>
        private void EvaluteResult(string token,Stack<string> reseults)
        {

            int valueOne = Convert.ToInt32(reseults.Pop());
            int valueTwo = Convert.ToInt32(reseults.Pop());
            switch (token)
            {
                case "+":
                    reseults.Push((valueTwo+valueOne).ToString());
                    break;
                case "-":
                    reseults.Push(( valueTwo - valueOne).ToString());
                    break;
                case "*":
                    reseults.Push((valueOne * valueTwo).ToString());
                    break;
                case "÷":
                    reseults.Push(( valueTwo / valueOne).ToString());
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Check for  math operators
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool IsOperator(string token)
        {
            return "+".Equals(token) ||
                "-".Equals(token) ||"*".Equals(token) || "÷".Equals(token);
        }

        /// <summary>
        /// balancee close  paranthasis
        /// </summary>
        private void HandleCloseParathasis()
        {
            while (!_lastTokens.Peek().Equals("("))
                AddLastToken();
            _lastTokens.Pop();
        }
        /// <summary>
        /// balance open paranthasis
        /// </summary>
        private void HandleOpenParanthasis()
        {
            _lastTokens.Push("(");
        }

        /// <summary>
        /// check for close paranthasis
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool HasCloseParanthasis(string token)
        {
            return token.Equals(")");
        }

        /// <summary>
        /// check for open paranthasis
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool HasOpenParathasis(string token)
        {
            return token.Equals("(");
        }

        /// <summary>
        /// append all tokens
        /// </summary>
        private  void AddAllLastTokens()
        {
            while (_lastTokens.Count > 0)
                AddLastToken();
        }

        /// <summary>
        /// add previous token
        /// </summary>
        private void AddLastToken()
        {
            if(_lastTokens.Count >0)
                AddToken(_lastTokens.Pop());
        }

        /// <summary>
        /// Manage precedence of  the operators
        /// 
        /// </summary>
        /// <param name="token"></param>
        private void HandleOperators(string token)
        {
            while (PreviousOperatorHasHigherPrecedence(token))
            {
                AddLastToken();
            }
            _lastTokens.Push( token);
        }

        /// <summary>
        /// Check the  level of precedence of  math operators
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool PreviousOperatorHasHigherPrecedence(string token)
        {
           if( _lastTokens.Count ==0)
                return false;
            int previousPrecedence = GetPrecedence(_lastTokens.Peek());
            int currnetPrecedence = GetPrecedence(token);

            return previousPrecedence >= currnetPrecedence; 
        }

        private int GetPrecedence(string token)
        {
            switch (token)
            {
                case "*":
                case "÷":
                    return 100;
                case "+":
                case "-":
                    return 10;
                case "(":
                case ")":
                    return -1;
                default:
                    return 1;
                    
            }
        }

        /// <summary>
        ///  return true for letters and  numbers
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool IsValue(string  token )
        {
            return Regex.IsMatch(token, @"\w+|\d+");
        }
    }
}