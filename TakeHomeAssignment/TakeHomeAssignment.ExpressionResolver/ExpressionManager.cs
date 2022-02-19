using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TakeHomeAssignment.ExpressionResolver
{
    internal class ExpressionManager
    {

        private string _postfix = "";
        private Stack<string> _lastTokens;
        private string[] tokens; 
        public ExpressionManager()
        {
            _lastTokens = new Stack<string>();
        }

        private  void AddToken (string  value)
        {
            if (_postfix.Length > 0 && value.Length > 0 )
                _postfix += " ";

            _postfix+=value;
        }
        internal string Tranceform(string givenEpression)
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
                case "/":
                    reseults.Push(( valueTwo / valueOne).ToString());
                    break;
                default:
                    break;
            }
        }

        private bool IsOperator(string token)
        {
            return "+".Equals(token) ||
                "-".Equals(token) ||"*".Equals(token) || "/".Equals(token);
        }

        private void HandleCloseParathasis()
        {
            while (!_lastTokens.Peek().Equals("("))
                AddLastToken();
            _lastTokens.Pop();
        }

        private void HandleOpenParanthasis()
        {
            _lastTokens.Push("(");
        }

        private bool HasCloseParanthasis(string token)
        {
            return token.Equals(")");
        }

        private bool HasOpenParathasis(string token)
        {
            return token.Equals("(");
        }

        private  void AddAllLastTokens()
        {
            while (_lastTokens.Count > 0)
                AddLastToken();
        }

        private void AddLastToken()
        {
            if(_lastTokens.Count >0)
                AddToken(_lastTokens.Pop());
        }

        private void HandleOperators(string token)
        {
            while (PreviousOperatorHasHigherPrecedence(token))
            {
                AddLastToken();
            }
            _lastTokens.Push( token);
        }

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
                case "/":
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

        private bool IsValue(string  token )
        {
            return Regex.IsMatch(token, @"\w+|\d+");
        }
    }
}