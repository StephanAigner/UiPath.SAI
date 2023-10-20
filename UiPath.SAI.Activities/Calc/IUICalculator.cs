using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPath.SAI.Activities.Calc
{
    public interface IUICalculator : IDisposable
    {
        void Connect();

        void Disconnect();
        void Clear();
        void Digit(DigitType number);
        void Add();
        void Subtract();
        void Multiply();
        void Divide();
        void Equals();
        double Display { get; }
        bool ResultAvailable { get; }


    }
}
