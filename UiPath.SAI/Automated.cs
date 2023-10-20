using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace UiPath.SAI
{
    public class Automated
    {
        protected Process _process;
        protected AutomationElement _root;

        private Dictionary<string, AutomationElement> _elements =
            new Dictionary<string, AutomationElement>();


        public void Test() {
            //System.Windows.MessageBox.Show("asdf"); 
        } 
    }
}
