using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Shared.Activities;

namespace UiPath.SAI.Activities.Helper
{
    public abstract class CalcAsyncActivity: ContinuableAsyncCodeActivity
    {
        public CalcAsyncActivity()
        {
            Constraints.Add(ActivityConstraints.HasParentType<CalcAsyncActivity, Calculator>("Parent only Calculator!"));
        }
    }
}
