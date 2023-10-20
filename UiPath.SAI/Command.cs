using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPath.SAI
{
    public abstract class Command
    {
        public abstract void Do(IUICalculator target);

        private class _Digit : Command
        {
            public readonly int Value;

            public _Digit(int value)
            {
                Value = value;
            }
            public override void Do(IUICalculator target)
            {
                target.Digit((byte)Value);
            }
            public override string ToString() => Value.ToString();
        }

        private class _Command : Command
        {
            public Action<IUICalculator> Action;
            public string Name;

            public _Command(Action<IUICalculator> action, string name)
            {
                Action = action;
                Name = name;
            }
            public override void Do(IUICalculator target)
            {
                Action(target);
            }
            public override string ToString() => Name;
        }


        public static Command Digit(int value) =>
        new _Digit(value);

        public static readonly Command Add =
            new _Command(c => c.Add(), "+");

        public static readonly Command Subtract =
            new _Command(c => c.Subtract(), "-");

        public static readonly Command Multiply =
            new _Command(c => c.Multiply(), "*");

        public static readonly Command Divide =
            new _Command(c => c.Divide(), "/");

        public static readonly new Command Equals =
            new _Command(c => c.Equals(), "=");
    }
}
