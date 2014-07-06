using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorPresenter
{
    class CalculatorViewModel
    {
        private bool _isEditing;
        private string _displayValue;
        private CalculationNode _head;

        public CalculatorViewModel()
        {
            DisplayValue = "0";
        }

        internal void EnterDigit(char character)
        {
            if (!IsEditing || DisplayValue == "0")
            {
                if (character == '0') return;

                DisplayValue = character.ToString();
                IsEditing = true;
            }
            else 
            {
                DisplayValue += character;
            }
        }

        internal void EnterOperator(Operator @operator)
        {
            int value = int.Parse(DisplayValue);
            Insert(value, @operator);
            IsEditing = false;
        }

        private void Insert(int value, Operator @operator)
        {
            if (_head == null)
            {
                _head = new CalculationNode(value, @operator);
            }
        }

        internal void Calculate()
        {
            int value = int.Parse(DisplayValue);
            var @operator = ((OperatorValue)_head.Value).Value;
            switch (@operator)
            {
                case Operator.Divide:
                    break;
                case Operator.Multiply:
                    break;
                case Operator.Subtract:
                    break;
                case Operator.Add:
                    var left = _head.Left;
                    var leftValue = ((NumericValue)left.Value).Value;
                    DisplayValue = (leftValue + value).ToString();
                    break;
                default:
                    break;
            }
        }

        public bool IsEditing
        {
            get { return _isEditing; }
            set { _isEditing = value; }
        }

        public string DisplayValue
        {
            get { return _displayValue; }
            set { _displayValue = value; }
        }
    }
}
