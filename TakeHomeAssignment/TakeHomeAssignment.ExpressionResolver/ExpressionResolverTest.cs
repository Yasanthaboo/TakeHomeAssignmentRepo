using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TakeHomeAssignment.ExpressionResolver
{
    [TestFixture]
 internal class ExpressionResolverTest
    {
        private string _result;

        [Test]
        public void ValidateEmptyResult ()
        {
            GivenTestData("");
            ExpectedOutput("");
        }

        [Test]
        public void ValidateNullExpressionResult()
        {
            GivenTestData(null);
            ExpectedOutput("");
        }

        [Test]
        public void TranceformExpressionWithSameLevelPrecisionOperators()
        {
            GivenTestData("4 + 5 - 3");
            ExpectedOutput("4 5 + 3 -");
        }

        [Test]
        public void TranceformExpressionWithMultipleLevelPrecedenceOperators()
        {
            GivenTestData("q = a - 5 * 3 + 4");
            ExpectedOutput("q a 5 3 * - 4 + =");
        }

        [Test]
        public void RemoveOutterparanthasis()
        {
            GivenTestData("( a - 5 ) + 4");
            ExpectedOutput("a 5 - 4 +");
        }

        [Test]
        public void EvaluateNeededparanthasis()
        {
            GivenTestData("( 3 + 5 ) / 4");
            ExpectedOutput("3 5 + 4 /");
        }


        [Test]
        public void EvaluateUnwantedNestedparanthasis()
        {
            GivenTestData("( ( 3 + 5 ) + 4 )");
            ExpectedOutput("3 5 + 4 +");
        }

        [Test]
        public void EvaluateNeededNestedparanthasis()
        {
            GivenTestData("( 15 / ( 7 - ( 1 + 1 ) ) * -3 ) - ( 2 + ( 1 + 1 ) )");
            ExpectedOutput("15 7 1 1 + - / -3 * 2 1 1 + + -");
        }

        [Test]
        public void EvaluatPostFixResult()
        {
            var manager = new ExpressionManager();
            var result = manager.EvaluatePostFix("15 7 1 1 + - / -3 * 2 1 1 + + -");
            Assert.That(result.ToString(), Is.EqualTo("-13"));
            
        }








        private void ExpectedOutput(string output)
        {
            Assert.That(_result,Is.EqualTo(output));
        }

        private void GivenTestData(string givenEpression)
        {
            var manager = new ExpressionManager();
            _result = manager.Tranceform(givenEpression);
        }
    }
}
