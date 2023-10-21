using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UiPath.SAI.Activities.Calc;

namespace UiPath.SAI.Activities.Design
{
    // Interaction logic for ButtonDesigner.xaml
    public partial class DigitDesigner
    {
        ObservableCollection<DigitType> _digits = new ObservableCollection<DigitType>(Enum.GetValues(typeof(DigitType)).Cast<DigitType>());

        public ObservableCollection<DigitType> Digits

        {

            get { return _digits; }

            set { _digits = value; }

        }

        public DigitDesigner()
        {
            InitializeComponent();
        }
    }
}
