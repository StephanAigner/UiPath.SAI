using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UiPath.SAI.Activities.Calc;

namespace UiPath.SAI.Activities.Design
{
    // Interaction logic for OperationDesigner.xaml
    public partial class OperationDesigner
    {

        ObservableCollection<string> _items = new ObservableCollection<string> { "a1", "a2" };


        public ObservableCollection<string> Items

        {

            get { return _items; }

            set { _items = value; }

        }


        public IEnumerable<OperatorType> Operators { get; set; }= Enum.GetValues(typeof(OperatorType)).Cast<OperatorType>();

        public OperationDesigner()
        {
            InitializeComponent();
        }

        private void ComboBox_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }
    }
}
