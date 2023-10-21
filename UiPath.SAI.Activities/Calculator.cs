using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UiPath.SAI.Activities.Calc;
using UiPath.SAI.Activities.Design;
using UiPath.Shared.Activities;

namespace UiPath.SAI.Activities
{
    [Designer(typeof(CalculatorDesigner))]
    public class Calculator : ContinuableAsyncNativeActivity
    {
        private IUICalculator uICalculator;

        public static readonly string CalcSessionPropertyName = "CalculatorSession";

        private int _PostWait =3;

        [Browsable(false)]
        public ActivityAction<IUICalculator> CalculatorDelegate { get; set; }


        public override InArgument<bool> ContinueOnError { get; set; } = false;

        public InArgument<int> PostWait {  get; set; } = 1;

        [Category("Debug")]
        [DisplayName("Debug Log")]
        [Description("If specified a debug log will be produced in the specified file.")]
        public OutArgument<string> DebugLog { get; set; }


        public Calculator()
        {
            CalculatorDelegate = new ActivityAction<IUICalculator>()
            {
                Argument = new DelegateInArgument<IUICalculator>(CalcSessionPropertyName),
                Handler = new Sequence() { DisplayName = "Calc" }
            };
        }


        protected override async Task<Action<NativeActivityContext>> ExecuteAsync(NativeActivityContext context, CancellationToken cancellationToken)
        {
            uICalculator = new Win10Calculator();

            uICalculator.Connect();
            _PostWait = PostWait.Get(context);

            return (asyncCodeActivityContext) =>
            {
                if (CalculatorDelegate != null)
                {
                    asyncCodeActivityContext.ScheduleAction(CalculatorDelegate, uICalculator, OnCompleted, OnFaulted);
                }
            };
        }

        private void OnFaulted(NativeActivityFaultContext faultContext, Exception propagatedException, ActivityInstance propagatedFrom)
        {
            if (uICalculator != null)
            {
                uICalculator.Disconnect();
            }
            else
            {
                DebugLog.Set(faultContext, "(uICalculator != null)");
            }
        }

        private void OnCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {

            Thread.Sleep(_PostWait*1000);

            if (uICalculator != null)
            {
                uICalculator.Disconnect();
            }
            else
            {
                DebugLog.Set(context, "(uICalculator != null)");
            }

        }
    }
}
