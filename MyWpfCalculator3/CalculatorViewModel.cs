using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfCalculator3
{
    public class CalculatorViewModel
    {
        private int _cachedValue;
        private string _displayValue = "0";
        private bool _isEditing;
        private Operator _operator;

        internal void EnteryKey(char character)
        {
            switch (character)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':
                    if (_isEditing && DisplayValue != "0")
                    {
                        DisplayValue += character.ToString();
                    }
                    else
                    {
                        _isEditing = true;
                        DisplayValue = character.ToString();
                    }
                    break;
                case '+': EnterOperator(Operator.Add); break;
                case '-': EnterOperator(Operator.Subtract); break;
                case 'x':
                case '*': EnterOperator(Operator.Multiply); break;
                case '/': EnterOperator(Operator.Divide); break;
                case '=':
                    switch (_operator)
                    {
                        case Operator.Add: UpdateResult(_cachedValue + Convert.ToInt32(DisplayValue)); break;
                        case Operator.Subtract: UpdateResult(_cachedValue - Convert.ToInt32(DisplayValue)); break;
                        case Operator.Multiply: UpdateResult(_cachedValue * Convert.ToInt32(DisplayValue)); break;
                        case Operator.Divide: UpdateResult(_cachedValue / Convert.ToInt32(DisplayValue)); break;
                        case Operator.None:
                            _isEditing = false;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void EnterOperator(Operator @operator)
        {
            _cachedValue = Convert.ToInt32(DisplayValue);
            _isEditing = false;
            _operator = @operator;
        }

        private void UpdateResult(int value)
        {
            DisplayValue = value.ToString();
            _isEditing = false;
        }

        private enum Operator
        {
            None,
            Add,
            Subtract,
            Divide,
            Multiply
        }
        public string DisplayValue
        {
            get { return _displayValue; }
            set { _displayValue = value; }
        }
    }
}
