using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorPresenter
{
    public abstract class CalculationValue
    {
    }

    public class OperatorValue : CalculationValue
    {
        public OperatorValue(Operator value)
        {
            Value = value;
        }

        public Operator Value { get; private set; }
    }

    public class NumericValue : CalculationValue
    {
        public NumericValue(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}
