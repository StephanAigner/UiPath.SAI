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
    [Designer(typeof(ResultDesigner))]
    public class Result : CalcAsyncActivity
    {
        public OutArgument<string> Value { get; set; }
        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            PropertyDescriptor calcSessionProperty = context.DataContext.GetProperties()[Calculator.CalcSessionPropertyName];
            IUICalculator uICalculator = calcSessionProperty?.GetValue(context.DataContext) as IUICalculator;

            if (uICalculator == null)
            {
                throw new InvalidOperationException("Calculator not connected!");
            }

            //if (!uICalculator.ResultAvailable)
            //{
            //    throw new InvalidOperationException("Result not available!");
            //}
            var result = uICalculator.Display;


            return (asyncCodeActivityContext) =>
            {
                Value.Set(asyncCodeActivityContext, result.ToString());
            };
        }
    }
}
