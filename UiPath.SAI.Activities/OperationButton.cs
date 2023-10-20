using System;
using System.Activities;
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
    [Designer(typeof(OperationDesigner))]
    public class OperationButton : CalcAsyncActivity
    {   
        public InArgument<string> inArgument { get; set; }

        [Category("Operation")]
        public InArgument<OperatorType> Operator { get; set; } = OperatorType.Add;

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            PropertyDescriptor calcSessionProperty = context.DataContext.GetProperties()[Calculator.CalcSessionPropertyName];
            IUICalculator uICalculator = calcSessionProperty?.GetValue(context.DataContext) as IUICalculator;

            

            if (uICalculator == null)
            {
                throw new InvalidOperationException("Calculator not connected!");
            }

            switch (Operator.Get(context))
            {
                case OperatorType.Add:
                    uICalculator.Add(); 
                    break;
                case OperatorType.Subtract:
                    uICalculator.Subtract();
                    break;
                case OperatorType.Multiply:
                    uICalculator.Multiply();
                    break;
                case OperatorType.Divide:
                    uICalculator.Divide();
                    break;
                case OperatorType.Equals: 
                    uICalculator.Equals(); 
                    break;
                default: 
                    throw new InvalidOperationException("Operator unknown!");
            }

            

            return (asyncCodeActivityContext) =>
            {

            };

        }
    }
}
