using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPath.SAI.Activities.Calc
{
    public enum DigitType
    {
        Zero =0,
        One=1,
        Two=2,
        Three=3,
        Four=4,
        Five=5,
        Six=6,
        Seven=7,
        Eight=8,
        Nine=9
    }

    public enum OperatorType
    {
        Add = 0,
        Subtract = 1,
        Multiply = 2,
        Divide = 3,
        Equals = 4,
    }
}
