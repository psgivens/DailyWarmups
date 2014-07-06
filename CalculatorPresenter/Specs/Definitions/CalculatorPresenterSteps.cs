using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace CalculatorPresenter.Specs.Definitions
{
    [Binding]
    public class CalculatorPresenterSteps
    {
        private readonly CalculatorViewModel _calculator = new CalculatorViewModel();

        [Given(@"I have entered the keys ""(.*)""")]
        public void GivenIHaveEnteredTheKeys(string sequence)
        {
            var @characters = sequence.ToCharArray();

            foreach (char @character in @characters)
            {
                EnterKey(@character);
            }
        }

        [When(@"I enter the key ""(.)""")]
        public void WhenIEnterTheKey(char key)
        {
            EnterKey(key);
        }

        [Then(@"the display value will be ""(.*)""")]
        public void ThenTheDisplayValueWillBe(string expectedResult)
        {
            var displayValue = _calculator.DisplayValue;
            Assert.IsTrue(expectedResult == displayValue, "Expected value {0}, but got {1}", expectedResult, displayValue);
        }

        private void EnterKey(char character)
        {
            switch (@character)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    _calculator.EnterDigit(@character);
                    break;
                case '+':
                    _calculator.EnterOperator(Operator.Add);
                    break;
                case '*':
                    _calculator.EnterOperator(Operator.Subtract);
                    break;
                case '-':
                    _calculator.EnterOperator(Operator.Multiply);
                    break;
                case '/':
                    _calculator.EnterOperator(Operator.Divide);
                    break;
                case '=':
                    _calculator.Calculate();
                    break;
                default:
                    break;
            }
        }
    }
}
