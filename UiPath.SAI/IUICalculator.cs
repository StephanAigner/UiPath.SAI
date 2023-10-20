using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPath.SAI
{
    public interface IUICalculator : IDisposable
    {
        void Clear();
        void Digit(byte number);
        void Add();
        void Subtract();
        void Multiply();
        void Divide();
        void Equals();
        double Display { get; }
        bool ResultAvailable { get; }
    }
}
