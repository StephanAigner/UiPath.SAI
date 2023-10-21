using Microsoft.VisualBasic.Activities;
using System;
using System.Activities.Expressions;
using System.Activities.Presentation.Model;
using System.Activities;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Controls;
using UiPath.SAI.Activities.Calc;
using System.Windows;
using System.Activities.Statements;

namespace UiPath.SAI.Activities
{

    public class ComboBoxOperatorConverter: ComboBoxEnumConverter<OperatorType> { }

    public class ComboBoxDigitConverter: ComboBoxEnumConverter<DigitType> { }

    public class ComboBoxEnumConverter<T> : IValueConverter where T : struct
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ModelItem modelItem = value as ModelItem;
            if (value != null)
            {
                InArgument<T> inArgument = modelItem.GetCurrentValue() as InArgument<T>;

                if (inArgument != null)
                {
                    Activity<T> expression = inArgument.Expression;
                    VisualBasicValue<T> vbexpression = expression as VisualBasicValue<T>;
                    string val = vbexpression.ExpressionText;
                    
                    if ( Enum.TryParse<T>(val.Substring(val.LastIndexOf('.')+1) ,true, out T convertValue))
                    {
                        return convertValue;
                    }
                }
            }
            return null;   
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            T operatorType = (T) value;
            VisualBasicValue<T> vbArgument = new VisualBasicValue<T>(typeof(T).Name + "." + operatorType.ToString());
            InArgument<T> inArgument = new InArgument<T>(vbArgument);
            return inArgument;
        }
    }
}
