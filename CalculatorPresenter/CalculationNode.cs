using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorPresenter
{
    class CalculationNode
    {
        public CalculationValue Value { get; private set; }
        
        public CalculationNode(int value, Operator @operator)
        {
            Value = new OperatorValue(@operator);
            Left = new CalculationNode(value);
        }

        public CalculationNode(int value)
        {
            // TODO: Complete member initialization
            this.Value = new NumericValue(value);
        }

        public CalculationNode Left { get; set;  }
        public CalculationNode Right { get; set; }
    }
}
