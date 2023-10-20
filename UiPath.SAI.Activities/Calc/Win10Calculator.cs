using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace UiPath.SAI.Activities.Calc
{
    public class Win10Calculator : Automated, IUICalculator
    {
        private AutomationElement _result;

        public Win10Calculator()
        {

        }


        public double Display => throw new NotImplementedException();

        public bool ResultAvailable => throw new NotImplementedException();

        public void Add()
        {
            PushButton("Plus");
        }

        public void Clear()
        {
            PushButton("Clear");
        }

        private readonly string[] _digitButtons = { "Zero", "One", "Two",
            "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

        public void Digit(DigitType number)
        {
            int val = (int)number;
            //if ((number < 0) || (number > 9))
             //   throw new ArgumentException("mumber must be a digit 0-9");

            GetInvokePattern(GetButton(_digitButtons[val])).Invoke();
        }

        public void Dispose()
        {
            PushButton("Close Calculator");
        }

        public void Divide()
        {
            PushButton("Divide by");
        }

        public void Equals()
        {
            PushButton("Equals");
        }

        public void Multiply()
        {
            PushButton("Multiply by");
        }

        public void Subtract()
        {
            PushButton("Minus");
        }

        public void Connect()
        {
            StartApp("calc.exe", "Calculator");
            Thread.Sleep(1000);
            _result = _root.FindFirst(TreeScope.Descendants,
                new PropertyCondition(
                    AutomationElement.AutomationIdProperty,
                    "CalculatorResults"));
            if (_result == null)
                throw new Exception("Could not find result box");
            Clear();
        }

        public void Disconnect()
        {
            QuitApp();
            
        }
    }
}
