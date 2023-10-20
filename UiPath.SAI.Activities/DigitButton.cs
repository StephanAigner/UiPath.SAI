using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UiPath.SAI.Activities.Calc;
using UiPath.SAI.Activities.Design;
using UiPath.SAI.Activities.Helper;

namespace UiPath.SAI.Activities
{
    [Designer(typeof(DigitDesigner))]
    public partial class DigitButton : CalcAsyncActivity
    {

        public OutArgument<string> OutArgument { get; set;}

        [Category("Behavior")]

        public DigitType Digit { get; set; } // = DigitType.Zero;

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            PropertyDescriptor calcSessionProperty = context.DataContext.GetProperties()[Calculator.CalcSessionPropertyName];
            IUICalculator uICalculator = calcSessionProperty?.GetValue(context.DataContext) as IUICalculator;

           


            if (uICalculator == null)
            {
                throw new InvalidOperationException("Calculator not connected!");
            }

            
            DigitType digit = Digit;
            uICalculator.Digit(digit);

            return (asyncCodeActivityContext) =>
            {
                
                OutArgument.Set(asyncCodeActivityContext, "OutArgumentDigi");
            };
        }
    }
}
