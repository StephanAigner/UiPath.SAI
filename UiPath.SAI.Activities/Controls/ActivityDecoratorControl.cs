using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace UiPath.Activities.Presentation
{
    public class ActivityDecoratorControl : ContentControl
    {
        static ActivityDecoratorControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ActivityDecoratorControl), new FrameworkPropertyMetadata(typeof(ActivityDecoratorControl)));
        }
    }
}
