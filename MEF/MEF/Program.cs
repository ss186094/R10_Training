using System.ComponentModel.Composition;
using CalculatorContract;

namespace CompositionHelper
{
    [Export(typeof(ICalculator))]
    public class Add : ICalculator
    {
        #region Interface members
        public int GetNumber(int num1, int num2)
        {
            return num1 + num2;
        }
        #endregion
    }
}